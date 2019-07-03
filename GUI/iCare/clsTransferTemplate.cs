using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Text;
using System.Drawing;
using com.digitalwave.Utility.Controls;
using iCareData;
using Crownwood.Magic.Menus;
//using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.GLS_WS;
using System.Reflection;
using com.digitalwave.Emr.Utility.DataShare;
using System.Xml;
using System.Xml.Schema;
using VO = com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.PACS;
namespace iCare
{
    public class clsTransferTemplate
    {
        #region Variable
        private ContextMenu m_ctmControl = new ContextMenu();
        private MenuItem m_mniDoubleStrike = new MenuItem("双划线删除");
        private MenuItem m_mniTemplate = new MenuItem("模板");
        private MenuItem m_mniCommonUse = new MenuItem("常用值模板");
        private MenuItem m_mniDataShare = new MenuItem("智能数据引擎");
        private MenuItem m_mniDataShareInvoking = new MenuItem("直接数据嵌入");
        private MenuItem m_mniApplyReport = new MenuItem("图文工作站");
        private MenuItem m_mniLabCheckResult = new MenuItem("检验结果");
        private MenuItem m_mniCheckResult = new MenuItem("检查结果");
        private MenuItem m_mniSuperSubScript = new MenuItem("上下标");
        private MenuItem m_mniTextTemplate = new MenuItem("最小元素集");

        private Hashtable m_hasMenuItems = new Hashtable();


        /// <summary>
        /// 记录已经展开的树节点，以免下次点击时再次查找子目录
        /// </summary>
        private ArrayList m_arlExpandedNodes;

        //private clsInpatMedRec_Type_Dept[] m_objType_DeptArr;
        //		private clsInpatMedRec_Type[] m_objType_DeptArr;

        private ContextMenuStrip m_ppmMenu = new ContextMenuStrip();
        private ToolStripMenuItem m_mncDoubleStrike = new ToolStripMenuItem("双划线删除");
        private ToolStripMenuItem m_mncTemplate = new ToolStripMenuItem("模板");
        private ToolStripMenuItem m_mncCommonUse = new ToolStripMenuItem("常用值模板");
        private ToolStripMenuItem m_mncDataShare = new ToolStripMenuItem("智能数据引擎");
        private ToolStripMenuItem m_mncDataShareInvoking = new ToolStripMenuItem("直接数据嵌入");
        private ToolStripMenuItem m_mncApplyReport = new ToolStripMenuItem("图文工作站");
        private ToolStripMenuItem m_mncLabCheckResult = new ToolStripMenuItem("检验结果");
        private ToolStripMenuItem m_mncCheckResult = new ToolStripMenuItem("检查结果");
        private ToolStripMenuItem m_mncSuperSubScript = new ToolStripMenuItem("上下标");
        private ToolStripMenuItem m_mncTextTemplate = new ToolStripMenuItem("最小元素集");
        //private PopupMenu m_ppmMenu = new PopupMenu();
        //private MenuCommand m_mncDoubleStrike = new MenuCommand("双划线删除");
        //private MenuCommand m_mncTemplate = new MenuCommand("模板");
        //private MenuCommand m_mncCommonUse = new MenuCommand("常用值模板");
        //private MenuCommand m_mncDataShare = new MenuCommand("智能数据引擎");
        //private MenuCommand m_mncDataShareInvoking = new MenuCommand("直接数据嵌入");
        //private MenuCommand m_mncApplyReport = new MenuCommand("图文工作站");
        //private MenuCommand m_mncLabCheckResult = new MenuCommand("检验结果");
        //private MenuCommand m_mncCheckResult = new MenuCommand("检查结果");
        //private MenuCommand m_mncSuperSubScript = new MenuCommand("上下标");
        //private MenuCommand m_mncTextTemplate = new MenuCommand("最小元素集");

        //frmDataShareTool m_objfrmDataShare
        #endregion

        public clsTransferTemplate()
        {
            m_mthInit();
            m_arlExpandedNodes = new ArrayList();
        }

