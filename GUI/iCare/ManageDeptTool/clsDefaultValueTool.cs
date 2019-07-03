using System;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.Utility.Controls;
using iCareData;

namespace iCare
{
	/// <summary>
	/// 默认值工具
	/// </summary>
	public class clsDefaultValueTool
	{
		private clsPatient m_objPatient;
		private Form m_frmParent;
		private Hashtable m_htControlValues = new Hashtable();
		private ArrayList m_arlControls = new ArrayList();
		private clsDefaultValueDomain m_objDomain = new clsDefaultValueDomain();
		private bool m_blnReplaceDataShare = true;
	
		public clsDefaultValueTool(Form p_frmParent)
		{
			m_frmParent = p_frmParent;
		}

		public clsDefaultValueTool(Form p_frmParent,clsPatient p_objPatient)
		{
			m_frmParent = p_frmParent;
			m_objPatient = p_objPatient;
		}

		/// <summary>
		/// 是否替换数据复用内容
		/// </summary>
		public bool m_BlnReplaceDataShare
		{
			set
			{
				m_blnReplaceDataShare = false;
			}
		}

		private void m_mthAddDefaultValueToHashTable(Control p_ctlParent)
		{
			foreach(Control ctlSub in p_ctlParent.Controls)
			{
				string strContent = "";
                if (ctlSub is com.digitalwave.Controls.ICustomValueControl)
                {
                    if (ctlSub is com.digitalwave.Controls.ICustomValueControl<string>)
                    {
                        strContent = ((com.digitalwave.Controls.ICustomValueControl<string>)ctlSub).m_objGetValue();
                    }
                    else if (ctlSub is com.digitalwave.Controls.ICustomValueControl<bool>)
                    {
                        strContent = (((com.digitalwave.Controls.ICustomValueControl<bool>)ctlSub).m_objGetValue()?"true":"");
                    }
                }
                else
                {
                    switch (ctlSub.GetType().FullName)
                    {
                        case "System.Windows.Forms.TextBox":
                            strContent = ctlSub.Text;
                            break;
                        case "System.Windows.Forms.RichTextBox":
                        case "iCare.CustomForm.ctlRichTextBox":
                            strContent = ((RichTextBox)ctlSub).Text;
                            break;
                        case "com.digitalwave.Utility.Controls.ctlBorderTextBox":
                            strContent = ctlSub.Text;
                            break;
                        case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                            strContent = ctlSub.Text;// ((ctlRichTextBox)ctlSub).m_strGetRightText();
                            break;
                        case "com.digitalwave.controls.ctlRichTextBox":
                            strContent = ctlSub.Text;// ((com.digitalwave.controls.ctlRichTextBox)ctlSub).m_strGetRightText();
                            break;
                        case "com.digitalwave.Utility.Controls.ctlComboBox":
                            strContent = ((ctlComboBox)ctlSub).Controls[0].Text;
                            break;
                        case "System.Windows.Forms.ComboBox":
                            strContent = ((ComboBox)ctlSub).SelectedText;
                            break;
                        case "System.Windows.Forms.RadioButton":
                            strContent = (((RadioButton)ctlSub).Checked) ? "true" : "";
                            break;
                        case "System.Windows.Forms.CheckBox":
                        case "iCare.CustomForm.ctlCheckBox":
                            strContent = (((CheckBox)ctlSub).Checked) ? "true" : "";
                            break;
                    }
                }
                if (!(ctlSub.AccessibleName == "NoDefault" || strContent == "" || ctlSub.AccessibleName == "NoDefaultIn" || !ctlSub.Enabled))
				{
					m_htControlValues.Add(ctlSub.Name,strContent);
				}

                if (ctlSub.HasChildren && ctlSub.GetType().Name != "ctlComboBox" && ctlSub.AccessibleName != "NoDefaultIn")
					m_mthAddDefaultValueToHashTable(ctlSub);
			}
			
		}

