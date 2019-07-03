using System;
using System.Windows ;
using System.Windows.Forms ;
using System.Data ;
using System.Collections ;
using iCareData ;
using com.digitalwave.MedicalExamService ;
using com.digitalwave.Utility ; 
using com.digitalwave.Utility.Controls ;

namespace iCare
{
	/// <summary>
	/// Summary description for clsDonotRun.
	/// </summary>
	internal class clsMedicalExamWithControlValue
	{
		public string m_strControlType;
		public string m_strControlName;
		public string m_strControlText;
		public clsMedicalExamMainRecordValue m_objclsMedicalExamMainRecord=new clsMedicalExamMainRecordValue();
	}

	public class clsMedicalExamDomain
	{
		public clsMedicalExamDomain()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public clsMedicalExamDomain (Form p_frmInput)
		{
			m_mthInitLoadAllMedicalExamControls(p_frmInput );
		}


		#region 清空体格检查控件,刘颖源,2003-5-26 11:10:49
		public void m_mthClearMedicalExamControls(Form p_frmInput)
		{
			m_mthInitLoadAllMedicalExamControls(p_frmInput );
			//Control [] ccc=(Control []) m_objArrMedicalExamControls.ToArray (typeof(Control ));

			for(int i=0;i<m_objArrMedicalExamControls.Count ;i++)
			{
				Control ctlMedicalExam=(Control )m_objArrMedicalExamControls[i];
				switch(ctlMedicalExam.GetType().Name)
				{ 
					case "ctlComboBox":
						((ctlComboBox )ctlMedicalExam).SelectedIndex =-1;
						break;
					case "ComboBox":		//单选,使用ComboBox来实现
						((ComboBox )ctlMedicalExam).SelectedIndex =-1;
						break;
					case "ctlBorderTextBox":
					case "RichTextBox":			//文本(含单选，多选中的文本) 
					case "TextBox":
						ctlMedicalExam.Text ="";
						break;
					case "RadioButton":		//单选，使用RadioButton Group来实现
						((RadioButton )ctlMedicalExam).Checked =false;
						break;
					case "CheckBox":		//多选
						//保存所有的多选选项
						((CheckBox)ctlMedicalExam).Checked =false;
						break;
					case "CheckedListBox":
						CheckedListBox ctl=(CheckedListBox) ctlMedicalExam ;
						for(int l=0;l<ctl.Items.Count ;l++)
							ctl.SetItemChecked (l,false);						
						break;
				}

			}
		}
		#endregion

		#region 成员变量,刘颖源,2003-5-22 10:52:42
		ArrayList m_objArrMedicalExamControls=new ArrayList ();		//保存所有的体格检查控件
		ArrayList m_objArrMainRecordWithControls=new ArrayList ();				//保存所有主记录
		ArrayList m_objArrDetailRecord=new ArrayList ();			//保存所有Detail记录
        //clsMedicalExamService m_objMedicalExamSer=new clsMedicalExamService();
		private bool m_blnInitialzed=false;
		#endregion

		#region 获得中括号中指定位置的字符串,刘颖源,2003-5-22 11:05:43
		private string strGetBracketString(string p_strSource,int p_intIndex)
		{
			int i=p_strSource.IndexOf ("[" ,0) ;
			int j=0;
			int intOld=i;
			while(i>=0 && j<=p_intIndex )
			{
				intOld=i;
				i=p_strSource.IndexOf("[",i+1);
				j++;
			}
			j=p_strSource.IndexOf ("]",intOld +1);
			if(j>intOld )
				return(p_strSource.Substring (intOld+1 ,j-intOld -1));
			else
				return("-1");
		}

		#endregion

		#region 获得体格检查ID,刘颖源,2003-5-22 11:12:56
		private string strGetMedicalExamID()
		{
            string strMedicalExam_ID = "";

            clsMedicalExamService m_objMedicalExamSer =
                (clsMedicalExamService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedicalExamService));

