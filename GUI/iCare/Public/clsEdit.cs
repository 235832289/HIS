using System;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using Static = com.digitalwave.Emr.StaticObject;
using com.digitalwave.emr.AssistModule;

namespace iCare
{
	/// <summary>
	/// 编辑:用于电子病历当前子窗体的保存、删除、打印等公共操作
	/// </summary>
	public class clsEdit
	{
		public clsEdit()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//	
		}
        /// <summary>
        /// 电子签名验证
        /// </summary>
		public void Verify()
		{
			if(clsEMRLogin.s_FrmMDI.ActiveMdiChild==null && !(clsEMRLogin.s_FrmMDI.ActiveMdiChild is PublicFunction))
				return;
            try
            {
			    Cursor.Current =Cursors.WaitCursor;				
			    ((PublicFunction)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).Verify(); 
			
            }
            finally
            {
                Cursor.Current =Cursors.Default;

            }
		}
        /// <summary>
        /// 保存当前表单
        /// </summary>
		public void Save()
		{
			if(clsEMRLogin.s_FrmMDI.ActiveMdiChild==null && !(clsEMRLogin.s_FrmMDI.ActiveMdiChild is PublicFunction))
				return;
            try
            {
                Cursor.Current =Cursors.WaitCursor;				
			    ((PublicFunction)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).Save(); 
            }
            finally
            {
                Cursor.Current =Cursors.Default;
            }
			
			
		}


        /// <summary>
        /// 删除当前选择表单记录
        /// </summary>
		public void Delete()
		{
			if(clsEMRLogin.s_FrmMDI.ActiveMdiChild==null && !(clsEMRLogin.s_FrmMDI.ActiveMdiChild is PublicFunction))
				return;
            try
            {
			    Cursor.Current =Cursors.WaitCursor;				
			    ((PublicFunction)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).Delete(); 

            }
            finally
            {
			    Cursor.Current =Cursors.Default;

            }
		}