        /// <summary>
        /// 数据复用菜单项
        /// </summary>
        public MenuItem m_MniDataShare
        {
            get
            {
                return m_mniDataShare;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void m_mthInit()
        {
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440104001")
            {
                m_mniCheckResult.Text = "影像报告单";
                m_mncCheckResult.Text = "影像报告单";
                m_mncApplyReport.Visible = false;
                m_mniApplyReport.Visible = false;
            }
            #region old menu
            s_mthInitDataShareItems(m_mniDataShare);
            s_mthInitDataShareItems(m_mniDataShareInvoking);

            //SQL版本暂时不要
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440104001")
                m_mthSetApplyReportSubMenu(m_mniApplyReport);

            m_mthSetShareItem(m_mniDataShare);
            m_mthSetShareItem(m_mniDataShareInvoking);

            m_mthAssociateDataShareItemsEvent(m_mniDataShare);
            m_mthAssociateDataShareInvokingItemsEvent(m_mniDataShareInvoking);

            m_mniDoubleStrike.Click += new EventHandler(m_mniDoubleStrike_Click);
            m_mniTemplate.Click += new EventHandler(m_ctmTemplate_Click);
            m_mniLabCheckResult.Click += new EventHandler(m_ctmLabCheckResult_Click);
            m_mniCheckResult.Click += new EventHandler(m_ctmCheckResult_Click);
            m_mniTextTemplate.Click += new EventHandler(m_mniTextTemplate_Click);

            EventHandler evhSuperSubScript = new EventHandler(SuperSubScript_Click);
            m_mniSuperSubScript.MenuItems.Add("上标", evhSuperSubScript);
            m_mniSuperSubScript.MenuItems.Add("下标", evhSuperSubScript);
            m_mniSuperSubScript.MenuItems.Add("正常", evhSuperSubScript);

            m_ctmControl.MenuItems.Add(m_mniTemplate);
            m_ctmControl.MenuItems.Add(m_mniCommonUse);
            m_ctmControl.MenuItems.Add("-");
            m_ctmControl.MenuItems.Add(new MenuItem("特殊符号", new EventHandler(m_mthInvokeSpecialSymbol)));
            m_ctmControl.MenuItems.Add("-");
            m_ctmControl.MenuItems.Add(m_mniDataShare);
            m_ctmControl.MenuItems.Add(m_mniDataShareInvoking);
            m_ctmControl.MenuItems.Add(m_mniApplyReport);
            m_ctmControl.MenuItems.Add(m_mniLabCheckResult);
            m_ctmControl.MenuItems.Add(m_mniCheckResult);
            m_ctmControl.MenuItems.Add(m_mniTextTemplate);
            m_ctmControl.MenuItems.Add("-");
            //m_ctmControl.MenuItems.Add(new MenuItem("剪切(&T)", new EventHandler(m_mthCut)));
            m_ctmControl.MenuItems.Add(new MenuItem("复制(&C)", new EventHandler(m_mthCopy)));
            m_ctmControl.MenuItems.Add(new MenuItem("粘贴(&P)", new EventHandler(m_mthPaste)));

            m_ctmControl.Popup += new EventHandler(m_ctmPopup);
            #endregion

            #region new menu
            s_mthInitDataShareItems(m_mncDataShare);
            s_mthInitDataShareItems(m_mncDataShareInvoking);

            //m_mthSetShareItem2(m_mncDataShare);
            //m_mthSetShareItem2(m_mncDataShareInvoking);

            //SQL版本暂时不要
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440104001")
                m_mthSetApplyReportSubMenu(m_mncApplyReport);

            m_mthAssociateDataShareItemsEvent(m_mncDataShare);
            m_mthAssociateDataShareInvokingItemsEvent(m_mncDataShareInvoking);

            m_mncDoubleStrike.Click += new EventHandler(m_mniDoubleStrike_Click);
            m_mncTemplate.Click += new EventHandler(m_ctmTemplate_Click);
            m_mncLabCheckResult.Click += new EventHandler(m_ctmLabCheckResult_Click);
            m_mncCheckResult.Click += new EventHandler(m_ctmCheckResult_Click);
            m_mncTextTemplate.Click += new EventHandler(m_mniTextTemplate_Click);

            EventHandler evhSuperSubScript2 = new EventHandler(SuperSubScript_Click);
            //MenuCommand mncUp = new MenuCommand("上标", evhSuperSubScript2);
            //MenuCommand mncDown = new MenuCommand("下标", evhSuperSubScript2);
            //MenuCommand mncNormal = new MenuCommand("正常", evhSuperSubScript2);
            ToolStripMenuItem mncUp = new ToolStripMenuItem("上标",null, evhSuperSubScript2);
            ToolStripMenuItem mncDown = new ToolStripMenuItem("下标", null, evhSuperSubScript2);
            ToolStripMenuItem mncNormal = new ToolStripMenuItem("正常", null, evhSuperSubScript2);
            m_mncSuperSubScript.DropDownItems.Add(mncUp);
            m_mncSuperSubScript.DropDownItems.Add(mncDown);
            m_mncSuperSubScript.DropDownItems.Add(mncNormal);

            #region set image
            frmImageList frmImg = new frmImageList();
            m_ppmMenu.ImageList = frmImg.m_ImgMenu;
            //m_mncDoubleStrike.ImageList = frmImg.m_ImgMenu;
            m_mncDoubleStrike.ImageIndex = 0;
            //m_mncSuperSubScript.ImageList = frmImg.m_ImgMenu;
            m_mncSuperSubScript.ImageIndex = 1;
            //m_mncTemplate.ImageList = frmImg.m_ImgMenu;
            m_mncTemplate.ImageIndex = 2;
            //m_mncCommonUse.ImageList = frmImg.m_ImgMenu;
            m_mncCommonUse.ImageIndex = 3;
            //m_mncDataShare.ImageList = frmImg.m_ImgMenu;
            m_mncDataShare.ImageIndex = 4;
            //m_mncDataShareInvoking.ImageList = frmImg.m_ImgMenu;
            m_mncDataShareInvoking.ImageIndex = 5;
            //m_mncLabCheckResult.ImageList = frmImg.m_ImgMenu;
            m_mncLabCheckResult.ImageIndex = 6;

            #endregion
            m_ppmMenu.Items.Add(m_mncDoubleStrike);
            m_ppmMenu.Items.Add(m_mncDoubleStrike);
            m_ppmMenu.Items.Add(m_mncSuperSubScript);
            m_ppmMenu.Items.Add(m_mncTemplate);
            m_ppmMenu.Items.Add(m_mncCommonUse);
            m_ppmMenu.Items.Add(new ToolStripSeparator());
            m_ppmMenu.Items.Add(new ToolStripMenuItem("特殊符号", frmImg.m_ImgMenu.Images[10],  new EventHandler(m_mthInvokeSpecialSymbol),"m_mncSpecialSymbol"));
            m_ppmMenu.Items.Add(new ToolStripSeparator());
            m_ppmMenu.Items.Add(m_mncDataShare);
            m_ppmMenu.Items.Add(m_mncDataShareInvoking);
            m_ppmMenu.Items.Add(m_mncApplyReport);
            m_ppmMenu.Items.Add(m_mncLabCheckResult);
            m_ppmMenu.Items.Add(m_mncCheckResult);
            m_ppmMenu.Items.Add(m_mncTextTemplate);
            m_ppmMenu.Items.Add(new ToolStripSeparator());
            //m_ppmMenu.Items.Add(new MenuCommand("剪切(&T)", frmImg.m_ImgMenu, 7, new EventHandler(m_mthCut)));
            m_ppmMenu.Items.Add(new ToolStripMenuItem("复制(&C)", frmImg.m_ImgMenu.Images[8], new EventHandler(m_mthCopy),"m_mncCopy"));
            m_ppmMenu.Items.Add(new ToolStripMenuItem("粘贴(&P)", frmImg.m_ImgMenu.Images[9], new EventHandler(m_mthPaste),"m_mncPaste"));

            //m_ppmMenu.MenuCommands.Add(m_mncDoubleStrike);
            //m_ppmMenu.MenuCommands.Add(m_mncSuperSubScript);
            //m_ppmMenu.MenuCommands.Add(m_mncTemplate);
            //m_ppmMenu.MenuCommands.Add(m_mncCommonUse);
            //m_ppmMenu.MenuCommands.Add(new MenuCommand("-"));
            //m_ppmMenu.MenuCommands.Add(new MenuCommand("特殊符号", frmImg.m_ImgMenu, 10, new EventHandler(m_mthInvokeSpecialSymbol)));
            //m_ppmMenu.MenuCommands.Add(new MenuCommand("-"));
            //m_ppmMenu.MenuCommands.Add(m_mncDataShare);
            //m_ppmMenu.MenuCommands.Add(m_mncDataShareInvoking);
            //m_ppmMenu.MenuCommands.Add(m_mncApplyReport);
            //m_ppmMenu.MenuCommands.Add(m_mncLabCheckResult);
            //m_ppmMenu.MenuCommands.Add(m_mncCheckResult);
            //m_ppmMenu.MenuCommands.Add(m_mncTextTemplate);
            //m_ppmMenu.MenuCommands.Add(new MenuCommand("-"));
            ////m_ppmMenu.MenuCommands.Add(new MenuCommand("剪切(&T)", frmImg.m_ImgMenu, 7, new EventHandler(m_mthCut)));
            //m_ppmMenu.MenuCommands.Add(new MenuCommand("复制(&C)", frmImg.m_ImgMenu, 8, new EventHandler(m_mthCopy)));
            //m_ppmMenu.MenuCommands.Add(new MenuCommand("粘贴(&P)", frmImg.m_ImgMenu, 9, new EventHandler(m_mthPaste)));

            //m_ppmMenu.MenuCommands.ExtraText = "iCare";
            //m_ppmMenu.MenuCommands.ExtraTextColor = Color.White;
            //m_ppmMenu.MenuCommands.ExtraBackColor = Color.SlateGray;
            //m_ppmMenu.MenuCommands.ShowInfrequent = true;
            //m_ppmMenu.MenuCommands.ExtraFont = new Font("Times New Roman", 12f, FontStyle.Bold | FontStyle.Italic);

            //			m_ppmMenu.
            #endregion
            this.m_ppmMenu.Opening += new System.ComponentModel.CancelEventHandler(ContextMenuStrip_Opening);
        }

        void m_mniTextTemplate_Click(object sender, EventArgs e)
        {
            iCare.CustomForm.clsExteriorFunctionInterface.m_ObjUserInfo = clsEMRLogin.LoginInfo;
            iCare.CustomForm.clsExteriorFunctionInterface.s_ObjCurrentPatient = MDIParent.s_ObjCurrentPatient;
            DateTime dtmCreatedDate = DateTime.Now;
            if (m_frmForm is frmHRPBaseForm)
                dtmCreatedDate = ((frmHRPBaseForm)m_frmForm).m_DtmCreatedDate;
            //int intSelectedStart = (m_txtRichTextBox.SelectionStart < 0 ? m_txtRichTextBox.Text.Length : m_txtRichTextBox.SelectionStart);
            int intSelectedStart = m_intGetControlSelectionStart(m_ctlText);
            using (iCare.CustomForm.frmTextTemplate frm = new iCare.CustomForm.frmTextTemplate(m_ctlText, m_ctlText.FindForm().Name, m_ctlText.Name, intSelectedStart, dtmCreatedDate))
            {
                if (frm.ShowDialog() == DialogResult.OK && m_frmForm is frmHRPBaseForm)
                {
                    frmHRPBaseForm frmBaseForm = (frmHRPBaseForm)m_frmForm;
                    frmBaseForm.m_arlMinElementColValue.AddRange((clsMinElementValues[])frm.m_ArlTextTemplate.ToArray(typeof(clsMinElementValues)));
                }
            }
        }

        /// <summary>
        /// 载入常用值模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mthLoadCommonUseTemplate(MenuItem p_ctmControl)
        {
            m_mniCommonUse.MenuItems.Clear();

            clsTemplateSetValue[] objValueArr;
            long lngRes = m_objDomain.m_lngGetTemplateSetValue(m_strFormID, m_txtRichTextBox.Name, "常用值--%", MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR, out objValueArr);
            if (lngRes <= 0 || objValueArr == null)
                return;

            for (int i = 0; i < objValueArr.Length; i++)
            {
                MenuItem mniItem = new MenuItem(objValueArr[i].m_strSet_Name);
                mniItem.Click += new EventHandler(m_ctmCommonTemplate_Click);
                m_htCommonUseItem.Add(mniItem, objValueArr[i].m_strSet_ID);

                int intIndex = -1;
                string strKeyword = objValueArr[i].m_strKeyword.Replace("常用值--", "");
                for (int j = 0; j < m_mniCommonUse.MenuItems.Count; j++)
                {
                    if (strKeyword == m_mniCommonUse.MenuItems[j].Text)
                    {
                        intIndex = j;
                        break;
                    }
                }
                if (intIndex == -1)//没找到同一分类
                {
                    MenuItem mniNewKeyword = new MenuItem(strKeyword);
                    mniNewKeyword.MenuItems.Add(mniItem);
                    m_mniCommonUse.MenuItems.Add(mniNewKeyword);
                }
                else
                    m_mniCommonUse.MenuItems[intIndex].MenuItems.Add(mniItem);

            }

            if (m_mniCommonUse.MenuItems.Count == 1)//只有一个分类直接将所有常用值模板放到根目录下
            {
                while (m_mniCommonUse.MenuItems[0].MenuItems.Count > 0)
                {
                    m_mniCommonUse.MenuItems.Add(m_mniCommonUse.MenuItems[0].MenuItems[0]);
                    m_mniCommonUse.MenuItems.RemoveAt(0);
                }
            }
        }

        ///// <summary>
        ///// 载入常用值模板
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void m_mthLoadCommonUseTemplate(MenuCommand p_ppmMenu)
        //{
        //    //m_mniCommonUse.MenuItems.Clear();
        //    m_mncCommonUse.MenuCommands.Clear();

        //    clsTemplateSetValue[] objValueArr;
        //    //long lngRes = m_objDomain.m_lngGetTemplateSetValue(m_strFormID, m_txtRichTextBox.Name, "常用值--%", MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR, out objValueArr);
        //    long lngRes = m_objDomain.m_lngGetTemplateSetValue(m_strFormID, m_ctlText.Name, "常用值--%", MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR, out objValueArr);
        //    if (lngRes <= 0 || objValueArr == null)
        //        return;

        //    for (int i = 0; i < objValueArr.Length; i++)
        //    {
        //        MenuCommand mniItem = new MenuCommand(objValueArr[i].m_strSet_Name);
        //        mniItem.Click += new EventHandler(m_ctmCommonTemplate_Click);
        //        m_htCommonUseItem.Add(mniItem, objValueArr[i].m_strSet_ID);

        //        int intIndex = -1;
        //        string strKeyword = objValueArr[i].m_strKeyword.Replace("常用值--", "");
        //        for (int j = 0; j < m_mncCommonUse.MenuCommands.Count; j++)
        //        {
        //            if (strKeyword == m_mncCommonUse.MenuCommands[j].Text)
        //            {
        //                intIndex = j;
        //                break;
        //            }
        //        }
        //        if (intIndex == -1)//没找到同一分类
        //        {
        //            MenuCommand mniNewKeyword = new MenuCommand(strKeyword);
        //            mniNewKeyword.MenuCommands.Add(mniItem);
        //            m_mncCommonUse.MenuCommands.Add(mniNewKeyword);
        //        }
        //        else
        //            m_mncCommonUse.MenuCommands[intIndex].MenuCommands.Add(mniItem);

        //    }

        //    if (m_mncCommonUse.MenuCommands.Count == 1)//只有一个分类直接将所有常用值模板放到根目录下
        //    {
        //        while (m_mncCommonUse.MenuCommands[0].MenuCommands.Count > 0)
        //        {
        //            m_mncCommonUse.MenuCommands.Add(m_mncCommonUse.MenuCommands[0].MenuCommands[0]);
        //            m_mncCommonUse.MenuCommands[0].MenuCommands.RemoveAt(0);
        //        }
        //        m_mncCommonUse.MenuCommands.RemoveAt(0);
        //    }
        //}

        /// <summary>
        /// 载入常用值模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mthLoadCommonUseTemplate(ToolStripMenuItem p_ppmMenu)
        {
            m_mncCommonUse.DropDownItems.Clear();

            //clsTemplateSetValue[] objValueArr;
            //long lngRes = m_objDomain.m_lngGetTemplateSetValue(m_strFormID, m_ctlText.Name, "常用值--%", MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR, out objValueArr);
            //if (lngRes <= 0 || objValueArr == null)
            //    return;

            VO::clsTemplateSet[] objValueArr = null;
            if (m_frmForm is frmHRPBaseForm)
            {
                frmHRPBaseForm frmBase = m_frmForm as frmHRPBaseForm;
                objValueArr = frmBase.m_ObjTemplateClient.m_objCommonUseTemplateSetList(m_strFormID, m_ctlText.Name, 
                    com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_ObjCurrentEmployee.m_strEMPID_CHR, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR);
            }
            if (objValueArr == null)
            {
                return;
            }

            for (int i = 0; i < objValueArr.Length; i++)
            {
                ToolStripMenuItem mniItem = new ToolStripMenuItem(objValueArr[i].m_strSetName);
                mniItem.Click += new EventHandler(m_ctmCommonTemplate_Click);
                m_htCommonUseItem.Add(mniItem, objValueArr[i].m_strSetID);

                int intIndex = -1;
                string strKeyword = objValueArr[i].m_strKeyword.Replace("常用值--", "");
                for (int j = 0; j < m_mncCommonUse.DropDownItems.Count; j++)
                {
                    if (strKeyword == m_mncCommonUse.DropDownItems[j].Text)
                    {
                        intIndex = j;
                        break;
                    }
                }
                if (intIndex == -1)//没找到同一分类
                {
                    ToolStripMenuItem rootItem = new ToolStripMenuItem(strKeyword);
                    m_mncCommonUse.DropDownItems.Add(rootItem);
                    rootItem.DropDownItems.Add(mniItem);
                }
                else
                    ((ToolStripMenuItem)m_mncCommonUse.DropDownItems[intIndex]).DropDownItems.Add(mniItem);

            }

            if (m_mncCommonUse.DropDownItems.Count == 1)//只有一个分类直接将所有常用值模板放到根目录下
            {
                while (((ToolStripMenuItem)m_mncCommonUse.DropDownItems[0]).DropDownItems.Count > 0)
                {
                    m_mncCommonUse.DropDownItems.Add(((ToolStripMenuItem)m_mncCommonUse.DropDownItems[0]).DropDownItems[0]);
                    //((ToolStripMenuItem)m_mncCommonUse.DropDownItems[0]).DropDownItems.RemoveAt(0);
                }
                m_mncCommonUse.DropDownItems.RemoveAt(0);
            }
        }

        /// <summary>
        /// 初始化数据复用字段
        /// </summary>
        public static void s_mthInitDataShareItems(MenuItem p_mniDataShare)
        {
            p_mniDataShare.MenuItems.AddRange(new MenuItem[] { new MenuItem("病人"), new MenuItem("-"), new MenuItem("其他信息") });

            p_mniDataShare.MenuItems[0].MenuItems.AddRange(new MenuItem[] { new MenuItem("姓名"), new MenuItem("性别"), new MenuItem("年龄"), new MenuItem("籍贯"), new MenuItem("地址"), new MenuItem("科室"), new MenuItem("病区"), new MenuItem("床号"), new MenuItem("住院号"), new MenuItem("入院时间") });

        }

        /// <summary>
        /// 初始化数据复用字段
        /// </summary>
        public static void s_mthInitDataShareItems(ToolStripMenuItem p_mniDataShare)
        {
            p_mniDataShare.DropDownItems.AddRange(new ToolStripItem[] { new ToolStripMenuItem("病人"), new ToolStripSeparator(), new ToolStripMenuItem("其他信息") });

            ((ToolStripMenuItem)p_mniDataShare.DropDownItems[0]).DropDownItems.AddRange(new ToolStripMenuItem[] { new ToolStripMenuItem("姓名"), new ToolStripMenuItem("性别"), new ToolStripMenuItem("年龄"), new ToolStripMenuItem("籍贯"), new ToolStripMenuItem("地址"), new ToolStripMenuItem("科室"), new ToolStripMenuItem("病区"), new ToolStripMenuItem("床号"), new ToolStripMenuItem("住院号"), new ToolStripMenuItem("入院时间") });

        }

        /// <summary>
        /// 初始化数据复用字段
        /// </summary>
        public static void s_mthInitDataShareItems2(MenuCommand p_mniDataShare)
        {
            p_mniDataShare.MenuCommands.AddRange(new MenuCommand[] { new MenuCommand("病人"), new MenuCommand("-"), new MenuCommand("其他信息") });

            p_mniDataShare.MenuCommands[0].MenuCommands.AddRange(new MenuCommand[] { new MenuCommand("姓名"), new MenuCommand("性别"), new MenuCommand("年龄"), new MenuCommand("籍贯"), new MenuCommand("地址"), new MenuCommand("科室"), new MenuCommand("病区"), new MenuCommand("床号"), new MenuCommand("住院号"), new MenuCommand("入院时间") });
        }

        /// <summary>
        /// 设置数据复用菜单点击事件
        /// </summary>
        /// <param name="p_mniRoot"></param>
        private void m_mthAssociateDataShareItemsEvent(ToolStripMenuItem p_mniRoot)
        {
            if (p_mniRoot.DropDownItems.Count > 0)
            {
                for (int i = 0; i < p_mniRoot.DropDownItems.Count; i++)
                {
                    if (p_mniRoot.DropDownItems[i] is ToolStripMenuItem)
                    {
                        m_mthAssociateDataShareItemsEvent(((ToolStripMenuItem)p_mniRoot.DropDownItems[i]));
                    }                    
                }
            }
            else
                p_mniRoot.Click += new EventHandler(m_mthDataShareItemClick);
        }

        /// <summary>
        /// 设置数据复用菜单点击事件
        /// </summary>
        /// <param name="p_mniRoot"></param>
        private void m_mthAssociateDataShareItemsEvent(MenuItem p_mniRoot)
        {
            if (p_mniRoot.MenuItems.Count > 0)
                for (int i = 0; i < p_mniRoot.MenuItems.Count; i++)
                    m_mthAssociateDataShareItemsEvent(p_mniRoot.MenuItems[i]);
            else
                p_mniRoot.Click += new EventHandler(m_mthDataShareItemClick);
        }

        /// <summary>
        /// 设置数据复用菜单点击事件
        /// </summary>
        /// <param name="p_mniRoot"></param>
        private void m_mthAssociateDataShareItemsEvent2(MenuCommand p_mniRoot)
        {
            if (p_mniRoot.MenuCommands.Count > 0)
                for (int i = 0; i < p_mniRoot.MenuCommands.Count; i++)
                    m_mthAssociateDataShareItemsEvent2((p_mniRoot.MenuCommands[i]) as MenuCommand);
            else
                p_mniRoot.Click += new EventHandler(m_mthDataShareItemClick2);
        }

        /// <summary>
        /// 数据复用格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mthDataShareItemClick(object sender, EventArgs e)
        {
            //此处加入判断，如果是【其他信息】，则弹出窗体
            string strContent = "";
            string strText = string.Empty;
            bool blnIsToolStripMenuItem = false;

            if (sender is MenuItem)
            {
                strText = ((MenuItem)sender).Text;
            }
            else if (sender is ToolStripMenuItem)
            {
                strText = ((ToolStripMenuItem)sender).Text;
                blnIsToolStripMenuItem = true;
            }

            if (strText != "其他信息")
            {
                if (!blnIsToolStripMenuItem)
                {
                    strContent = "[" + ((MenuItem)sender).Parent.ToString().Substring(((MenuItem)sender).Parent.ToString().IndexOf("Text: ") + 6) + "--" + ((MenuItem)sender).Text + "]";
                }
                else
                {
                    strContent = "[" + ((ToolStripMenuItem)sender).OwnerItem.Text + "--" + ((ToolStripMenuItem)sender).Text + "]";
                }
                m_mthInertText(strContent);
            }
            else
            {
                frmDataShareTool.m_mthShowDataShareTool(MDIParent.s_ObjCurrentPatient.m_StrInPatientID, MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate, true, out strContent);
                if (strContent != "") m_mthInertText(strContent);
            }


        }
        /// <summary>
        /// 数据复用格式2,MenuCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mthDataShareItemClick2(object sender, EventArgs e)
        {
            //此处加入判断，如果是【其他信息】，则弹出窗体
            string strContent = "";
            //if((MenuItem)sender)
            if (((MenuCommand)sender).Text != "其他信息")
            {
                strContent = "[" + ((MenuCommand)sender).Parent.Text + "--" + ((MenuCommand)sender).Text + "]";
                m_mthInertText(strContent);
            }
            else
            {
                //this.Cursor =Cursors.WaitCursor;
                frmDataShareTool.m_mthShowDataShareTool(MDIParent.s_ObjCurrentPatient.m_StrInPatientID, MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate, true, out strContent);
                if (strContent != "") m_mthInertText(strContent);

                //this.Cursor =Cursors.Default;

            }


        }

        /// <summary>
        /// 设置直接数据复用菜单点击事件
        /// </summary>
        /// <param name="p_mniRoot"></param>
        private void m_mthAssociateDataShareInvokingItemsEvent(ToolStripMenuItem p_mniRoot)
        {
            if (p_mniRoot.DropDownItems.Count > 0)
            {
                for (int i = 0; i < p_mniRoot.DropDownItems.Count; i++)
                {
                    if (p_mniRoot.DropDownItems[i] is ToolStripMenuItem)
                    {
                        m_mthAssociateDataShareInvokingItemsEvent(((ToolStripMenuItem)p_mniRoot.DropDownItems[i]));
                    }                    
                }
            }
            else
                p_mniRoot.Click += new EventHandler(m_mthDataShareInvokingItemClick);
        }

        /// <summary>
        /// 设置直接数据复用菜单点击事件
        /// </summary>
        /// <param name="p_mniRoot"></param>
        private void m_mthAssociateDataShareInvokingItemsEvent(MenuItem p_mniRoot)
        {
            if (p_mniRoot.MenuItems.Count > 0)
                for (int i = 0; i < p_mniRoot.MenuItems.Count; i++)
                    m_mthAssociateDataShareInvokingItemsEvent(p_mniRoot.MenuItems[i]);
            else
                p_mniRoot.Click += new EventHandler(m_mthDataShareInvokingItemClick);
        }

        /// <summary>
        /// 设置直接数据复用菜单点击事件
        /// </summary>
        /// <param name="p_mniRoot"></param>
        private void m_mthAssociateDataShareInvokingItemsEvent2(MenuCommand p_mniRoot)
        {
            if (p_mniRoot.MenuCommands.Count > 0)
                for (int i = 0; i < p_mniRoot.MenuCommands.Count; i++)
                    m_mthAssociateDataShareInvokingItemsEvent2((p_mniRoot.MenuCommands[i]) as MenuCommand);
            else
                p_mniRoot.Click += new EventHandler(m_mthDataShareInvokingItemClick2);
        }

        /// <summary>
        /// 直接数据复用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mthDataShareInvokingItemClick(object sender, EventArgs e)
        {
            m_mthDataShareInvokingItemClick2(sender, e);
        }

        /// <summary>
        /// 直接数据复用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mthDataShareInvokingItemClick2(object sender, EventArgs e)
        {
            if (MDIParent.s_ObjCurrentPatient == null)
            {
                MessageBox.Show("请选择患者！");
                return;
            }
            //此处加入判断，如果是【其他信息】，则弹出窗体
            string strContent = "";
            string m_strMenuText = "";
            //if((MenuItem)sender)

            string strParentText = "";
            string strText = "";

            if (sender is MenuCommand)
            {
                strParentText = ((MenuCommand)sender).Parent.Text;
                strText = ((MenuCommand)sender).Text;
            }
            else if (sender is MenuItem)
            {
                strParentText = ((MenuItem)sender).Parent.ToString().Substring(((MenuItem)sender).Parent.ToString().IndexOf("Text: ") + 6);
                strText = ((MenuItem)sender).Text;
            }
            else if (sender is ToolStripMenuItem)
            {
                strParentText = ((ToolStripMenuItem)sender).OwnerItem.Text;
                strText = ((ToolStripMenuItem)sender).Text;
            }

            if (strText != "其他信息")
            {

                strContent = "[" + strParentText + "--" + strText + "]";
                clsDataShareReplace.s_mthReplaceDataShareValue(MDIParent.s_ObjCurrentPatient, ref strContent, true);

                m_mthInertText( strContent);
            }
            else
            {
                //this.Cursor =Cursors.WaitCursor;

                frmDataShareTool.m_mthShowDataShareTool(MDIParent.s_ObjCurrentPatient.m_StrInPatientID, MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate, false, out strContent);
                if (strContent != "") m_mthInertText(strContent);

                //this.Cursor =Cursors.Default;
            }
        }


        #region 初始化控件
        private void m_mthInitInput(Form p_frmInput)
        {
            //			if(m_blnIsInited)
            //				return;
            //
            //			m_blnIsInited = true;
            //
            //			m_lstTemplate=new ListBox ();
            //			m_txtInputKeyword=new TextBox ();
            //			m_txtPreviewTemplate = new ctlTemplateEditer();
            //
            //			p_frmInput.Controls.Add (m_lstTemplate);
            //			p_frmInput.Controls.Add (m_txtInputKeyword);
            //			p_frmInput.Controls.Add (m_txtPreviewTemplate);
            //
            //			this.m_lstTemplate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
            //			this.m_lstTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //			this.m_lstTemplate.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            //			this.m_lstTemplate.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
            //			this.m_lstTemplate.ItemHeight = 25;
            //			this.m_lstTemplate.Location = new System.Drawing.Point(10, 10);
            //			this.m_lstTemplate.Name = "m_lstTemplate";
            //			this.m_lstTemplate.Size = new System.Drawing.Size(200, 300);
            //			this.m_lstTemplate.TabIndex = 15006;
            //			this.m_lstTemplate.BringToFront ();
            //			this.m_lstTemplate.Visible = false;
            //			this.m_lstTemplate.HorizontalScrollbar = true;
            //
            //			this.m_txtInputKeyword.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
            //			this.m_txtInputKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle ;
            //			this.m_txtInputKeyword.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            //			this.m_txtInputKeyword.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
            //			this.m_txtInputKeyword.Location = new System.Drawing.Point(10, 10);
            //			this.m_txtInputKeyword.Name = "m_txtInputKeyword";
            //			this.m_txtInputKeyword.Size = new System.Drawing.Size(200, 19);
            //			this.m_txtInputKeyword.TabIndex = 15000;
            //			this.m_txtInputKeyword.Text = "";
            //
            //			this.m_lstTemplate.BringToFront ();
            //			this.m_txtInputKeyword.Visible =false;
            //
            //			this.m_txtInputKeyword.KeyDown +=new System.Windows.Forms.KeyEventHandler(this.m_mthKeywordText_KeyDown ); 
            //			this.m_lstTemplate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lstTemplate_KeyDown);
            //			this.m_lstTemplate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_lstTemplate_KeyPress);
            //			this.m_lstTemplate.MouseDown   +=new System.Windows.Forms.MouseEventHandler  (this.m_lstTemplate_MouseDown );
            //
            //			this.m_lstTemplate.LostFocus  += new System.EventHandler(this.m_txtPreviewTemplate_LostFocus);
            //			this.m_txtInputKeyword.LostFocus +=new System.EventHandler(this.m_txtPreviewTemplate_LostFocus);
            //			this.m_lstTemplate.SelectedIndexChanged += new System.EventHandler(this.m_lstTemplate_SelectedIndexChanged);
            //
            //			// 
            //			// m_txtPreviewTemplate
            //			// 
            //			this.m_txtPreviewTemplate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
            //			this.m_txtPreviewTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle ;
            //			this.m_txtPreviewTemplate.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            //			this.m_txtPreviewTemplate.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
            //			this.m_txtPreviewTemplate.Location = new System.Drawing.Point(10, 10);
            //			this.m_txtPreviewTemplate.Name = "m_txtPreviewTemplate";
            ////			this.m_txtPreviewTemplate.Size = new System.Drawing.Size(400, 300+19-3);
            //			this.m_txtPreviewTemplate.Size = new System.Drawing.Size(400, 300-3);
            //			this.m_txtPreviewTemplate.TabIndex = 15007;
            //			this.m_txtPreviewTemplate.Text = "";
            //			this.m_txtPreviewTemplate.BringToFront();
            //			this.m_txtPreviewTemplate.Visible = false;
            //			this.m_txtPreviewTemplate.LostFocus += new System.EventHandler(m_txtPreviewTemplate_LostFocus);
        }
        #endregion

        private bool m_blnShowMessagebox = false;
        private void m_txtPreviewTemplate_LostFocus(object sender, System.EventArgs e)
        {
            if (!m_txtInputKeyword.Focused && !m_lstTemplate.Focused && !m_txtPreviewTemplate.Focused && !m_blnShowMessagebox)
            {
                m_txtInputKeyword.Visible = false;
                m_lstTemplate.Visible = false;
                m_txtPreviewTemplate.Visible = false;
                m_intPreSelectedIndex = -1;
            }
        }

        private int m_intPreSelectedIndex = -1;
        private void m_lstTemplate_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (m_lstTemplate.SelectedIndex != m_intPreSelectedIndex)
            {
                m_intPreSelectedIndex = m_lstTemplate.SelectedIndex;
                m_mthPreviewTemplate();
            }
        }


        /// <summary>
        /// 显示预览框
        /// </summary>
        private void m_mthShowPreviewTemplate()
        {
            m_txtPreviewTemplate.Top = m_lstTemplate.Top;
            m_txtPreviewTemplate.Left = m_lstTemplate.Right;
            m_txtPreviewTemplate.Visible = true;
            m_txtPreviewTemplate.BringToFront();
        }

        clsTemplatesetContentValue[] m_objTemplatesetContent;
        private string m_strSetID = "";

        /// <summary>
        /// 模板预览
        /// </summary>
        private void m_mthPreviewTemplate()
        {
            m_mthShowPreviewTemplate();
            #region 当前窗体所有控件
            //			clsGUI_Info_DetailValue[] objControls = m_objDomain.lngGetAllControls(m_strFormID);
            //			Hashtable htControls = new Hashtable();
            //			for(int i=0;i<objControls.Length;i++)
            //				htControls.Add(objControls[i].m_strControl_ID,objControls[i].m_strControl_Desc);
            #endregion

            StringBuilder sb = new StringBuilder();

            #region old
            //			switch(m_intSelectedLevel)
            //			{
            //				case 3:		//关键字层
            //					if(m_lstTemplate.Text.EndsWith("..."))
            //					{
            //						//一个关键字对应多个名称
            //						m_strKeyWord = m_lstTemplate.Text.Replace("...","");
            //						m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateKeywordName(m_strFormID,m_txtRichTextBox.Name ,m_strKeyWord,MDIParent.OperatorID,MDIParent.s_ObjDepartment.m_StrDeptID);
            //						if(m_objTemplateSet_ID_Name!=null && m_objTemplateSet_ID_Name.Length > 0)
            //						{
            //							for(int i=0;i<m_objTemplateSet_ID_Name.Length;i++)	
            //							{
            //								sb.Append(m_objTemplateSet_ID_Name[i].m_strSet_Name);
            //								sb.Append("\r\n");
            //							}
            //						}
            //					}
            //					else
            //					{
            //						//一个关键字对应一个名称，直接load出模板的值
            //						m_strKeyWord = m_lstTemplate.Text;
            //						m_objTemplateSet_ID_Name=m_objDomain.lngGetSetTemplateKeywordName(m_strFormID,m_txtRichTextBox.Name,m_strKeyWord,MDIParent.OperatorID,MDIParent.s_ObjDepartment.m_StrDeptID);
            //						m_objTemplatesetContent = m_objDomain.lngGetAllTemplatesetContent(m_objTemplateSet_ID_Name[0].m_strSet_ID);
            //						if(m_objTemplatesetContent==null || m_objTemplatesetContent.Length<=0)
            //							return;
            //
            //						for(int i=0;i<m_objTemplatesetContent.Length;i++)	
            //						{							
            //							sb.Append(htControls[m_objTemplatesetContent[i].m_strControl_ID].ToString());
            //							sb.Append(":\r\n    ");
            //							sb.Append(m_objTemplatesetContent[i].m_strContent);
            //							sb.Append("\r\n");
            //							sb.Append("         ");
            //							sb.Append("\r\n");
            //						}
            //					}					
            //					break;
            //				case 4:		//模板名层					
            //					//					string strSetID="";
            //					if(m_objTemplateSet_ID_Name !=null && m_objTemplateSet_ID_Name.Length >m_intSelectContentIndex )
            //					{
            //						m_strSetID=m_objTemplateSet_ID_Name[m_lstTemplate.SelectedIndex].m_strSet_ID;
            //					}
            //					if(m_strSetID=="")return;
            //					m_objTemplatesetContent = m_objDomain.lngGetAllTemplatesetContent(m_strSetID);
            //					if(m_objTemplatesetContent==null || m_objTemplatesetContent.Length<=0)
            //						return;
            //					for(int i=0;i<m_objTemplatesetContent.Length;i++)	
            //					{
            //						sb.Append(htControls[m_objTemplatesetContent[i].m_strControl_ID].ToString());
            //						sb.Append(":\r\n    ");
            //						sb.Append(m_objTemplatesetContent[i].m_strContent);
            //						sb.Append("\r\n");
            //						sb.Append("         ");
            //						sb.Append("\r\n");
            //					}
            //					break;
            //			}
            #endregion

            if (m_lstTemplate.Text.EndsWith("..."))//选中的是分类
            {
                sb.Append(m_strLoadSubKeywordOrTemplateName());
            }
            else//选中的是具体某一个模板名
            {
                //				m_strSetID = ((clsTemplateSet_ID_NameValue)m_lstTemplate.SelectedItem).m_strSet_ID;
                m_strSetID = m_htSet_ID[m_lstTemplate.SelectedIndex].ToString();
                m_objTemplatesetContent = m_objDomain.lngGetAllTemplatesetContent(m_strSetID);
                if (m_objTemplatesetContent == null || m_objTemplatesetContent.Length <= 0)
                    return;
                for (int i = 0; i < m_objTemplatesetContent.Length; i++)
                {
                    //					sb.Append(htControls[m_objTemplatesetContent[i].m_strControl_ID].ToString());
                    sb.Append(m_objTemplatesetContent[i].m_strControl_Desc);
                    sb.Append(":\r\n");
                    sb.Append(m_objTemplatesetContent[i].m_strContent);
                    sb.Append("\r\n");
                    sb.Append("         ");
                    sb.Append("\r\n");
                }
            }
            m_txtPreviewTemplate.m_mthSetTemplateText(sb.ToString());
        }

        private void m_lstTemplate_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Clicks > 1)
            {
                //				KeyEventArgs ee=new KeyEventArgs (System.Windows.Forms.Keys.Enter);
                //				m_lstTemplate_KeyDown(this.m_lstTemplate ,ee);

                if (m_lstTemplate.Text.EndsWith("..."))//选中的是分类
                {
                    m_intPreSelectedIndex = -1;//进入下一层之前将上次选中哪一行复位

                    if (m_strCurFolder == "")
                        m_strCurFolder = m_lstTemplate.Text.Replace("...", "");
                    else
                        m_strCurFolder += ">>" + m_lstTemplate.Text.Replace("...", "");
                    m_mthLoadSubKeywordOrTemplateName();
                }
                else//选中的是具体某一个模板名
                {
                    m_mthReplaceTemplateToTextBox();
                }
            }
        }
        private void m_txtInputKeyword_Leave(object sender, System.EventArgs e)
        {
            //			if(this.m_lstTemplate.Visible )
            //			{
            //				m_lstTemplate.Focus ();
            //				return;
            //			}
            //
            //			if(!this.m_txtInputKeyword.Focus () && !this.m_lstTemplate.Focus () && !this.m_txtRichTextBox.Focus () && !this.m_txtInputKeyword.Focus ())
            //			{
            //				this.m_txtInputKeyword.Visible =false;
            //				this.m_lstTemplate.Visible =false;
            //				this.m_txtPreviewTemplate.Visible = false;
            //				this.m_txtRichTextBox.Focus ();
            //				this.m_mthResetValiant ();
            //			}
        }
        #region 成员变量,刘颖源,2003-5-9 16:11:08
        bool m_blnIsInited = false;