            try
            {
                strMedicalExam_ID = m_objMedicalExamSer.strGetMedicalExam_ID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial);
            }
            finally
            {
                //m_objMedicalExamSer.Dispose();
            }
			if(strMedicalExam_ID ==null || strMedicalExam_ID.Trim () =="")
				return("00000000000000000001");
			else
				return(strMedicalExam_ID);
		}
		#endregion

		#region 利用递归调用,得到所有体格检查的Tag的信息,刘颖源,2003-5-22 10:38:17
		private void m_mthLoadAllMedicalExamControlInfo(Control p_ctlControl)
		{
			if(p_ctlControl.Tag !=null && p_ctlControl.Tag.ToString().Length >1 && p_ctlControl.Tag.ToString().Substring (0,1)=="[")
			{		
				m_objArrMedicalExamControls.Add  (p_ctlControl);
			}

			if(p_ctlControl.HasChildren )
			{
				foreach(Control subcontrol in p_ctlControl.Controls )
				{
					m_mthLoadAllMedicalExamControlInfo(subcontrol );
				}
			}		
		}
		#endregion

		#region 读入所有的体格检查控件,刘颖源,2003-5-23 16:23:26
		private void m_mthInitLoadAllMedicalExamControls(Form p_frmInput)
		{
			if(m_blnInitialzed)return;
			m_objArrMedicalExamControls.Clear ();
			m_mthLoadAllMedicalExamControlInfo(p_frmInput );
			if(m_objArrMedicalExamControls.Count >0)
				m_blnInitialzed=true;
		}

		private void m_mthInitLoadAllMedicalExamControls1(Control p_ctl)
		{
			if(m_blnInitialzed)return;
			m_objArrMedicalExamControls.Clear ();
			m_mthLoadAllMedicalExamControlInfo(p_ctl );
			if(m_objArrMedicalExamControls.Count >0)
				m_blnInitialzed=true;
		}
		#endregion

		#region 保存体格检查选项,刘颖源,2003-5-23 16:29:57
		//Control.Tag="[0][0001][000001][0]"	==> [OptionType][ElementID][OptionID][Index]
		public void m_mthSaveMedicalExamRecord(Form p_frmInput,string p_strCateGory_ID,clsMedicalExamInHospital_TargetValue p_objMedicalExamInHospital_Target)
		{
			m_objArrDetailRecord.Clear ();
			m_objArrMainRecordWithControls.Clear ();
			
			m_mthInitLoadAllMedicalExamControls (p_frmInput);
			
			#region 把体格检查控件信息转入到结构体中,刘颖源,2003-5-23 13:15:05
			string strCurrentDate=DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss");
			if(p_objMedicalExamInHospital_Target.m_strMedicalExam_ID ==null || p_objMedicalExamInHospital_Target.m_strMedicalExam_ID =="") 
				p_objMedicalExamInHospital_Target.m_strMedicalExam_ID= strGetMedicalExamID();

			long lngDetailIndex=1;
			for(int ii=0;ii<m_objArrMedicalExamControls.Count ;ii++ )
			{
				//当前要记录的控件
				clsMedicalExamWithControlValue objMedicalExamControlsInfo=new clsMedicalExamWithControlValue();

				Control ctlMedicalExam=(Control)m_objArrMedicalExamControls[ii];
				string strTag=ctlMedicalExam.Tag.ToString ();
				

				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strMedicalExam_ID= p_objMedicalExamInHospital_Target.m_strMedicalExam_ID;

				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strCategory_ID= p_strCateGory_ID;
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID=strGetBracketString(strTag,1);
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID=strGetBracketString(strTag,2);
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strActivity_Date=strCurrentDate;
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type=strGetBracketString(strTag,0);
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index ="-1";
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text ="";
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text ="";
				objMedicalExamControlsInfo.m_strControlType =ctlMedicalExam.GetType().Name  ;
				objMedicalExamControlsInfo.m_strControlName =ctlMedicalExam.Name ;
				objMedicalExamControlsInfo.m_strControlText =ctlMedicalExam.Text ;
				//写入用户输入信息
				switch(ctlMedicalExam.GetType().Name)
				{ 
					case "ctlComboBox":
						if(((ctlComboBox)ctlMedicalExam).SelectedIndex >=0 && ((ctlComboBox)ctlMedicalExam).SelectedIndex < ((ctlComboBox)ctlMedicalExam).GetItemsCount())
						{
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index=((ctlComboBox)ctlMedicalExam).SelectedIndex.ToString ();
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ctlComboBox)ctlMedicalExam).Text ;
						}
						else if(((ctlComboBox)ctlMedicalExam).Text !=null)
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ctlComboBox)ctlMedicalExam).Text ;

						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="1";
						break;
					case "ComboBox":		//单选,使用ComboBox来实现
						if(((ComboBox)ctlMedicalExam).SelectedIndex >=0 && ((ComboBox)ctlMedicalExam).SelectedIndex < ((ComboBox)ctlMedicalExam).Items.Count )
						{
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index=((ComboBox)ctlMedicalExam).SelectedIndex.ToString ();
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ComboBox)ctlMedicalExam).Text ;
						}
						else if(((ComboBox)ctlMedicalExam).Text !=null)
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ComboBox)ctlMedicalExam).Text ;

						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="1";
						break;
					case "ctlBorderTextBox":
					case "RichTextBox":			//文本(含单选，多选中的文本) 
					case "TextBox":
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord. m_strSelected_Option_Text=ctlMedicalExam.Text;						
						//objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index =strGetBracketString(strTag,3);
						break;
					case "RadioButton":		//单选，使用RadioButton Group来实现
						if(((RadioButton )ctlMedicalExam).Checked )
						{
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index =strGetBracketString(strTag,3);
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text =  ((RadioButton )ctlMedicalExam).Text ;
						}
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="1";
						break;
					case "CheckBox":		//多选
						//保存所有的多选选项
						if(((CheckBox)ctlMedicalExam).Checked )
						{
							clsMedicalExamDetailRecordValue objMedicalExamDetailRecordRecord=new clsMedicalExamDetailRecordValue();
							objMedicalExamDetailRecordRecord.m_strActivity_Date =strCurrentDate ;
							objMedicalExamDetailRecordRecord.m_strCategory_ID =p_strCateGory_ID;
							objMedicalExamDetailRecordRecord.m_strDetailItem_ID =lngDetailIndex.ToString ("0000");
							objMedicalExamDetailRecordRecord.m_strElement_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID;
							objMedicalExamDetailRecordRecord.m_strMedicalExam_ID =strGetMedicalExamID ();
							objMedicalExamDetailRecordRecord.m_strOption_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID;
							objMedicalExamDetailRecordRecord.m_strSelected_Option_Indexes 	=strGetBracketString(strTag,3);
							objMedicalExamDetailRecordRecord.m_strSelected_OptionValue_Text =ctlMedicalExam.Text;
							m_objArrDetailRecord.Add (objMedicalExamDetailRecordRecord);
							lngDetailIndex++;
						}
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="2";
						break;
					case "CheckedListBox":
						CheckedListBox ctl=(CheckedListBox)ctlMedicalExam;
						for(int l=0;l<ctl.Items.Count ;l++)
						{
							if(ctl.GetItemChecked(l))
							{
								clsMedicalExamDetailRecordValue objMedicalExamDetailRecordRecord=new clsMedicalExamDetailRecordValue();
								objMedicalExamDetailRecordRecord.m_strActivity_Date =strCurrentDate ;
								objMedicalExamDetailRecordRecord.m_strCategory_ID =p_strCateGory_ID;
								objMedicalExamDetailRecordRecord.m_strDetailItem_ID =lngDetailIndex.ToString ("0000");
								objMedicalExamDetailRecordRecord.m_strElement_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID;
								objMedicalExamDetailRecordRecord.m_strMedicalExam_ID =strGetMedicalExamID ();
								objMedicalExamDetailRecordRecord.m_strOption_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID;																
								objMedicalExamDetailRecordRecord.m_strSelected_Option_Indexes =l.ToString ();
								objMedicalExamDetailRecordRecord.m_strSelected_OptionValue_Text = ctl.Items [l].ToString ();							
								m_objArrDetailRecord.Add (objMedicalExamDetailRecordRecord);
								lngDetailIndex ++;
							}
						}
						break;
				}
				m_objArrMainRecordWithControls.Add (objMedicalExamControlsInfo);
			}
			#endregion
			
			//clsMedicalExamWithControlValue[] aa=(clsMedicalExamWithControlValue [])m_objArrMainRecordWithControls.ToArray (typeof(clsMedicalExamWithControlValue));

			#region 合并同组控件作为同一条记录,刘颖源,2003-5-23 13:15:05
			//合并同一条记录中的Control
			clsMedicalExamWithControlValue objMedicalExamWithControl=null;
			clsMedicalExamMainRecordValue objMedicalExamRecord=null;
			ArrayList objArrMedicalExamMainRecordsToDb=new ArrayList ();
			objArrMedicalExamMainRecordsToDb.Clear ();
			int intControlsInSameRecord=-1;
			for(int i=0;i<m_objArrMainRecordWithControls.Count ;i++)
			{
				objMedicalExamWithControl=(clsMedicalExamWithControlValue)m_objArrMainRecordWithControls[i];

				#region 查找是否已经加入过此控件的记录,对于使用RadioBox组和CheckBox组(包含其中的TextBox)才出现此情况,刘颖源,2003-5-23 13:17:48
				intControlsInSameRecord=-1;
//				if(objMedicalExamWithControl.m_strControlType =="RadioButton" || 
//					objMedicalExamWithControl.m_strControlType =="CheckBox" ||
//					objMedicalExamWithControl.m_strControlType == "TextBox" ||
//					objMedicalExamWithControl.m_strControlType =="RichTextBox" ||
//					objMedicalExamWithControl.m_strControlType =="ctlBorderTextBox" )
				for(int j=0;j<objArrMedicalExamMainRecordsToDb.Count ;j++)
				{
					objMedicalExamRecord=(clsMedicalExamMainRecordValue) objArrMedicalExamMainRecordsToDb[j];
					//是否在MainRecord中表示同一条记录中的多个控件
					if(objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strElement_ID == objMedicalExamRecord.m_strElement_ID &&
						objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strOption_ID == objMedicalExamRecord.m_strOption_ID )
						intControlsInSameRecord=j;			//记录下已经有的Index
				}
				#endregion

				#region 合并同组控件为一条记录,刘颖源,2003-5-23 13:19:40
				if(intControlsInSameRecord==-1)				//从来没有加入过此控件选项
					objArrMedicalExamMainRecordsToDb.Add (objMedicalExamWithControl.m_objclsMedicalExamMainRecord );
				else		//是同一条记录中的信息，加入此部分信息
				{
					//对于纯文本情况应绝对不会执行到此，OptionID肯定唯一
					//单选的情况,RadioBox实现同一条记录内容
					if(int.Parse (objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strOption_Type )==1)	//单选
					{
						//丰富原来记录信息
						clsMedicalExamMainRecordValue objOldRecord=(clsMedicalExamMainRecordValue)objArrMedicalExamMainRecordsToDb[intControlsInSameRecord];
						//对于单选中的文本，如果选中了'其他'时候，使用控件的Tag属性更新该记录信息，
						//否则（没有选中'其他'），不要随便更新Index和OptionValue信息,OptionText可以设置为空
						if((objMedicalExamWithControl.m_strControlType =="TextBox" || 
							objMedicalExamWithControl.m_strControlType =="RichTextBox" || 
							objMedicalExamWithControl.m_strControlType =="ctlBorderTextBox") && 
							objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index == objOldRecord.m_strSelected_Option_Index )
						{
							objOldRecord.m_strSelected_Option_Text =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text   ;
						}
						else
						{
							//能设置属性，肯定是已经选中了的单选控件,objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index !=""表示该控件选中
							if(objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index !="")
							{
								objOldRecord.m_strSelected_Option_Index =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index;
								objOldRecord.m_strSelected_OptionValue_Text =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text ;
							}
						}
						objArrMedicalExamMainRecordsToDb.RemoveAt (intControlsInSameRecord);
						objArrMedicalExamMainRecordsToDb.Add (objOldRecord);
					}
					else		//多选，使用GroupBox组实现同一条记录内容
					{
						clsMedicalExamMainRecordValue objOldRecord=(clsMedicalExamMainRecordValue)objArrMedicalExamMainRecordsToDb[intControlsInSameRecord];

						objOldRecord.m_strSelected_Option_Index ="" ;
						objOldRecord.m_strSelected_OptionValue_Text ="";
						if(objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text !="")
							objOldRecord.m_strSelected_Option_Text =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text;			
						objArrMedicalExamMainRecordsToDb.RemoveAt (intControlsInSameRecord);
						objArrMedicalExamMainRecordsToDb.Add (objOldRecord);
					}

				}
				#endregion
			}
			#endregion

			//开始写入数据库
			//clsMedicalExamMainRecordValue [] bb=(clsMedicalExamMainRecordValue [])objArrMedicalExamMainRecordsToDb.ToArray (typeof(clsMedicalExamMainRecordValue));
			long lngEff=0;
			lngSaveMedicalExam(p_objMedicalExamInHospital_Target,objArrMedicalExamMainRecordsToDb ,m_objArrDetailRecord ,ref lngEff );
		}
		private long lngSaveMedicalExam(clsMedicalExamInHospital_TargetValue p_objMedicalExamInHospital_Target, ArrayList p_objMedicalExamMainRecord,ArrayList p_objMedicalDetalRecord,ref long lngEff)
		{
            clsMedicalExamService m_objMedicalExamSer =
                (clsMedicalExamService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedicalExamService));

            long lngRes = 0;
            try
            {
                lngRes = m_objMedicalExamSer.lngSaveMedicalExam(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objMedicalExamInHospital_Target, p_objMedicalExamMainRecord, p_objMedicalDetalRecord, ref lngEff);
            }
            finally
            {
                //m_objMedicalExamSer.Dispose();
            }
            return lngRes;
		}
		#endregion

		#region 显式体格检查项目选项,刘颖源,2003-5-23 16:31:15
		public void m_mthDisplayMedicalExamOptions(Form p_frmInput,string p_strMedicalExam_ID)
		{
			m_mthInitLoadAllMedicalExamControls(p_frmInput);
			m_mthClearMedicalExamControls(p_frmInput );
			clsMedicalExamMainRecordValue[] objMedicalExamMainRecord=null;
			clsMedicalExamDetailRecordValue[] objMedicalDetailRecord=null;

            clsMedicalExamService m_objMedicalExamSer =
                (clsMedicalExamService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedicalExamService));

            long lngRes = 0;
            try
            {
                lngRes = m_objMedicalExamSer.lngLoadMedicalExamOptions(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strMedicalExam_ID, out objMedicalExamMainRecord, out objMedicalDetailRecord);
            }
            finally
            {
                //m_objMedicalExamSer.Dispose();
            }
			#region 设置MainRecord的值,刘颖源,2003-5-23 17:24:22
			if(objMedicalExamMainRecord !=null && objMedicalExamMainRecord.Length >0)
			{
				for(int i=0;i<objMedicalExamMainRecord.Length ;i++)
				{
					clsMedicalExamMainRecordValue objMedicalExamMainInfo=objMedicalExamMainRecord[i];

					objMedicalExamMainInfo.m_strSelected_Option_Index =(objMedicalExamMainInfo.m_strSelected_Option_Index ==null? "-1":objMedicalExamMainInfo.m_strSelected_Option_Index );
					objMedicalExamMainInfo.m_strSelected_Option_Text =(objMedicalExamMainInfo.m_strSelected_Option_Text ==null ? "":objMedicalExamMainInfo.m_strSelected_Option_Text );
					objMedicalExamMainInfo.m_strSelected_OptionValue_Text =(objMedicalExamMainInfo.m_strSelected_OptionValue_Text ==null ? "": objMedicalExamMainInfo.m_strSelected_OptionValue_Text );

					//寻找设置了该属性的控件
					for(int j=0;j<m_objArrMedicalExamControls.Count ;j++)
					{
						clsMedicalExamWithControlValue objMedicalExamControlsInfo=new clsMedicalExamWithControlValue();
						Control ctlMedicalExam=(Control)m_objArrMedicalExamControls[j];

						string strTag=ctlMedicalExam.Tag.ToString ();
												
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID=strGetBracketString(strTag,1);
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID=strGetBracketString(strTag,2);						
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type=strGetBracketString(strTag,0);
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index =strGetBracketString (strTag,3);
						switch(ctlMedicalExam.GetType().Name )
						{
							case "ctlBorderTextBox":
							case "RichTextBox":			//文本(含单选，多选中的文本) 
							case "TextBox":
								if(objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID == objMedicalExamMainInfo.m_strElement_ID &&
									objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID == objMedicalExamMainInfo.m_strOption_ID) 
								ctlMedicalExam.Text =objMedicalExamMainInfo.m_strSelected_Option_Text ;
								break;				
							case "RadioButton":
								if(objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID == objMedicalExamMainInfo.m_strElement_ID &&
									objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID == objMedicalExamMainInfo.m_strOption_ID &&
									objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index == objMedicalExamMainInfo.m_strSelected_Option_Index ) 
								((RadioButton )ctlMedicalExam).Checked =true;
								break;
							case "ctlComboBox":
								if(objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID == objMedicalExamMainInfo.m_strElement_ID &&
									objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID == objMedicalExamMainInfo.m_strOption_ID) 
								{
									if(((ctlComboBox)ctlMedicalExam).GetItemsCount()    >0 && 
										objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index !=null &&
										int.Parse (objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index)<((ctlComboBox)ctlMedicalExam).GetItemsCount () )
										((ctlComboBox)ctlMedicalExam).SelectedIndex =int.Parse (objMedicalExamMainInfo.m_strSelected_Option_Index );
								}
								break;
							case "ComboBox":
								if(objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID == objMedicalExamMainInfo.m_strElement_ID &&
									objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID == objMedicalExamMainInfo.m_strOption_ID) 
								{
									if(((ComboBox)ctlMedicalExam).Items.Count   >0 && 
										objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index !=null &&
										int.Parse (objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index)<((ComboBox)ctlMedicalExam).Items.Count   )
									((ComboBox)ctlMedicalExam).SelectedIndex =int.Parse (objMedicalExamMainInfo.m_strSelected_Option_Index );
								}
									break;

						}
						
					}
				}
			}
			#endregion

			#region 设置Detail Record的值,刘颖源,2003-5-23 17:25:14
			if(objMedicalDetailRecord !=null && objMedicalDetailRecord.Length >0)
			{
				for(int i=0;i<objMedicalDetailRecord.Length ;i++)
				{					
					clsMedicalExamDetailRecordValue objMedicalExamDetailInfo=objMedicalDetailRecord[i];
					//寻找设置了该属性的控件
					for(int j=0;j<m_objArrMedicalExamControls.Count ;j++)
					{
						clsMedicalExamDetailRecordValue objMedicalExamDetailRecordRecord=new clsMedicalExamDetailRecordValue();
						Control ctlMedicalExam=(Control)m_objArrMedicalExamControls[j];

						string strTag=ctlMedicalExam.Tag.ToString ();
												
						objMedicalExamDetailRecordRecord.m_strElement_ID=strGetBracketString(strTag,1);
						objMedicalExamDetailRecordRecord.m_strOption_ID=strGetBracketString(strTag,2);
						objMedicalExamDetailRecordRecord.m_strSelected_Option_Indexes =strGetBracketString(strTag,3);
						switch(ctlMedicalExam.GetType().Name )
						{
							case "CheckBox":
								if(objMedicalExamDetailRecordRecord.m_strElement_ID == objMedicalExamDetailInfo.m_strElement_ID &&
									objMedicalExamDetailRecordRecord.m_strOption_ID == objMedicalExamDetailInfo.m_strOption_ID &&
									objMedicalExamDetailRecordRecord.m_strSelected_Option_Indexes  == objMedicalExamDetailInfo.m_strSelected_Option_Indexes ) 
									((CheckBox )ctlMedicalExam).Checked =true;
								break;
							case "CheckedListBox":
								if(objMedicalExamDetailRecordRecord.m_strElement_ID == objMedicalExamDetailInfo.m_strElement_ID &&
									objMedicalExamDetailRecordRecord.m_strOption_ID == objMedicalExamDetailInfo.m_strOption_ID)
								{
									CheckedListBox ctl=(CheckedListBox )ctlMedicalExam;
									if(objMedicalExamDetailRecordRecord.m_strSelected_Option_Indexes !=null && int.Parse (objMedicalExamDetailInfo.m_strSelected_Option_Indexes)<ctl.Items.Count ) 
										ctl.SetItemChecked  (int.Parse (objMedicalExamDetailInfo.m_strSelected_Option_Indexes),true); 
								}
								break;
								
						}
						
					}

				}
			}
			#endregion

		}
		#endregion

		#region 合成字符串,刘颖源,2003-5-26 12:31:34
		public string m_strGetMedicalExamUnitString(string p_strMedicalExamID)
		{
			clsMedicalExamUnitStringValue [] objMedicalExamUnitString=null;

            clsMedicalExamService m_objMedicalExamSer =
                (clsMedicalExamService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedicalExamService));

            long lngRes = 0;
            try
            {
                lngRes =m_objMedicalExamSer.lngGetMedicalExamUnitString (clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strMedicalExamID,out objMedicalExamUnitString);
            }
            finally
            {
                //m_objMedicalExamSer.Dispose();
            }
			if(objMedicalExamUnitString==null || objMedicalExamUnitString.Length <=0)return("");
			#region 合并字符串,刘颖源,2003-5-27 8:56:02
			ArrayList objArrMedicalExamUnitString=new ArrayList ();
			objArrMedicalExamUnitString.Clear ();
			bool blnIsSeries2=false;
			string strOutput="";
			string strElement_ID=objMedicalExamUnitString[0].m_strElement_ID ;
			string strOption_ID=objMedicalExamUnitString[0].m_strOption_ID ;
			for(int i=0;i<objMedicalExamUnitString.Length ;i++)
			{

				switch(int.Parse (objMedicalExamUnitString[i].m_strOption_Type))
				{
					case 0:
					case 1:
						blnIsSeries2=false;
						objArrMedicalExamUnitString.Add (objMedicalExamUnitString[i]);
						break;
					case 2:
						if(blnIsSeries2==false)
						{
							clsMedicalExamUnitStringValue objTempMedicalUnitString=objMedicalExamUnitString[i];		//更新最后一条记录
							objTempMedicalUnitString.m_strSelected_OptionValue_DetailText = objMedicalExamUnitString[i].m_strSelected_OptionValue_DetailText + "、"; 
							objArrMedicalExamUnitString.Add (objTempMedicalUnitString );
						}
						else
						{
							int intMedicalIndex=objArrMedicalExamUnitString.Count -1;
							clsMedicalExamUnitStringValue objTempMedicalUnitString=(clsMedicalExamUnitStringValue) objArrMedicalExamUnitString[intMedicalIndex];		//更新最后一条记录
							objTempMedicalUnitString.m_strSelected_OptionValue_DetailText += objMedicalExamUnitString[i].m_strSelected_OptionValue_DetailText + "、"; 
							objArrMedicalExamUnitString.RemoveAt (intMedicalIndex );
							objArrMedicalExamUnitString.Add (objTempMedicalUnitString );
						}
						blnIsSeries2=true;							
						break;
				}
			}
			#endregion

			#region 生成字符串,刘颖源,2003-5-27 9:11:20
			string strOldElement_ID="";
			for(int i=0;i<objArrMedicalExamUnitString.Count ;i++)
			{
				clsMedicalExamUnitStringValue objTempMedicalUnitString=(clsMedicalExamUnitStringValue) objArrMedicalExamUnitString[i];
				if(i==0)
				{
					strOldElement_ID =objTempMedicalUnitString.m_strElement_ID ;
					strOutput=objTempMedicalUnitString.m_strElementName + ":\r\n";
				}
				if(objTempMedicalUnitString.m_strElement_ID !=strOldElement_ID)
				{
					strOutput +="\r\n\r\n" + objTempMedicalUnitString.m_strElementName + ":\r\n";
					strOldElement_ID=objTempMedicalUnitString.m_strElement_ID;
				}
				switch(int.Parse (objTempMedicalUnitString.m_strOption_Type ))
				{
					case 0:
						if(objTempMedicalUnitString.m_strSelected_Option_Text.Trim () !="")
							strOutput +=objTempMedicalUnitString.m_strOption_Name  + objTempMedicalUnitString.m_strSelected_Option_Text ;
						break;
					case 1:
						if(objTempMedicalUnitString.m_strSelected_Option_Text !=null && objTempMedicalUnitString.m_strSelected_Option_Text !="")
							strOutput +=objTempMedicalUnitString.m_strOption_Name + objTempMedicalUnitString.m_strSelected_OptionValue_Text + "(" + objTempMedicalUnitString.m_strSelected_Option_Text + ")" ;
						else
							strOutput +=objTempMedicalUnitString.m_strOption_Name + objTempMedicalUnitString.m_strSelected_OptionValue_Text;
						break;
					case 2:
						if(objTempMedicalUnitString.m_strSelected_OptionValue_DetailText.Length >0)
							objTempMedicalUnitString.m_strSelected_OptionValue_DetailText=objTempMedicalUnitString.m_strSelected_OptionValue_DetailText.Substring (0,objTempMedicalUnitString.m_strSelected_OptionValue_DetailText.Length -1);
						if(objTempMedicalUnitString.m_strSelected_Option_Text !=null && objTempMedicalUnitString.m_strSelected_Option_Text !="")
							strOutput +=objTempMedicalUnitString.m_strOption_Name + objTempMedicalUnitString.m_strSelected_OptionValue_DetailText  + "(" + objTempMedicalUnitString.m_strSelected_Option_Text + ")" ;
						else
							strOutput +=objTempMedicalUnitString.m_strOption_Name+ objTempMedicalUnitString.m_strSelected_OptionValue_DetailText;
						break;
				}
				strOutput+="; ";

																				
			}
			
			#endregion
			return(strOutput);
		}
		#endregion

		public string strGetInPatientCaseMedicalExam_ID(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate)
		{
            clsMedicalExamService m_objMedicalExamSer =
                (clsMedicalExamService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedicalExamService));

            string strRes = "";
            try
            {
                strRes = (m_objMedicalExamSer.strGetInPatientCaseMedicalExam_ID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate));
            }
            finally
            {
                //m_objMedicalExamSer.Dispose();
            }
            return strRes;
		}

		#region 合成字符串2,刘颖源,2003-6-3 12:31:34