		/// <summary>
		/// 查询已删除记录
		/// </summary>
        public void LoadDeletedRecord()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (clsEMRLogin.s_FrmMDI.ActiveMdiChild is frmHRPBaseForm)
                {
                    frmHRPBaseForm frmHrp = (frmHRPBaseForm)clsEMRLogin.s_FrmMDI.ActiveMdiChild;
                    if (frmHrp.m_blnIsNewSetInactiveForm)
                    {
                            m_mthOpenInactiveView(frmHrp.m_ObjCurrentEmrPatientSession, frmHrp);
                    }
                    else
                    {
                        frmRecordsBase frmRecords = clsEMRLogin.s_FrmMDI.ActiveMdiChild as frmRecordsBase;

                        if (frmRecords != null && frmRecords.m_FrmCurrentSub != null && frmRecords.m_FrmCurrentSub is frmHRPBaseForm)
                        {
                            ((frmHRPBaseForm)(frmRecords.m_FrmCurrentSub)).m_mthSearchDeactiveInfo();
                        }
                        else if (clsEMRLogin.s_FrmMDI.ActiveMdiChild is frmHRPBaseForm)
                        {
                            ((frmHRPBaseForm)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).m_mthSearchDeactiveInfo();
                        }
                    }
                }
                else if (clsEMRLogin.s_FrmMDI.ActiveMdiChild is infInactiveRecord)
                {
                    m_mthOpenInactiveView(((infInactiveRecord)clsEMRLogin.s_FrmMDI.ActiveMdiChild).m_objGetSessionInfo, clsEMRLogin.s_FrmMDI.ActiveMdiChild);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }
        private void m_mthOpenInactiveView(iCareData.clsEmrPatientSessionInfo_VO p_objSessionInfo, Form p_frmSelectedForm)
        {
            if (p_objSessionInfo == null) return;
            frmInactiveView frm = new frmInactiveView(p_objSessionInfo, (infInactiveRecord)p_frmSelectedForm);
            frm.ShowDialog(p_frmSelectedForm);
        }
        /// <summary>
        /// 打印预览
        /// </summary>
		public void Preview()
		{
			if(clsEMRLogin.s_FrmMDI.ActiveMdiChild==null )
				return;

			frmRecordsBase frmRecords = clsEMRLogin.s_FrmMDI.ActiveMdiChild as frmRecordsBase;

			if(frmRecords != null && frmRecords.m_FrmCurrentSub != null)
			{
				//正在使用子窗体，不打印。
				return;
			}
            try
            {
			    Cursor.Current =Cursors.WaitCursor;
			    if(clsEMRLogin.s_FrmMDI.ActiveMdiChild is frmHRPBaseForm)
				    ((frmHRPBaseForm)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).m_BlnDirectPrint = false;
			    ((PublicFunction)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).Print(); 

            }
            finally
            {
			    Cursor.Current =Cursors.Default;

            }
		}
        /// <summary>
        /// 打印
        /// </summary>
		public void Print()
		{
			if(clsEMRLogin.s_FrmMDI.ActiveMdiChild==null )
				return;


			frmRecordsBase frmRecords = clsEMRLogin.s_FrmMDI.ActiveMdiChild as frmRecordsBase;

			if(frmRecords != null && frmRecords.m_FrmCurrentSub != null)
			{
				//正在使用子窗体，不打印。
				return;
			}
            try
            {
			    Cursor.Current =Cursors.WaitCursor;
                if (clsEMRLogin.s_FrmMDI.ActiveMdiChild is frmHRPBaseForm)
                {
                    if (((frmHRPBaseForm)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).m_objBaseCurrentPatient != null
                        && ((frmHRPBaseForm)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).m_objBaseCurrentPatient.m_IntCharacter == 1)
                    {
                        bool blnIsCase = false;
                        if (Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr != null)
                        {
                            int intRolesCount = Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr.Length;
                            for (int i = 0; i < intRolesCount; i++)
                            {
                                if (Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr[i] == "病案室")
                                {
                                    blnIsCase = true;
                                    break;
                                }
                            }
                        }
                        if (!blnIsCase)
                        {
                            clsPublicFunction.ShowInformationMessageBox("此病人病历为只读，不能打印！");
                            return;
                        }
                    }
                    ((frmHRPBaseForm)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).m_BlnDirectPrint = true;
                }
                
                PrintDialog pdSet = new PrintDialog();
                if (string.IsNullOrEmpty(pdSet.PrinterSettings.PrinterName))
                {
                    pdSet.ShowDialog(clsEMRLogin.s_FrmMDI.ActiveMdiChild);
                }

                if (string.IsNullOrEmpty(pdSet.PrinterSettings.PrinterName))//关闭打印设置后再次判断
                {
                    clsPublicFunction.ShowInformationMessageBox("请先指定一台打印机！");
                    return;
                }

			    ((PublicFunction)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).Print(); 

            }
            finally
            {
			    Cursor.Current =Cursors.Default;

            }
		}
        /// <summary>
        /// 剪贴
        /// </summary>
		public void Cut()
		{
            //因为痕迹处理的原因，屏蔽剪切功能
            //if(clsEMRLogin.s_FrmMDI.ActiveMdiChild==null && !(clsEMRLogin.s_FrmMDI.ActiveMdiChild is PublicFunction))
            //    return;

            //Cursor.Current =Cursors.WaitCursor;				
            //((PublicFunction)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).Cut(); 
            //Cursor.Current =Cursors.Default;
		}
        /// <summary>
        /// 拷贝
        /// </summary>
		public void Copy()
		{
			if(clsEMRLogin.s_FrmMDI.ActiveMdiChild==null && !(clsEMRLogin.s_FrmMDI.ActiveMdiChild is PublicFunction))
				return;
            try
            {
			    Cursor.Current =Cursors.WaitCursor;				
			    ((PublicFunction)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).Copy(); 

            }
            finally
            {
			    Cursor.Current =Cursors.Default;

            }
		}
        /// <summary>
        /// 粘贴
        /// </summary>
		public void Paste()
		{
			if(clsEMRLogin.s_FrmMDI.ActiveMdiChild==null && !(clsEMRLogin.s_FrmMDI.ActiveMdiChild is PublicFunction))
				return;
            try
            {
			    Cursor.Current =Cursors.WaitCursor;				
			    ((PublicFunction)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).Paste(); 

            }
            finally
            {
			    Cursor.Current =Cursors.Default;

            }
		}
        /// <summary>
        /// 撤销操作
        /// </summary>
		public void Undo()
		{
			switch(clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl.GetType().Name)
			{
				case "dwtBorderTextBox":
				case "ctlBorderTextBox":
				case "TextBox":
				case "RichTextBox":
					((TextBoxBase)clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl).Undo();
					break;
                case "ctlRichTextBox":
                    {
                        if(clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl.GetType().FullName == 
                            "com.digitalwave.Utility.Controls.ctlRichTextBox")
                            ((ctlRichTextBox)clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl).m_mthUndo();
                        else if(clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl.GetType().FullName == 
                            "com.digitalwave.controls.ctlRichTextBox")
                            ((com.digitalwave.controls.ctlRichTextBox)clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl).m_mthUndo();
                    }
                    break;
			}
		}
        /// <summary>
        /// 重做
        /// </summary>
		public void Redo()
		{
			switch(clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl.GetType().Name)
			{
				case "RichTextBox":
					((RichTextBox)clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl).Redo();
					break;
				case "dwtBorderTextBox":
				case "ctlBorderTextBox":
				case "TextBox":
					((TextBoxBase)clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl).Undo();
					break;
				case "ctlRichTextBox":
                    {
                        if (clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl.GetType().FullName ==
                            "com.digitalwave.Utility.Controls.ctlRichTextBox")
                            ((ctlRichTextBox)clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl).m_mthRedo();
                        else if (clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl.GetType().FullName ==
                            "com.digitalwave.controls.ctlRichTextBox")
                            ((com.digitalwave.controls.ctlRichTextBox)clsEMRLogin.s_FrmMDI.ActiveMdiChild.ActiveControl).m_mthRedo();
                    }
					break;
			}
		}
        /// <summary>
        /// 退出
        /// </summary>
		public void Exit()
		{
			Form activeform;			
				
			if (clsEMRLogin.s_FrmMDI.ActiveMdiChild  == null)
				clsEMRLogin.s_FrmMDI.Close();
			else
			{
				Cursor.Current =Cursors.WaitCursor;
				activeform=clsEMRLogin.s_FrmMDI.ActiveMdiChild ;
				activeform.Close() ; 
				Cursor.Current =Cursors.Default;
			}
		}