        private ListBox m_lstTemplate;
        private TextBox m_txtInputKeyword;
        private ctlTemplateEditer m_txtPreviewTemplate;
        private int m_intLeftOfferset = 0;
        private int m_intTopOfferset = 0;

        private int m_intSelectedLevel = -1;						//当前ListBox在第几层
        private int m_intSingleSetTemplate = -1;					//选择了单元模板还是套装模板
        private int m_intSelectContentIndex = -1;					//选中的模板ID

        private int m_intByTemplate = -1;							//选择了BY ICD-10,关键字,八大系统

        internal Form m_frmForm;									//窗体
        private RichTextBox m_txtRichTextBox;					//加入的TextBox
        private string m_strFormID = "";							//FormID
        private string m_strControlID = "";						//ControlID
        private string m_strKeyWord = "";						//关键字名称		

        private clsTemplatesetInvoke m_objTemplatesetParent;	//父实例指针

        private clsTemplate_KeywordValue[] m_objTemplate_KeyWord = null;	//模板关键字
        private clsTemplate_DetailValue[] m_objTemplate_Detail = null;	//模板名称

        private clsTemplate_Set_KeywordValue[] m_objTemplateSet_KeywordValue = null;		//TemplateSetKeyword
        private clsTemplateSet_ID_NameValue[] m_objTemplateSet_ID_Name = null;		//TemplateSetKeywordName

        private clsTemplateDomain m_objDomain = new clsTemplateDomain();
        private Hashtable m_hasContolIDs = new Hashtable();

        /// <summary>
        /// 加入的控件(可以为各种TextBox及ComboBox)
        /// </summary>
        private Control m_ctlText = null;
        #endregion

        public void m_mthSetParent(clsTemplatesetInvoke p_objTemplatesetInvoke)
        {
            m_objTemplatesetParent = p_objTemplatesetInvoke;
        }
        private void m_mthResetValiant()
        {

            //			System.Drawing.Point pt= m_txtRichTextBox.GetPositionFromCharIndex(this.m_txtRichTextBox.Text.Length );
            //
            //			this.m_txtInputKeyword.Left = m_intLeftOfferset + pt.X ;
            //			this.m_txtInputKeyword.Top  =m_intTopOfferset +pt.Y+20;
            //			this.m_lstTemplate.Left = m_intLeftOfferset + pt.X ;
            //			this.m_lstTemplate.Top =m_intTopOfferset +pt.Y + 40;
            //		
            //			m_intSelectedLevel=-1;						//当前ListBox在第几层
            //			m_intSingleSetTemplate=-1;					//选择了单元模板还是套装模板
            //			m_intSelectContentIndex=-1;					//选中的模板ID
            //
            //			m_intByTemplate=-1;							//选择了BY ICD-10,关键字,八大系统
            //
            //			m_objTemplate_Detail=null;	//模板
        }

        private void m_mthCalculatePosition(Form p_frmInput, Control p_txtInput)
        {
            Control ctlTemp = p_txtInput;

            Control ctlBase = p_frmInput;
            if (ctlBase == null) return;
            m_intLeftOfferset = 0;
            m_intTopOfferset = 0;

            while (!ctlTemp.Equals(ctlBase))
            {
                if (ctlTemp.Parent == null)
                    return;

                m_intLeftOfferset += ctlTemp.Location.X;
                m_intTopOfferset += ctlTemp.Location.Y;

                ctlTemp = ctlTemp.Parent;
            }
        }

        private Hashtable htIfAddMenuItem = new Hashtable();

        public void m_mthAddTextBox(Form p_frmInput, Control p_txtInput, string p_strFormID, string p_strControlID)
        {
            m_hasContolIDs[p_txtInput] = p_strControlID;

            m_frmForm = p_frmInput;
            //m_txtRichTextBox = p_txtInput;
            m_ctlText = p_txtInput;
            m_strFormID = p_strFormID;
            m_strControlID = p_strControlID;
            //			p_txtInput.KeyDown += new KeyEventHandler(m_mthKeyDown);//不要mb.


            if (p_txtInput.ContextMenuStrip != null && htIfAddMenuItem[p_frmInput] == null)
            {
                this.m_ctlText.ContextMenuStrip.Items.Add(m_mncTemplate);
                this.m_ctlText.ContextMenuStrip.Items.Add(m_mncCommonUse);
                htIfAddMenuItem[p_frmInput] = false;
            }
            else
            {
                this.m_ctlText.ContextMenuStrip = m_ppmMenu;
            }

            //if (p_txtInput.ContextMenu != null && htIfAddMenuItem[p_frmInput] == null)
            //{
            //    p_txtInput.ContextMenu.MenuItems.Add(m_mniSuperSubScript);
            //    p_txtInput.ContextMenu.MenuItems.Add("-");
            //    while (m_ctmControl.MenuItems.Count > 0)
            //        p_txtInput.ContextMenu.MenuItems.Add(m_ctmControl.MenuItems[0]);
            //    //				p_txtInput.ContextMenu.MergeMenu(m_ctmControl);
            //    //				p_txtInput.ContextMenu = m_ctmControl;
            //    p_txtInput.ContextMenu.Popup += new EventHandler(m_ctmPopup);
            //    htIfAddMenuItem[p_frmInput] = false;
            //    m_intStartRemove = m_ctmControl.MenuItems.Count;
            //}
            //else if (p_txtInput.ContextMenu == null)//用新的右键菜单
            //{
            //    this.m_ctlText.MouseUp += new MouseEventHandler(m_txtTextBox_MouseUp);
            //    //this.m_txtRichTextBox.MouseUp += new MouseEventHandler(m_txtRichTextBox_MouseUp);
            //    //				p_txtInput.ContextMenu = m_ctmControl;
            //    //				m_intStartRemove = m_ctmControl.MenuItems.Count;
            //}

            m_mthCalculatePosition(m_frmForm, m_ctlText);
            this.m_ctlText.Enter += new EventHandler(m_ctlText_Enter);
            //m_mthInitInput(p_frmInput);

            //this.m_txtRichTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtRichTextBox_MouseDown);
            //this.m_txtRichTextBox.Enter += new System.EventHandler(this.m_txtRichTextBox_Enter);
        }

        private void m_ctlText_Enter(object sender, EventArgs e)
        {
            m_ctlText = (Control)sender;
            m_mthCalculatePosition(m_frmForm, m_ctlText);
            m_strControlID = m_hasContolIDs[m_ctlText].ToString();
        }

        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                m_mthSetPatientID(((Control)sender).FindForm());
                m_mthLoadCommonUseTemplate(m_mncCommonUse);
                m_mncCommonUse.Enabled = m_mncCommonUse.DropDownItems.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private Hashtable m_htCommonUseItem = new Hashtable();

        /// <summary>
        /// 删除常用值模板的开始点
        /// </summary>
        private int m_intStartRemove = -1;

        /// <summary>
        /// 查出常用值模板
        /// </summary>
        private void m_mthLoadCommonUse()
        {
            m_mniCommonUse.MenuItems.Clear();
            //先清空常用值模板
            while (m_ctmControl.MenuItems.Count > m_intStartRemove)
            {
                m_ctmControl.MenuItems.RemoveAt(m_intStartRemove);
            }

            if (m_objTemplateSet_KeywordValue != null && m_objTemplateSet_KeywordValue.Length > 0)
            {
                string strKeyword = "";
                for (int i = 0; i < m_objTemplateSet_KeywordValue.Length; i++)
                {
                    if (m_objTemplateSet_KeywordValue[i].m_strKeyword.StartsWith("常用值") && m_objTemplateSet_KeywordValue[i].m_strKeyword != strKeyword)
                    {
                        m_mniCommonUse.MenuItems.Add(m_objTemplateSet_KeywordValue[i].m_strKeyword);
                        strKeyword = m_objTemplateSet_KeywordValue[i].m_strKeyword;
                    }
                }

                if (m_mniCommonUse.MenuItems.Count < 1)
                    return;
                else
                {
                    m_ctmControl.MenuItems.Add("-");

                    if (m_mniCommonUse.MenuItems.Count == 1)
                    {
                        m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateKeywordName(m_strFormID, m_txtRichTextBox.Name, m_mniCommonUse.MenuItems[0].Text, MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR);

                        m_mniCommonUse.MenuItems.Clear();

                        if (m_objTemplateSet_ID_Name != null && m_objTemplateSet_ID_Name.Length > 0)
                        {
                            for (int j = 0; j < m_objTemplateSet_ID_Name.Length; j++)
                            {
                                MenuItem mniItem = new MenuItem(m_objTemplateSet_ID_Name[j].m_strSet_Name);
                                mniItem.Click += new EventHandler(m_ctmCommonTemplate_Click);
                                m_ctmControl.MenuItems.Add(mniItem);
                                m_htCommonUseItem.Add(mniItem, m_objTemplateSet_ID_Name[j].m_strSet_ID);
                            }
                        }
                    }
                    else
                    {
                        ArrayList arlTemp = new ArrayList();

                        for (int i = 0; i < m_mniCommonUse.MenuItems.Count; i++)
                        {
                            m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateKeywordName(m_strFormID, m_txtRichTextBox.Name, m_mniCommonUse.MenuItems[i].Text, MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR);
                            if (m_objTemplateSet_ID_Name != null && m_objTemplateSet_ID_Name.Length > 0)
                            {
                                for (int j = 0; j < m_objTemplateSet_ID_Name.Length; j++)
                                {
                                    MenuItem mniItem = new MenuItem(m_objTemplateSet_ID_Name[j].m_strSet_Name);
                                    mniItem.Click += new EventHandler(m_ctmCommonTemplate_Click);
                                    m_htCommonUseItem.Add(mniItem, m_objTemplateSet_ID_Name[j].m_strSet_ID);

                                    if (m_mniCommonUse.MenuItems[i].Text.Equals("常用值"))
                                    {
                                        m_ctmControl.MenuItems.Add(mniItem);
                                    }
                                    else
                                    {
                                        m_mniCommonUse.MenuItems[i].Text = m_mniCommonUse.MenuItems[i].Text.Replace("常用值--", "");

                                        m_mniCommonUse.MenuItems[i].MenuItems.Add(mniItem);
                                    }
                                }
                            }

                            if (!m_mniCommonUse.MenuItems[i].Text.Equals("常用值"))
                            {
                                arlTemp.Add(m_mniCommonUse.MenuItems[i]);
                            }
                        }

                        m_ctmControl.MenuItems.AddRange((MenuItem[])arlTemp.ToArray(typeof(MenuItem)));

                    }


                }

            }
        }

        /// <summary>
        /// 常用值插入点
        /// </summary>
        //		private int m_intSelectionStart;

        /// <summary>
        /// 检测是否有模板，如果没有，则模板按钮不可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_ctmPopup(object sender, EventArgs e)
        {
            m_mthSetItemsVisible();

            //			m_mthLoadCommonUse();
            m_mthLoadCommonUseTemplate(m_mniCommonUse);
            m_mniCommonUse.Enabled = m_mniCommonUse.MenuItems.Count > 0 ? true : false;
        }

        /// <summary>
        /// 设置一些右键菜单项目的可见性
        /// </summary>
        private void m_mthSetItemsVisible()
        {
            ContextMenu ctm = m_txtRichTextBox.ContextMenu;

            if (m_frmForm.Name == "frmGeneralDisease" && m_txtRichTextBox.Name == "m_txtRecordTitle")
            {
                for (int i = 0; i < ctm.MenuItems.Count; i++)
                {
                    if (ctm.MenuItems[i].Text != "模板")
                        ctm.MenuItems[i].Visible = false;
                    else
                        break;
                }
            }
            else
            {
                for (int i = 0; i < ctm.MenuItems.Count; i++)
                {
                    ctm.MenuItems[i].Visible = true;
                }
            }
        }