//		public string m_strGetMedicalExamUnitString(Form p_frmInput)
//		{
//			#region 555
//						m_objArrDetailRecord.Clear ();
//						m_objArrMainRecordWithControls.Clear ();
//						
//						m_mthInitLoadAllMedicalExamControls (p_frmInput);
//						
//						#region 把体格检查控件信息转入到结构体中,刘颖源,2003-5-23 13:15:05
//						string strCurrentDate=DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss");
//
//						long lngDetailIndex=1;
//						for(int ii=0;ii<m_objArrMedicalExamControls.Count ;ii++ )
//						{
//							//当前要记录的控件
//							clsMedicalExamWithControlValue objMedicalExamControlsInfo=new clsMedicalExamWithControlValue();
//
//							Control ctlMedicalExam=(Control)m_objArrMedicalExamControls[ii];
//							string strTag=ctlMedicalExam.Tag.ToString ();
//							
//
//
//							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID=strGetBracketString(strTag,1);
//							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID=strGetBracketString(strTag,2);
//							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strActivity_Date=strCurrentDate;
//							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type=strGetBracketString(strTag,0);
//							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index ="";
//							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text ="";
//							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text ="";
//							objMedicalExamControlsInfo.m_strControlType =ctlMedicalExam.GetType().Name  ;
//							objMedicalExamControlsInfo.m_strControlName =ctlMedicalExam.Name ;
//							objMedicalExamControlsInfo.m_strControlText =ctlMedicalExam.Text ;
//							//写入用户输入信息
//							switch(ctlMedicalExam.GetType().Name)
//							{ 
//								case "ctlComboBox":
//									if(((ctlComboBox)ctlMedicalExam).SelectedIndex >=0 && ((ctlComboBox)ctlMedicalExam).SelectedIndex < ((ctlComboBox)ctlMedicalExam).GetItemsCount())
//									{
//										objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index=((ctlComboBox)ctlMedicalExam).SelectedIndex.ToString ();
//										objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ctlComboBox)ctlMedicalExam).Text ;
//									}
//									else if(((ctlComboBox)ctlMedicalExam).Text !=null)
//										objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ctlComboBox)ctlMedicalExam).Text ;
//
//									objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="1";
//									break;
//								case "ComboBox":		//单选,使用ComboBox来实现
//									if(((ComboBox)ctlMedicalExam).SelectedIndex >=0 && ((ComboBox)ctlMedicalExam).SelectedIndex < ((ComboBox)ctlMedicalExam).Items.Count )
//									{
//										objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index=((ComboBox)ctlMedicalExam).SelectedIndex.ToString ();
//										objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ComboBox)ctlMedicalExam).Text ;
//									}
//									else if(((ComboBox)ctlMedicalExam).Text !=null)
//										objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ComboBox)ctlMedicalExam).Text ;
//
//									objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="1";
//									break;
//								case "ctlBorderTextBox":
//								case "RichTextBox":			//文本(含单选，多选中的文本) 
//								case "TextBox":
//									objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord. m_strSelected_Option_Text=ctlMedicalExam.Text;						
//									//objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index =strGetBracketString(strTag,3);
//									break;
//								case "RadioButton":		//单选，使用RadioButton Group来实现
//									if(((RadioButton )ctlMedicalExam).Checked )
//									{
//										objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index =strGetBracketString(strTag,3);
//										objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text =  ((RadioButton )ctlMedicalExam).Text ;
//									}
//									objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="1";
//									break;
//								case "CheckBox":		//多选
//									//保存所有的多选选项
//									if(((CheckBox)ctlMedicalExam).Checked )
//									{
//										clsMedicalExamDetailRecordValue objMedicalExamDetailRecordRecord=new clsMedicalExamDetailRecordValue();
//										objMedicalExamDetailRecordRecord.m_strActivity_Date =strCurrentDate ;
//										objMedicalExamDetailRecordRecord.m_strDetailItem_ID =lngDetailIndex.ToString ("0000");
//										objMedicalExamDetailRecordRecord.m_strElement_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID;
//										objMedicalExamDetailRecordRecord.m_strMedicalExam_ID =strGetMedicalExamID ();
//										objMedicalExamDetailRecordRecord.m_strOption_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID;
//										objMedicalExamDetailRecordRecord.m_strSelected_Option_Indexes 	=strGetBracketString(strTag,3);
//										objMedicalExamDetailRecordRecord.m_strSelected_OptionValue_Text =ctlMedicalExam.Text;
//										m_objArrDetailRecord.Add (objMedicalExamDetailRecordRecord);
//										lngDetailIndex++;
//									}
//									objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="2";
//									break;
//								case "CheckedListBox":
//									CheckedListBox ctl=(CheckedListBox)ctlMedicalExam;
//									for(int l=0;l<ctl.Items.Count ;l++)
//									{
//										if(ctl.GetItemChecked(l))
//										{
//											clsMedicalExamDetailRecordValue objMedicalExamDetailRecordRecord=new clsMedicalExamDetailRecordValue();
//											objMedicalExamDetailRecordRecord.m_strActivity_Date =strCurrentDate ;
//											objMedicalExamDetailRecordRecord.m_strDetailItem_ID =lngDetailIndex.ToString ("0000");
//											objMedicalExamDetailRecordRecord.m_strElement_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID;
//											objMedicalExamDetailRecordRecord.m_strMedicalExam_ID =strGetMedicalExamID ();
//											objMedicalExamDetailRecordRecord.m_strOption_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID;																
//											objMedicalExamDetailRecordRecord.m_strSelected_Option_Indexes =l.ToString ();
//											objMedicalExamDetailRecordRecord.m_strSelected_OptionValue_Text = ctl.Items [l].ToString ();							
//											m_objArrDetailRecord.Add (objMedicalExamDetailRecordRecord);
//											lngDetailIndex ++;
//										}
//									}
//									break;
//							}
//							m_objArrMainRecordWithControls.Add (objMedicalExamControlsInfo);
//						}
//						#endregion
//						
//						//clsMedicalExamWithControlValue[] aa=(clsMedicalExamWithControlValue [])m_objArrMainRecordWithControls.ToArray (typeof(clsMedicalExamWithControlValue));
//
//						#region 合并同组控件作为同一条记录,刘颖源,2003-5-23 13:15:05
//						//合并同一条记录中的Control
//						clsMedicalExamWithControlValue objMedicalExamWithControl=null;
//						clsMedicalExamMainRecordValue objMedicalExamRecord=null;
//						ArrayList objArrMedicalExamMainRecordsToDb=new ArrayList ();
//						objArrMedicalExamMainRecordsToDb.Clear ();
//						int intControlsInSameRecord=-1;
//						for(int i=0;i<m_objArrMainRecordWithControls.Count ;i++)
//						{
//							objMedicalExamWithControl=(clsMedicalExamWithControlValue)m_objArrMainRecordWithControls[i];
//
//							#region 查找是否已经加入过此控件的记录,对于使用RadioBox组和CheckBox组(包含其中的TextBox)才出现此情况,刘颖源,2003-5-23 13:17:48
//							intControlsInSameRecord=-1;
//							//				if(objMedicalExamWithControl.m_strControlType =="RadioButton" || 
//							//					objMedicalExamWithControl.m_strControlType =="CheckBox" ||
//							//					objMedicalExamWithControl.m_strControlType == "TextBox" ||
//							//					objMedicalExamWithControl.m_strControlType =="RichTextBox" ||
//							//					objMedicalExamWithControl.m_strControlType =="ctlBorderTextBox" )
//							for(int j=0;j<objArrMedicalExamMainRecordsToDb.Count ;j++)
//							{
//								objMedicalExamRecord=(clsMedicalExamMainRecordValue) objArrMedicalExamMainRecordsToDb[j];
//								//是否在MainRecord中表示同一条记录中的多个控件
//								if(objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strElement_ID == objMedicalExamRecord.m_strElement_ID &&
//									objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strOption_ID == objMedicalExamRecord.m_strOption_ID )
//									intControlsInSameRecord=j;			//记录下已经有的Index
//							}
//							#endregion
//
//							#region 合并同组控件为一条记录,刘颖源,2003-5-23 13:19:40
//							if(intControlsInSameRecord==-1)				//从来没有加入过此控件选项
//								objArrMedicalExamMainRecordsToDb.Add (objMedicalExamWithControl.m_objclsMedicalExamMainRecord );
//							else		//是同一条记录中的信息，加入此部分信息
//							{
//								//对于纯文本情况应绝对不会执行到此，OptionID肯定唯一
//								//单选的情况,RadioBox实现同一条记录内容
//								if(int.Parse (objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strOption_Type )==1)	//单选
//								{
//									//丰富原来记录信息
//									clsMedicalExamMainRecordValue objOldRecord=(clsMedicalExamMainRecordValue)objArrMedicalExamMainRecordsToDb[intControlsInSameRecord];
//									//对于单选中的文本，如果选中了'其他'时候，使用控件的Tag属性更新该记录信息，
//									//否则（没有选中'其他'），不要随便更新Index和OptionValue信息,OptionText可以设置为空
//									if((objMedicalExamWithControl.m_strControlType =="TextBox" || 
//										objMedicalExamWithControl.m_strControlType =="RichTextBox" || 
//										objMedicalExamWithControl.m_strControlType =="ctlBorderTextBox") && 
//										objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index == objOldRecord.m_strSelected_Option_Index )
//									{
//										objOldRecord.m_strSelected_Option_Text =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text   ;
//									}
//									else
//									{
//										//能设置属性，肯定是已经选中了的单选控件,objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index !=""表示该控件选中
//										if(objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index !="")
//										{
//											objOldRecord.m_strSelected_Option_Index =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index;
//											objOldRecord.m_strSelected_OptionValue_Text =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text ;
//										}
//									}
//									objArrMedicalExamMainRecordsToDb.RemoveAt (intControlsInSameRecord);
//									objArrMedicalExamMainRecordsToDb.Add (objOldRecord);
//								}
//								else		//多选，使用GroupBox组实现同一条记录内容
//								{
//									clsMedicalExamMainRecordValue objOldRecord=(clsMedicalExamMainRecordValue)objArrMedicalExamMainRecordsToDb[intControlsInSameRecord];
//
//									objOldRecord.m_strSelected_Option_Index ="" ;
//									objOldRecord.m_strSelected_OptionValue_Text ="";
//									if(objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text !="")
//										objOldRecord.m_strSelected_Option_Text =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text;			
//									objArrMedicalExamMainRecordsToDb.RemoveAt (intControlsInSameRecord);
//									objArrMedicalExamMainRecordsToDb.Add (objOldRecord);
//								}
//
//							}
//							#endregion
//						}
//						#endregion
//						//!!!!!!!!!!!!////////////////////////////////////////////////////////////////
//						clsMedicalExamUnitStringValue [] objMedicalExamUnitString=null;
//						if(objArrMedicalExamMainRecordsToDb.Count >0)
//						{
//							objMedicalExamUnitString=new clsMedicalExamUnitStringValue[objArrMedicalExamMainRecordsToDb.Count];
//							for(int i=0;i<objArrMedicalExamMainRecordsToDb.Count ;i++)
//							{
//								clsMedicalExamMainRecordValue objTempRecord=(clsMedicalExamMainRecordValue)objArrMedicalExamMainRecordsToDb[i];
//								long lngCompart=long.Parse (objTempRecord.m_strElement_ID)*10000 + long.Parse (objTempRecord.m_strOption_ID);
//
//								objMedicalExamUnitString[i]=new clsMedicalExamUnitStringValue();
//								objMedicalExamUnitString[i].m_strElement_ID =objTempRecord.m_strElement_ID ;
//								objMedicalExamUnitString[i].m_strElementName =lngCompart.ToString ();		//暂时用于排序
//								objMedicalExamUnitString[i].m_strOption_ID =objTempRecord.m_strOption_ID ;
//								objMedicalExamUnitString[i].m_strOption_Name =objTempRecord.m_strOption_ID ;
//								objMedicalExamUnitString[i].m_strOption_Type =objTempRecord.m_strOption_Type ;
//								objMedicalExamUnitString[i].m_strSelected_Option_Index =objTempRecord.m_strSelected_Option_Index ;
//								objMedicalExamUnitString[i].m_strSelected_Option_Text =objTempRecord.m_strSelected_Option_Text ;
//								objMedicalExamUnitString[i].m_strSelected_OptionValue_DetailText =objTempRecord.m_strSelected_OptionValue_Text ;
//								objMedicalExamUnitString[i].m_strSelected_OptionValue_Text =objTempRecord.m_strSelected_OptionValue_Text ;
//							}
//
//							for(int i=0;i<objMedicalExamUnitString.Length -1;i++)
//								for(int j=i+1;j<objMedicalExamUnitString.Length ;j++)
//								{
//									if(long.Parse (objMedicalExamUnitString[i].m_strElementName )>long.Parse (objMedicalExamUnitString[j].m_strElementName ))
//									{
//										clsMedicalExamUnitStringValue  objTemp=objMedicalExamUnitString[i];
//										objMedicalExamUnitString[i]=objMedicalExamUnitString[j];
//										objMedicalExamUnitString[j]=objTemp ;
//									}
//								}
//							clsMedicalExamElementOptionUnionValue [] objElementOption=m_objMedicalExamSer.lngGetAllExamElementOptionUnion (clsLoginContext.s_ObjLoginContext.m_ObjPrincial);
//							if(objElementOption!=null && objElementOption.Length >0)
//							{
//								for(int i=0;i<objMedicalExamUnitString.Length ;i++)
//								{
//									for(int j=0;j<objElementOption.Length ;j++)
//									{
//										if(objElementOption[j].m_strOE_ID.Trim () ==objMedicalExamUnitString[i].m_strElement_ID.Trim ())
//											objMedicalExamUnitString[i].m_strElementName =objElementOption[j].m_strOE_NAME ;
//										if(objElementOption[j].m_strOE_ID.Trim () ==objMedicalExamUnitString[i].m_strOption_ID.Trim () )
//											objMedicalExamUnitString[i].m_strOption_Name =objElementOption[j].m_strOE_NAME ;
////										objMedicalExamUnitString[i].m_strOption_Type =objTempRecord.m_strOption_Type ;
//									}
//								}
//							}
//						}
//						//!!!!!!!!!!!!!!!!!!!!/////////////////////////////////////////////////////////////////
//						if(objMedicalExamUnitString==null || objMedicalExamUnitString.Length <=0)return("");
//						#region 合并字符串,刘颖源,2003-5-27 8:56:02
//						ArrayList objArrMedicalExamUnitString=new ArrayList ();
//						objArrMedicalExamUnitString.Clear ();
//						bool blnIsSeries2=false;
//						string strOutput="";
//						string strElement_ID=objMedicalExamUnitString[0].m_strElement_ID ;
//						string strOption_ID=objMedicalExamUnitString[0].m_strOption_ID ;
//						for(int i=0;i<objMedicalExamUnitString.Length ;i++)
//						{
//
//							switch(int.Parse (objMedicalExamUnitString[i].m_strOption_Type))
//							{
//								case 0:
//								case 1:
//									blnIsSeries2=false;
//									objArrMedicalExamUnitString.Add (objMedicalExamUnitString[i]);
//									break;
//								case 2:
//									if(blnIsSeries2==false)
//									{
//										clsMedicalExamUnitStringValue objTempMedicalUnitString=objMedicalExamUnitString[i];		//更新最后一条记录
//										objTempMedicalUnitString.m_strSelected_OptionValue_DetailText = objMedicalExamUnitString[i].m_strSelected_OptionValue_DetailText + "、"; 
//										objArrMedicalExamUnitString.Add (objTempMedicalUnitString );
//									}
//									else
//									{
//										int intMedicalIndex=objArrMedicalExamUnitString.Count -1;
//										clsMedicalExamUnitStringValue objTempMedicalUnitString=(clsMedicalExamUnitStringValue) objArrMedicalExamUnitString[intMedicalIndex];		//更新最后一条记录
//										objTempMedicalUnitString.m_strSelected_OptionValue_DetailText += objMedicalExamUnitString[i].m_strSelected_OptionValue_DetailText + "、"; 
//										objArrMedicalExamUnitString.RemoveAt (intMedicalIndex );
//										objArrMedicalExamUnitString.Add (objTempMedicalUnitString );
//									}
//									blnIsSeries2=true;							
//									break;
//							}
//						}
//						#endregion
//
//						#region 生成字符串,刘颖源,2003-5-27 9:11:20
//						string strOldElement_ID="";
//						for(int i=0;i<objArrMedicalExamUnitString.Count ;i++)
//						{
//							clsMedicalExamUnitStringValue objTempMedicalUnitString=(clsMedicalExamUnitStringValue) objArrMedicalExamUnitString[i];
//							if(i==0)
//							{
//								strOldElement_ID =objTempMedicalUnitString.m_strElement_ID ;
//								strOutput=objTempMedicalUnitString.m_strElementName + ":\r\n";
//							}
//							if(objTempMedicalUnitString.m_strElement_ID !=strOldElement_ID)
//							{
//								strOutput +="\r\n\r\n" + objTempMedicalUnitString.m_strElementName + ":\r\n";
//								strOldElement_ID=objTempMedicalUnitString.m_strElement_ID;
//							}
//							switch(int.Parse (objTempMedicalUnitString.m_strOption_Type ))
//							{
//								case 0:
//									if(objTempMedicalUnitString.m_strSelected_Option_Text.Trim () !="")
//										strOutput +=objTempMedicalUnitString.m_strOption_Name  + objTempMedicalUnitString.m_strSelected_Option_Text ;
//									break;
//								case 1:
//									if(objTempMedicalUnitString.m_strSelected_Option_Text !=null && objTempMedicalUnitString.m_strSelected_Option_Text !="")
//										strOutput +=objTempMedicalUnitString.m_strOption_Name + objTempMedicalUnitString.m_strSelected_OptionValue_Text + "(" + objTempMedicalUnitString.m_strSelected_Option_Text + ")" ;
//									else
//										strOutput +=objTempMedicalUnitString.m_strOption_Name + objTempMedicalUnitString.m_strSelected_OptionValue_Text;
//									break;
//								case 2:
//									if(objTempMedicalUnitString.m_strSelected_OptionValue_DetailText.Length >0)
//										objTempMedicalUnitString.m_strSelected_OptionValue_DetailText=objTempMedicalUnitString.m_strSelected_OptionValue_DetailText.Substring (0,objTempMedicalUnitString.m_strSelected_OptionValue_DetailText.Length -1);
//									if(objTempMedicalUnitString.m_strSelected_Option_Text !=null && objTempMedicalUnitString.m_strSelected_Option_Text !="")
//										strOutput +=objTempMedicalUnitString.m_strOption_Name + objTempMedicalUnitString.m_strSelected_OptionValue_DetailText  + "(" + objTempMedicalUnitString.m_strSelected_Option_Text + ")" ;
//									else
//										strOutput +=objTempMedicalUnitString.m_strOption_Name+ objTempMedicalUnitString.m_strSelected_OptionValue_DetailText;
//									break;
//							}
//							strOutput+="; ";
//
//																							
//						}
//						
//						#endregion
//
//						return(strOutput);
//
//			#endregion
//
//		}

		#endregion

		/// <summary>
		/// 合成字符串 new
		/// </summary>
		/// <param name="p_ctl"></param>
		/// <returns></returns>
		public string m_strGetMedicalExamUnitString(Control p_ctl)
		{
			#region 555
			m_objArrDetailRecord.Clear ();
			m_objArrMainRecordWithControls.Clear ();
						
			m_mthInitLoadAllMedicalExamControls1(p_ctl);
						
			#region 把体格检查控件信息转入到结构体中,刘颖源,2003-5-23 13:15:05

			string strCurrentDate=DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss");

			long lngDetailIndex=1;
			for(int ii=0;ii<m_objArrMedicalExamControls.Count ;ii++ )
			{
				//当前要记录的控件
				clsMedicalExamWithControlValue objMedicalExamControlsInfo=new clsMedicalExamWithControlValue();

				Control ctlMedicalExam=(Control)m_objArrMedicalExamControls[ii];

				string strTag=ctlMedicalExam.Tag.ToString ();			


				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID=strGetBracketString(strTag,1);
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID=strGetBracketString(strTag,2);
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strActivity_Date=strCurrentDate;
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type=strGetBracketString(strTag,0);
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index ="-1";
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text ="";
				objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text ="";
				objMedicalExamControlsInfo.m_strControlType =ctlMedicalExam.GetType().Name  ;
				objMedicalExamControlsInfo.m_strControlName =ctlMedicalExam.Name ;
				objMedicalExamControlsInfo.m_strControlText =ctlMedicalExam.Text ;
				//写入用户输入信息
				switch(ctlMedicalExam.GetType().Name)
				{ 
					case "ctlComboBox":
						if(((ctlComboBox)ctlMedicalExam).SelectedIndex >=0 && ((ctlComboBox)ctlMedicalExam).SelectedIndex < ((ctlComboBox)ctlMedicalExam).GetItemsCount())
						{
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index=((ctlComboBox)ctlMedicalExam).SelectedIndex.ToString ();
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ctlComboBox)ctlMedicalExam).Text ;
						}
						else if(((ctlComboBox)ctlMedicalExam).Text !=null)
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ctlComboBox)ctlMedicalExam).Text ;
						
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="1";
						break;
					case "ComboBox":		//单选,使用ComboBox来实现
						if(((ComboBox)ctlMedicalExam).SelectedIndex >=0 && ((ComboBox)ctlMedicalExam).SelectedIndex < ((ComboBox)ctlMedicalExam).Items.Count )
						{
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index=((ComboBox)ctlMedicalExam).SelectedIndex.ToString ();
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ComboBox)ctlMedicalExam).Text ;
						}
						else if(((ComboBox)ctlMedicalExam).Text !=null)
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text = ((ComboBox)ctlMedicalExam).Text ;

						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="1";
						break;
					case "ctlBorderTextBox":
					case "RichTextBox":			//文本(含单选，多选中的文本) 
					case "TextBox":
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord. m_strSelected_Option_Text=ctlMedicalExam.Text;						
						//objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index =strGetBracketString(strTag,3);
						break;
					case "RadioButton":		//单选，使用RadioButton Group来实现
						if(((RadioButton )ctlMedicalExam).Checked )
						{
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index =strGetBracketString(strTag,3);
							objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text =  ((RadioButton )ctlMedicalExam).Text ;
						}
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="1";
						break;
					case "CheckBox":		//多选
						//保存所有的多选选项
						if(((CheckBox)ctlMedicalExam).Checked )
						{
							clsMedicalExamDetailRecordValue objMedicalExamDetailRecordRecord=new clsMedicalExamDetailRecordValue();
							objMedicalExamDetailRecordRecord.m_strActivity_Date =strCurrentDate ;
							objMedicalExamDetailRecordRecord.m_strDetailItem_ID =lngDetailIndex.ToString ("0000");
							objMedicalExamDetailRecordRecord.m_strElement_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID;
							objMedicalExamDetailRecordRecord.m_strMedicalExam_ID =strGetMedicalExamID ();
							objMedicalExamDetailRecordRecord.m_strOption_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID;
							objMedicalExamDetailRecordRecord.m_strSelected_Option_Indexes 	=strGetBracketString(strTag,3);
							objMedicalExamDetailRecordRecord.m_strSelected_OptionValue_Text =ctlMedicalExam.Text;
							m_objArrDetailRecord.Add (objMedicalExamDetailRecordRecord);
							lngDetailIndex++;
						}
						objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_Type ="2";
						break;
					case "CheckedListBox":
						CheckedListBox ctl=(CheckedListBox)ctlMedicalExam;
						for(int l=0;l<ctl.Items.Count ;l++)
						{
							if(ctl.GetItemChecked(l))
							{
								clsMedicalExamDetailRecordValue objMedicalExamDetailRecordRecord=new clsMedicalExamDetailRecordValue();
								objMedicalExamDetailRecordRecord.m_strActivity_Date =strCurrentDate ;
								objMedicalExamDetailRecordRecord.m_strDetailItem_ID =lngDetailIndex.ToString ("0000");
								objMedicalExamDetailRecordRecord.m_strElement_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strElement_ID;
								objMedicalExamDetailRecordRecord.m_strMedicalExam_ID =strGetMedicalExamID ();
								objMedicalExamDetailRecordRecord.m_strOption_ID =objMedicalExamControlsInfo.m_objclsMedicalExamMainRecord.m_strOption_ID;																
								objMedicalExamDetailRecordRecord.m_strSelected_Option_Indexes =l.ToString ();
								objMedicalExamDetailRecordRecord.m_strSelected_OptionValue_Text = ctl.Items [l].ToString ();							
								m_objArrDetailRecord.Add (objMedicalExamDetailRecordRecord);
								lngDetailIndex ++;
							}
						}
						break;
				}
				m_objArrMainRecordWithControls.Add (objMedicalExamControlsInfo);
			}
						#endregion

			#region 合并同组控件作为同一条记录,刘颖源,2003-5-23 13:15:05

			//合并同一条记录中的Control
			clsMedicalExamWithControlValue objMedicalExamWithControl=null;
			clsMedicalExamMainRecordValue objMedicalExamRecord=null;
			ArrayList objArrMedicalExamMainRecordsToDb=new ArrayList ();
			objArrMedicalExamMainRecordsToDb.Clear ();
			int intControlsInSameRecord=-1;
			for(int i=0;i<m_objArrMainRecordWithControls.Count ;i++)
			{
				objMedicalExamWithControl=(clsMedicalExamWithControlValue)m_objArrMainRecordWithControls[i];

				#region 查找是否已经加入过此控件的记录,对于使用RadioBox组和CheckBox组(包含其中的TextBox)才出现此情况,刘颖源,2003-5-23 13:17:48
				intControlsInSameRecord=-1;

				for(int j=0;j<objArrMedicalExamMainRecordsToDb.Count ;j++)
				{
					objMedicalExamRecord=(clsMedicalExamMainRecordValue) objArrMedicalExamMainRecordsToDb[j];
					//是否在MainRecord中表示同一条记录中的多个控件
					if(objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strElement_ID == objMedicalExamRecord.m_strElement_ID &&
						objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strOption_ID == objMedicalExamRecord.m_strOption_ID )
						intControlsInSameRecord=j;			//记录下已经有的Index
				}
				#endregion

				#region 合并同组控件为一条记录,刘颖源,2003-5-23 13:19:40
				if(intControlsInSameRecord==-1)				//从来没有加入过此控件选项
					objArrMedicalExamMainRecordsToDb.Add (objMedicalExamWithControl.m_objclsMedicalExamMainRecord );
				else		//是同一条记录中的信息，加入此部分信息
				{
					//对于纯文本情况应绝对不会执行到此，OptionID肯定唯一
					//单选的情况,RadioBox实现同一条记录内容
					if(int.Parse (objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strOption_Type )==1)	//单选,ctlComboBox
					{
						//丰富原来记录信息
						clsMedicalExamMainRecordValue objOldRecord=(clsMedicalExamMainRecordValue)objArrMedicalExamMainRecordsToDb[intControlsInSameRecord];
						//对于单选中的文本，如果选中了'其他'时候，使用控件的Tag属性更新该记录信息，
						//否则（没有选中'其他'），不要随便更新Index和OptionValue信息,OptionText可以设置为空
						if((objMedicalExamWithControl.m_strControlType =="TextBox" || 
							objMedicalExamWithControl.m_strControlType =="RichTextBox" || 
							objMedicalExamWithControl.m_strControlType =="ctlBorderTextBox") && 
							objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index == objOldRecord.m_strSelected_Option_Index )
						{
							objOldRecord.m_strSelected_Option_Text =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text   ;
						}
						else
						{
							//能设置属性，肯定是已经选中了的单选控件,objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index !=""表示该控件选中
							if(objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index !="")
							{
								objOldRecord.m_strSelected_Option_Index =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Index;
								objOldRecord.m_strSelected_OptionValue_Text =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_OptionValue_Text ;
							}
						}
						objArrMedicalExamMainRecordsToDb.RemoveAt (intControlsInSameRecord);
						objArrMedicalExamMainRecordsToDb.Add (objOldRecord);
					}
					else		//多选，使用GroupBox组实现同一条记录内容
					{
						clsMedicalExamMainRecordValue objOldRecord=(clsMedicalExamMainRecordValue)objArrMedicalExamMainRecordsToDb[intControlsInSameRecord];

						objOldRecord.m_strSelected_Option_Index ="" ;
						objOldRecord.m_strSelected_OptionValue_Text ="";
						if(objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text !="")
							objOldRecord.m_strSelected_Option_Text =objMedicalExamWithControl.m_objclsMedicalExamMainRecord.m_strSelected_Option_Text;			
						objArrMedicalExamMainRecordsToDb.RemoveAt (intControlsInSameRecord);
						objArrMedicalExamMainRecordsToDb.Add (objOldRecord);
					}

				}
							#endregion
			}
						#endregion
			//!!!!!!!!!!!!////////////////////////////////////////////////////////////////
			clsMedicalExamUnitStringValue [] objMedicalExamUnitString=null;
			if(objArrMedicalExamMainRecordsToDb.Count >0)
			{
				objMedicalExamUnitString=new clsMedicalExamUnitStringValue[objArrMedicalExamMainRecordsToDb.Count];
				for(int i=0;i<objArrMedicalExamMainRecordsToDb.Count ;i++)
				{
					clsMedicalExamMainRecordValue objTempRecord=(clsMedicalExamMainRecordValue)objArrMedicalExamMainRecordsToDb[i];
					long lngCompart=long.Parse (objTempRecord.m_strElement_ID)*10000 + long.Parse (objTempRecord.m_strOption_ID);

					objMedicalExamUnitString[i]=new clsMedicalExamUnitStringValue();
					objMedicalExamUnitString[i].m_strElement_ID =objTempRecord.m_strElement_ID ;
					objMedicalExamUnitString[i].m_strElementName =lngCompart.ToString ();		//暂时用于排序
					objMedicalExamUnitString[i].m_strOption_ID =objTempRecord.m_strOption_ID ;
					objMedicalExamUnitString[i].m_strOption_Name =objTempRecord.m_strOption_ID ;
					objMedicalExamUnitString[i].m_strOption_Type =objTempRecord.m_strOption_Type ;
					objMedicalExamUnitString[i].m_strSelected_Option_Index =objTempRecord.m_strSelected_Option_Index ;
					objMedicalExamUnitString[i].m_strSelected_Option_Text =objTempRecord.m_strSelected_Option_Text ;
					objMedicalExamUnitString[i].m_strSelected_OptionValue_DetailText =objTempRecord.m_strSelected_OptionValue_Text ;
					objMedicalExamUnitString[i].m_strSelected_OptionValue_Text =objTempRecord.m_strSelected_OptionValue_Text ;
				}

				for(int i=0;i<objMedicalExamUnitString.Length -1;i++)
					for(int j=i+1;j<objMedicalExamUnitString.Length ;j++)
					{
						if(long.Parse (objMedicalExamUnitString[i].m_strElementName )>long.Parse (objMedicalExamUnitString[j].m_strElementName ))
						{
							clsMedicalExamUnitStringValue  objTemp=objMedicalExamUnitString[i];
							objMedicalExamUnitString[i]=objMedicalExamUnitString[j];
							objMedicalExamUnitString[j]=objTemp ;
						}
					}

                clsMedicalExamService m_objMedicalExamSer =
                    (clsMedicalExamService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedicalExamService));

                clsMedicalExamElementOptionUnionValue[] objElementOption = null;
                try
                {
                    objElementOption = m_objMedicalExamSer.lngGetAllExamElementOptionUnion(clsLoginContext.s_ObjLoginContext.m_ObjPrincial);
                }
                finally
                {
                    //m_objMedicalExamSer.Dispose();
                }
				if(objElementOption!=null && objElementOption.Length >0)
				{
					for(int i=0;i<objMedicalExamUnitString.Length ;i++)
					{
						for(int j=0;j<objElementOption.Length ;j++)
						{
							if(objElementOption[j].m_strOE_ID.Trim () ==objMedicalExamUnitString[i].m_strElement_ID.Trim ())
								objMedicalExamUnitString[i].m_strElementName =objElementOption[j].m_strOE_NAME ;
							if(objElementOption[j].m_strOE_ID.Trim () ==objMedicalExamUnitString[i].m_strOption_ID.Trim () )
								objMedicalExamUnitString[i].m_strOption_Name =objElementOption[j].m_strOE_NAME ;							
						}
					}
				}
			}
			//!!!!!!!!!!!!!!!!!!!!/////////////////////////////////////////////////////////////////
			if(objMedicalExamUnitString==null || objMedicalExamUnitString.Length <=0)return("");
			#region 合并字符串,刘颖源,2003-5-27 8:56:02
			ArrayList objArrMedicalExamUnitString=new ArrayList ();
			objArrMedicalExamUnitString.Clear ();
			bool blnIsSeries2=false;
			string strElement_ID=objMedicalExamUnitString[0].m_strElement_ID ;
			string strOption_ID=objMedicalExamUnitString[0].m_strOption_ID ;
			for(int i=0;i<objMedicalExamUnitString.Length ;i++)
			{

				switch(int.Parse (objMedicalExamUnitString[i].m_strOption_Type))
				{
					case 0:
					case 1:
						blnIsSeries2=false;
						objArrMedicalExamUnitString.Add (objMedicalExamUnitString[i]);
						break;
					case 2:
						if(blnIsSeries2==false)
						{
							clsMedicalExamUnitStringValue objTempMedicalUnitString=objMedicalExamUnitString[i];		//更新最后一条记录
							objTempMedicalUnitString.m_strSelected_OptionValue_DetailText = objMedicalExamUnitString[i].m_strSelected_OptionValue_DetailText + "、"; 
							objArrMedicalExamUnitString.Add (objTempMedicalUnitString );
						}
						else
						{
							int intMedicalIndex=objArrMedicalExamUnitString.Count -1;
							clsMedicalExamUnitStringValue objTempMedicalUnitString=(clsMedicalExamUnitStringValue) objArrMedicalExamUnitString[intMedicalIndex];		//更新最后一条记录
							objTempMedicalUnitString.m_strSelected_OptionValue_DetailText += objMedicalExamUnitString[i].m_strSelected_OptionValue_DetailText + "、"; 
							objArrMedicalExamUnitString.RemoveAt (intMedicalIndex );
							objArrMedicalExamUnitString.Add (objTempMedicalUnitString );
						}
						blnIsSeries2=true;							
						break;
				}
			}
						#endregion

						#region 生成字符串,刘颖源,2003-5-27 9:11:20
			string strOldElement_ID="";
			System.Text.StringBuilder sbOut = new System.Text.StringBuilder("");
			for(int i=0;i<objArrMedicalExamUnitString.Count ;i++)
			{
				clsMedicalExamUnitStringValue objTempMedicalUnitString=(clsMedicalExamUnitStringValue) objArrMedicalExamUnitString[i];
				#region 显示大项名称
//				if(i==0)
//				{
//					strOldElement_ID =objTempMedicalUnitString.m_strElement_ID ;
//					sbOut.Append(objTempMedicalUnitString.m_strElementName + ":\r\n");
//				}
//				if(objTempMedicalUnitString.m_strElement_ID !=strOldElement_ID)
//				{
//					sbOut.Append("\r\n\r\n" + objTempMedicalUnitString.m_strElementName + ":\r\n");
//					strOldElement_ID=objTempMedicalUnitString.m_strElement_ID;
//				}
				#endregion
				switch(int.Parse (objTempMedicalUnitString.m_strOption_Type ))
				{
					case 0:
						if(objTempMedicalUnitString.m_strSelected_Option_Text.Trim () !="")
							sbOut.Append(objTempMedicalUnitString.m_strOption_Name.Replace("さ",objTempMedicalUnitString.m_strSelected_Option_Text) + ",");
						break;
					case 1:
						if(objTempMedicalUnitString.m_strSelected_Option_Text !="" || objTempMedicalUnitString.m_strSelected_OptionValue_Text!="")
							sbOut.Append(objTempMedicalUnitString.m_strOption_Name.Replace("さ",objTempMedicalUnitString.m_strSelected_OptionValue_Text).Replace("し",objTempMedicalUnitString.m_strSelected_Option_Text) + ",");
//						else
//							strOutput +=objTempMedicalUnitString.m_strOption_Name + objTempMedicalUnitString.m_strSelected_OptionValue_Text  + ",";
						break;
					case 2:
						if(objTempMedicalUnitString.m_strSelected_OptionValue_DetailText.Length >0)
							objTempMedicalUnitString.m_strSelected_OptionValue_DetailText=objTempMedicalUnitString.m_strSelected_OptionValue_DetailText.Substring (0,objTempMedicalUnitString.m_strSelected_OptionValue_DetailText.Length -1)  + ",";
						if(objTempMedicalUnitString.m_strSelected_Option_Text !=null && objTempMedicalUnitString.m_strSelected_Option_Text !="")
//							strOutput +=objTempMedicalUnitString.m_strOption_Name + objTempMedicalUnitString.m_strSelected_OptionValue_DetailText  + "(" + objTempMedicalUnitString.m_strSelected_Option_Text + ")"  + ",";
							sbOut.Append(objTempMedicalUnitString.m_strOption_Name.Replace("さ",objTempMedicalUnitString.m_strSelected_OptionValue_DetailText+ "(" + objTempMedicalUnitString.m_strSelected_Option_Text + ")") + ",");
//						else
//							strOutput +=objTempMedicalUnitString.m_strOption_Name+ objTempMedicalUnitString.m_strSelected_OptionValue_DetailText  + ",";
						break;
				}

																							
			}
						
						#endregion

			
			string strOutput = sbOut.ToString();
			if(strOutput.Length > 0)
				strOutput = strOutput.Substring(0,strOutput.Length-1)+"。";

			return(strOutput);

			#endregion
		}

		/*------------------------------------------------------------------------*/
	}


}