		/// <summary>
		/// 生成模板
		/// </summary>
		public void NewTemplate()
		{
			if (clsEMRLogin.s_FrmMDI.ActiveMdiChild  != null)
			{
				frmRecordsBase frmRecords = clsEMRLogin.s_FrmMDI.ActiveMdiChild as frmRecordsBase;

				if(frmRecords != null && frmRecords.m_FrmCurrentSub != null)
				{
					frmRecords.m_FrmCurrentSub.m_mthNewTemplateWithThis();						
				}
				else if(clsEMRLogin.s_FrmMDI.ActiveMdiChild is frmHRPBaseForm)
				{
					((frmHRPBaseForm)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).m_mthNewTemplate(); 
				}

			}
		}

		/// <summary>
		/// 生成常用值模板
		/// </summary>
		public void NewCommonUseTemplate()
		{
			if (clsEMRLogin.s_FrmMDI.ActiveMdiChild  != null)
			{
				frmRecordsBase frmRecords = clsEMRLogin.s_FrmMDI.ActiveMdiChild as frmRecordsBase;

				if(frmRecords != null && frmRecords.m_FrmCurrentSub != null)
				{
					frmRecords.m_FrmCurrentSub.m_mthNewCommonUseWithThis();						
				}
				else if(clsEMRLogin.s_FrmMDI.ActiveMdiChild is frmHRPBaseForm)
				{
					((frmHRPBaseForm)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).m_mthNewCommonUse(); 
				}

			}
		}