        private void m_ctmCommonTemplate_Click(object sender, EventArgs e)
        {
            string strSetID = m_htCommonUseItem[sender].ToString();

            //clsTemplatesetContentValue[] objTemplatesetContent = m_objDomain.lngGetAllTemplatesetContent(strSetID);
            VO::clsTemplate[] objTemplate = null;
            if (m_frmForm is frmHRPBaseForm)
            {
                frmHRPBaseForm frmBase = m_frmForm as frmHRPBaseForm;
                if (frmBase.m_ObjTemplateClient != null)
                {
                    objTemplate = frmBase.m_ObjTemplateClient.m_objCommonUseTemplateArr(strSetID);
                }                
            }

            m_objTemplatesetParent.m_mthLoadTemplateset(objTemplate,m_ctlText);
        }

        /// <summary>
        /// 查找所有模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_ctmTemplate_Click(object sender, EventArgs e)
        {
            //			if(m_frmForm.Name.StartsWith("frmInPatientCaseHistory") && (m_txtRichTextBox.Name == "m_txtPrimaryDiagnose" || m_txtRichTextBox.Name == "m_txtCurrentStatus"))
            //				m_blnIfSaveDisease = true;

            //			if(m_frmForm.Name.StartsWith("frmInPatientCaseHistory"))
            //				m_blnIfSaveDisease = true;
            //
            //			#region old
            ////			this.m_txtInputKeyword.Text ="mb.";
            ////			m_strTemplate_Type = ".套装模板.按关键字.";
            ////			m_intSingleSetTemplate = 0;
            ////			m_intByTemplate = 0;
            ////			this.m_mthKeywordText_KeyDown (m_txtInputKeyword ,new KeyEventArgs(Keys.Decimal));
            //			#endregion
            //			m_intPreSelectedIndex = -1;
            //			m_strCurFolder = "";
            ////			m_mthLoadAllTemplateKeyword();
            //			new frmTemplateSelect(this).Show();
            try
            {
                if (m_frmForm is frmHRPBaseForm)
                {
                    frmHRPBaseForm frmBase = m_frmForm as frmHRPBaseForm;
                    if (frmBase.m_ObjTemplateClient != null)
                    {
                        frmBase.m_ObjTemplateClient.m_mthUseTemplate(m_ctlText, com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_ObjSelectArea.m_strDEPTID_CHR);
                    }
                }
                else
                {
                    m_mthInvokeTemplate();
                }
            }
            catch (Exception exp)
            {
                string strErrMessage = exp.Message + "\n at Module:[" + exp.TargetSite.ReflectedType.Name + "]\n  Method:[" + exp.TargetSite.Name + "]";
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.Log2File(MDIParent.s_strErrorFilePath, "Exception: \r\n" + strErrMessage);
            }            
        }

