using System;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using com.digitalwave.GLS_WS;

namespace iCare.FormUtility
{
	/// <summary>
	/// 提示窗体保存修改
    /// 原理：创建一个哈希表存放各个窗体。
    /// 窗体key。value为一个哈希表。该哈希表存放该窗体所有控件的值状态
	/// </summary>
	public class clsSaveCue
	{
        #region 变量
        /// <summary>
        /// 模板的输入框，不需要记录和判断状态。
        /// </summary>
        private const string c_strTemplateTextBox = "m_txtInputKeyword";
        /// <summary>
        /// 模板的选择框，不需要记录和判断状态。
        /// </summary>
        private const string c_strTemplateListBox = "m_lstTemplate";

        /// <summary>
        /// 自定义表单作特殊处理
        /// </summary>
        private const string c_strCustomForm = "frmCustomForm_";

        /// <summary>
        /// 窗体信息（窗体为key，窗体状态的Hashtable为value）
        /// 哈希表 （）
        /// </summary>
        private Hashtable m_hasFormInfo; 
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsSaveCue()
        {
            //
            // TODO: Add constructor logic here
            //
            m_hasFormInfo = new Hashtable();
        } 
        #endregion

        #region 记录窗体状态
        /// <summary>
        /// 添加窗体
        /// 添加窗体到哈西表中。默认值为null
        /// 同时绑定窗体的关闭事件
        /// </summary>
        /// <param name="p_frmNeedSaveCue"></param>
        public void m_mthAddForm(Form p_frmNeedSaveCue)
        {
            try
            {
                if (p_frmNeedSaveCue == null)
                    return;

                //保存窗体
                if (m_hasFormInfo.Contains(p_frmNeedSaveCue))
                    return;
                else
                {
                    //取窗体名称＋当前住院号，已实现一个病人只能打开同样一个窗体功能
                    string strHash = p_frmNeedSaveCue.Name + com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strINPATIENTID_CHR;
                    m_hasFormInfo.Add(strHash.GetHashCode(), null);
                }

                if (!(p_frmNeedSaveCue is frmApplyReportBase))
                    //添加关闭处理
                    p_frmNeedSaveCue.Closing += new CancelEventHandler(m_mthHandleFormClosing);
   }
            catch 
            {
                //若没有设置当前病人抛出
            }
        }