		/// <summary>
		/// 生成默认值
		/// </summary>
		public void SetDefault()
		{
			if (clsEMRLogin.s_FrmMDI.ActiveMdiChild  != null)
			{
				Form frmParent = clsEMRLogin.s_FrmMDI.ActiveMdiChild;

				clsDefaultValueTool objTool = null;

				if(clsEMRLogin.s_FrmMDI.ActiveMdiChild is frmRecordsBase)
				{
					frmRecordsBase frmActive = (frmRecordsBase)clsEMRLogin.s_FrmMDI.ActiveMdiChild;
					if(frmActive.m_FrmCurrentSub != null)
					{
						objTool = new clsDefaultValueTool(frmActive.m_FrmCurrentSub);
						frmParent = frmActive.m_FrmCurrentSub;
					}
				}
				else if(clsEMRLogin.s_FrmMDI.ActiveMdiChild is frmHRPBaseForm)
					objTool = new clsDefaultValueTool(clsEMRLogin.s_FrmMDI.ActiveMdiChild,MDIParent.s_ObjCurrentPatient);	

				if(objTool != null)
				{
					if(clsPublicFunction.ShowQuestionMessageBox(frmParent,"注意！保存默认值后将会覆盖原来的默认值，这样可能会引起数据混乱，在未确定您所输入的默认值是否为正常的默认值时，请不要随便保存，是否继续？") == DialogResult.Yes)
						objTool.m_mthSaveDefaultValue();
				}

			}
		}

		/// <summary>
		/// 重置默认值
		/// </summary>
		public void ResetDefault()
		{
			if (clsEMRLogin.s_FrmMDI.ActiveMdiChild  != null)
			{					
				Form frmParent = clsEMRLogin.s_FrmMDI.ActiveMdiChild;

				clsDefaultValueTool objTool = null;

				if(clsEMRLogin.s_FrmMDI.ActiveMdiChild is frmRecordsBase)
				{
					frmRecordsBase frmActive = (frmRecordsBase)clsEMRLogin.s_FrmMDI.ActiveMdiChild;
					if(frmActive.m_FrmCurrentSub != null)
					{
						objTool = new clsDefaultValueTool(frmActive.m_FrmCurrentSub,MDIParent.s_ObjCurrentPatient);
						frmParent = frmActive.m_FrmCurrentSub;
					}
				}
						else if(clsEMRLogin.s_FrmMDI.ActiveMdiChild is frmHRPBaseForm)
					objTool = new clsDefaultValueTool(clsEMRLogin.s_FrmMDI.ActiveMdiChild,MDIParent.s_ObjCurrentPatient);

				if(objTool != null)
				{
					if(clsPublicFunction.ShowQuestionMessageBox(frmParent,"是否重置默认值？") == DialogResult.Yes)
					{
						objTool.m_BlnReplaceDataShare = false;
						objTool.m_mthSetDefaultValue();
					}
				}

			}
		}

		
		public void Approve()
		{
			if(clsEMRLogin.s_FrmMDI.ActiveMdiChild==null)
				return;

			Cursor.Current =Cursors.WaitCursor;
			try
			{
				//把子窗体造为frmHRPBaseForm				
				((frmHRPBaseForm)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).m_lngApprove(); 
			}
			catch(InvalidCastException)//造型错误，因为有些窗体不是继承frmHRPBaseForm的
			{
			}
			Cursor.Current =Cursors.Default;
		}

		public void Unapprove()
		{
			if(clsEMRLogin.s_FrmMDI.ActiveMdiChild==null)
				return;

			Cursor.Current =Cursors.WaitCursor;
			try
			{				
				((frmHRPBaseForm)(clsEMRLogin.s_FrmMDI.ActiveMdiChild)).m_lngUnApprove(); 
			}
			catch(InvalidCastException)
			{
			}
			Cursor.Current =Cursors.Default;
		}

	}
}