        private void m_txtRichTextBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            m_mthSetCurRichTextBox((RichTextBox)sender);
        }
        private void m_txtRichTextBox_Enter(object sender, System.EventArgs e)
        {
            m_txtRichTextBox = (RichTextBox)sender;
            m_mthCalculatePosition(m_frmForm, m_txtRichTextBox);
            m_strControlID = m_hasContolIDs[m_txtRichTextBox].ToString();

        }

        private string m_strTemplate_Type = ".套装模板.按关键字.";

        public void m_mthKeywordText_KeyDown(object p_objSender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                this.m_lstTemplate.Visible = false;
                this.m_txtInputKeyword.Visible = false;
                this.m_txtRichTextBox.Focus();
                m_mthResetValiant();
                return;
            }
            if (m_txtInputKeyword.Visible == false)
            {
                int intSelectionStartIndex = this.m_txtRichTextBox.SelectionStart;
                System.Drawing.Point pt = this.m_txtRichTextBox.GetPositionFromCharIndex(intSelectionStartIndex);

                this.m_txtInputKeyword.Left = m_intLeftOfferset + pt.X;
                this.m_txtInputKeyword.Top = m_intTopOfferset + pt.Y + 20;
                this.m_lstTemplate.Left = m_intLeftOfferset + pt.X;
                this.m_lstTemplate.Top = m_intTopOfferset + pt.Y + 40;
            }
            this.m_lstTemplate.Items.Clear();

            if ((e.KeyCode == System.Windows.Forms.Keys.Decimal || e.KeyCode == System.Windows.Forms.Keys.OemPeriod || e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                //判断是否加载ListBox,此小数点前是否mb

                int intSelectStart = this.m_txtRichTextBox.SelectionStart;
                int intPointnumber = 0;
                string strText = "";
                strText = this.m_txtInputKeyword.Text + m_strTemplate_Type;
                //				m_intSingleSetTemplate = 0;
                //				m_intByTemplate = 0;
                strText = strText.Replace("..", ".");
                for (int i = 0; i < strText.Length; i++)
                    if (strText[i] == '.') intPointnumber++;
                m_intSelectedLevel = intPointnumber;
                switch (intPointnumber)
                {
                    case 1:
                        this.m_lstTemplate.Items.Add("套装模板");
                        this.m_lstTemplate.Items.Add("单个模板");
                        break;
                    case 2:
                        this.m_lstTemplate.Items.Add("按关键字");
                        this.m_lstTemplate.Items.Add("按ICD-10");
                        this.m_lstTemplate.Items.Add("按八大系统");
                        if (this.m_txtInputKeyword.Text.EndsWith("单个模板"))
                            this.m_lstTemplate.Items.Add("按常用值");
                        break;
                    case 3:
                        m_mthLoadTemplate();
                        break;
                    case 4:
                        m_mthLoadTemplateName();
                        break;
                }

                m_mthAddListBoxItemPYCode(this.m_lstTemplate);

                this.m_txtInputKeyword.Text = this.m_txtInputKeyword.Text.Replace("..", ".");
                this.m_txtInputKeyword.Visible = true;
                this.m_txtInputKeyword.SelectionStart = this.m_txtInputKeyword.TextLength;
                this.m_txtInputKeyword.SelectionLength = 0;
                this.m_txtInputKeyword.BringToFront();
                this.m_lstTemplate.Visible = true;
                this.m_lstTemplate.BringToFront();

                if (this.m_lstTemplate.Items.Count > 0)
                {
                    this.m_lstTemplate.SelectedIndex = 0;
                }
                this.m_lstTemplate.Focus();
                if (this.m_lstTemplate.Items.Count <= 0 && this.m_txtInputKeyword.Visible == true)
                    this.m_txtInputKeyword.Focus();
            }


        }

        public void m_mthKeyDown(object p_objSender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                this.m_lstTemplate.Visible = false;
                this.m_txtInputKeyword.Visible = false;
                this.m_txtRichTextBox.Focus();
                m_mthResetValiant();
                return;
            }
            m_txtRichTextBox = (RichTextBox)p_objSender;
            m_mthCalculatePosition(m_frmForm, m_txtRichTextBox);

            if ((e.KeyCode == System.Windows.Forms.Keys.Decimal || e.KeyCode == System.Windows.Forms.Keys.OemPeriod))
            {
                //判断是否加载ListBox,此小数点前是否mb
                int intSelectStart = this.m_txtRichTextBox.SelectionStart;

                if (intSelectStart < 2) return;
                string strMB = this.m_txtRichTextBox.Text.Substring(intSelectStart - 2, 2);
                if (strMB != "mb")
                {
                    return;
                }
                else
                {
                    this.m_txtInputKeyword.Text = "mb.";
                    this.m_mthKeywordText_KeyDown(m_txtInputKeyword, e);
                }
            }
        }


        private DateTime m_dtPre;//相当于DateTime.MinValue
        private string m_strQuery;

        /// <summary>
        /// ListBox模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_lstTemplate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TimeSpan ts;

            if (m_dtPre == DateTime.MinValue)
            {
                m_dtPre = DateTime.Now;
                m_strQuery = e.KeyChar.ToString().ToUpper();//变大写的用途：用户输入时可能是小写状态，为了避免用户按Shift键
            }
            else
            {
                ts = DateTime.Now - m_dtPre;
                if (ts.Seconds < 1)
                {
                    m_strQuery += e.KeyChar.ToString().ToUpper();
                }
                else
                {
                    m_strQuery = e.KeyChar.ToString().ToUpper();
                    m_dtPre = DateTime.Now;
                }
            }

            m_mthGoToItem(m_strQuery);

            e.Handled = true;//该事件已经处理，系统不用理它了
        }

        //ListBox事件处理
        public void m_lstTemplate_KeyDown(object p_objSender, KeyEventArgs e)
        {
            #region old
            //			if(e.KeyCode ==System.Windows.Forms.Keys.Escape )
            //			{
            //				this.m_lstTemplate.Visible =false;
            //				m_mthResetValiant();
            //				this.m_txtInputKeyword.SelectionStart = this.m_txtInputKeyword.TextLength ;
            //				this.m_txtInputKeyword.SelectionLength =0;
            //				this.m_txtInputKeyword.Focus ();
            //				return;
            //			}
            //
            //			if(this.m_lstTemplate.Items.Count <=0)return;
            //			
            //			#region 键盘处理程序(Space和Enter处理),刘颖源,2003-5-8 17:26:57
            //			if((e.KeyCode == System.Windows.Forms.Keys.Space || e.KeyCode ==System.Windows.Forms.Keys.Enter ) && this.m_lstTemplate.Visible )
            //			{
            //				int intIndex=this.m_lstTemplate.SelectedIndex ;
            //				if(intIndex>=0 && intIndex < this.m_lstTemplate.Items.Count )
            //				{
            //					switch(m_intSelectedLevel)
            //					{
            //						case 1:
            //							m_intSingleSetTemplate=intIndex;			//套装,单个模板
            //							break;
            //						case 2:
            //							m_intByTemplate =intIndex;					//ICD-10,关键字,八大系统
            //							break;
            //						case 3:		//关键字这一层
            //							if(m_lstTemplate.Text.EndsWith("..."))
            //							{
            //								//一个关键字对应多个名称
            //								m_strKeyWord = m_lstTemplate.Text.Replace("...","");
            //								break;
            //							}
            //							else
            //							{
            //								//一个关键字对应一个名称，直接load出模板的值
            //								m_strKeyWord = m_lstTemplate.Text;
            //								if(m_txtInputKeyword.Text.StartsWith("mb.单个模板"))
            //								{
            //									if(m_txtInputKeyword.Text.EndsWith("按关键字"))
            //										m_objTemplate_Detail=m_objDomain.lngGetSingleKeywordTemplates(1,m_strFormID,m_strControlID ,m_strKeyWord,MDIParent.OperatorID,MDIParent.s_ObjDepartment.m_StrDeptID);
            //									else
            //										m_objTemplate_Detail=m_objDomain.lngGetSingleKeywordTemplates(4,m_strFormID,m_strControlID ,m_strKeyWord,MDIParent.OperatorID,MDIParent.s_ObjDepartment.m_StrDeptID);
            //								}
            //								else
            //								{
            //									m_objTemplateSet_ID_Name=m_objDomain.lngGetSetTemplateKeywordName(m_strFormID,m_txtRichTextBox.Name,m_strKeyWord,MDIParent.OperatorID,MDIParent.s_ObjDepartment.m_StrDeptID);
            //								}
            //								m_intSelectContentIndex=0 ;			
            //								m_mthReplaceTemplateToTextBox();
            //								return;
            //							}
            //						case 4:			//模板名这一层，即最后一层
            //							m_intSelectContentIndex=intIndex ;			//选中的模板ID
            //							m_mthReplaceTemplateToTextBox();
            //							return;
            //
            //					}
            //
            //					this.m_txtInputKeyword.Text +="." + this.m_lstTemplate.Text.Replace("...","") ;	//mb(.)
            //					this.m_txtInputKeyword.Text =this.m_txtInputKeyword.Text.Replace ("..",".");
            //					this.m_txtInputKeyword.SelectionStart =this.m_txtInputKeyword.Text.Length ;
            //					this.m_txtInputKeyword.SelectionLength =0;
            //					this.m_txtInputKeyword.Focus ();					//转移焦点以便获取新的'.'或回车	
            //
            //					KeyEventArgs ee=new KeyEventArgs (System.Windows.Forms.Keys.Enter);
            //					m_mthKeywordText_KeyDown(this.m_txtInputKeyword ,ee);
            //				}
            //				return;
            //			}
            //			#endregion			
            //			
            //			return;
            #endregion
            if (e.KeyCode == Keys.Enter)
                m_lstTemplate_MouseDown(null, new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
        }

        /// <summary>
        /// ListBox的模糊查询定位
        /// </summary>
        /// <param name="p_strStart"></param>
        private void m_mthGoToItem(string p_strStart)
        {
            if (m_lstTemplate.Items.Count > 0)
            {
                int intCur;
                if (p_strStart.Length > 1)//如果用户输入多位字符进行查询，从SelectedIndex开始查找
                    intCur = m_lstTemplate.SelectedIndex;
                else//如果用户只输入一位字符进行查询，从SelectedIndex的下一个开始查找
                    intCur = (m_lstTemplate.SelectedIndex + 1 >= m_lstTemplate.Items.Count ? 0 : (m_lstTemplate.SelectedIndex + 1));

                for (int i = intCur; i < m_lstTemplate.Items.Count; i++)
                {
                    if (((clsListBoxSearchItem)m_lstTemplate.Items[i]).m_StrPY.StartsWith(p_strStart))
                    {
                        m_lstTemplate.SelectedIndex = i;
                        return;
                    }
                }
                for (int i1 = 0; i1 < m_lstTemplate.SelectedIndex; i1++)
                {
                    if (((clsListBoxSearchItem)m_lstTemplate.Items[i1]).m_StrPY.StartsWith(p_strStart))
                    {
                        m_lstTemplate.SelectedIndex = i1;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 得到汉字的拼音首码
        /// </summary>
        /// <param name="p_strChinese"></param>
        /// <returns></returns>
        private string m_strGetPYCode(string p_strChinese)
        {
            long tmp;
            string getpychar = "";
            for (int i = 0; i < p_strChinese.Length; i++)
            {
                if (Math.Abs(Strings.Asc(p_strChinese[i])) <= 256) getpychar += p_strChinese[i];
                else
                {
                    tmp = 65536 + Strings.Asc(p_strChinese[i]);
                    if (tmp >= 45217 && tmp <= 45252) getpychar += "A";
                    if (tmp >= 45253 && tmp <= 45760) getpychar += "B";
                    if (tmp >= 45761 && tmp <= 46317) getpychar += "C";
                    if (tmp >= 46318 && tmp <= 46825) getpychar += "D";
                    if (tmp >= 46826 && tmp <= 47009) getpychar += "E";
                    if (tmp >= 47010 && tmp <= 47296) getpychar += "F";
                    if (tmp >= 47297 && tmp <= 47613) getpychar += "G";
                    if (tmp >= 47614 && tmp <= 48118) getpychar += "H";
                    if (tmp >= 48119 && tmp <= 49061) getpychar += "J";
                    if (tmp >= 49062 && tmp <= 49323) getpychar += "K";
                    if (tmp >= 49324 && tmp <= 49895) getpychar += "L";
                    if (tmp >= 49896 && tmp <= 50370) getpychar += "M";
                    if (tmp >= 50371 && tmp <= 50613) getpychar += "N";
                    if (tmp >= 50614 && tmp <= 50621) getpychar += "O";
                    if (tmp >= 50622 && tmp <= 50905) getpychar += "P";
                    if (tmp >= 50906 && tmp <= 51386) getpychar += "Q";
                    if (tmp >= 51387 && tmp <= 51445) getpychar += "R";
                    if (tmp >= 51446 && tmp <= 52217) getpychar += "S";
                    if (tmp >= 52218 && tmp <= 52697) getpychar += "T";
                    if (tmp >= 52698 && tmp <= 52979) getpychar += "W";
                    if (tmp >= 52980 && tmp <= 53688) getpychar += "X";
                    if (tmp >= 53689 && tmp <= 54480) getpychar += "Y";
                    if (tmp >= 54481 && tmp <= 56289) getpychar += "Z";
                }
            }
            return getpychar.ToUpper();
        }

        /// <summary>
        /// 为ListBox上的每个Item加上拼音码--蔡沐忠
        /// </summary>
        /// <param name="p_lst"></param>
        private void m_mthAddListBoxItemPYCode(ListBox p_lst)
        {
            if (p_lst.Items.Count > 0)
            {
                ArrayList arlTemp = new ArrayList();
                clsListBoxSearchItem[] objItemArr = new clsListBoxSearchItem[p_lst.Items.Count];
                for (int i = 0; i < p_lst.Items.Count; i++)
                {
                    string strName = p_lst.Items[i].ToString();
                    string strPY = m_strGetPYCode(strName);
                    clsListBoxSearchItem objItem = new clsListBoxSearchItem(strName, strPY);
                    arlTemp.Add(objItem);
                }
                objItemArr = (clsListBoxSearchItem[])arlTemp.ToArray(typeof(clsListBoxSearchItem));
                p_lst.Items.Clear();
                p_lst.Items.AddRange(objItemArr);
            }
        }

        #region 载入模板关键字
        private void m_mthLoadTemplate()
        {
            #region 查出所有模板
            if (m_intSingleSetTemplate == 1)			//单模板
            {
                switch (m_intByTemplate)
                {
                    case 0:						//关键字
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplate_KeyWord = m_objDomain.lngGetSingleKeyword(1/*1为关键字，4为常用值*/, m_strFormID, m_strControlID, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);

                        if (m_objTemplate_KeyWord != null && m_objTemplate_KeyWord.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplate_KeyWord.Length; i++)
                            {
                                if (m_lstTemplate.Items.Count == 0)
                                    this.m_lstTemplate.Items.Add(m_objTemplate_KeyWord[i].m_strKeyword);
                                else if (m_objTemplate_KeyWord[i].m_strKeyword != m_lstTemplate.Items[m_lstTemplate.Items.Count - 1].ToString().Replace("...", ""))
                                {
                                    this.m_lstTemplate.Items.Add(m_objTemplate_KeyWord[i].m_strKeyword);
                                }
                                else
                                    m_lstTemplate.Items[m_lstTemplate.Items.Count - 1] = m_objTemplate_KeyWord[i].m_strKeyword + "...";

                            }
                        }
                        break;
                    case 1:						//ICD - 10
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplate_Detail = m_objDomain.lngGetSingleICD_10Templates(m_strFormID, m_strControlID, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplate_Detail != null && m_objTemplate_Detail.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplate_Detail.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplate_Detail[i].m_strTemplate_Name);
                        }
                        break;
                    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    case 2:						//八大系统
                        m_objTemplate_Detail = m_objDomain.lngGetSingleBio_SystemTemplates(m_strFormID, m_strControlID, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplate_Detail != null && m_objTemplate_Detail.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplate_Detail.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplate_Detail[i].m_strTemplate_Name);
                        }
                        break;
                    case 3:						//常用值
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplate_KeyWord = m_objDomain.lngGetSingleKeyword(4/*1为关键字，4为常用值*/, m_strFormID, m_strControlID, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);

                        if (m_objTemplate_KeyWord != null && m_objTemplate_KeyWord.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplate_KeyWord.Length; i++)
                            {
                                if (m_lstTemplate.Items.Count == 0)
                                    this.m_lstTemplate.Items.Add(m_objTemplate_KeyWord[i].m_strKeyword);
                                else if (m_objTemplate_KeyWord[i].m_strKeyword != m_lstTemplate.Items[m_lstTemplate.Items.Count - 1].ToString().Replace("...", ""))
                                {
                                    this.m_lstTemplate.Items.Add(m_objTemplate_KeyWord[i].m_strKeyword);
                                }
                                else
                                    m_lstTemplate.Items[m_lstTemplate.Items.Count - 1] = m_objTemplate_KeyWord[i].m_strKeyword + "...";

                            }
                        }

                        //如果只有一个分类，直接出模板名
                        if (m_lstTemplate.Items.Count == 1)
                        {
                            m_strKeyWord = m_lstTemplate.Items[0].ToString().Replace("...", "");
                            m_lstTemplate.Items.Clear();
                            m_intSelectedLevel = 4;		//ListBox位于第几层，4为最后一层模板名
                            m_mthLoadTemplateName();
                        }

                        break;

                }
            }
            else									//套装模板
            {
                switch (m_intByTemplate)
                {
                    case 1:						//ICD-10
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateICD_10(m_strFormID, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplateSet_ID_Name != null && m_objTemplateSet_ID_Name.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplateSet_ID_Name.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplateSet_ID_Name[i].m_strSet_Name);
                        }
                        break;

                    case 0:					//关键字
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplateSet_KeywordValue = m_objDomain.lngGetSetTemplateKeyword(m_strFormID, m_txtRichTextBox.Name, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplateSet_KeywordValue != null && m_objTemplateSet_KeywordValue.Length > 0)
                        {
                            //上一个文件夹名，在这里将分类名比如为文件夹；最前面的分类名即根目录
                            string strPreFolder = "";
                            for (int i = 0; i < m_objTemplateSet_KeywordValue.Length; i++)
                            {
                                int intIndexOfArrow = m_objTemplateSet_KeywordValue[i].m_strKeyword.IndexOf(">>");
                                if (intIndexOfArrow != -1)//多层目录
                                {
                                    if (m_objTemplateSet_KeywordValue[i].m_strKeyword.Substring(0, intIndexOfArrow) != strPreFolder)
                                    {
                                        this.m_lstTemplate.Items.Add(m_objTemplateSet_KeywordValue[i].m_strKeyword.Substring(0, intIndexOfArrow) + "...");
                                        strPreFolder = m_objTemplateSet_KeywordValue[i].m_strKeyword.Substring(0, intIndexOfArrow);
                                    }
                                }
                                else if (m_objTemplateSet_KeywordValue[i].m_strKeyword != strPreFolder)
                                {
                                    this.m_lstTemplate.Items.Add(m_objTemplateSet_KeywordValue[i].m_strKeyword + "...");
                                    strPreFolder = m_objTemplateSet_KeywordValue[i].m_strKeyword;
                                }

                                //								if(m_lstTemplate.Items.Count==0)
                                //									this.m_lstTemplate.Items.Add (m_objTemplateSet_KeywordValue[i].m_strKeyword);
                                //								else if(m_objTemplateSet_KeywordValue[i].m_strKeyword!=m_lstTemplate.Items[m_lstTemplate.Items.Count-1].ToString().Replace("...",""))
                                //								{
                                //									this.m_lstTemplate.Items.Add (m_objTemplateSet_KeywordValue[i].m_strKeyword);
                                //								}								
                                //								else
                                //									m_lstTemplate.Items[m_lstTemplate.Items.Count-1] = m_objTemplateSet_KeywordValue[i].m_strKeyword + "...";
                            }
                        }

                        //如果只有一个分类，直接出模板名
                        //						if(m_lstTemplate.Items.Count == 1 && m_lstTemplate.Items[0].ToString().EndsWith("..."))
                        //						{
                        //							m_strKeyWord = m_lstTemplate.Items[0].ToString().Replace("...","");
                        //							m_lstTemplate.Items.Clear();
                        //							m_intSelectedLevel = 4;		//ListBox位于第几层，4为最后一层模板名
                        //							m_mthLoadTemplateName();
                        //						}


                        break;
                    case 2:					//八大系统
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateBio_System(m_strFormID, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplateSet_ID_Name != null && m_objTemplateSet_ID_Name.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplateSet_ID_Name.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplateSet_ID_Name[i].m_strSet_Name);
                        }
                        break;
                }
            }

            #endregion

            #region 为每个模板名加上拼音码--蔡沐忠
            //			m_mthAddListBoxItemPYCode(this.m_lstTemplate);
            #endregion
        }
        #endregion

        #region 载入模板名称
        private void m_mthLoadTemplateName()
        {
            if (m_intSingleSetTemplate == 1)			//单模板
            {
                switch (m_intByTemplate)
                {
                    case 0:						//关键字
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplate_Detail = m_objDomain.lngGetSingleKeywordTemplates(1, m_strFormID, m_strControlID, m_strKeyWord, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplate_Detail != null && m_objTemplate_Detail.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplate_Detail.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplate_Detail[i].m_strTemplate_Name);
                        }
                        break;
                    case 1:						//ICD - 10
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplate_Detail = m_objDomain.lngGetSingleICD_10Templates(m_strFormID, m_strControlID, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplate_Detail != null && m_objTemplate_Detail.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplate_Detail.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplate_Detail[i].m_strTemplate_Name);
                        }
                        break;
                    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    case 2:						//八大系统
                        m_objTemplate_Detail = m_objDomain.lngGetSingleBio_SystemTemplates(m_strFormID, m_strControlID, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplate_Detail != null && m_objTemplate_Detail.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplate_Detail.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplate_Detail[i].m_strTemplate_Name);
                        }
                        break;
                    case 3:						//常用值
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplate_Detail = m_objDomain.lngGetSingleKeywordTemplates(4, m_strFormID, m_strControlID, m_strKeyWord, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplate_Detail != null && m_objTemplate_Detail.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplate_Detail.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplate_Detail[i].m_strTemplate_Name);
                        }
                        break;
                }
            }
            else									//套装模板
            {
                switch (m_intByTemplate)
                {
                    case 1:						//ICD-10
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateICD_10(m_strFormID, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplateSet_ID_Name != null && m_objTemplateSet_ID_Name.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplateSet_ID_Name.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplateSet_ID_Name[i].m_strSet_Name);
                        }
                        break;

                    case 0:					//关键字
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateKeywordName(m_strFormID, m_txtRichTextBox.Name, m_strKeyWord, MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR);
                        if (m_objTemplateSet_ID_Name != null && m_objTemplateSet_ID_Name.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplateSet_ID_Name.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplateSet_ID_Name[i].m_strSet_Name);
                        }
                        break;
                    case 2:					//八大系统
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateBio_System(m_strFormID, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
                        if (m_objTemplateSet_ID_Name != null && m_objTemplateSet_ID_Name.Length > 0)
                        {
                            for (int i = 0; i < m_objTemplateSet_ID_Name.Length; i++)
                                this.m_lstTemplate.Items.Add(m_objTemplateSet_ID_Name[i].m_strSet_Name);
                        }
                        break;

                }
            }

            #region 为每个模板名加上拼音码--蔡沐忠
            //			m_mthAddListBoxItemPYCode(this.m_lstTemplate);
            #endregion
        }
        #endregion

        public void m_lstTemplateLeave_Leave(object sender, System.EventArgs e)
        {
            //			if(m_txtInputKeyword.Visible )
            //			{
            //				this.m_txtInputKeyword.SelectionStart =this.m_txtInputKeyword.TextLength ;
            //				this.m_txtInputKeyword.SelectionLength =0;
            //				this.m_txtInputKeyword.Focus ();
            //			}

            //			if(m_txtPreviewTemplate.Visible )
            //			{
            //				this.m_txtInputKeyword.Focus ();
            //			}

            if (m_txtPreviewTemplate.Visible)
            {
                m_txtPreviewTemplate.Focus();
            }
        }


        public static string s_strSetID = "";

        #region 使用模板替换文本,刘颖源,2003-5-9 20:36:28
        private void m_mthReplaceTemplateToTextBox()
        {
            if (m_intSingleSetTemplate == 1)			//单元模板
            {
                if (m_objTemplate_Detail != null && m_objTemplate_Detail.Length > m_intSelectContentIndex)
                {
                    switch (this.m_txtRichTextBox.GetType().FullName)
                    {
                        case "System.Windows.Forms.RichTextBox":
                            this.m_txtRichTextBox.Text = this.m_txtRichTextBox.Text.Replace("mb.", "");
                            this.m_txtRichTextBox.Text += m_objTemplate_Detail[m_intSelectContentIndex].m_strContent;
                            break;
                        case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                            ((com.digitalwave.Utility.Controls.ctlRichTextBox)m_txtRichTextBox).m_mthReplace("mb.", "");
                            int intLength = ((com.digitalwave.Utility.Controls.ctlRichTextBox)m_txtRichTextBox).Text.Length;
                            ((com.digitalwave.Utility.Controls.ctlRichTextBox)m_txtRichTextBox).m_mthInsertText(m_objTemplate_Detail[m_intSelectContentIndex].m_strContent, intLength);
                            break;
                        case "com.digitalwave.controls.ctlRichTextBox":
                            ((com.digitalwave.controls.ctlRichTextBox)m_txtRichTextBox).m_mthReplace("mb.", "");
                            int intLength1 = ((com.digitalwave.controls.ctlRichTextBox)m_txtRichTextBox).Text.Length;
                            ((com.digitalwave.controls.ctlRichTextBox)m_txtRichTextBox).m_mthInsertText(m_objTemplate_Detail[m_intSelectContentIndex].m_strContent, intLength1);
                            break;
                    }

                }
            }
            else
            {
                #region 旧的模板内容，直接从数据库读取
                //				clsTemplatesetContentValue[] objTemplatesetContent;
                //				string strSetID="";
                //				if(m_objTemplateSet_ID_Name !=null && m_objTemplateSet_ID_Name.Length >m_intSelectContentIndex )
                //				{
                //					strSetID=m_objTemplateSet_ID_Name[m_intSelectContentIndex].m_strSet_ID;
                //				}
                //				if(strSetID=="")return;
                //				objTemplatesetContent =m_objDomain.lngGetAllTemplatesetContent (strSetID);
                #endregion

                #region 新的模板内容，从预览框获取
                //				if(!m_txtPreviewTemplate.m_BlnIsSelected)
                //				{
                //					m_blnShowMessagebox = true;
                //					if(MDIParent.ShowQuestionMessageBox("模板内容中有一些未选择，是否继续？",MessageBoxButtons.YesNo)==DialogResult.No)
                //					{
                //						m_blnShowMessagebox = false;
                //						return;
                //					}
                //				}
                //				string strContent = m_txtPreviewTemplate.m_StrEditedText;
                //				int intIndex1 = 0;
                //				int intIndex2 = 0;
                //				for(int i=0;i<m_objTemplatesetContent.Length;i++)
                //				{
                //					intIndex1 = strContent.IndexOf(":",intIndex2);
                //					intIndex2 = strContent.IndexOf("         ",intIndex1);
                //					if(intIndex1!=-1 && intIndex2!=-1)
                //						m_objTemplatesetContent[i].m_strContent = strContent.Substring(intIndex1+3,intIndex2-intIndex1-3-1).TrimEnd();
                //				}
                #endregion

                //病程记录特殊处理
                if (m_frmForm.Name.Equals("frmGeneralDisease") && m_objTemplatesetContent != null && m_objTemplatesetContent.Length == 1)
                {
                    string strTemplateContent = m_objTemplatesetContent[0].m_strContent;
                    clsDataShareReplace.s_mthReplaceDataShareValue(MDIParent.s_ObjCurrentPatient, ref strTemplateContent, true);
                    int intIndex = m_txtRichTextBox.Text.IndexOf("鉴别诊断");
                    if (intIndex > 0)
                        m_txtRichTextBox.Text = m_txtRichTextBox.Text.Substring(0, intIndex).TrimEnd() + "\r\n";
                    m_txtRichTextBox.Text += strTemplateContent;
                }
                else
                {
                    this.m_objTemplatesetParent.m_mthLoadTemplateset(m_objTemplatesetContent, -1, m_txtRichTextBox.GetHashCode());
                }

                if (m_frmForm.Name == "frmGeneralDisease" && m_txtRichTextBox.Name == "m_txtRecordContent")
                {
                    m_txtRichTextBox.Tag = new clsTemplateDomain().m_strGetAssociateIDBySetID(m_strSetID, (int)enmAssociate.Operation);
                }
            }
            //			m_mthResetValiant();
            //
            //			this.m_txtInputKeyword.Visible =false;
            //			//变为不可见之后会自动跳到下一控件
            //			m_lstTemplate.TabIndex = (m_txtRichTextBox.TabIndex > 0) ? m_txtRichTextBox.TabIndex - 1 : 0;
            //			this.m_lstTemplate.Visible =false;
            //			this.m_txtRichTextBox.SelectionStart = this.m_txtRichTextBox.Text.Length ;
            //			this.m_txtRichTextBox.Focus ();
            //			this.m_txtPreviewTemplate.Visible = false;
        }
        #endregion

        #region 剪切，复制，粘贴
        private void m_mthCut(object sender, EventArgs e)
        {
            ((PublicFunction)m_frmForm).Cut();
        }
        private void m_mthCopy(object sender, EventArgs e)
        {
            ((PublicFunction)m_frmForm).Copy();
        }
        private void m_mthPaste(object sender, EventArgs e)
        {
            ((PublicFunction)m_frmForm).Paste();
        }
        #endregion

        #region 新的模板控制
        /// <summary>
        /// 查出所有模板分类
        /// </summary>
        private void m_mthLoadAllTemplateKeyword()
        {
            int intSelectionStartIndex = this.m_txtRichTextBox.SelectionStart;
            System.Drawing.Point pt = this.m_txtRichTextBox.GetPositionFromCharIndex(intSelectionStartIndex);
            this.m_lstTemplate.Left = m_intLeftOfferset + pt.X;
            this.m_lstTemplate.Top = m_intTopOfferset + pt.Y + 20;

            this.m_lstTemplate.Items.Clear();

            m_objTemplateSet_KeywordValue = m_objDomain.lngGetSetTemplateKeyword(m_strFormID, m_txtRichTextBox.Name, MDIParent.OperatorID, MDIParent.s_ObjDepartment.m_StrDeptID);
            if (m_objTemplateSet_KeywordValue == null || m_objTemplateSet_KeywordValue.Length == 0)
            {
                MDIParent.ShowInformationMessageBox("对不起，该项目没有模板可用，请先建立模板！");
                return;
            }

            //上一个文件夹名，在这里将分类名比如为文件夹；最前面的分类名即根目录
            string strPreFolder = "";
            for (int i = 0; i < m_objTemplateSet_KeywordValue.Length; i++)
            {
                string strKeyword = m_objTemplateSet_KeywordValue[i].m_strKeyword;
                if (strKeyword.StartsWith("常用值--"))
                    continue;

                int intIndexOfArrow = strKeyword.IndexOf(">>");
                if (intIndexOfArrow != -1)//多层目录
                {
                    if (strKeyword.Substring(0, intIndexOfArrow) != strPreFolder)
                    {
                        this.m_lstTemplate.Items.Add(strKeyword.Substring(0, intIndexOfArrow) + "...");
                        strPreFolder = strKeyword.Substring(0, intIndexOfArrow);
                    }
                }
                else if (strKeyword != strPreFolder)
                {
                    this.m_lstTemplate.Items.Add(strKeyword + "...");
                    strPreFolder = strKeyword;
                }
            }

            m_mthAddListBoxItemPYCode(this.m_lstTemplate);

            if (this.m_lstTemplate.Items.Count > 0)
            {
                this.m_lstTemplate.Visible = true;
                this.m_lstTemplate.BringToFront();
                this.m_lstTemplate.SelectedIndex = 0;
                this.m_lstTemplate.Focus();
            }

        }

        /// <summary>
        /// 当前目录
        /// </summary>
        private string m_strCurFolder = "";

        /// <summary>
        /// 查找某分类下的分类或者模板名
        /// </summary>
        private void m_mthLoadSubKeywordOrTemplateName()
        {
            m_lstTemplate.Items.Clear();

            if (m_objTemplateSet_KeywordValue != null && m_objTemplateSet_KeywordValue.Length > 0)
            {
                //上一个文件夹名，在这里将分类名比如为文件夹；最前面的分类名即根目录
                string strPreFolder = "";
                for (int i = 0; i < m_objTemplateSet_KeywordValue.Length; i++)
                {
                    string strKeyword = m_objTemplateSet_KeywordValue[i].m_strKeyword;
                    if (strKeyword == m_strCurFolder || strKeyword.IndexOf(m_strCurFolder + ">>") != -1)//属于该分类下
                    {
                        int intIndexOfArrow = strKeyword.IndexOf(">>", m_strCurFolder.Length);
                        if (intIndexOfArrow != -1)//多层目录
                        {
                            int intNextArrow = strKeyword.IndexOf(">>", intIndexOfArrow + 2);
                            string strToAdd = "";
                            if (intNextArrow != -1)//还有下一层目录
                            {
                                strToAdd = strKeyword.Substring(intIndexOfArrow + 2, intNextArrow - intIndexOfArrow - 2);
                            }
                            else//没有下一层目录
                            {
                                strToAdd = strKeyword.Substring(intIndexOfArrow + 2);
                            }
                            if (strToAdd != strPreFolder)
                            {
                                this.m_lstTemplate.Items.Add(strToAdd + "...");
                                strPreFolder = strToAdd;
                            }
                        }
                        else//上一层目录已是最后一层
                        {
                            if (strKeyword != strPreFolder)
                            {
                                m_mthLoadAllTemplateName(strKeyword);
                                strPreFolder = strKeyword;
                            }
                        }
                    }
                }

            }

            m_mthAddListBoxItemPYCode(this.m_lstTemplate);

            if (m_lstTemplate.Items.Count > 0)
            {
                m_lstTemplate.SelectedIndex = 0;
            }

            if (m_lstTemplate.Items.Count == 1 && !m_lstTemplate.Items[0].ToString().EndsWith("..."))//只有一个模板名时，直接赋值
            {
                m_mthReplaceTemplateToTextBox();
            }
        }


        /// <summary>
        /// 查找某分类下的分类或者模板名,返回的是一串字符
        /// </summary>
        private string m_strLoadSubKeywordOrTemplateName()
        {
            StringBuilder sb = new StringBuilder();
            string strCurFolder = (m_strCurFolder == "") ? m_lstTemplate.SelectedItem.ToString().Replace("...", "") : m_strCurFolder + ">>" + m_lstTemplate.SelectedItem.ToString().Replace("...", "");

            if (m_objTemplateSet_KeywordValue != null && m_objTemplateSet_KeywordValue.Length > 0)
            {
                //上一个文件夹名，在这里将分类名比如为文件夹；最前面的分类名即根目录
                string strPreFolder = "";
                for (int i = 0; i < m_objTemplateSet_KeywordValue.Length; i++)
                {
                    string strKeyword = m_objTemplateSet_KeywordValue[i].m_strKeyword;
                    if (strKeyword == strCurFolder || strKeyword.IndexOf(strCurFolder + ">>") != -1)//属于该分类下
                    {
                        int intIndexOfArrow = strKeyword.IndexOf(">>", strCurFolder.Length);
                        if (intIndexOfArrow != -1)//多层目录
                        {
                            int intNextArrow = strKeyword.IndexOf(">>", intIndexOfArrow + 2);
                            string strToAdd = "";
                            if (intNextArrow != -1)//还有下一层目录
                            {
                                strToAdd = strKeyword.Substring(intIndexOfArrow + 2, intNextArrow - intIndexOfArrow - 2);
                            }
                            else//没有下一层目录
                            {
                                strToAdd = strKeyword.Substring(intIndexOfArrow + 2);
                            }
                            if (strToAdd != strPreFolder)
                            {
                                //								this.m_lstTemplate.Items.Add (strToAdd + "...");
                                sb.Append(strToAdd);
                                sb.Append("...");
                                sb.Append("\r\n");
                                strPreFolder = strToAdd;
                            }
                        }
                        else//上一层目录已是最后一层
                        {
                            if (strKeyword != strPreFolder)
                            {
                                sb.Append(m_strLoadAllTemplateName(m_objTemplateSet_KeywordValue[i].m_strKeyword));
                                strPreFolder = strKeyword;
                            }
                        }
                    }
                }

            }

            return sb.ToString();
        }

        /// <summary>
        /// 存放模板ID的哈希表
        /// </summary>
        private Hashtable m_htSet_ID = new Hashtable();
        /// <summary>
        /// 查找某关键字下的所有模板
        /// </summary>
        /// <param name="p_strKeyword"></param>
        private void m_mthLoadAllTemplateName(string p_strKeyword)
        {
            m_htSet_ID.Clear();

            m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateKeywordName(m_strFormID, m_txtRichTextBox.Name, p_strKeyword, MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR);
            if (m_objTemplateSet_ID_Name != null && m_objTemplateSet_ID_Name.Length > 0)
            {
                for (int i = 0; i < m_objTemplateSet_ID_Name.Length; i++)
                {
                    this.m_lstTemplate.Items.Add(m_objTemplateSet_ID_Name[i].m_strSet_Name);
                    m_htSet_ID.Add(i, m_objTemplateSet_ID_Name[i].m_strSet_ID);
                }
            }
        }

        /// <summary>
        /// 查找某关键字下的所有模板,返回的是一串字符
        /// </summary>
        /// <param name="p_strKeyword"></param>
        private string m_strLoadAllTemplateName(string p_strKeyword)
        {
            StringBuilder sb = new StringBuilder();

            m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateKeywordName(m_strFormID, m_txtRichTextBox.Name, p_strKeyword, MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR);
            if (m_objTemplateSet_ID_Name != null && m_objTemplateSet_ID_Name.Length > 0)
            {
                for (int i = 0; i < m_objTemplateSet_ID_Name.Length; i++)
                {
                    //					this.m_lstTemplate.Items.Add (m_objTemplateSet_ID_Name[i]); 
                    sb.Append(m_objTemplateSet_ID_Name[i].m_strSet_Name);
                    sb.Append("\r\n");
                }
            }

            return sb.ToString();
        }
        #endregion

        #region 调用检验检查结果

        private void m_ctmLabCheckResult_Click(object sender, EventArgs e)
        {
            clsPatient objPatient = MDIParent.s_ObjCurrentPatient;
            if (clsEMRLogin.m_StrCurrentHospitalNO == "440104001")//市一调用
            {
                frmLabCheckReport frmlabcheckreport = new frmLabCheckReport();
                frmlabcheckreport.m_mthSetPatient(objPatient);
                frmlabcheckreport.m_mthInitLabCheckResult(m_txtRichTextBox);
                frmlabcheckreport.ShowDialog(m_frmForm);
                frmlabcheckreport.Close();
                frmlabcheckreport.Dispose();
            }
            else if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
            {
                if (objPatient != null)
                {
                    using (com.digitalwave.Emr.LisCheckResult.frmCheckResult frmResult = new com.digitalwave.Emr.LisCheckResult.frmCheckResult(objPatient.m_StrExtendPatientID, objPatient.m_StrName))
                    { 
                        if(frmResult.ShowDialog(m_frmForm) == DialogResult.OK)
                            m_mthInertText(frmResult.m_StrResult);
                    }
                }
            }
            else//其他
            {
                if (m_strPatientID != null && m_strPatientID != "")
                    objPatient = new clsPatient(m_strPatientID, "");

                if (objPatient == null)
                    return;
                iCare.DoctorWorkStation.frmLISResult objfrm = new iCare.DoctorWorkStation.frmLISResult();
                objfrm.SetPatientInfo = objPatient;
                if (objfrm.ShowDialog(m_frmForm) == DialogResult.OK)
                {
                    m_mthInertText(objfrm.Result);
                    objfrm.Close();
                    objfrm.Dispose();
                }
                //
                //			frmLabCheckReport frmlabcheckreport=new frmLabCheckReport();
                //			frmlabcheckreport.m_mthSetPatient(MDIParent.s_ObjCurrentPatient);
                //			frmlabcheckreport.m_mthInitLabCheckResult(m_txtRichTextBox);
                //			frmlabcheckreport.ShowDialog(m_frmForm);
            }
        }

        private void m_ctmCheckResult_Click(object sender, EventArgs e)
        {
            clsPatient objPatient = MDIParent.s_ObjCurrentPatient;
            if (clsEMRLogin.m_StrCurrentHospitalNO == "440104001")//市一调用
            {
                frmImageReport frm = new frmImageReport();
                frm.m_mthSetPatient(MDIParent.s_ObjCurrentPatient);
                //frm.ShowDialog(m_frmForm);
                frm.m_mthShowPACS();
            }
            else //其他调用（以后做成配置）
            {
                if (m_strPatientID != null && m_strPatientID != "")
                    objPatient = new clsPatient(m_strPatientID, "");
                if (objPatient == null)
                    return;

                try
                {
                    //string strRes = m_strGetPacsType();
                    //if (strRes != "" && strRes == "1")
                    //{
                    //    com.digitalwave.iCare.gui.PACS.frmPacsWSLeftNew pacs = new com.digitalwave.iCare.gui.PACS.frmPacsWSLeftNew();
                    //    pacs.m_mthShow(objPatient.m_StrInPatientID, m_ctlText);
                    //}
                    //else
                    //{
                    com.digitalwave.iCare.gui.PACS.frmPacsWSLeftNew pacs = new com.digitalwave.iCare.gui.PACS.frmPacsWSLeftNew();
                        pacs.m_mthShow(objPatient.m_StrInPatientID, m_ctlText);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //			System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom("Pacs_GUI.dll");
                //			object obj = asm.CreateInstance("com.digitalwave.iCare.gui.PACS.frmPacsWSLeft");
                //			Type type = obj.GetType();
                //			System.Reflection.MethodInfo mi = type.GetMethod("m_mthShow");
                //			mi.Invoke(obj,new object[]{MDIParent.s_ObjCurrentPatient.m_StrInPatientID,m_txtRichTextBox});
            }
        }

        private string m_strGetPacsType()
        {
            string strRes = "";
            string XMLFile = Application.StartupPath + "\\" + "LoginFile.xml";
            try
            {
                if (System.IO.File.Exists(XMLFile))
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(XMLFile);

                    XmlNode xndP = xdoc.DocumentElement.SelectNodes(@"//" + "PACS")[0];
                    XmlNode xndC = xndP.SelectSingleNode(@"//UseSimpleForm[@key='AnyOne']");

                    if (xndP != null)
                    {
                        strRes = xndC.Attributes["value"].Value.ToString().Trim();
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
            return strRes;
        }

        /// <summary>
        /// 控件插入值
        /// </summary>
        /// <param name="p_ctlInput"></param>
        /// <param name="p_strValue"></param>
        public void m_mthInsertControlValue(Control p_ctlInput, string p_strValue)
        {
            switch (p_ctlInput.GetType().FullName)
            {
                case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                    com.digitalwave.Utility.Controls.ctlRichTextBox txt = (com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlInput;
                    txt.m_mthInsertText(p_strValue, txt.SelectionStart);
                    break;
                case "com.digitalwave.controls.ctlRichTextBox":
                    com.digitalwave.controls.ctlRichTextBox txt1 = (com.digitalwave.controls.ctlRichTextBox)p_ctlInput;
                    txt1.m_mthInsertText(p_strValue, txt1.SelectionStart);
                    break;
                case "System.Windows.Forms.RichTextBox":
                case "System.Windows.Forms.TextBox":
                    System.Windows.Forms.TextBoxBase txt2 = (System.Windows.Forms.TextBoxBase)p_ctlInput;
                    int intPreStart = txt2.SelectionStart;
                    txt2.Text = txt2.Text.Insert(txt2.SelectionStart, p_strValue);
                    txt2.SelectionStart = intPreStart + p_strValue.Length;
                    break;
            }
        }

        #endregion

        /// <summary>
        /// 上下标处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuperSubScript_Click(object sender, EventArgs e)
        {
            string strText = "";
            if (sender is MenuItem)
            {
                strText = ((MenuItem)sender).Text;
            }
            else if (sender is MenuCommand)
            {
                strText = ((MenuCommand)sender).Text;
            }
            else if (sender is ToolStripMenuItem)
            {
                strText = ((ToolStripMenuItem)sender).Text;
            }

            //com.digitalwave.Utility.Controls.ctlRichTextBox txtRTB = m_txtRichTextBox as com.digitalwave.Utility.Controls.ctlRichTextBox;
            //com.digitalwave.controls.ctlRichTextBox textBase = m_txtRichTextBox as com.digitalwave.controls.ctlRichTextBox;
            com.digitalwave.Utility.Controls.ctlRichTextBox txtRTB = m_ctlText as com.digitalwave.Utility.Controls.ctlRichTextBox;
            com.digitalwave.controls.ctlRichTextBox textBase = m_ctlText as com.digitalwave.controls.ctlRichTextBox;
            
            if (txtRTB != null)
            {
                if (strText == "上标")
                {
                    txtRTB.m_mthSetSelectionScript(0);
                }
                else if (strText == "下标")
                {
                    txtRTB.m_mthSetSelectionScript(1);
                }
                else
                {
                    txtRTB.m_mthSetSelectionScript(2);
                }
            }
            else if (textBase != null)
            {
                if (strText == "上标")
                {
                    textBase.m_mthSetSelectionScript(0);
                }
                else if (strText == "下标")
                {
                    textBase.m_mthSetSelectionScript(1);
                }
                else
                {
                    textBase.m_mthUndoSuperSubScript();
                }
            }
        }

        /// <summary>
        /// 调用特殊符号
        /// </summary>
        private void m_mthInvokeSpecialSymbol(object sender, EventArgs e)
        {
            string strContent = "";
            try
            {
                using (iCare.AssitantTool.frmSpecialSymbolList frmSpecialSymbolList = new AssitantTool.frmSpecialSymbolList())
                {
                    frmSpecialSymbolList.ShowDialog();
                    strContent = frmSpecialSymbolList.m_StrOutputSpectialSymbol;
                    if (strContent == null)
                        strContent = "";
                }
            }
            catch
            {
                strContent = "";
            }

            m_mthInertText(strContent);
        }

        /// <summary>
        /// 在当前文本框插入值
        /// </summary>
        /// <param name="p_strText"></param>
        private void m_mthInertText(string p_strText)
        {
            //switch (m_txtRichTextBox.GetType().FullName) 
            //{
            //    case "com.digitalwave.Utility.Controls.ctlRichTextBox":
            //        ((com.digitalwave.Utility.Controls.ctlRichTextBox)m_txtRichTextBox).m_mthInsertText(p_strText, m_txtRichTextBox.SelectionStart);
            //        break;
            //    case "com.digitalwave.controls.ctlRichTextBox":
            //        ((com.digitalwave.controls.ctlRichTextBox)m_txtRichTextBox).m_mthInsertText(p_strText, m_txtRichTextBox.SelectionStart);
            //        break;
            //    default:
            //        int intPreStart = m_txtRichTextBox.SelectionStart;
            //        m_txtRichTextBox.Text = m_txtRichTextBox.Text.Insert(m_txtRichTextBox.SelectionStart, p_strText);
            //        m_txtRichTextBox.SelectionStart = intPreStart + p_strText.Length;
            //        break;
            //}
            switch (m_ctlText.GetType().FullName)
            {
                case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                    com.digitalwave.Utility.Controls.ctlRichTextBox rtb1 = m_ctlText as com.digitalwave.Utility.Controls.ctlRichTextBox;
                    rtb1.m_mthInsertText(p_strText, rtb1.SelectionStart);
                    break;
                case "com.digitalwave.controls.ctlRichTextBox":
                    com.digitalwave.controls.ctlRichTextBox rtb2 = m_ctlText as com.digitalwave.controls.ctlRichTextBox;
                    rtb2.m_mthInsertText(p_strText, rtb2.SelectionStart);
                    break;
                case "System.Windows.Forms.TextBox":
                    System.Windows.Forms.TextBox text1 = m_ctlText as TextBox;
                    int intPreStart1 = text1.SelectionStart;
                    text1.Text = text1.Text.Insert(text1.SelectionStart, p_strText);
                    text1.SelectionStart = intPreStart1 + p_strText.Length;
                    break;
                case "com.digitalwave.Utility.Controls.ctlComboBox":
                    com.digitalwave.Utility.Controls.ctlComboBox text2 = m_ctlText as com.digitalwave.Utility.Controls.ctlComboBox;
                    int intPreStart2 = text2.SelectionStart;
                    text2.Text = text2.Text.Insert(text2.SelectionStart, p_strText);
                    text2.SelectionStart = intPreStart2 + p_strText.Length;
                    break;
                case "System.Windows.Forms.ComboBox":
                    System.Windows.Forms.ComboBox text3 = m_ctlText as System.Windows.Forms.ComboBox;
                    int intPreStart3 = text3.SelectionStart;
                    text3.Text = text3.Text.Insert(text3.SelectionStart, p_strText);
                    text3.SelectionStart = intPreStart3 + p_strText.Length;
                    break;
            }
        }

        private void m_mthClearText()
        {
            switch (m_txtRichTextBox.GetType().FullName)
            {
                case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                    ((com.digitalwave.Utility.Controls.ctlRichTextBox)m_txtRichTextBox).m_mthResetContextInfo();
                    break;
                case "com.digitalwave.controls.ctlRichTextBox":
                    ((com.digitalwave.controls.ctlRichTextBox)m_txtRichTextBox).m_mthClearText();
                    break;
                default:
                    m_txtRichTextBox.Text = "";
                    break;
            }
        }

        #region 新病历的添加菜单方法  HB 2004-08-10

        /// <summary>
        /// 添加专科病历菜单
        /// </summary>
        /// <param name="p_mniPopuoItem"></param>
        private void m_mthSetShareItem(MenuItem p_mniPopuoItem)
        {
            //			clsInpatMedRec_Type[] objTypeArr;
            ////			long lngRes = new clsInpatMedRecDomain().m_lngGetAllFormID(out objTypeArr);
            //			objTypeArr=MDIParent.s_ObjInpatMedRec_DataShare.m_objTypeArr;
            //			if(objTypeArr == null)
            //				return;
            //			m_objType_DeptArr=objTypeArr;
            //			p_mniPopuoItem.MenuItems.Add("-");
            //			for(int i =0; i <objTypeArr.Length; i++)
            //			{
            //				MenuItem mniChild = new MenuItem(objTypeArr[i].m_strTypeName);
            //				m_mthSetShareChildItem(mniChild);
            //				p_mniPopuoItem.MenuItems.Add(mniChild);
            //			}
        }

        //		/// <summary>
        //		/// 添加专科病历菜单
        //		/// </summary>
        //		/// <param name="p_mniPopuoItem"></param>
        //		private void m_mthSetShareItem2(MenuCommand p_mniPopuoItem)
        //		{
        //			clsInpatMedRec_Type[] objTypeArr;
        ////			//long lngRes = new clsInpatMedRecDomain().m_lngGetAllFormID(out objTypeArr);
        ////			objTypeArr=MDIParent.s_ObjInpatMedRec_DataShare.m_objTypeArr;
        ////			if(objTypeArr == null)
        ////				return;
        ////			m_objType_DeptArr=objTypeArr;
        ////			p_mniPopuoItem.MenuCommands.Add(new MenuCommand("-"));
        ////			for(int i =0; i <objTypeArr.Length; i++)
        ////			{
        ////				MenuCommand mniChild = new MenuCommand(objTypeArr[i].m_strTypeName);
        ////				m_mthSetShareChildItem2(mniChild);
        ////				p_mniPopuoItem.MenuCommands.Add(mniChild);
        ////			}
        //		}

        //		/// <summary>
        //		/// 添加专科病历子菜单
        //		/// </summary>
        //		/// <param name="p_mniCaseItem"></param>
        //		private void m_mthSetShareChildItem(MenuItem p_mniCaseItem)
        //		{
        //			clsInpatMedRecDomain objInpatMedRecDomain = new clsInpatMedRecDomain();
        //			clsInpatMedRec_Type_Item[] objType_ItemArr;
        //			//long lngRes = objInpatMedRecDomain.m_lngGetType_ItemRecord(m_strGetTypeID(p_mniCaseItem.Text),out objType_ItemArr);
        //			objType_ItemArr=MDIParent.s_ObjInpatMedRec_DataShare.m_objGetInpatMedRec_Type_Item(m_strGetTypeID(p_mniCaseItem.Text));
        ////			if(lngRes <= 0)
        ////				return;
        //			if ((objType_ItemArr!=null) && (objType_ItemArr.Length > 0))
        //			{
        //				for(int i =0; i< objType_ItemArr.Length; i++)
        //				{
        //					if(objType_ItemArr[i].m_strItemType =="ctlRichTextBox" || objType_ItemArr[i].m_strItemType =="RichTextBox" || objType_ItemArr[i].m_strItemType =="ctlComboBox")
        //					{
        //						m_mniAddMenuItem(objType_ItemArr[i],p_mniCaseItem,objType_ItemArr[i].m_strItemName);
        //					}
        //				}
        //			}
        //			
        //		}
        //
        //		/// <summary>
        //		/// 添加专科病历子菜单
        //		/// </summary>
        //		/// <param name="p_mniCaseItem"></param>
        //		private void m_mthSetShareChildItem2(MenuCommand p_mniCaseItem)
        //		{
        //			clsInpatMedRecDomain objInpatMedRecDomain = new clsInpatMedRecDomain();
        //			clsInpatMedRec_Type_Item[] objType_ItemArr;
        //			//long lngRes = objInpatMedRecDomain.m_lngGetType_ItemRecord(m_strGetTypeID(p_mniCaseItem.Text),out objType_ItemArr);
        //			objType_ItemArr=MDIParent.s_ObjInpatMedRec_DataShare.m_objGetInpatMedRec_Type_Item(m_strGetTypeID(p_mniCaseItem.Text));
        ////			if(lngRes <= 0)
        ////				return;
        //			if ( ( objType_ItemArr != null ) && (objType_ItemArr.Length > 0) )
        //			{
        //				for(int i =0; i< objType_ItemArr.Length; i++)
        //				{
        //					if(objType_ItemArr[i].m_strItemType =="ctlRichTextBox" || objType_ItemArr[i].m_strItemType =="RichTextBox" || objType_ItemArr[i].m_strItemType =="ctlComboBox")
        //					{
        //						m_mniAddMenuItem2(objType_ItemArr[i],p_mniCaseItem as MenuCommand,objType_ItemArr[i].m_strItemName);
        //					}
        //				}
        //			}
        //			
        //		}

        //		/// <summary>
        //		/// 根据菜单名称返回窗体ID
        //		/// </summary>
        //		/// <param name="p_strFormName"></param>
        //		/// <returns></returns>
        //		private string m_strGetTypeID(string p_strFormName)
        //		{
        //			if(m_objType_DeptArr == null || m_objType_DeptArr.Length < 1 || p_strFormName == null)
        //				return null;
        //			for(int i=0;i < m_objType_DeptArr.Length; i++)
        //			{
        //				if(m_objType_DeptArr[i].m_strTypeName == p_strFormName)
        //				{
        //					return m_objType_DeptArr[i].m_strTypeID;
        //				}
        //			}
        //			return null;
        //		}
        /// <summary>
        //		/// 根据窗体ID返回窗体名称
        //		/// </summary>
        //		/// <param name="p_strTypeID"></param>
        //		/// <returns></returns>
        //		private string m_strGetTypeName(string p_strTypeID)
        //		{
        //			if(m_objType_DeptArr == null || m_objType_DeptArr.Length < 1 || p_strTypeID == null)
        //				return null;
        //			for(int i=0;i < m_objType_DeptArr.Length; i++)
        //			{
        //				if(m_objType_DeptArr[i].m_strTypeID == p_strTypeID)
        //				{
        //					return m_objType_DeptArr[i].m_strTypeName;
        //				}
        //			}
        //			return null;
        //		}

        /// <summary>
        /// 递归添加菜单项
        /// </summary>
        /// <param name="p_strItemText"></param>
        /// <param name="p_mniItem"></param>
        ////		private void m_mniAddMenuItem(clsInpatMedRec_Type_Item p_objContent,MenuItem p_mniItem,string p_strItemName)
        //		{
        //			MenuItem mniItem = null;
        //			int intIndex = p_strItemName.IndexOf(">>");
        //			if(intIndex > 0)
        //			{
        //				//有子项
        //				string strFirstItem = p_strItemName.Substring(0,intIndex);
        //				p_strItemName = p_strItemName.Substring(intIndex+2);
        //				if(p_mniItem.MenuItems.Count > 0)
        //				{
        //					foreach(MenuItem mni in p_mniItem.MenuItems)
        //					{
        //						if(mni.Text == strFirstItem)
        //						{
        //							mniItem = mni;
        //							break;
        //						}
        //					}
        //					if(mniItem != null)
        //					{
        //						//子菜单已存在
        //						m_mniAddMenuItem(p_objContent,mniItem,p_strItemName);
        //					}
        //					else
        //					{
        //						mniItem = new MenuItem(strFirstItem);
        //						p_mniItem.MenuItems.Add(mniItem);
        //						m_mniAddMenuItem(p_objContent,mniItem,p_strItemName);
        //					}
        //					return;
        //				}
        //				else
        //				{
        //					//菜单子项为空
        //					mniItem = new MenuItem(strFirstItem);
        //					p_mniItem.MenuItems.Add(mniItem);
        //					m_mniAddMenuItem(p_objContent,mniItem,p_strItemName);
        //				}
        //				return;
        //			}
        //			else
        //			{
        //				mniItem = new MenuItem(p_strItemName);
        //				m_hasMenuItems.Add(mniItem,p_objContent);
        //			}
        //			p_mniItem.MenuItems.Add(mniItem);
        //		}

        //		/// <summary>
        //		/// 递归添加菜单项
        //		/// </summary>
        //		/// <param name="p_strItemText"></param>
        //		/// <param name="p_mniItem"></param>
        //		private void m_mniAddMenuItem2(clsInpatMedRec_Type_Item p_objContent,MenuCommand p_mniItem,string p_strItemName)
        //		{
        //			MenuCommand mniItem = null;
        //			int intIndex = p_strItemName.IndexOf(">>");
        //			if(intIndex > 0)
        //			{
        //				//有子项
        //				string strFirstItem = p_strItemName.Substring(0,intIndex);
        //				p_strItemName = p_strItemName.Substring(intIndex+2);
        //				if(p_mniItem.MenuCommands.Count > 0)
        //				{
        //					foreach(MenuCommand mni in p_mniItem.MenuCommands)
        //					{
        //						if(mni.Text == strFirstItem)
        //						{
        //							mniItem = mni;
        //							break;
        //						}
        //					}
        //					if(mniItem != null)
        //					{
        //						//子菜单已存在
        //						m_mniAddMenuItem2(p_objContent,mniItem,p_strItemName);
        //					}
        //					else
        //					{
        //						mniItem = new MenuCommand(strFirstItem);
        //						p_mniItem.MenuCommands.Add(mniItem);
        //						m_mniAddMenuItem2(p_objContent,mniItem,p_strItemName);
        //					}
        //					return;
        //				}
        //				else
        //				{
        //					//菜单子项为空
        //					mniItem = new MenuCommand(strFirstItem);
        //					p_mniItem.MenuCommands.Add(mniItem);
        //					m_mniAddMenuItem2(p_objContent,mniItem,p_strItemName);
        //				}
        //				return;
        //			}
        //			else
        //			{
        //				mniItem = new MenuCommand(p_strItemName);
        //				m_hasMenuItems.Add(mniItem,p_objContent);
        //			}
        //			p_mniItem.MenuCommands.Add(mniItem);
        //		}
        #endregion

        #region 树型结构

        //保存节点信息
        class clsNodeInfo
        {
            public static string c_strNodeType_Folder = "F";
            public static string c_strNodeType_Text = "T";

            public static int c_intOpenFolder = 0;
            public static int c_intCloseFolder = 1;
            public static int c_intFile = 2;

            public string m_strNodeType = "";
            public bool m_blnIsFolder
            {
                get
                {
                    return (this.m_strNodeType == c_strNodeType_Folder);
                }
            }

            public string m_strText = "";
            public string m_strXml = "<r></r>";
            public string m_strSetID = "";
            public string m_strSetName = "";
        }


        //加载根节点, 类似m_mthLoadAllTemplateKeyword
        public void m_mthLoadTemplateRootNode(TreeView tvwTemp)
        {
            //Load Node Data

            tvwTemp.Nodes.Clear();

            //m_objTemplateSet_KeywordValue = m_objDomain.lngGetSetTemplateKeyword(m_strFormID, m_txtRichTextBox.Name, MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR);//			
            m_objTemplateSet_KeywordValue = m_objDomain.lngGetSetTemplateKeyword(m_strFormID, m_ctlText.Name, MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR);
            if (m_objTemplateSet_KeywordValue == null || m_objTemplateSet_KeywordValue.Length == 0)
            {
                //				MDIParent.ShowInformationMessageBox("对不起，该项目没有模板可用，请先建立模板！");
                //				return;
            }

            if (m_objTemplateSet_KeywordValue != null && m_objTemplateSet_KeywordValue.Length > 0)
            {
                //filter the same Name
                string strPreFolder = "";
                for (int i = 0; i < m_objTemplateSet_KeywordValue.Length; i++)
                {
                    string strKeyword = m_objTemplateSet_KeywordValue[i].m_strKeyword;

                    if (strKeyword.StartsWith("常用值--")) continue;										//常用值

                    int intIndexOfArrow = strKeyword.IndexOf(">>");										//多级目录
                    if (intIndexOfArrow > 0) strKeyword = strKeyword.Substring(0, intIndexOfArrow);

                    if (strKeyword == strPreFolder) continue;												//与前一目录相同


                    clsNodeInfo objNode = new clsNodeInfo();
                    objNode.m_strNodeType = clsNodeInfo.c_strNodeType_Folder;

                    TreeNode tnNode = tvwTemp.Nodes.Add(strKeyword);
                    tnNode.ImageIndex = clsNodeInfo.c_intCloseFolder;
                    tnNode.SelectedImageIndex = clsNodeInfo.c_intOpenFolder;
                    tnNode.Tag = objNode;
                    tnNode.Nodes.Add("null");

                    strPreFolder = strKeyword;

                }
            }

            //PY Search
            //m_mthAddListBoxItemPYCode(this.m_lstTemplate);
            //			for(int i=0;i<tvwTemp.Nodes.Count;i++)
            //			{
            //				m_mthExpandTemplateNode(tvwTemp.Nodes[i]);
            //			}
        }


        private string m_strGetNodePath(TreeNode tnNode)
        {
            if (tnNode == null) return "";
            string strPath = tnNode.Text;

            TreeNode tnParent = tnNode.Parent;
            while (tnParent != null)
            {
                strPath = tnParent.Text + ">>" + strPath;
                tnParent = tnParent.Parent;
            }
            return strPath;
        }


        //展开节点, 类似m_mthPreviewTemplate
        public void m_mthExpandTemplateNode(TreeNode tnNode)
        {
            if (tnNode == null) return;
            if (tnNode.Tag == null) return;
            if (m_arlExpandedNodes.Contains(tnNode))//Already load , Don't load again.
                return;
            else
                m_arlExpandedNodes.Add(tnNode);

            tnNode.Nodes.Clear();//清除假节点

            clsNodeInfo objNode = (clsNodeInfo)(tnNode.Tag);

            string strCurFolder = m_strGetNodePath(tnNode);

            //Load sub floder
            if (m_objTemplateSet_KeywordValue != null && m_objTemplateSet_KeywordValue.Length > 0)
            {
                string strPreFolder = "";
                for (int i = 0; i < m_objTemplateSet_KeywordValue.Length; i++)
                {
                    string strKeyword = m_objTemplateSet_KeywordValue[i].m_strKeyword;

                    if (!strKeyword.StartsWith(strCurFolder + ">>")) continue;

                    //					if(strKeyword == strCurFolder) continue;

                    string strLeave = strKeyword.Substring(strCurFolder.Length + 2);

                    int intIndexOfArrow = strLeave.IndexOf(">>");
                    if (intIndexOfArrow > 0) strLeave = strLeave.Substring(0, intIndexOfArrow);

                    if (strLeave == strPreFolder) continue;

                    clsNodeInfo objNewInfo = new clsNodeInfo();
                    objNewInfo.m_strNodeType = clsNodeInfo.c_strNodeType_Folder;

                    TreeNode tnNewNode = tnNode.Nodes.Add(strLeave);
                    tnNewNode.ImageIndex = clsNodeInfo.c_intCloseFolder;
                    tnNewNode.SelectedImageIndex = clsNodeInfo.c_intOpenFolder;
                    tnNewNode.Tag = objNewInfo;
                    tnNewNode.Nodes.Add("null");//节点展开时只需查找当前节点下的目录，提高速度

                    strPreFolder = strLeave;
                }
            }

            //查找当前关键字下的模板
            //m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateKeywordName(m_strFormID, m_txtRichTextBox.Name, strCurFolder, MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR);
            m_objTemplateSet_ID_Name = m_objDomain.lngGetSetTemplateKeywordName(m_strFormID, m_ctlText.Name, strCurFolder, MDIParent.OperatorID, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR);
            if (m_objTemplateSet_ID_Name != null && m_objTemplateSet_ID_Name.Length > 0)
            {
                for (int i = 0; i < m_objTemplateSet_ID_Name.Length; i++)
                {
                    clsNodeInfo objNewInfo = new clsNodeInfo();
                    objNewInfo.m_strNodeType = clsNodeInfo.c_strNodeType_Text;
                    objNewInfo.m_strSetID = m_objTemplateSet_ID_Name[i].m_strSet_ID;
                    objNewInfo.m_strSetName = m_objTemplateSet_ID_Name[i].m_strSet_Name;

                    TreeNode tnNewNode = tnNode.Nodes.Add(m_objTemplateSet_ID_Name[i].m_strSet_Name);
                    tnNewNode.ImageIndex = clsNodeInfo.c_intFile;
                    tnNewNode.SelectedImageIndex = clsNodeInfo.c_intFile;
                    tnNewNode.Tag = objNewInfo;
                }
            }

        }


        //获取节点内容
        public void m_mthGetTemplateNodeContent(TreeNode tnNode, out string[] strTitle, out string[] strContent, out string[] strXml)
        {
            strTitle = null;
            strContent = null;
            strXml = null;

            if (tnNode == null) return;
            if (tnNode.Tag == null) return;
            clsNodeInfo objNode = (clsNodeInfo)(tnNode.Tag);
            if (objNode.m_blnIsFolder) return;

            #region 当前窗体所有控件
            //			clsGUI_Info_DetailValue[] objControls = m_objDomain.lngGetAllControls(m_strFormID);
            //			Hashtable htControls = new Hashtable();
            //			for(int i=0;i<objControls.Length;i++)
            //				htControls.Add(objControls[i].m_strControl_ID,objControls[i].m_strControl_Desc);
            #endregion

            m_objTemplatesetContent = m_objDomain.lngGetAllTemplatesetContent(objNode.m_strSetID);
            if (m_objTemplatesetContent != null || m_objTemplatesetContent.Length > 0)
            {
                strTitle = new string[m_objTemplatesetContent.Length];
                strContent = new string[m_objTemplatesetContent.Length];
                strXml = new string[m_objTemplatesetContent.Length];
                for (int i = 0; i < m_objTemplatesetContent.Length; i++)
                {
                    strTitle[i] = m_objTemplatesetContent[i].m_strControl_Desc;

                    strContent[i] = m_objTemplatesetContent[i].m_strContent;

                    //					strXml[i] = m_objTemplatesetContent[i].m_strContentXml;
                    strXml[i] = "<root/>";
                }
            }


        }


        //使用当前模板内容
        public void m_mthSelectedTemplateNode(TreeNode tnNode)
        {
            if (m_frmForm is frmHRPBaseForm)
            {
                if (((frmHRPBaseForm)m_frmForm).m_BlnIsMark)
                {
                    MessageBox.Show(m_frmForm, "当前病案已超过修改时限，不能复用模板！", "警告");
                    return;
                }
            }
            if (tnNode == null) return;
            if (tnNode.Tag == null) return;
            clsNodeInfo objNode = (clsNodeInfo)(tnNode.Tag);
            if (objNode.m_blnIsFolder) return;

            m_mthReplaceTemplateToTextBox();

        }


        //计算控件位置
        private Point m_ptGetControlPosition(Control ctlCur)
        {
            if (ctlCur == null) return new Point(0, 0);

            Point ptCur = ctlCur.Location;

            Control ctlParent = ctlCur.Parent;
            while (ctlParent != null)
            {
                ptCur.Offset(ctlParent.Location.X, ctlParent.Location.Y);
                if (ctlParent is Form) break;

                ctlParent = ctlParent.Parent;
            }
            return ptCur;
        }

        //获取最佳位置
        public Point m_ptGetCursorPosition()
        {
            //Get the position
            int intSelectionStartIndex = this.m_txtRichTextBox.SelectionStart;
            System.Drawing.Point pt = this.m_txtRichTextBox.GetPositionFromCharIndex(intSelectionStartIndex);

            //			Point ptLocation=new Point(m_intLeftOfferset + pt.X, m_intTopOfferset + pt.Y);
            //			Point ptLocation=new Point(32 + pt.X, 8 + pt.Y + 20);
            //
            //			Point ptPosition=m_ptGetControlPosition(this.m_txtRichTextBox);
            //
            //			ptPosition.Offset(ptLocation.X,ptLocation.Y);

            return pt;
        }

        #endregion

        #region Public
        /// <summary>
        /// 设置当前要调用模板的RTB
        /// </summary>
        /// <param name="p_rtbInput"></param>
        public void m_mthSetCurRichTextBox(RichTextBox p_rtbInput)
        {
            this.m_txtRichTextBox = p_rtbInput;
            //如果是预览控件，不重新计算位置
            if (m_txtRichTextBox != m_txtPreviewTemplate)
            {
                //				m_mthResetValiant();
                m_mthCalculatePosition(m_frmForm, m_txtRichTextBox);
                m_strControlID = m_hasContolIDs[m_txtRichTextBox].ToString();
            }
        }

        /// <summary>
        /// 调用模板
        /// </summary>
        public void m_mthInvokeTemplate()
        {
            m_intPreSelectedIndex = -1;
            m_strCurFolder = "";
            //			m_mthLoadAllTemplateKeyword();
            new frmTemplateSelect(this).Show();
        }
        #endregion

        private void m_mniDoubleStrike_Click(object sender, EventArgs e)
        {
            //if (this.m_txtRichTextBox is com.digitalwave.Utility.Controls.ctlRichTextBox)
            //    ((com.digitalwave.Utility.Controls.ctlRichTextBox)this.m_txtRichTextBox).m_mthSelectionDoubleStrikeThough(true);
            //else if (this.m_txtRichTextBox is com.digitalwave.controls.ctlRichTextBox)
            //    ((com.digitalwave.controls.ctlRichTextBox)this.m_txtRichTextBox).m_mthSelectionDoubleStrikeThough(true);
            if (this.m_ctlText is com.digitalwave.Utility.Controls.ctlRichTextBox)
                ((com.digitalwave.Utility.Controls.ctlRichTextBox)this.m_ctlText).m_mthSelectionDoubleStrikeThough(true);
            else if (this.m_ctlText is com.digitalwave.controls.ctlRichTextBox)
                ((com.digitalwave.controls.ctlRichTextBox)this.m_ctlText).m_mthSelectionDoubleStrikeThough(true);
        }

        private void m_txtTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    m_mthSetPatientID(((Control)sender).FindForm());
                    m_mthLoadCommonUseTemplate(m_mncCommonUse);
                    m_mncCommonUse.Enabled = m_mncCommonUse.DropDownItems.Count > 0 ? true : false;
                    //m_ppmMenu.TrackPopup(m_txtRichTextBox.PointToScreen(new Point(e.X, e.Y)));
                    //m_ppmMenu.TrackPopup(m_ctlText.PointToScreen(new Point(e.X, e.Y)));
                    m_ppmMenu.Show(m_ctlText.PointToScreen(new Point(e.X, e.Y)));
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
        }
        private void m_mthSetPatientID(Form p_frmParent)
        {
            m_strPatientID = "";
            if (p_frmParent is frmHRPBaseForm)
            {
                m_strPatientID = ((frmHRPBaseForm)p_frmParent).m_StrPatientID;
            }
            else if (p_frmParent is frmApplyReportBase)
            {
                m_strPatientID = ((frmApplyReportBase)p_frmParent).m_StrPatientID;
            }
        }

        #region 图文工作站(旧)
        /// <summary>
        /// 图文工作站菜单添加
        /// </summary>
        /// <param name="p_mniDataShare"></param>
        //private void m_mthSetApplyReportSubMenu(MenuCommand p_mniDataShare)
        //{
        //    //m_mncApplyReport.MenuCommands
        //    string SQL = "";
        //    string strOldFormName = "";
        //    ArrayList altTemp = new ArrayList();

        //    System.Data.DataTable dtRecords = null;
        //    MenuCommand McdMenuCmd = null;

        //    SQL = "select AR_CONTROL_DESC.FORMCLSNAME,FORMDESC,CONTROLID,CONTROLDESC from AR_FORM,AR_CONTROL_DESC where AR_FORM.FORMCLSNAME=AR_CONTROL_DESC.FORMCLSNAME and FORMSTATUS=0 order by AR_CONTROL_DESC.FORMCLSNAME,CONTROLDESC";

        //    new com.digitalwave.ApplyReportServer.clsApplyReportServer().m_lngGetData(SQL, ref dtRecords);

        //    if (dtRecords != null)
        //    {
        //        for (int i = 0; i < dtRecords.Rows.Count; i++)
        //        {
        //            if (strOldFormName != dtRecords.Rows[i]["FORMCLSNAME"].ToString())
        //            {
        //                McdMenuCmd = null;
        //                McdMenuCmd = new MenuCommand(dtRecords.Rows[i]["FORMDESC"].ToString());
        //                strOldFormName = dtRecords.Rows[i]["FORMCLSNAME"].ToString();

        //                p_mniDataShare.MenuCommands.Add(McdMenuCmd);

        //                altTemp.Clear();
        //            }

        //            int intIndex = -1;
        //            string strTemp = dtRecords.Rows[i]["CONTROLDESC"].ToString();
        //            strTemp = strTemp.Replace(">>", ">");
        //            string[] strSplitArry = strTemp.Split(">".ToCharArray());

        //            for (int j = 0; j < strSplitArry.Length; j++)
        //            {
        //                bool blnIsExists = false;//默认当前要添加的节点不存在
        //                for (int k = 0; k < altTemp.Count; k++)
        //                {
        //                    MenuCommand McdTemp = (MenuCommand)altTemp[k];
        //                    if (McdTemp.Text == strSplitArry[j] && j != strSplitArry.Length - 1)
        //                    {
        //                        blnIsExists = true;
        //                        break;
        //                    }
        //                    if (j != 0)
        //                    {
        //                        if (McdTemp.Text == strSplitArry[j - 1] && McdTemp.Tag == null)
        //                        {
        //                            intIndex = k;
        //                        }
        //                    }

        //                }

        //                MenuCommand McdAdd = new MenuCommand(strSplitArry[j]);
        //                if (j == strSplitArry.Length - 1)
        //                {
        //                    McdAdd.Tag = strOldFormName + "^" + dtRecords.Rows[i]["CONTROLID"].ToString();
        //                    McdAdd.Click += new EventHandler(ApplyReprotItems_Click);
        //                }

        //                if (!blnIsExists)
        //                {
        //                    if (intIndex == -1)
        //                        McdMenuCmd.MenuCommands.Add(McdAdd);
        //                    else
        //                        ((MenuCommand)altTemp[intIndex]).MenuCommands.Add(McdAdd);
        //                    altTemp.Add(McdAdd);
        //                }

        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 图文工作站菜单事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ApplyReprotItems_Click(object sender, EventArgs e)
        //{
        //    string SQL = "";
        //    string str = ((MenuCommand)sender).Tag.ToString();
        //    string[] strSplitArry = str.Split("^".ToCharArray());
        //    string strContent = "";

        //    System.Data.DataTable dtRecords = null;

        //    string strPatientID = m_strPatientID;
        //    if (strPatientID.Trim() == string.Empty && MDIParent.s_ObjCurrentPatient != null)
        //        strPatientID = MDIParent.s_ObjCurrentPatient.m_StrPatientID;
        //    SQL = "select CTL_CONTENT from AR_CONTENT where RECORDID=(select RECORDID from AR_APPLY_REPORT where PATIENTID='" + strPatientID + "' and OPENDATE=(select max(OPENDATE) from AR_APPLY_REPORT where DELSTATUS=0 and PATIENTID='" + strPatientID + "' and FORMCLSNAME='" + strSplitArry[0].Replace("'", "''") + "') and FORMCLSNAME='" + strSplitArry[0].Replace("'", "''") + "') and CONTROLID='" + strSplitArry[1].Replace("'", "''") + "'";
        //    new com.digitalwave.ApplyReportServer.clsApplyReportServer().m_lngGetData(SQL, ref dtRecords);

        //    if (dtRecords != null && dtRecords.Rows.Count > 0)
        //    {
        //        strContent = dtRecords.Rows[0][0].ToString();
        //    }

        //    m_mthInertText(strContent);
        //}
        #endregion 图文工作站

        #region 图文工作站菜单添加(新)
        /// <summary>
        /// 图文工作站菜单添加
        /// </summary>
        /// <param name="p_mniDataShare"></param>
        public void m_mthSetApplyReportSubMenu(ToolStripMenuItem p_mniDataShare)
        {
            string SQL = "";
            string strOldFormName = "";
            List<ToolStripMenuItem> altTemp = new List<ToolStripMenuItem>();

            System.Data.DataTable dtRecords = null;
            ToolStripMenuItem McdMenuCmd = null;

            SQL = "select AR_CONTROL_DESC.FORMCLSNAME,FORMDESC,CONTROLID,CONTROLDESC from AR_FORM,AR_CONTROL_DESC where AR_FORM.FORMCLSNAME=AR_CONTROL_DESC.FORMCLSNAME and FORMSTATUS=0 order by AR_CONTROL_DESC.FORMCLSNAME,CONTROLDESC";

            com.digitalwave.ApplyReportServer.clsApplyReportServer objServ =
                    (com.digitalwave.ApplyReportServer.clsApplyReportServer)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.ApplyReportServer.clsApplyReportServer));

            objServ.m_lngGetData(SQL, ref dtRecords);

            if (dtRecords != null)
            {
                for (int i = 0; i < dtRecords.Rows.Count; i++)
                {
                    if (strOldFormName != dtRecords.Rows[i]["FORMCLSNAME"].ToString())
                    {
                        McdMenuCmd = null;
                        McdMenuCmd = new ToolStripMenuItem(dtRecords.Rows[i]["FORMDESC"].ToString());
                        strOldFormName = dtRecords.Rows[i]["FORMCLSNAME"].ToString();

                        p_mniDataShare.DropDownItems.Add(McdMenuCmd);

                        altTemp.Clear();
                    }

                    int intIndex = -1;
                    string strTemp = dtRecords.Rows[i]["CONTROLDESC"].ToString();
                    strTemp = strTemp.Replace(">>", ">");
                    string[] strSplitArry = strTemp.Split(">".ToCharArray());

                    for (int j = 0; j < strSplitArry.Length; j++)
                    {
                        bool blnIsExists = false;//默认当前要添加的节点不存在
                        for (int k = 0; k < altTemp.Count; k++)
                        {
                            ToolStripMenuItem McdTemp = altTemp[k];
                            if (McdTemp.Text == strSplitArry[j] && j != strSplitArry.Length - 1)
                            {
                                blnIsExists = true;
                                break;
                            }
                            if (j != 0)
                            {
                                if (McdTemp.Text == strSplitArry[j - 1] && McdTemp.Tag == null)
                                {
                                    intIndex = k;
                                }
                            }

                        }

                        ToolStripMenuItem McdAdd = new ToolStripMenuItem(strSplitArry[j]);
                        if (j == strSplitArry.Length - 1)
                        {
                            McdAdd.Tag = strOldFormName + "^" + dtRecords.Rows[i]["CONTROLID"].ToString();
                            McdAdd.Click += new EventHandler(ApplyReprotItems_Click);
                        }

                        if (!blnIsExists)
                        {
                            if (intIndex == -1)
                                McdMenuCmd.DropDownItems.Add(McdAdd);
                            else
                                altTemp[intIndex].DropDownItems.Add(McdAdd);
                            altTemp.Add(McdAdd);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 图文工作站菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyReprotItems_Click(object sender, EventArgs e)
        {
            string SQL = "";
            string str = ((ToolStripMenuItem)sender).Tag.ToString();
            string[] strSplitArry = str.Split("^".ToCharArray());
            string strContent = "";

            System.Data.DataTable dtRecords = null;

            string strPatientID = m_strPatientID;
            if (strPatientID.Trim() == string.Empty && MDIParent.s_ObjCurrentPatient != null)
                strPatientID = MDIParent.s_ObjCurrentPatient.m_StrPatientID;
            SQL = "select CTL_CONTENT from AR_CONTENT where RECORDID=(select RECORDID from AR_APPLY_REPORT where PATIENTID='" + strPatientID + "' and OPENDATE=(select max(OPENDATE) from AR_APPLY_REPORT where DELSTATUS=0 and PATIENTID='" + strPatientID + "' and FORMCLSNAME='" + strSplitArry[0].Replace("'", "''") + "') and FORMCLSNAME='" + strSplitArry[0].Replace("'", "''") + "') and CONTROLID='" + strSplitArry[1].Replace("'", "''") + "'";

            com.digitalwave.ApplyReportServer.clsApplyReportServer objServ =
                    (com.digitalwave.ApplyReportServer.clsApplyReportServer)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.ApplyReportServer.clsApplyReportServer));

            objServ.m_lngGetData(SQL, ref dtRecords);

            if (dtRecords != null && dtRecords.Rows.Count > 0)
            {
                strContent = dtRecords.Rows[0][0].ToString();
            }

            m_mthInertText(strContent);
        }
        #endregion

        #region 图文工作站普通菜单
        private static string m_strPatientID = "";
        private static Control m_ctlAccept;
        public static void m_mthSetARDataShareCondition(/*MenuItem p_mniDataShare,*/string p_strPatientID, Control p_ctlAccept)
        {
            m_strPatientID = p_strPatientID;
            m_ctlAccept = p_ctlAccept;
            //			if(p_mniDataShare.MenuItems.Count <= 0)
            //				m_mthSetApplyReportSubMenu(p_mniDataShare);
        }
        /// <summary>
        /// 图文工作站菜单添加
        /// </summary>
        /// <param name="p_mniDataShare"></param>
        public void m_mthSetApplyReportSubMenu(MenuItem p_mniDataShare)
        {
            //m_mncApplyReport.MenuCommands
            string SQL = "";
            string strOldFormName = "";
            ArrayList altTemp = new ArrayList();

            System.Data.DataTable dtRecords = null;
            MenuItem McdMenuCmd = null;

            SQL = "select AR_CONTROL_DESC.FORMCLSNAME,FORMDESC,CONTROLID,CONTROLDESC from AR_FORM,AR_CONTROL_DESC where AR_FORM.FORMCLSNAME=AR_CONTROL_DESC.FORMCLSNAME and FORMSTATUS=0 order by AR_CONTROL_DESC.FORMCLSNAME,CONTROLDESC";


            com.digitalwave.ApplyReportServer.clsApplyReportServer objServ =
                    (com.digitalwave.ApplyReportServer.clsApplyReportServer)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.ApplyReportServer.clsApplyReportServer));

            objServ.m_lngGetData(SQL, ref dtRecords);

            if (dtRecords != null)
            {
                for (int i = 0; i < dtRecords.Rows.Count; i++)
                {
                    if (strOldFormName != dtRecords.Rows[i]["FORMCLSNAME"].ToString())
                    {
                        McdMenuCmd = null;
                        McdMenuCmd = new MenuItem(dtRecords.Rows[i]["FORMDESC"].ToString());
                        strOldFormName = dtRecords.Rows[i]["FORMCLSNAME"].ToString();

                        p_mniDataShare.MenuItems.Add(McdMenuCmd);

                        for (int intMenuCount = 0; intMenuCount < altTemp.Count; intMenuCount++)
                        {
                            ((MenuItem)altTemp[intMenuCount]).Visible = true;
                        }

                        altTemp.Clear();
                    }

                    int intIndex = -1;
                    string strTemp = dtRecords.Rows[i]["CONTROLDESC"].ToString();
                    strTemp = strTemp.Replace(">>", ">");
                    string[] strSplitArry = strTemp.Split(">".ToCharArray());

                    for (int j = 0; j < strSplitArry.Length; j++)
                    {
                        bool blnIsExists = false;//默认当前要添加的节点不存在
                        for (int k = 0; k < altTemp.Count; k++)
                        {
                            MenuItem McdTemp = (MenuItem)altTemp[k];
                            if (McdTemp.Text == strSplitArry[j] && j != strSplitArry.Length - 1)
                            {
                                blnIsExists = true;
                                break;
                            }
                            if (j != 0)
                            {
                                if (McdTemp.Text == strSplitArry[j - 1] && McdTemp.Visible == false)
                                {
                                    intIndex = k;
                                }
                            }

                        }

                        MenuItem McdAdd = new MenuItem(strSplitArry[j]);
                        if (j == strSplitArry.Length - 1)
                        {
                            //McdAdd.Tag=strOldFormName + "^" +dtRecords.Rows[i]["CONTROLID"].ToString();
                            string strTag = strOldFormName + "^" + dtRecords.Rows[i]["CONTROLID"].ToString();
                            m_hasMenuItems.Add(McdAdd, strTag);
                            McdAdd.Click += new EventHandler(ApplyReprotItems_Click1);
                        }
                        else
                        {
                            McdAdd.Visible = false;
                        }

                        if (!blnIsExists)
                        {
                            if (intIndex == -1)
                                McdMenuCmd.MenuItems.Add(McdAdd);
                            else
                                ((MenuItem)altTemp[intIndex]).MenuItems.Add(McdAdd);
                            altTemp.Add(McdAdd);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 图文工作站菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyReprotItems_Click1(object sender, EventArgs e)
        {
            string SQL = "";
            string str = m_hasMenuItems[(MenuItem)sender].ToString();
            string[] strSplitArry = str.Split("^".ToCharArray());
            string strContent = "";

            System.Data.DataTable dtRecords = null;

            SQL = "select CTL_CONTENT from AR_CONTENT where RECORDID=(select RECORDID from AR_APPLY_REPORT where PATIENTID='" + m_strPatientID + "' and OPENDATE=(select max(OPENDATE) from AR_APPLY_REPORT where DELSTATUS=0 and PATIENTID='" + m_strPatientID + "' and FORMCLSNAME='" + strSplitArry[0].Replace("'", "''") + "') and FORMCLSNAME='" + strSplitArry[0].Replace("'", "''") + "') and CONTROLID='" + strSplitArry[1].Replace("'", "''") + "'";

            com.digitalwave.ApplyReportServer.clsApplyReportServer objServ =
                    (com.digitalwave.ApplyReportServer.clsApplyReportServer)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.ApplyReportServer.clsApplyReportServer));

            objServ.m_lngGetData(SQL, ref dtRecords);

            if (dtRecords != null && dtRecords.Rows.Count > 0)
            {
                strContent = dtRecords.Rows[0][0].ToString();
            }

            if (m_ctlAccept != null)
            {
                if (m_ctlAccept is ComboBox)
                    m_ctlAccept.Text = m_ctlAccept.Text.Insert(((ComboBox)m_ctlAccept).SelectionStart, strContent);
                else if (m_ctlAccept is TextBoxBase)
                    m_ctlAccept.Text = m_ctlAccept.Text.Insert(((TextBoxBase)m_ctlAccept).SelectionStart, strContent);
            }
        }
        #endregion 图文工作站

        /// <summary>
        /// 获取可编辑控件选定文本起始点
        /// </summary>
        /// <param name="p_ctlText">控件</param>
        /// <returns></returns>
        internal int m_intGetControlSelectionStart(Control p_ctlText)
        {
            int intSelectionStart = 0;
            if (p_ctlText != null)
            {
                intSelectionStart = p_ctlText.Text.Length;
                switch (p_ctlText.GetType().FullName)
                {
                    case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                        com.digitalwave.Utility.Controls.ctlRichTextBox rtb1 = p_ctlText as com.digitalwave.Utility.Controls.ctlRichTextBox;
                        intSelectionStart = rtb1.SelectionStart;
                        break;
                    case "com.digitalwave.controls.ctlRichTextBox":
                        com.digitalwave.controls.ctlRichTextBox rtb2 = p_ctlText as com.digitalwave.controls.ctlRichTextBox;
                        intSelectionStart = rtb2.SelectionStart;
                        break;
                    case "System.Windows.Forms.TextBox":
                        System.Windows.Forms.TextBox text1 = p_ctlText as TextBox;
                        intSelectionStart = text1.SelectionStart;
                        break;
                    case "com.digitalwave.Utility.Controls.ctlComboBox":
                        com.digitalwave.Utility.Controls.ctlComboBox text2 = p_ctlText as com.digitalwave.Utility.Controls.ctlComboBox;
                        intSelectionStart = text2.SelectionStart;
                        break;
                    case "System.Windows.Forms.ComboBox":
                        System.Windows.Forms.ComboBox text3 = p_ctlText as System.Windows.Forms.ComboBox;
                        intSelectionStart = text3.SelectionStart;
                        break;
                }
            }            
            return intSelectionStart;
        }

        /// <summary>
        /// 释放所有本层对象所锁定的资源
        /// 注意：请确保您再也不须要使用此对象
        /// </summary>
        public void Release()
        {
            //			if (this.Disposing || this.IsDisposed)
            //				return;
            if (m_arlExpandedNodes != null) m_arlExpandedNodes.Clear();
            if (m_hasMenuItems != null) m_hasMenuItems.Clear();
            if (m_ctmControl != null) m_ctmControl.Dispose();
            if (m_htSet_ID != null) m_htSet_ID.Clear();
            if (m_hasContolIDs != null) m_hasContolIDs.Clear();

            Type type = this.GetType();

            //只扫描本层字段
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public |
                BindingFlags.NonPublic;//| BindingFlags.DeclaredOnly ;

            FieldInfo[] fields = type.GetFields(flags);

            foreach (FieldInfo field in fields)
            {
                object obj = field.GetValue(this);
                if (obj == null)
                    continue;

                Type t = obj.GetType();

                try
                {
                    //排除不能置空的类型
                    if (!t.IsValueType && (t.ToString().IndexOf("Native") < 0))
                        field.SetValue(this, null);
                }
                catch
                {
                    //BUG	
                    MessageBox.Show("技术人员：请把类型" + t.ToString() + "加到Release()的排除项中去！");
                }
            }

            //			this.Dispose(true);
        }
    }
}