        /// <summary>
        /// 添加窗体上控件状态
        /// </summary>
        /// <param name="p_frmNeedSaveCue"></param>
        public void m_mthAddFormStatus(Form p_frmNeedSaveCue)
        {
            try
            {
                //取窗体名称＋当前住院号，已实现一个病人只能打开同样一个窗体功能
                string strHash = p_frmNeedSaveCue.Name + com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strINPATIENTID_CHR;
                if (!m_hasFormInfo.Contains(strHash.GetHashCode()))
                    m_mthAddForm(p_frmNeedSaveCue);

                Hashtable hasStatus = (Hashtable)m_hasFormInfo[strHash.GetHashCode()];
                if (hasStatus == null)
                {
                    hasStatus = new Hashtable();
                    m_hasFormInfo[strHash.GetHashCode()] = hasStatus;
                }
                else
                {
                    hasStatus.Clear();
                }

                //记录当前状态

                m_mthAddStatus(p_frmNeedSaveCue, hasStatus);
            }
            catch 
            {
                //若没有设置当前病人抛出
            }
        }
        /// <summary>
        /// 记录控件的当前状态
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_hasStatus"></param>
        private void m_mthAddStatus(Control p_ctlControl, Hashtable p_hasStatus)
        {
            if (p_ctlControl.Name == c_strTemplateTextBox || p_ctlControl.Name == c_strTemplateListBox)
                return;
            try
            {
                switch (p_ctlControl.GetType().FullName)
                {
                    //非输入框不做处理
                    //case "System.Windows.Forms.LinkLabel":
                    //case "System.Windows.Forms.Button":
                    //case "System.Windows.Forms.Label":
                    //系统自带处理
                    case "System.Windows.Forms.ComboBox":
                        p_hasStatus.Add(p_ctlControl.Name, p_ctlControl.Text.GetHashCode());
                        break;
                    case "System.Windows.Forms.TextBox":
                        p_hasStatus.Add(p_ctlControl.Name, p_ctlControl.Text.GetHashCode());
                        break;
                    case "System.Windows.Forms.MaskedTextBox":
                        p_hasStatus.Add(p_ctlControl.Name, p_ctlControl.Text.GetHashCode());
                        break;
                    case "System.Windows.Forms.NumericUpDown":
                        p_hasStatus.Add(p_ctlControl.Name, ((System.Windows.Forms.NumericUpDown)p_ctlControl).Value.GetHashCode());
                        break;
                    case "System.Windows.Forms.CheckBox":
                        p_hasStatus.Add(p_ctlControl.Name, ((CheckBox)p_ctlControl).Checked);
                        break;
                    case "System.Windows.Forms.CheckedListBox":
                        break;
                    case "System.Windows.Forms.RadioButton":
                        p_hasStatus.Add(p_ctlControl.Name, ((RadioButton)p_ctlControl).Checked);
                        break;
                    case "System.Windows.Forms.DateTimePicker":
                        p_hasStatus.Add(p_ctlControl.Name, ((System.Windows.Forms.DateTimePicker)p_ctlControl).Value.GetHashCode());
                        break;
                    case "System.Windows.Forms.ListView":
                        break;
                    case "System.Windows.Forms.ListBox":
                        break;
                    case "System.Windows.Forms.DataGridTextBox":
                        break;

                    //自定义框转换处理
                    case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                        p_hasStatus.Add(((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).Name, ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_strGetRightText().GetHashCode());
                        break;
                    case "com.digitalwave.controls.ctlRichTextBox":
                        p_hasStatus.Add(((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).Name, ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_strGetRightText().GetHashCode());
                        break;
                    case "com.digitalwave.Utility.Controls.ctlTimePicker":
                        p_hasStatus.Add(((com.digitalwave.Utility.Controls.ctlTimePicker)p_ctlControl).Name, ((com.digitalwave.Utility.Controls.ctlTimePicker)p_ctlControl).Text.GetHashCode());
                        break;

                    case "com.digitalwave.Utility.Controls.ctlComboBox":
                        p_hasStatus.Add(((com.digitalwave.Utility.Controls.ctlComboBox)p_ctlControl).Name, ((com.digitalwave.Utility.Controls.ctlComboBox)p_ctlControl).Text.GetHashCode());
                        break;
                    case "com.digitalwave.Utility.Controls.ctlBorderTextBox":
                        p_hasStatus.Add(((com.digitalwave.Utility.Controls.ctlBorderTextBox)p_ctlControl).Name, ((com.digitalwave.Utility.Controls.ctlBorderTextBox)p_ctlControl).Text.GetHashCode());
                        break;
                    default:
                        break;
                }
                //自定义控件不递归
                if (p_ctlControl.GetType().FullName.IndexOf("digitalwave") < 0
                    && !(p_ctlControl is System.Windows.Forms.DataGrid && p_ctlControl.Parent is frmRecordsBase))
                {
                    foreach (Control ctlChild in p_ctlControl.Controls)
                    {
                        m_mthAddStatus(ctlChild, p_hasStatus);
                    }
                }

            }
            catch (Exception exp)
            {
                string strError = exp.Message;
            }

        } 
        #endregion

        #region 验证窗体状态
        /// <summary>
        /// 检查窗体状态是否有改变
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_hasStatus"></param>
        /// <returns>没有改变返回True，否则返回False</returns>
        private bool m_blnCheckStatusSame(Control p_ctlControl, Hashtable p_hasStatus)
        {
            if (p_ctlControl.Name == c_strTemplateTextBox || p_ctlControl.Name == c_strTemplateListBox)
                return true;

            //自定义窗体特殊处理
            if (p_ctlControl.Name == c_strCustomForm)
                return m_blnCheckStatusSameOfCustomForm(p_ctlControl, p_hasStatus);

            bool blnRes = true;

                 switch (p_ctlControl.GetType().FullName)
                {
                    //非输入框不做处理
                    //case "System.Windows.Forms.LinkLabel":
                    //case "System.Windows.Forms.Button":
                    //case "System.Windows.Forms.Label":
                    //系统自带处理
                    case "System.Windows.Forms.ComboBox":
                        if ((int)p_hasStatus[p_ctlControl.Name] != p_ctlControl.Text.GetHashCode())
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "System.Windows.Forms.TextBox":
                        if ((int)p_hasStatus[p_ctlControl.Name] != p_ctlControl.Text.GetHashCode())
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "System.Windows.Forms.MaskedTextBox":
                        if ((int)p_hasStatus[p_ctlControl.Name] != p_ctlControl.Text.GetHashCode())
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "System.Windows.Forms.NumericUpDown":
                        if ((int)p_hasStatus[p_ctlControl.Name] != ((System.Windows.Forms.NumericUpDown)p_ctlControl).Value.GetHashCode())
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "System.Windows.Forms.CheckBox":
                        if ((bool)p_hasStatus[p_ctlControl.Name] != ((System.Windows.Forms.CheckBox)p_ctlControl).Checked)
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "System.Windows.Forms.CheckedListBox":
                        break;
                    case "System.Windows.Forms.RadioButton":
                        if ((bool)p_hasStatus[p_ctlControl.Name] != ((System.Windows.Forms.RadioButton)p_ctlControl).Checked)
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "System.Windows.Forms.DateTimePicker":
                        if ((int)p_hasStatus[p_ctlControl.Name] != ((System.Windows.Forms.DateTimePicker)p_ctlControl).Value.GetHashCode())
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "System.Windows.Forms.ListView":
                        break;
                    case "System.Windows.Forms.ListBox":
                        break;
                    case "System.Windows.Forms.DataGridTextBox":
                        break;

                    //自定义框转换处理
                    case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                        if ((int)p_hasStatus[p_ctlControl.Name] != ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_strGetRightText(true).GetHashCode())
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "com.digitalwave.controls.ctlRichTextBox":
                        if ((int)p_hasStatus[p_ctlControl.Name] != ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_strGetRightText(true).GetHashCode())
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "com.digitalwave.Utility.Controls.ctlTimePicker":
                        if ((int)p_hasStatus[p_ctlControl.Name] != ((com.digitalwave.Utility.Controls.ctlTimePicker)p_ctlControl).Text.GetHashCode())
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "com.digitalwave.Utility.Controls.ctlComboBox":
                        if ((int)p_hasStatus[p_ctlControl.Name] != ((com.digitalwave.Utility.Controls.ctlComboBox)p_ctlControl).Text.GetHashCode())
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    case "com.digitalwave.Utility.Controls.ctlBorderTextBox":
                        if ((int)p_hasStatus[p_ctlControl.Name] != ((com.digitalwave.Utility.Controls.ctlBorderTextBox)p_ctlControl).Text.GetHashCode())
                        {
                            blnRes = false;
                            return blnRes;
                        }
                        break;
                    default:
                        break;

                }
            //自定义控件不递归
                if (p_ctlControl.GetType().FullName.IndexOf("digitalwave") < 0 
                    && !(p_ctlControl is System.Windows.Forms.DataGrid && p_ctlControl.Parent is frmRecordsBase))
            {
                foreach (Control ctlChild in p_ctlControl.Controls)
                {
                    if (!m_blnCheckStatusSame(ctlChild, p_hasStatus))
                        blnRes = false;
                }
            }

            return blnRes;
        }

        private void m_mthHandleFormClosing(object p_objForm, CancelEventArgs p_objArg)
        {
            m_mthHandleSaveCue((Form)p_objForm, p_objArg);

            //			m_hasFormInfo.Remove(p_objForm);
        }

        /// <summary>
        /// 在记录选择改变前，保存窗体记录。
        /// </summary>
        /// <param name="p_frmNeedSaveCue"></param>
        public void m_mthHandleRecordAfterSelect(Form p_frmNeedSaveCue)
        {
            //			m_mthHandleSaveCue(p_frmNeedSaveCue);
        }

        /// <summary>
        /// 保存窗体记录
        /// </summary>
        /// <param name="p_frmNeedSaveCue">需要保存的窗体</param>
        private void m_mthHandleSaveCue(Form p_frmNeedSaveCue, CancelEventArgs e)
        {   
            try
            {         
                //取窗体名称＋当前住院号，已实现一个病人只能打开同样一个窗体功能
                string strHash = p_frmNeedSaveCue.Name + com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strINPATIENTID_CHR;

                Hashtable hasStatus = (Hashtable)m_hasFormInfo[strHash.GetHashCode()];

                if (hasStatus == null)
                    return;

           

            //检查窗体状态是否改变
            bool blnIsSame = m_blnCheckStatusSame(p_frmNeedSaveCue, hasStatus);


            //窗体状态改变，提示保存，如需要保存，调用保存功能			
            if (!blnIsSame && p_frmNeedSaveCue.DialogResult != DialogResult.Yes)
            {            
                frmHRPBaseForm frmBase = p_frmNeedSaveCue as frmHRPBaseForm;
                if (frmBase != null)
                {
                    frmBase.m_blnHasClosing = true;
                }
                //if (p_frmNeedSaveCue is frmHRPBaseForm)
                //{
                //    ((frmHRPBaseForm)p_frmNeedSaveCue).m_blnHasClosing = true;
                //}

                DialogResult dlgResult = DialogResult.None;

                if (MDIParent.s_ObjCurrentPatient != null && MDIParent.s_ObjCurrentPatient.m_IntCharacter == 1)
                {
                    dlgResult = DialogResult.No;
                }
                else
                {
             
                    dlgResult = clsPublicFunction.ShowQuestionMessageBox("[" + p_frmNeedSaveCue.Text + "]做了改动，是否保存？", MessageBoxButtons.YesNoCancel);
                }

                if (dlgResult == DialogResult.Yes)
                {
                    #region yes
                    if (p_frmNeedSaveCue is frmPatientInfoManage)
                    {
                        ((frmPatientInfoManage)p_frmNeedSaveCue).m_mthSave();
                    }
                    else if (p_frmNeedSaveCue is iCareBaseForm.frmPatientRecordForm)
                    {
                        ((iCareBaseForm.frmPatientRecordForm)p_frmNeedSaveCue).m_mthSave();
                    }
                    else if (p_frmNeedSaveCue is frmRecordsBase)
                    {
                        ((frmRecordsBase)p_frmNeedSaveCue).Save();
                    }
                    else
                    {
                        //frmHRPBaseForm frmBase = p_frmNeedSaveCue as frmHRPBaseForm;

                        if (frmBase != null)
                        {
                            if (frmBase.m_lngSave() > 0)
                                frmBase.DialogResult = DialogResult.Yes;
                        }
                        else
                        {
                            PublicFunction objPF = p_frmNeedSaveCue as PublicFunction;

                            if (objPF != null)
                            {
                                objPF.Save();
                                if (frmBase != null)
                                    frmBase.DialogResult = DialogResult.Yes;
                            }
                        }
                    }

                    m_hasFormInfo.Remove(strHash.GetHashCode()); 
                    #endregion
                }
                else if (dlgResult == DialogResult.No)
                {
                    #region no
                        m_hasFormInfo.Remove(strHash.GetHashCode()); 
                    #endregion
                }
                else if (dlgResult == DialogResult.Cancel)
                {
                    #region cancel
                    e.Cancel = true;

                    if (frmBase != null)
                    {
                        frmBase.m_blnHasClosing = false;
                    }
                    //if (p_frmNeedSaveCue is frmHRPBaseForm)
                    //{
                    //    ((frmHRPBaseForm)p_frmNeedSaveCue).m_blnHasClosing = false;
                    //} 
                    #endregion
                }
            }
            else
            {
                m_hasFormInfo.Remove(strHash.GetHashCode());
            }
        }
        catch
        {
            //若没有设置当前病人抛出
            return;
        }
        }

        /// <summary>
        /// 检查窗体状态是否有改变
        /// </summary>
        /// <param name="p_frmNeedSaveCue"></param>
        /// <returns></returns>
        public bool m_blnCheckStatusSame(Form p_frmNeedSaveCue)
        {
            bool blnRes = true;
            try
            {
                //取窗体名称＋当前住院号，已实现一个病人只能打开同样一个窗体功能
                string strHash = p_frmNeedSaveCue.Name + com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strINPATIENTID_CHR;

                Hashtable hasStatus = (Hashtable)m_hasFormInfo[strHash.GetHashCode()];

                if (hasStatus == null)
                    return true;

                blnRes = m_blnCheckStatusSame(p_frmNeedSaveCue, hasStatus);

            }
            catch 
            {
                //若没有设置当前病人抛出
            }
            return blnRes;
        }

        /// <summary>
        /// 检查窗体状态是否有改变，自定义表单作特殊处理
        /// </summary>
        /// <returns>没有改变返回True，否则返回False</returns>
        private bool m_blnCheckStatusSameOfCustomForm(Control p_ctlControl, Hashtable p_hasStatus)
        {
            bool blnRes = true;

            if (p_hasStatus[p_ctlControl] != null)
            {
                switch (p_ctlControl.GetType().Name)
                {
                    case "iCare.CustomForm.ctlCheckBox":
                        if ((bool)p_hasStatus[p_ctlControl.Name] != ((iCare.CustomForm.ctlCheckBox)p_ctlControl).Checked)
                            blnRes = false;
                        return blnRes;
                    default:
                        if ((int)p_hasStatus[p_ctlControl.Name] != p_ctlControl.Text.GetHashCode())
                            blnRes = false;
                        break;
                }
            }

            foreach (Control ctlChild in p_ctlControl.Controls)
            {
                if (!m_blnCheckStatusSameOfCustomForm(ctlChild, p_hasStatus))
                    blnRes = false;
            }

            return blnRes;
        } 
        #endregion

        #region 删除窗体状态
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_frmCue"></param>
        public void m_mthRemoveForm(Form p_frmCue)
        {
            try
            {
                //取窗体名称＋当前住院号，已实现一个病人只能打开同样一个窗体功能
               string strHash = p_frmCue.Name + com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strINPATIENTID_CHR;
               if (!(p_frmCue is frmApplyReportBase))
                     //添加关闭处理,取消绑定
                     p_frmCue.Closing -= new CancelEventHandler(m_mthHandleFormClosing);

                //从哈希表中删除
                if (m_hasFormInfo.Contains(strHash.GetHashCode()))
                {
                    //从哈希表中删除
                    m_hasFormInfo.Remove(strHash.GetHashCode());
                }
             }
             catch 
            {
                //若没有设置当前病人抛出
            }


        } 
        #endregion


	}
}