		public void m_mthSaveDefaultValue()
		{
			m_mthAddDefaultValueToHashTable(m_frmParent);

			if(m_htControlValues.Count > 0)
			{
				ArrayList arlValue = new ArrayList();
				IDictionaryEnumerator enm = m_htControlValues.GetEnumerator();
				while(enm.MoveNext())
				{
					clsCustomDefaultValue obj = new clsCustomDefaultValue();
					//obj.m_strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_strDeptNewID;
                    obj.m_strDeptID = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR;
                    //if(m_objPatient==null)
                    //{
                    //    if (MDIParent.s_ObjCurrentPatient!=null)
                    //        obj.m_strAreaID = MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_strAreaNewID;
                    //    else
                    //        obj.m_strAreaID="";
                    //}
                    //else
                    //{
                    //    obj.m_strAreaID = m_objPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_strAreaNewID;
                    //}
                    if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea == null)
                        obj.m_strAreaID = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR;
                    else
                        obj.m_strAreaID = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea.m_strDEPTID_CHR;
//					obj.m_strAreaID = m_objPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID;
					//自定义表单以FormID替代窗体名
					if(m_frmParent is iCare.CustomForm.frmCustomFormBase)
					{
						obj.m_strFormName = ((iCare.CustomForm.frmCustomFormBase)m_frmParent).m_strGetCurFormName();
                        //obj.m_strAreaID = MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_strAreaNewID;
					}
					else
						obj.m_strFormName = m_frmParent.Name;
					obj.m_strControlName = enm.Key.ToString();
					obj.m_strContent = enm.Value.ToString();

					arlValue.Add(obj);
				}
				clsCustomDefaultValue[] objArr = (clsCustomDefaultValue[])arlValue.ToArray(typeof(clsCustomDefaultValue));
                
				long lngRes = m_objDomain.m_lngSaveDefaultValue(objArr);
			}
		}

		/// <summary>
		/// 获取某窗体的默认值并赋到界面上
		/// </summary>
		public void m_mthSetDefaultValue()
		{
			if(m_objPatient == null)
			{
				if(MDIParent.s_ObjCurrentPatient==null)
					return;
				else
					m_objPatient=MDIParent.s_ObjCurrentPatient;
			}

            if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea == null)
            {
                return;
            }
			string strFormName;
			//自定义表单以FormID替代窗体名
			if(m_frmParent is iCare.CustomForm.frmCustomFormBase)
				strFormName = ((iCare.CustomForm.frmCustomFormBase)m_frmParent).m_strGetCurFormName();
			else
				strFormName = m_frmParent.Name;

			m_mthGetControls(m_frmParent);
			Control[] ctlControls = (Control[])m_arlControls.ToArray(typeof(Control));

			clsCustomDefaultValue[] objArr;
            long lngRes = m_objDomain.m_lngGetDefaultValue(com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea.m_strDEPTID_CHR, strFormName, out objArr);
			if(lngRes > 0 && objArr != null && objArr.Length > 0)
			{

				#region 替换数据复用内容
				ArrayList arlTemp = new ArrayList();
				for(int i = 0; i < objArr.Length; i++)
					arlTemp.Add(objArr[i].m_strContent);
				string[] strContentArr = (string[])arlTemp.ToArray(typeof(string));
				if(m_blnReplaceDataShare)
                    com.digitalwave.Emr.Utility.DataShare.clsDataShareReplace.s_mthReplaceDataShareValue(m_objPatient,ref strContentArr);
				#endregion
                clsCustomDefaultValue objDefaultValue = null;
                Control ctl = null; 
				for(int i = 0; i < objArr.Length; i++)
				{
                    objDefaultValue = objArr[i];
					for(int j = 0; j < ctlControls.Length; j++)
					{
                        ctl = ctlControls[j];
                        if (objDefaultValue.m_strControlName == ctl.Name)
                        {
							string strContent = strContentArr[i];
                            if (!(ctl.AccessibleName == "NoDefault" || strContent == "" || ctl.AccessibleName == "NoDefaultIn" || !ctl.Enabled))
                            {
                                if (ctl is com.digitalwave.Controls.ICustomValueControl)
                                {
                                    if (ctl is com.digitalwave.Controls.ICustomValueControl<string>)
                                    {
                                        ((com.digitalwave.Controls.ICustomValueControl<string>)ctl).m_mthSetValue(strContent);
                                    }
                                    else if (ctl is com.digitalwave.Controls.ICustomValueControl<bool>)
                                    {
                                        ((com.digitalwave.Controls.ICustomValueControl<bool>)ctl).m_mthSetValue(true);
                                    }
                                }
                                else
                                {
                                    switch (ctlControls[j].GetType().FullName)
                                    {
                                        case "System.Windows.Forms.TextBox":
                                            ctl.Text = strContent;
                                            break;
                                        case "System.Windows.Forms.RichTextBox":
                                        case "iCare.CustomForm.ctlRichTextBox":
                                            ctl.Text = strContent;
                                            break;
                                        case "com.digitalwave.Utility.Controls.ctlBorderTextBox":
                                            ctl.Text = strContent;
                                            break;
                                        case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                                            ((ctlRichTextBox)ctl).m_mthClearText();
                                            ((ctlRichTextBox)ctl).m_mthInsertText(strContent, 0);
                                            break;
                                        case "com.digitalwave.controls.ctlRichTextBox":
                                            ((com.digitalwave.controls.ctlRichTextBox)ctl).m_mthClearText();
                                            ((com.digitalwave.controls.ctlRichTextBox)ctl).m_mthInsertText(strContent, 0);
                                            break;
                                        case "com.digitalwave.Utility.Controls.ctlComboBox":
                                            //									((ctlComboBox)ctl).Controls[0].Text = strContent;
                                            ((ctlComboBox)ctl).Text = strContent;
                                            break;
                                        case "System.Windows.Forms.ComboBox":
                                            ctl.Text = strContent;
                                            break;
                                        case "System.Windows.Forms.RadioButton":
                                            ((RadioButton)ctl).Checked = true;
                                            break;
                                        case "System.Windows.Forms.CheckBox":
                                        case "iCare.CustomForm.ctlCheckBox":
                                            ((CheckBox)ctl).Checked = true;
                                            break;
                                    }
                                }
                            }//
						}
					}
				}

				//设置后默认值后回到床位
				if(m_frmParent is frmHRPBaseForm)
					((frmHRPBaseForm)m_frmParent).m_mthSetBedFocus();
			}
		}

		private void m_mthGetControls(Control p_ctlParent)
		{
			foreach(Control ctlSub in p_ctlParent.Controls)
			{
				switch(ctlSub.GetType().FullName)
				{
					case "System.Windows.Forms.TextBox" :
						m_arlControls.Add(ctlSub);
						break;
					case "System.Windows.Forms.RichTextBox" :
					case "iCare.CustomForm.ctlRichTextBox":
						m_arlControls.Add(ctlSub);
						break;
					case "com.digitalwave.Utility.Controls.ctlBorderTextBox" :
						m_arlControls.Add(ctlSub);
						break;
					case "com.digitalwave.Utility.Controls.ctlRichTextBox" :
						m_arlControls.Add(ctlSub);
						break;
					case "com.digitalwave.controls.ctlRichTextBox" :
						m_arlControls.Add(ctlSub);
						break;
					case "com.digitalwave.Utility.Controls.ctlComboBox" :
						m_arlControls.Add(ctlSub);
						break;
					case "System.Windows.Forms.ComboBox" :
						m_arlControls.Add(ctlSub);
						break;
					case "System.Windows.Forms.RadioButton" :
						m_arlControls.Add(ctlSub);
						break;
					case "System.Windows.Forms.CheckBox" :
					case "iCare.CustomForm.ctlCheckBox" :
						m_arlControls.Add(ctlSub);
						break;
				}
				
				if(ctlSub.HasChildren && ctlSub.GetType().Name != "ctlComboBox")
					m_mthGetControls(ctlSub);
			}
		}
	}
}
