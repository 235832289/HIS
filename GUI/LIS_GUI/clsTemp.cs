using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.iCare.Template.Client;
using System.Collections;

namespace com.digitalwave.iCare.gui.LIS
{

	#region clsLIS_App 刘彬 2004.05.28

    /// <summary>
    /// 申请单Biz类
    /// </summary>
	public class clsLIS_App
	{

        #region 私有成员

        private enmObjectOperationState m_enmOprState;

        private clsLisApplMainVO m_objDataVO;
        private clsLisApplMainVO m_objOriginalDataVO;

        private clsAppCheckReportCollection m_objAppReports;
        private clsAppApplyUnitCollection m_objAppApplyUnits;

        private string m_strAppID; 

        #endregion

        #region 构造函数

        public clsLIS_App(clsLisApplMainVO p_objDataVO)
        {
            this.m_objDataVO = p_objDataVO;
            m_enmOprState = enmObjectOperationState.New;

            m_objAppReports = new clsAppCheckReportCollection();
            m_objAppApplyUnits = new clsAppApplyUnitCollection();
            m_objAppReports.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppReports_evtItemAdded);
            m_objAppApplyUnits.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppApplyUnits_evtItemAdded);
            m_objAppReports.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppReports_evtItemRemoved);
            m_objAppApplyUnits.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppApplyUnits_evtItemRemoved);
        }
        public clsLIS_App(clsLisApplMainVO p_objDataVO, bool p_blnIsOriginal)
        {
            if (p_blnIsOriginal)
            {
                this.m_objDataVO = p_objDataVO;
                this.m_objOriginalDataVO = new clsLisApplMainVO();

                m_mthDataTransfer(p_objDataVO, m_objOriginalDataVO);

                m_enmOprState = enmObjectOperationState.Original;
            }
            else
            {
                this.m_objDataVO = p_objDataVO;
                m_enmOprState = enmObjectOperationState.New;
            }
            m_objAppReports = new clsAppCheckReportCollection();
            m_objAppApplyUnits = new clsAppApplyUnitCollection();
            m_objAppReports.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppReports_evtItemAdded);
            m_objAppApplyUnits.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppApplyUnits_evtItemAdded);
            m_objAppReports.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppReports_evtItemRemoved);
            m_objAppApplyUnits.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppApplyUnits_evtItemRemoved);

        }

        #endregion

		#region VOManage

        /// <summary>
        /// 申请单号
        /// </summary>
        public string m_StrAppID
        {
            get
            {
                return this.m_objDataVO.m_strAPPLICATION_ID;
            }
            set
            {
                if (this.m_objDataVO.m_strAPPLICATION_ID != value || this.m_strAppID != value)
                {
                    this.m_objDataVO.m_strAPPLICATION_ID = value;
                    this.m_strAppID = value;
                    foreach (clsLIS_AppApplyUnit objUnit in this.m_ObjAppApplyUnits)
                    {
                        objUnit.m_StrAppID = value;
                    }
                    foreach (clsLIS_AppCheckReport objAppReport in this.m_ObjAppReports)
                    {
                        objAppReport.m_StrAppID = value;
                    }
                    if (this.evtApplicationIDChanged != null)
                    {
                        evtApplicationIDChanged(this, new EventArgs());
                    }

                }
            }
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        public string m_StrMODIFY_DAT
        {
            get
            {
                return this.m_objDataVO.m_strMODIFY_DAT;
            }
        }
        /// <summary>
        /// 病人编号：每个病人的维一编号
        /// </summary>
        public string m_StrPatientID
        {
            get
            {
                return this.m_objDataVO.m_strPatientID;
            }
            set
            {
                this.m_objDataVO.m_strPatientID = value;
            }
        }
        /// <summary>
        /// 申请日期
        /// </summary>
        public string m_StrAppDat
        {
            get
            {
                return this.m_objDataVO.m_strAppl_Dat;
            }
            set
            {
                this.m_objDataVO.m_strAppl_Dat = value;
            }
        }
        /// <summary>
        /// 病人性别
        /// </summary>
        public string m_StrSex
        {
            get
            {
                return this.m_objDataVO.m_strSex;
            }
            set
            {
                this.m_objDataVO.m_strSex = value;
            }
        }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string m_StrPatientName
        {
            get
            {
                return this.m_objDataVO.m_strPatient_Name;
            }
            set
            {
                this.m_objDataVO.m_strPatient_Name = value;
            }
        }
        /// <summary>
        /// 作废
        /// </summary>
        public string m_StrPatientSubNO
        {
            get
            {
                return this.m_objDataVO.m_strPatient_SubNO;
            }
            set
            {
                this.m_objDataVO.m_strPatient_SubNO = value;
            }
        }
        /// <summary>
        /// 病人年龄
        /// </summary>
        public string m_StrAge
        {
            get
            {
                return this.m_objDataVO.m_strAge;
            }
            set
            {
                this.m_objDataVO.m_strAge = value;
            }
        }
        /// <summary>
        /// 病人类别 分门诊、住院、急诊、体检等
        /// </summary>
        public string m_StrPatientType
        {
            get
            {
                return this.m_objDataVO.m_strPatientType;
            }
            set
            {
                this.m_objDataVO.m_strPatientType = value;
            }
        }
        /// <summary>
        /// 临床诊断
        /// </summary>
        public string m_StrDiagnose
        {
            get
            {
                return this.m_objDataVO.m_strDiagnose;
            }
            set
            {
                this.m_objDataVO.m_strDiagnose = value;
            }
        }
        /// <summary>
        /// 病人床号
        /// </summary>
        public string m_StrBedNO
        {
            get
            {
                return this.m_objDataVO.m_strBedNO;
            }
            set
            {
                this.m_objDataVO.m_strBedNO = value;
            }
        }
        /// <summary>
        /// 临床诊断ICD码
        /// </summary>
        public string m_StrICD
        {
            get
            {
                return this.m_objDataVO.m_strICD;
            }
            set
            {
                this.m_objDataVO.m_strICD = value;
            }
        }
        /// <summary>
        /// 就诊卡号
        /// </summary>
        public string m_StrPatientCardID
        {
            get
            {
                return this.m_objDataVO.m_strPatientcardID;
            }
            set
            {
                this.m_objDataVO.m_strPatientcardID = value;
            }
        }
        /// <summary>
        /// 申请表编号
        /// </summary>
        public string m_StrApplicationFormNO
        {
            get
            {
                return this.m_objDataVO.m_strApplication_Form_NO;
            }
            set
            {
                this.m_objDataVO.m_strApplication_Form_NO = value;
            }
        }
        /// <summary>
        /// 操作员工ID
        /// </summary>
        public string m_StrOperatorID
        {
            get
            {
                return this.m_objDataVO.m_strOperator_ID;
            }
            set
            {
                this.m_objDataVO.m_strOperator_ID = value;
            }
        }
        /// <summary>
        /// 申请医生的员工ID
        /// </summary>
        public string m_StrApplEmpID
        {
            get
            {
                return this.m_objDataVO.m_strAppl_EmpID;
            }
            set
            {
                this.m_objDataVO.m_strAppl_EmpID = value;
            }
        }
        /// <summary>
        /// 申请检验的科室部门ID
        /// </summary>
        public string m_StrApplDeptID
        {
            get
            {
                return this.m_objDataVO.m_strAppl_DeptID;
            }
            set
            {
                this.m_objDataVO.m_strAppl_DeptID = value;
            }
        }
        /// <summary>
        /// 检验结果建议
        /// </summary>
        public string m_StrSummary
        {
            get
            {
                return this.m_objDataVO.m_strSummary;
            }
            set
            {
                this.m_objDataVO.m_strSummary = value;
            }
        }
        /// <summary>
        /// 过程状态标识
        /// </summary>
        public int m_IntPStatus
        {
            get
            {
                return this.m_objDataVO.m_intPStatus_int;
            }
            set
            {
                this.m_objDataVO.m_intPStatus_int = value;
            }
        }
        /// <summary>
        /// 急诊状态
        /// </summary>
        public int m_IntEmergency
        {
            get
            {
                return this.m_objDataVO.m_intEmergency;
            }
            set
            {
                this.m_objDataVO.m_intEmergency = value;
            }
        }
        /// <summary>
        /// 特殊状态
        /// </summary>
        public int m_IntSpecial
        {
            get
            {
                return this.m_objDataVO.m_intSpecial;
            }
            set
            {
                this.m_objDataVO.m_intSpecial = value;
            }
        }
        /// <summary>
        /// 0-正式申请,1-后补申请
        /// </summary>
        public int m_IntForm
        {
            get
            {
                return this.m_objDataVO.m_intForm_int;
            }
            set
            {
                this.m_objDataVO.m_intForm_int = value;
            }
        }
        /// <summary>
        /// 病人住院号
        /// </summary>
        public string m_StrPatientInhospNO
        {
            get
            {
                return this.m_objDataVO.m_strPatient_inhospitalno_chr;
            }
            set
            {
                this.m_objDataVO.m_strPatient_inhospitalno_chr = value;
            }
        }

		#endregion

        #region 事件申明

        /// <summary>
        /// 申请单元Id改变事件
        /// </summary>
        private event EventHandler evtApplicationIDChanged;
        
        #endregion

        #region 属 性
       

        /// <summary>
        /// 当前的状态
        /// </summary>
        private enmObjectOperationState m_EnuOprState
        {
            get
            {
                return this.m_enmOprState;
            }
        }

        /// <summary>
        /// 修改前的原数据
        /// </summary>
        public clsLisApplMainVO m_ObjOriginalDataVO
        {
            get
            {
                return m_objOriginalDataVO;
            }
        }

        /// <summary>
        /// 修改以后的数据
        /// </summary>
        public clsLisApplMainVO m_ObjDataVO
        {
            get
            {
                return this.m_objDataVO;
            }
        }

        /// <summary>
        /// 获取检验报告集合
        /// </summary>
        public clsAppCheckReportCollection m_ObjAppReports
        {
            get { return this.m_objAppReports; }
        }

        /// <summary>
        /// 获取申请单元集合
        /// </summary>
        public clsAppApplyUnitCollection m_ObjAppApplyUnits
        {
            get { return this.m_objAppApplyUnits; }
        }
        
        #endregion

        #region 辅助方法

        /// <summary>
        /// 【删除App操作】只有 Original,Modified 状态的使用本方法才有效
        /// </summary>
        public void m_mthDelete()
        {
            if (this.m_enmOprState != enmObjectOperationState.New)
            {
                this.m_mthDataTransfer(this.m_objOriginalDataVO, this.m_objDataVO);
                this.m_objDataVO.m_intPStatus_int = 0;
                this.m_enmOprState = enmObjectOperationState.Deleted;
            }
        }

        private void m_mthMatchOpState()
        {
            if (this.m_EnuOprState != enmObjectOperationState.New
                && this.m_EnuOprState != enmObjectOperationState.Deleted)
            {
                if (m_objOriginalDataVO.m_intEmergency == m_objDataVO.m_intEmergency &&
                    m_objOriginalDataVO.m_intForm_int  == m_objDataVO.m_intForm_int &&
                    m_objOriginalDataVO.m_intPStatus_int == m_objDataVO.m_intPStatus_int &&
                    m_objOriginalDataVO.m_intSpecial     == m_objDataVO.m_intSpecial &&
                    m_objOriginalDataVO.m_strAge == m_objDataVO.m_strAge &&
                    m_objOriginalDataVO.m_strAppl_Dat == m_objDataVO.m_strAppl_Dat &&
                    m_objOriginalDataVO.m_strAppl_DeptID == m_objDataVO.m_strAppl_DeptID &&
                    m_objOriginalDataVO.m_strAppl_EmpID == m_objDataVO.m_strAppl_EmpID &&
                    m_objOriginalDataVO.m_strApplication_Form_NO == m_objDataVO.m_strApplication_Form_NO &&
                    m_objOriginalDataVO.m_strAPPLICATION_ID == m_objDataVO.m_strAPPLICATION_ID &&
                    m_objOriginalDataVO.m_strBedNO == m_objDataVO.m_strBedNO &&
                    m_objOriginalDataVO.m_strDiagnose == m_objDataVO.m_strDiagnose &&
                    m_objOriginalDataVO.m_strICD == m_objDataVO.m_strICD &&
                    m_objOriginalDataVO.m_strMODIFY_DAT == m_objDataVO.m_strMODIFY_DAT &&
                    m_objOriginalDataVO.m_strOperator_ID == m_objDataVO.m_strOperator_ID &&
                    m_objOriginalDataVO.m_strPatient_inhospitalno_chr == m_objDataVO.m_strPatient_inhospitalno_chr &&
                    m_objOriginalDataVO.m_strPatient_Name == m_objDataVO.m_strPatient_Name &&
                    m_objOriginalDataVO.m_strPatient_SubNO == m_objDataVO.m_strPatient_SubNO &&
                    m_objOriginalDataVO.m_strPatientcardID == m_objDataVO.m_strPatientcardID &&
                    m_objOriginalDataVO.m_strPatientID == m_objDataVO.m_strPatientID &&
                    m_objOriginalDataVO.m_strPatientType == m_objDataVO.m_strPatientType &&
                    m_objOriginalDataVO.m_strSex == m_objDataVO.m_strSex &&
                    m_objOriginalDataVO.m_strSummary == m_objDataVO.m_strSummary)
                {
                    m_enmOprState = enmObjectOperationState.Original;
                }
                else
                {
                    m_enmOprState = enmObjectOperationState.Modified;
                }
            }
        }

        public void m_mthAcceptChanges()
        {
            if (this.m_objOriginalDataVO == null)
            {
                this.m_objOriginalDataVO = new clsLisApplMainVO();
            }
            this.m_mthDataTransfer(this.m_objDataVO, this.m_objOriginalDataVO);
            this.m_enmOprState = enmObjectOperationState.Original;
        }

        private void m_mthSetPatientInfoFromPatient(clsLIS_Patient p_objPatient)
        {
            this.m_StrAge = p_objPatient.m_StrAge;
            this.m_StrBedNO = p_objPatient.m_StrBedNO;
            this.m_StrPatientCardID = p_objPatient.m_StrCardID;
            this.m_StrDiagnose = p_objPatient.m_StrDiagnose;
            this.m_StrICD = p_objPatient.m_StrICD;
            this.m_StrPatientInhospNO = p_objPatient.m_StrInhospNO;
            this.m_StrPatientID = p_objPatient.m_StrPatientID;
            this.m_StrPatientName = p_objPatient.m_StrPatientName;
            this.m_StrPatientType = p_objPatient.m_StrPatientTypeID;
            this.m_StrSex = p_objPatient.m_StrSex;
            this.m_StrPatientSubNO = p_objPatient.m_StrSubNO;

        }

        private void m_mthDataTransfer(clsLisApplMainVO p_objSource, clsLisApplMainVO p_objTarget)
        {
            p_objTarget.m_intEmergency = p_objSource.m_intEmergency;
            p_objTarget.m_intForm_int = p_objSource.m_intForm_int;
            p_objTarget.m_intPStatus_int = p_objSource.m_intPStatus_int;
            p_objTarget.m_intSpecial = p_objSource.m_intSpecial;
            p_objTarget.m_strAge = p_objSource.m_strAge;
            p_objTarget.m_strAppl_Dat = p_objSource.m_strAppl_Dat;
            p_objTarget.m_strAppl_DeptID = p_objSource.m_strAppl_DeptID;
            p_objTarget.m_strAppl_EmpID = p_objSource.m_strAppl_EmpID;
            p_objTarget.m_strApplication_Form_NO = p_objSource.m_strApplication_Form_NO;
            p_objTarget.m_strAPPLICATION_ID = p_objSource.m_strAPPLICATION_ID;
            p_objTarget.m_strBedNO = p_objSource.m_strBedNO;
            p_objTarget.m_strDiagnose = p_objSource.m_strDiagnose;
            p_objTarget.m_strICD = p_objSource.m_strICD;
            p_objTarget.m_strMODIFY_DAT = p_objSource.m_strMODIFY_DAT;
            p_objTarget.m_strOperator_ID = p_objSource.m_strOperator_ID;
            p_objTarget.m_strPatient_inhospitalno_chr = p_objSource.m_strPatient_inhospitalno_chr;
            p_objTarget.m_strPatient_Name = p_objSource.m_strPatient_Name;
            p_objTarget.m_strPatient_SubNO = p_objSource.m_strPatient_SubNO;
            p_objTarget.m_strPatientcardID = p_objSource.m_strPatientcardID;
            p_objTarget.m_strPatientID = p_objSource.m_strPatientID;
            p_objTarget.m_strPatientType = p_objSource.m_strPatientType;
            p_objTarget.m_strSex = p_objSource.m_strSex;
            p_objTarget.m_strSummary = p_objSource.m_strSummary;
            p_objTarget.m_strSampleType = p_objSource.m_strSampleType;
            p_objTarget.m_strSampleTypeID = p_objSource.m_strSampleTypeID;
            p_objTarget.m_strCheckContent = p_objSource.m_strCheckContent;
        } 

        #endregion

        #region 事件实现

        private void m_objAppReports_evtItemAdded(object sender, clsObjectArrEventArgs e)
        {
            if (e.m_ObjContentsArr != null)
            {
                for (int i = 0; i < e.m_ObjContentsArr.Length; i++)
                {
                    if (((clsLIS_AppCheckReport)e.m_ObjContentsArr[i]).m_ObjApp != this)
                    {
                        ((clsLIS_AppCheckReport)e.m_ObjContentsArr[i]).m_ObjApp = this;
                    }
                }
            }
        }

        private void m_objAppApplyUnits_evtItemAdded(object sender, clsObjectArrEventArgs e)
        {
            if (e.m_ObjContentsArr != null)
            {
                for (int i = 0; i < e.m_ObjContentsArr.Length; i++)
                {
                    if (((clsLIS_AppApplyUnit)e.m_ObjContentsArr[i]).m_ObjApp != this)
                    {
                        ((clsLIS_AppApplyUnit)e.m_ObjContentsArr[i]).m_ObjApp = this;
                    }
                }
            }
        }

        private void m_objAppReports_evtItemRemoved(object sender, clsObjectArrEventArgs e)
        {
            if (e.m_ObjContentsArr != null)
            {
                for (int i = 0; i < e.m_ObjContentsArr.Length; i++)
                {
                    if (((clsLIS_AppCheckReport)e.m_ObjContentsArr[i]).m_ObjApp == this)
                    {
                        ((clsLIS_AppCheckReport)e.m_ObjContentsArr[i]).m_ObjApp = null;
                    }
                }
            }
        }

        private void m_objAppApplyUnits_evtItemRemoved(object sender, clsObjectArrEventArgs e)
        {
            if (e.m_ObjContentsArr != null)
            {
                for (int i = 0; i < e.m_ObjContentsArr.Length; i++)
                {
                    if (((clsLIS_AppApplyUnit)e.m_ObjContentsArr[i]).m_ObjApp == this)
                    {
                        ((clsLIS_AppApplyUnit)e.m_ObjContentsArr[i]).m_ObjApp = null;
                    }
                }
            }
        } 

        #endregion

	}

	#endregion

	
    #region clsLIS_AppApplyUnit 刘彬 2004.05.28
	public class clsLIS_AppApplyUnit
	{
		private enmObjectOperationState m_enmOprState;

		private clsT_OPR_LIS_APP_APPLY_UNIT_VO m_objDataVO;
		private clsT_OPR_LIS_APP_APPLY_UNIT_VO m_objOriginalDataVO;
		private clsLIS_ApplyUnit m_objApplyUnit;
		private clsLisAppUnitItemVO[] m_objItemArr;
		

		private clsLIS_App m_objApp;

		#region VOManage
		/// <summary>
		///申请单ID
		/// </summary>
		public string m_StrAppID
		{
			get
			{
				return this.m_objDataVO.m_strAPPLICATION_ID_CHR;
			}
			set
			{
				if(this.m_objDataVO.m_strAPPLICATION_ID_CHR != value)
				{
					this.m_objDataVO.m_strAPPLICATION_ID_CHR = value;
					if(this.evtApplicationIDChanged != null)
					{
						evtApplicationIDChanged(this,new EventArgs());
					}
				}
			}
		}
		/// <summary>
		///用户自定义组痕迹跟踪
		/// </summary>
		public string m_StrUserGroupPath
		{
			get
			{
				return this.m_objDataVO.m_strUSER_GROUP_STRING;
			}
			set
			{
				this.m_objDataVO.m_strUSER_GROUP_STRING = value;
			}
		}
		/// <summary>
		///检验申请单元ID
		/// </summary>
		public string m_StrApplyUnitID
		{
			get
			{
				return this.m_objDataVO.m_strAPPLY_UNIT_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strAPPLY_UNIT_ID_CHR = value;
			}
		}
		#endregion

		public event EventHandler evtApplicationIDChanged;

		public  enmObjectOperationState m_EnuOprState
		{
			get
			{
				return this.m_enmOprState;
			}
		}


		public clsT_OPR_LIS_APP_APPLY_UNIT_VO m_ObjOriginalDataVO
		{
			get
			{
				return m_objOriginalDataVO;
			}
		}
		public clsT_OPR_LIS_APP_APPLY_UNIT_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			}
		}
		public clsLIS_ApplyUnit m_ObjApplyUnit{get{return this.m_objApplyUnit;} set{this.m_objApplyUnit = value;}}

		public clsLisAppUnitItemVO[] m_ObjItemArr
		{
			get
			{
				return this.m_objItemArr;
			}
			set
			{
				this.m_objItemArr = value;
			}
		}

		public clsLIS_App m_ObjApp
		{
			get
			{
				return this.m_objApp;
			} 
			set
			{
				if(value != this.m_objApp)
				{
					if(this.m_objApp != null)
					{	
						clsLIS_App objApp = this.m_objApp;
						this.m_objApp = null;
						objApp.m_ObjAppApplyUnits.Remove(this);
					}
					this.m_objApp = value;
					if(value != null)
					{
						this.m_objApp.m_ObjAppApplyUnits.Add(this);
					}
				}
			}
		}



		#region 构造函数
		public clsLIS_AppApplyUnit(clsT_OPR_LIS_APP_APPLY_UNIT_VO p_objDataVO)
		{
			this.m_objDataVO = p_objDataVO;
			m_enmOprState = enmObjectOperationState.New;
		}
		public clsLIS_AppApplyUnit(clsT_OPR_LIS_APP_APPLY_UNIT_VO p_objDataVO,bool p_blnIsOriginal)
		{
			if(p_blnIsOriginal)
			{
				this.m_objDataVO = p_objDataVO;
				this.m_objOriginalDataVO = new clsT_OPR_LIS_APP_APPLY_UNIT_VO();

				m_mthDataTransfer(m_objDataVO,m_objOriginalDataVO);

				m_enmOprState = enmObjectOperationState.Original;
			}
			else
			{
				this.m_objDataVO = p_objDataVO;
				m_enmOprState = enmObjectOperationState.New;
			}
		}
		#endregion

		/// <summary>
		/// 只有 Original,Modified 状态的使用本方法才有效
		/// </summary>
		public void m_mthDelete()
		{
			if(this.m_enmOprState != enmObjectOperationState.New)
			{
				this.m_enmOprState = enmObjectOperationState.Deleted;
			}
		}

		public void m_mthMatchOpState()
		{
			if(this.m_EnuOprState != enmObjectOperationState.New 
				&& this.m_EnuOprState != enmObjectOperationState.Deleted)
			{
				if(m_objDataVO.m_strAPPLICATION_ID_CHR == m_objOriginalDataVO.m_strAPPLICATION_ID_CHR
					&& m_objDataVO.m_strAPPLY_UNIT_ID_CHR == m_objOriginalDataVO.m_strAPPLY_UNIT_ID_CHR
					&& m_objDataVO.m_strUSER_GROUP_STRING == m_objOriginalDataVO.m_strUSER_GROUP_STRING)
				{
					m_enmOprState = enmObjectOperationState.Original;
				}
				else
				{
					m_enmOprState = enmObjectOperationState.Modified;
				}
			}
		}
		public void m_mthAcceptChanges()
		{
			if(this.m_objOriginalDataVO == null)
			{
				this.m_objOriginalDataVO = new clsT_OPR_LIS_APP_APPLY_UNIT_VO();
			}
			this.m_mthDataTransfer(this.m_objDataVO,this.m_objOriginalDataVO);
			this.m_enmOprState = enmObjectOperationState.Original;
		}

		public void m_mthDataTransfer(clsT_OPR_LIS_APP_APPLY_UNIT_VO p_objSource, clsT_OPR_LIS_APP_APPLY_UNIT_VO p_objTarget)
		{
			p_objTarget.m_strAPPLICATION_ID_CHR = p_objSource.m_strAPPLICATION_ID_CHR;
			p_objTarget.m_strAPPLY_UNIT_ID_CHR = p_objSource.m_strAPPLY_UNIT_ID_CHR;
			p_objTarget.m_strUSER_GROUP_STRING = p_objSource.m_strUSER_GROUP_STRING;
		}

	}
	#endregion


	#region clsLIS_AppCheckReport 刘彬 2004.05.28
	public class clsLIS_AppCheckReport
	{
		private enmObjectOperationState m_enmOprState;

		private clsT_OPR_LIS_APP_REPORT_VO m_objDataVO ;
		private clsT_OPR_LIS_APP_REPORT_VO m_objOriginalDataVO ;

		private clsLIS_CheckReport m_objCheckReport;

		private clsLIS_App m_objApp;
		private clsAppSampleGroupCollection m_objAppSampleGroups;

		#region VOManage
		/// <summary>
		///申请单ID
		/// </summary>
		public string m_StrAppID
		{
			get
			{
				return this.m_objDataVO.m_strAPPLICATION_ID_CHR;
			}
			set
			{
				if(this.m_objDataVO.m_strAPPLICATION_ID_CHR != value)
				{
					this.m_objDataVO.m_strAPPLICATION_ID_CHR = value;
					foreach(clsLIS_AppSampleGroup objAppSampleGroup in this.m_ObjAppSampleGroups)
					{
						objAppSampleGroup.m_StrAppID = value;
					}						
					if(this.evtApplicationIDChanged != null)
					{
						evtApplicationIDChanged(this,new EventArgs());
					}					
				}
			}
		}
		/// <summary>
		///报告意见的XML形式
		/// </summary>
		public string m_StrXMLSummary
		{
			get
			{
				return this.m_objDataVO.m_strXML_SUMMARY_VCHR;
			}
			set
			{
				this.m_objDataVO.m_strXML_SUMMARY_VCHR = value;
			}
		}
		/// <summary>
		///检验报告组ID
		/// </summary>
		public string m_StrReportGroupID
		{
			get
			{
				return this.m_objDataVO.m_strREPORT_GROUP_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strREPORT_GROUP_ID_CHR = value;
			}
		}
		/// <summary>
		///
		/// </summary>
		public string m_StrModifyDate
		{
			get
			{
				return this.m_objDataVO.m_strMODIFY_DAT;
			}
		}
		/// <summary>
		///报告意见
		/// </summary>
		public string m_StrSummary
		{
			get
			{
				return this.m_objDataVO.m_strSUMMARY_VCHR;
			}
			set
			{
				this.m_objDataVO.m_strSUMMARY_VCHR = value;
			}
		}
		/// <summary>
		///操作员ID
		/// </summary>
		public string m_StrOperatorID
		{
			get
			{
				return this.m_objDataVO.m_strOPERATOR_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strOPERATOR_ID_CHR = value;
			}
		}
		/// <summary>
		///状态：-1:历史记录 0 -- 无效 1:初始状态 2:已审核
		/// </summary>
		public int m_IntStatus
		{
			get
			{
				return this.m_objDataVO.m_intSTATUS_INT;
			}
			set
			{
				this.m_objDataVO.m_intSTATUS_INT = value;
			}
		}
		/// <summary>
		///报告日期
		/// </summary>
		public string m_StrReportDate
		{
			get
			{
				return this.m_objDataVO.m_strREPORT_DAT;
			}
			set
			{
				this.m_objDataVO.m_strREPORT_DAT = value;
			}
		}
		/// <summary>
		///报告者id
		/// </summary>
		public string m_StrReportorId
		{
			get
			{
				return this.m_objDataVO.m_strREPORTOR_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strREPORTOR_ID_CHR = value;
			}
		}
		/// <summary>
		///审核时间
		/// </summary>
		public string m_StrConfirmDate
		{
			get
			{
				return this.m_objDataVO.m_strCONFIRM_DAT;
			}
			set
			{
				this.m_objDataVO.m_strCONFIRM_DAT = value;
			}
		}
		/// <summary>
		///审核者id
		/// </summary>
		public string m_StrConfirmerID
		{
			get
			{
				return this.m_objDataVO.m_strCONFIRMER_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strCONFIRMER_ID_CHR = value;
			}
		}
		#endregion

		public event EventHandler evtApplicationIDChanged;

		public  enmObjectOperationState m_EnuOprState
		{
			get
			{
				return this.m_enmOprState;
			}
		}


		public clsT_OPR_LIS_APP_REPORT_VO m_ObjOriginalDataVO
		{
			get
			{
				return m_objOriginalDataVO;
			}
		}
		public clsT_OPR_LIS_APP_REPORT_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			} 
		}


		public clsLIS_CheckReport m_ObjCheckReport{get{return this.m_objCheckReport;} set{this.m_objCheckReport = value;}}
		public clsLIS_App m_ObjApp
		{
			get
			{
				return this.m_objApp;
			} 
			set
			{
				if(value != this.m_objApp)
				{
					if(this.m_objApp != null)
					{	
						clsLIS_App objApp = this.m_objApp;
						this.m_objApp = null;
						objApp.m_ObjAppReports.Remove(this);
					}
					this.m_objApp = value;
					if(value != null)
					{
						this.m_objApp.m_ObjAppReports.Add(this);
					}
				}
			}
		}
		public clsAppSampleGroupCollection m_ObjAppSampleGroups{get{return this.m_objAppSampleGroups;} }

		#region 构造函数
		public clsLIS_AppCheckReport(clsT_OPR_LIS_APP_REPORT_VO p_objDataVO)
		{
			this.m_objDataVO = p_objDataVO;
			m_enmOprState = enmObjectOperationState.New;
			m_objAppSampleGroups = new clsAppSampleGroupCollection();
			m_objAppSampleGroups.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppSampleGroups_evtItemAdded);
			m_objAppSampleGroups.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppSampleGroups_evtItemRemoved);
		}
		public clsLIS_AppCheckReport(clsT_OPR_LIS_APP_REPORT_VO p_objDataVO,bool p_blnIsOriginal)
		{
			if(p_blnIsOriginal)
			{
				this.m_objDataVO = p_objDataVO;
				this.m_objOriginalDataVO = new clsT_OPR_LIS_APP_REPORT_VO();

				m_mthDataTransfer(m_objDataVO,m_objOriginalDataVO);

				m_enmOprState = enmObjectOperationState.Original;
			}
			else
			{
				this.m_objDataVO = p_objDataVO;
				m_enmOprState = enmObjectOperationState.New;
			}
			m_objAppSampleGroups = new clsAppSampleGroupCollection();
			m_objAppSampleGroups.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppSampleGroups_evtItemAdded);
			m_objAppSampleGroups.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppSampleGroups_evtItemRemoved);
		}
		#endregion


		/// <summary>
		/// 只有 Original,Modified 状态的使用本方法才有效
		/// </summary>
		public void m_mthDelete()
		{
			if(this.m_enmOprState != enmObjectOperationState.New)
			{
				this.m_enmOprState = enmObjectOperationState.Deleted;
			}
		}

		public void m_mthMatchOpState()
		{
			if(this.m_EnuOprState != enmObjectOperationState.New 
				&& this.m_EnuOprState != enmObjectOperationState.Deleted)
			{
				if(m_objOriginalDataVO.m_intSTATUS_INT == m_objDataVO.m_intSTATUS_INT && 
					m_objOriginalDataVO.m_strAPPLICATION_ID_CHR == m_objDataVO.m_strAPPLICATION_ID_CHR && 
					m_objOriginalDataVO.m_strCONFIRM_DAT == m_objDataVO.m_strCONFIRM_DAT && 
					m_objOriginalDataVO.m_strCONFIRMER_ID_CHR == m_objDataVO.m_strCONFIRMER_ID_CHR && 
					m_objOriginalDataVO.m_strMODIFY_DAT == m_objDataVO.m_strMODIFY_DAT && 
					m_objOriginalDataVO.m_strOPERATOR_ID_CHR == m_objDataVO.m_strOPERATOR_ID_CHR && 
					m_objOriginalDataVO.m_strREPORT_DAT == m_objDataVO.m_strREPORT_DAT && 
					m_objOriginalDataVO.m_strREPORT_GROUP_ID_CHR == m_objDataVO.m_strREPORT_GROUP_ID_CHR && 
					m_objOriginalDataVO.m_strREPORTOR_ID_CHR == m_objDataVO.m_strREPORTOR_ID_CHR && 
					m_objOriginalDataVO.m_strSUMMARY_VCHR == m_objDataVO.m_strSUMMARY_VCHR && 
					m_objOriginalDataVO.m_strXML_SUMMARY_VCHR == m_objDataVO.m_strXML_SUMMARY_VCHR)
				{
					m_enmOprState = enmObjectOperationState.Original;
				}
				else
				{
					m_enmOprState = enmObjectOperationState.Modified;
				}
			}
		}

		public void m_mthAcceptChanges()
		{
			if(this.m_objOriginalDataVO == null)
			{
				this.m_objOriginalDataVO = new clsT_OPR_LIS_APP_REPORT_VO();
			}
			this.m_mthDataTransfer(this.m_objDataVO,this.m_objOriginalDataVO);
			this.m_enmOprState = enmObjectOperationState.Original;
		}


		public void m_mthDataTransfer(clsT_OPR_LIS_APP_REPORT_VO p_objSource, clsT_OPR_LIS_APP_REPORT_VO p_objTarget)
		{
			p_objTarget.m_intSTATUS_INT = p_objSource.m_intSTATUS_INT;
			p_objTarget.m_strAPPLICATION_ID_CHR = p_objSource.m_strAPPLICATION_ID_CHR;
			p_objTarget.m_strCONFIRM_DAT = p_objSource.m_strCONFIRM_DAT;
			p_objTarget.m_strCONFIRMER_ID_CHR = p_objSource.m_strCONFIRMER_ID_CHR;
			p_objTarget.m_strMODIFY_DAT = p_objSource.m_strMODIFY_DAT;
			p_objTarget.m_strOPERATOR_ID_CHR = p_objSource.m_strOPERATOR_ID_CHR;
			p_objTarget.m_strREPORT_DAT = p_objSource.m_strREPORT_DAT;
			p_objTarget.m_strREPORT_GROUP_ID_CHR = p_objSource.m_strREPORT_GROUP_ID_CHR;
			p_objTarget.m_strREPORTOR_ID_CHR = p_objSource.m_strREPORTOR_ID_CHR;
			p_objTarget.m_strSUMMARY_VCHR = p_objSource.m_strSUMMARY_VCHR;
			p_objTarget.m_strXML_SUMMARY_VCHR = p_objSource.m_strXML_SUMMARY_VCHR;
		}


		private void m_objAppSampleGroups_evtItemAdded(object sender, clsObjectArrEventArgs e)
		{
			if(e.m_ObjContentsArr != null)
			{
				for(int i=0;i<e.m_ObjContentsArr.Length;i++)
				{
					if(((clsLIS_AppSampleGroup)e.m_ObjContentsArr[i]).m_ObjAppReport != this)
					{
						((clsLIS_AppSampleGroup)e.m_ObjContentsArr[i]).m_ObjAppReport = this;
					}
				}
			}
		}

		private void m_objAppSampleGroups_evtItemRemoved(object sender, clsObjectArrEventArgs e)
		{
			if(e.m_ObjContentsArr != null)
			{
				for(int i=0;i<e.m_ObjContentsArr.Length;i++)
				{
					if(((clsLIS_AppSampleGroup)e.m_ObjContentsArr[i]).m_ObjAppReport == this)
					{
						((clsLIS_AppSampleGroup)e.m_ObjContentsArr[i]).m_ObjAppReport = null;
					}
				}
			}
		}
	}
	#endregion
	#region clsLIS_AppSampleGroup 刘彬 2004.05.28
	public class clsLIS_AppSampleGroup
	{
		private enmObjectOperationState m_enmOprState;

		private clsT_OPR_LIS_APP_SAMPLE_VO m_objDataVO;
		private clsT_OPR_LIS_APP_SAMPLE_VO m_objOriginalDataVO;

		private clsLIS_SampleGroup m_objSampleGroup;
		private int m_intPrintSeq = -1;

		private clsLIS_AppCheckReport m_objAppReport;
		private clsAppCheckItemCollection m_objAppCheckItems;
		private clsLIS_Sample m_objSample;
		private clsLIS_AppApplyUnit[] m_objAppUnitArr;

		#region VOManage
		/// <summary>
		///申请单ID
		/// </summary>
		public string m_StrAppID
		{
			get
			{
				return this.m_objDataVO.m_strAPPLICATION_ID_CHR;
			}
			set
			{
				if(this.m_objDataVO.m_strAPPLICATION_ID_CHR != value)
				{
					this.m_objDataVO.m_strAPPLICATION_ID_CHR = value;
					if(this.m_ObjSample != null)
					{
						this.m_ObjSample.m_StrAppID = value;
					}
					foreach(clsLIS_AppCheckItem objAppCheckItem in this.m_ObjAppCheckItems)
					{
						objAppCheckItem.m_StrAppID = value;
					}
										
					if(this.evtApplicationIDChanged != null)
					{
						evtApplicationIDChanged(this,new EventArgs());
					}					
				}
			}
		}
		/// <summary>
		///检验样本组ID
		/// </summary>
		public string m_StrSampleGroupID
		{
			get
			{
				return this.m_objDataVO.m_strSAMPLE_GROUP_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strSAMPLE_GROUP_ID_CHR = value;
			}
		}
		/// <summary>
		///检验报告组ID
		/// </summary>
		public string m_StrReportGroupID
		{
			get
			{
				return this.m_objDataVO.m_strREPORT_GROUP_ID_CHR;
			}	
			set
			{
				this.m_objDataVO.m_strREPORT_GROUP_ID_CHR = value;
			}
		}
		/// <summary>
		///样本ID
		/// </summary>
		public string m_StrSampleID
		{
			get
			{
				return this.m_objDataVO.m_strSAMPLE_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strSAMPLE_ID_CHR = value;
			}
		}
		#endregion

		public event EventHandler evtApplicationIDChanged;

		public  enmObjectOperationState m_EnuOprState
		{
			get
			{
				return this.m_enmOprState;
			}
		}


		public clsT_OPR_LIS_APP_SAMPLE_VO m_ObjOriginalDataVO
		{
			get
			{
				return m_objOriginalDataVO;
			}
		}

        /// <summary>
        /// 检验单下的标本组
        /// </summary>
		public clsT_OPR_LIS_APP_SAMPLE_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			} 
		}

		public clsLIS_AppApplyUnit[] m_ObjAppUnitArr
		{
			get
			{
				return this.m_objAppUnitArr;
			}
			set
			{
				this.m_objAppUnitArr = value;
			}
		}

		public int m_IntPrintSeq
		{
			get
			{
				return this.m_intPrintSeq;
			}
			set
			{
				this.m_intPrintSeq = value;
			}
		}	
	

		public clsLIS_SampleGroup m_ObjSampleGroup{get{return this.m_objSampleGroup;} set{this.m_objSampleGroup = value;}}
		public clsLIS_AppCheckReport m_ObjAppReport
		{
			get
			{
				return this.m_objAppReport;
			} 
			set
			{
				if(value != this.m_objAppReport)
				{
					if(this.m_objAppReport != null)
					{	
						clsLIS_AppCheckReport objAppReport = this.m_objAppReport;
						this.m_objAppReport = null;
						objAppReport.m_ObjAppSampleGroups.Remove(this);
					}
					this.m_objAppReport = value;
					if(value != null)
					{
						this.m_objAppReport.m_ObjAppSampleGroups.Add(this);
					}
				}
			}
		}
		public clsAppCheckItemCollection m_ObjAppCheckItems{get{return this.m_objAppCheckItems;}}
		public clsLIS_Sample m_ObjSample
		{
			get
			{
				return this.m_objSample;
			} 
			set
			{
				if(this.m_objSample != null && !m_objSample.Equals(value))
				{
					this.m_objSample.m_ObjAppSampeGroup = null;
				}			
				if(value == null || !value.Equals(this.m_objSample))
				{

					this.m_objSample = value;
					if(this.m_objSample != null)
					{
						this.m_objSample.m_ObjAppSampeGroup = this;						
					}
				}
			}
		}


		#region 构造函数
		public clsLIS_AppSampleGroup(clsT_OPR_LIS_APP_SAMPLE_VO p_objDataVO)
		{
			this.m_objDataVO = p_objDataVO;
			m_enmOprState = enmObjectOperationState.New;
			m_objAppCheckItems = new clsAppCheckItemCollection();
			m_objAppCheckItems.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppCheckItems_evtItemAdded);
			m_objAppCheckItems.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppCheckItems_evtItemRemoved);
		}
		public clsLIS_AppSampleGroup(clsT_OPR_LIS_APP_SAMPLE_VO p_objDataVO,bool p_blnIsOriginal)
		{
			if(p_blnIsOriginal)
			{
				this.m_objDataVO = p_objDataVO;
				this.m_objOriginalDataVO = new clsT_OPR_LIS_APP_SAMPLE_VO();

				m_mthDataTransfer(m_objDataVO,m_objOriginalDataVO);

				m_enmOprState = enmObjectOperationState.Original;
			}
			else
			{
				this.m_objDataVO = p_objDataVO;
				m_enmOprState = enmObjectOperationState.New;
			}
			m_objAppCheckItems = new clsAppCheckItemCollection();
			m_objAppCheckItems.evtItemAdded += new dlgCollectionContentsChangedEventHandler(m_objAppCheckItems_evtItemAdded);
			m_objAppCheckItems.evtItemRemoved += new dlgCollectionContentsChangedEventHandler(m_objAppCheckItems_evtItemRemoved);
		}
		#endregion

		/// <summary>
		/// 只有 Original,Modified 状态的使用本方法才有效
		/// </summary>
		public void m_mthDelete()
		{
			if(this.m_enmOprState != enmObjectOperationState.New)
			{
				this.m_enmOprState = enmObjectOperationState.Deleted;
			}
		}

		public void m_mthMatchOpState()
		{
			if(this.m_EnuOprState != enmObjectOperationState.New 
				&& this.m_EnuOprState != enmObjectOperationState.Deleted)
			{
				if(m_objDataVO.m_strAPPLICATION_ID_CHR == m_objOriginalDataVO.m_strAPPLICATION_ID_CHR
					&& m_objDataVO.m_strSAMPLE_ID_CHR == m_objOriginalDataVO.m_strSAMPLE_ID_CHR
					&& m_objDataVO.m_strREPORT_GROUP_ID_CHR == m_objOriginalDataVO.m_strREPORT_GROUP_ID_CHR
					&& m_objDataVO.m_strSAMPLE_GROUP_ID_CHR == m_objOriginalDataVO.m_strSAMPLE_GROUP_ID_CHR)
				{
					m_enmOprState = enmObjectOperationState.Original;
				}
				else
				{
					m_enmOprState = enmObjectOperationState.Modified;
				}
			}
		}

		public void m_mthAcceptChanges()
		{
			if(this.m_objOriginalDataVO == null)
			{
				this.m_objOriginalDataVO = new clsT_OPR_LIS_APP_SAMPLE_VO();
			}
			this.m_mthDataTransfer(this.m_objDataVO,this.m_objOriginalDataVO);
			this.m_enmOprState = enmObjectOperationState.Original;
		}


		public void m_mthDataTransfer(clsT_OPR_LIS_APP_SAMPLE_VO p_objSource, clsT_OPR_LIS_APP_SAMPLE_VO p_objTarget)
		{
			p_objTarget.m_strAPPLICATION_ID_CHR = p_objSource.m_strAPPLICATION_ID_CHR;
			p_objTarget.m_strREPORT_GROUP_ID_CHR = p_objSource.m_strREPORT_GROUP_ID_CHR;
			p_objTarget.m_strSAMPLE_GROUP_ID_CHR = p_objSource.m_strSAMPLE_GROUP_ID_CHR;
			p_objTarget.m_strSAMPLE_ID_CHR = p_objSource.m_strSAMPLE_ID_CHR;
		}


		public void m_mthGenerateNewSample()
		{
			clsT_OPR_LIS_SAMPLE_VO obj = new clsT_OPR_LIS_SAMPLE_VO();
			this.m_ObjSample = new clsLIS_Sample(obj);
		}

		private void m_objAppCheckItems_evtItemAdded(object sender, clsObjectArrEventArgs e)
		{
			if(e.m_ObjContentsArr != null)
			{
				for(int i=0;i<e.m_ObjContentsArr.Length;i++)
				{
					if(((clsLIS_AppCheckItem)e.m_ObjContentsArr[i]).m_ObjAppSampleGroup != this)
					{
						((clsLIS_AppCheckItem)e.m_ObjContentsArr[i]).m_ObjAppSampleGroup = this;
					}
				}
			}
		}

		private void m_objAppCheckItems_evtItemRemoved(object sender, clsObjectArrEventArgs e)
		{
			if(e.m_ObjContentsArr != null)
			{
				for(int i=0;i<e.m_ObjContentsArr.Length;i++)
				{
					if(((clsLIS_AppCheckItem)e.m_ObjContentsArr[i]).m_ObjAppSampleGroup == this)
					{
						((clsLIS_AppCheckItem)e.m_ObjContentsArr[i]).m_ObjAppSampleGroup = null;
					}
				}
			}
		}
	}
	#endregion
	#region clsLIS_AppCheckItem 刘彬 2004.05.28
	public class clsLIS_AppCheckItem
	{
		private enmObjectOperationState m_enmOprState;

		private clsT_OPR_LIS_APP_CHECK_ITEM_VO m_objDataVO;
		private clsT_OPR_LIS_APP_CHECK_ITEM_VO m_objOriginalDataVO;

		private clsLIS_CheckItem m_objCheckItem;
		private int m_intPrintSeq = -1;

		private clsLIS_AppSampleGroup m_objAppSampleGroup;
		private clsLIS_CheckItemResult m_objCheckResult;
		private clsLIS_CheckItemDeviceResult m_objDeviceResult;

		#region VOManage
		/// <summary>
		///检验项目编号
		/// </summary>
		public string m_StrCheckItemID
		{
			get
			{
				return this.m_objDataVO.m_strCHECK_ITEM_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strCHECK_ITEM_ID_CHR = value;
			}
		}
		/// <summary>
		///检验样本组ID
		/// </summary>
		public string m_StrSampleGroupID
		{
			get
			{
				return this.m_objDataVO.m_strSAMPLE_GROUP_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strSAMPLE_GROUP_ID_CHR = value;
			}
		}
		/// <summary>
		///检验报告组ID
		/// </summary>
		public string m_StrReportGroupID
		{
			get
			{
				return this.m_objDataVO.m_strREPORT_GROUP_ID_CHR;
			}	
			set
			{
				this.m_objDataVO.m_strREPORT_GROUP_ID_CHR = value;
			}
		}
		/// <summary>
		///申请单ID
		/// </summary>
		public string m_StrAppID
		{
			get
			{
				return this.m_objDataVO.m_strAPPLICATION_ID_CHR;
			}
			set
			{
				if(this.m_objDataVO.m_strAPPLICATION_ID_CHR != value)
				{
					this.m_objDataVO.m_strAPPLICATION_ID_CHR = value;

					if(this.evtApplicationIDChanged != null)
					{
						evtApplicationIDChanged(this,new EventArgs());
					}	
				}
			}
		}
		#endregion

		public event EventHandler evtApplicationIDChanged;

		public  enmObjectOperationState m_EnuOprState
		{
			get
			{
				return this.m_enmOprState;
			}
		}


		public clsT_OPR_LIS_APP_CHECK_ITEM_VO m_ObjOriginalDataVO
		{
			get
			{
				return m_objOriginalDataVO;
			}
		}
		public clsT_OPR_LIS_APP_CHECK_ITEM_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			} 
		}


		public clsLIS_CheckItem m_ObjCheckItem
		{
			get
			{
				return this.m_objCheckItem;
			} 
			set
			{
				this.m_objCheckItem = value;
			}
		}

		public int m_IntPrintSeq
		{
			get
			{
				return this.m_intPrintSeq;
			}
			set
			{
				this.m_intPrintSeq = value;
			}
		}


		public clsLIS_AppSampleGroup m_ObjAppSampleGroup
		{
			get
			{
				return this.m_objAppSampleGroup;
			} 
			set
			{
				if(value != this.m_objAppSampleGroup)
				{
					if(this.m_objAppSampleGroup != null)
					{	
						clsLIS_AppSampleGroup objAppSampleGroup = this.m_objAppSampleGroup;
						this.m_objAppSampleGroup = null;
						objAppSampleGroup.m_ObjAppCheckItems.Remove(this);
						
					}
					this.m_objAppSampleGroup = value;
					if(value != null)
					{
						this.m_objAppSampleGroup.m_ObjAppCheckItems.Add(this);
					}
				}
			}
		}

		public clsLIS_CheckItemResult m_ObjCheckResult
		{
			get
			{
				return this.m_objCheckResult;
			}
			set
			{
				this.m_objCheckResult.m_ObjAppCheckItem = null;
				this.m_objCheckResult = value;
				if(this.m_objCheckResult != null)
				{
					this.m_objCheckResult.m_ObjAppCheckItem = this;
				}
			}
		}
		public clsLIS_CheckItemDeviceResult m_ObjDeviceResult
		{
			get
			{
				return this.m_objDeviceResult;
			}
			set
			{
				this.m_objDeviceResult = value;
			}
		}


		public object Tag;


		#region 构造函数
		public clsLIS_AppCheckItem(clsT_OPR_LIS_APP_CHECK_ITEM_VO p_objDataVO)
		{
			this.m_objDataVO = p_objDataVO;
			m_enmOprState = enmObjectOperationState.New;
		}
		public clsLIS_AppCheckItem(clsT_OPR_LIS_APP_CHECK_ITEM_VO p_objDataVO,bool p_blnIsOriginal)
		{
			if(p_blnIsOriginal)
			{
				this.m_objDataVO = p_objDataVO;
				this.m_objOriginalDataVO = new clsT_OPR_LIS_APP_CHECK_ITEM_VO();

				m_mthDataTransfer(m_objDataVO,m_objOriginalDataVO);
				m_enmOprState = enmObjectOperationState.Original;
			}
			else
			{
				this.m_objDataVO = p_objDataVO;
				m_enmOprState = enmObjectOperationState.New;
			}
		}
		#endregion

		/// <summary>
		/// 只有 Original,Modified 状态的使用本方法才有效
		/// </summary>
		public void m_mthDelete()
		{
			if(this.m_enmOprState != enmObjectOperationState.New)
			{
				this.m_enmOprState = enmObjectOperationState.Deleted;
			}
		}

		public void m_mthMatchOpState()
		{
			if(this.m_EnuOprState != enmObjectOperationState.New 
				&& this.m_EnuOprState != enmObjectOperationState.Deleted)
			{
				if(m_objDataVO.m_strAPPLICATION_ID_CHR == m_objOriginalDataVO.m_strAPPLICATION_ID_CHR
					&& m_objDataVO.m_strCHECK_ITEM_ID_CHR == m_objOriginalDataVO.m_strCHECK_ITEM_ID_CHR
					&& m_objDataVO.m_strREPORT_GROUP_ID_CHR == m_objOriginalDataVO.m_strREPORT_GROUP_ID_CHR
					&& m_objDataVO.m_strSAMPLE_GROUP_ID_CHR == m_objOriginalDataVO.m_strSAMPLE_GROUP_ID_CHR)
				{
					m_enmOprState = enmObjectOperationState.Original;
				}
				else
				{
					m_enmOprState = enmObjectOperationState.Modified;
				}
			}
		}

		public void m_mthAcceptChanges()
		{
			if(this.m_objOriginalDataVO == null)
			{
				this.m_objOriginalDataVO = new clsT_OPR_LIS_APP_CHECK_ITEM_VO();
			}
			this.m_mthDataTransfer(this.m_objDataVO,this.m_objOriginalDataVO);
			this.m_enmOprState = enmObjectOperationState.Original;
		}


		public void m_mthDataTransfer(clsT_OPR_LIS_APP_CHECK_ITEM_VO p_objSource, clsT_OPR_LIS_APP_CHECK_ITEM_VO p_objTarget)
		{
			p_objTarget.m_strAPPLICATION_ID_CHR = p_objSource.m_strAPPLICATION_ID_CHR;
			p_objTarget.m_strCHECK_ITEM_ID_CHR = p_objSource.m_strCHECK_ITEM_ID_CHR;
			p_objTarget.m_strREPORT_GROUP_ID_CHR = p_objSource.m_strREPORT_GROUP_ID_CHR;
			p_objTarget.m_strSAMPLE_GROUP_ID_CHR = p_objSource.m_strSAMPLE_GROUP_ID_CHR;

		}


		public void m_mthGenerateCheckResult()
		{
			clsCheckResult_VO objVO = new clsCheckResult_VO();
			clsLIS_CheckItemResult obj = new clsLIS_CheckItemResult(objVO);
			this.m_ObjCheckResult = obj;
		}
	}
	#endregion
	#region clsLIS_Sample 刘彬 2004.05.28
	public class clsLIS_Sample
	{
		private enmObjectOperationState m_enmOprState;

		private clsT_OPR_LIS_SAMPLE_VO m_objDataVO;
		private clsT_OPR_LIS_SAMPLE_VO m_objOriginalDataVO;

		private clsLIS_AppSampleGroup m_objAppSampeGroup;
		private clsLIS_DeviceRelation m_objDeviceRelation;

		private string m_strSampleID;

		#region VOManage
		/// <summary>
		///样本联号：指样本中心的顺序编号
		/// </summary>
		public string m_StrSampleID
		{
			get
			{
				return this.m_objDataVO.m_strSAMPLE_ID_CHR;
			}
			set
			{
				if(this.m_objDataVO.m_strSAMPLE_ID_CHR != value || this.m_strSampleID != value)
				{
					this.m_objDataVO.m_strSAMPLE_ID_CHR = value;
					this.m_strSampleID = value;
					if(this.m_objDeviceRelation != null)
					{
						this.m_objDeviceRelation.m_StrSampleID = value;
					}
					if(this.m_ObjAppSampeGroup != null)
					{
						this.m_ObjAppSampeGroup.m_StrSampleID = value;
						foreach(clsLIS_AppCheckItem objCheckItem in this.m_ObjAppSampeGroup.m_ObjAppCheckItems)
						{
							if(objCheckItem.m_ObjCheckResult != null)
							{
								objCheckItem.m_ObjCheckResult.m_StrSampleID = value;
							}							
						}
					}
					if(this.evtSampleIDChanged != null)
					{
						evtSampleIDChanged(this,new EventArgs());
					}
				}
			}
		}

		/// <summary>
		///申请单编号
		/// </summary>
		public string m_StrAppID
		{
			get
			{
				return this.m_objDataVO.m_strAPPLICATION_ID_CHR;
			}
			set
			{
				if(this.m_objDataVO.m_strAPPLICATION_ID_CHR != value)
				{
					this.m_objDataVO.m_strAPPLICATION_ID_CHR = value;
					if(this.evtApplicationIDChanged != null)
					{
						evtApplicationIDChanged(this,null);
					}
				}
			}
		}



		/// <summary>
		///申请日期
		/// </summary>
		public string m_StrAppDate
		{
			get
			{
				return this.m_objDataVO.m_strAPPL_DAT;
			}
			set
			{
				this.m_objDataVO.m_strAPPL_DAT = value;
			}
		}
		/// <summary>
		///性别
		/// </summary>
		public string m_StrSex
		{
			get
			{
				return this.m_objDataVO.m_strSEX_CHR;
			}
			set
			{
				this.m_objDataVO.m_strSEX_CHR = value;
			}
		}
		/// <summary>
		///病人姓名
		/// </summary>
		public string m_StrPatientName
		{
			get
			{
				return this.m_objDataVO.m_strPATIENT_NAME_VCHR;
			}
			set
			{
				this.m_objDataVO.m_strPATIENT_NAME_VCHR = value;
			}
		}
		/// <summary>
		///病人辅助编号
		/// </summary>
		public string m_StrPatientSubNO
		{
			get
			{
				return this.m_objDataVO.m_strPATIENT_SUBNO_CHR;
			}
			set
			{
				this.m_objDataVO.m_strPATIENT_SUBNO_CHR = value;
			}
		}
		/// <summary>
		///年龄
		/// </summary>
		public string m_StrAge
		{
			get
			{
				return this.m_objDataVO.m_strAGE_CHR;
			}
			set
			{
				this.m_objDataVO.m_strAGE_CHR = value;
			}
		}
		/// <summary>
		///病人类别
		/// </summary>
		public string m_StrPatientType
		{
			get
			{
				return this.m_objDataVO.m_strPATIENT_TYPE_CHR;
			}
			set
			{
				this.m_objDataVO.m_strPATIENT_TYPE_CHR = value;
			}
		}
		/// <summary>
		///临床诊断
		/// </summary>
		public string m_StrDiagnose
		{
			get
			{
				return this.m_objDataVO.m_strDIAGNOSE_VCHR;
			}
			set
			{
				this.m_objDataVO.m_strDIAGNOSE_VCHR = value;
			}
		}
		/// <summary>
		///样本类型
		/// </summary>
		public string m_StrSampleType
		{
			get
			{
				return this.m_objDataVO.m_strSAMPLETYPE_VCHR;
			}
			set
			{
				this.m_objDataVO.m_strSAMPLETYPE_VCHR = value;
			}
		}
		/// <summary>
		///样本状态
		/// </summary>
		public string m_StrSampleState
		{
			get
			{
				return this.m_objDataVO.m_strSAMPLESTATE_VCHR;
			}
			set
			{
				this.m_objDataVO.m_strSAMPLESTATE_VCHR = value;
			}
		}
		/// <summary>
		///床号
		/// </summary>
		public string m_StrBedNO
		{
			get
			{
				return this.m_objDataVO.m_strBEDNO_CHR;
			}
			set
			{
				this.m_objDataVO.m_strBEDNO_CHR = value;
			}
		}
		/// <summary>
		///临床诊断ICD码
		/// </summary>
		public string m_StrICD
		{
			get
			{
				return this.m_objDataVO.m_strICD_VCHR;
			}
			set
			{
				this.m_objDataVO.m_strICD_VCHR = value;
			}
		}
		/// <summary>
		///就诊卡号
		/// </summary>
		public string m_StrPatientCardID
		{
			get
			{
				return this.m_objDataVO.m_strPATIENTCARDID_CHR;
			}
			set
			{
					this.m_objDataVO.m_strPATIENTCARDID_CHR = value;
			}
		}
		/// <summary>
		///瓶签号或条码
		/// </summary>
		public string m_StrBarcode
		{
			get
			{
				return this.m_objDataVO.m_strBARCODE_VCHR;
			}
			set
			{
				this.m_objDataVO.m_strBARCODE_VCHR = value;
			}
		}
		/// <summary>
		///病人编号：每个病人的维一编号。
		/// </summary>
		public string m_StrPatientID
		{
			get
			{
				return this.m_objDataVO.m_strPATIENTID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strPATIENTID_CHR = value;
			}
		}
		/// <summary>
		///采样时间
		/// </summary>
		public string m_StrSamplingDate
		{
			get
			{
				return this.m_objDataVO.m_strSAMPLING_DATE_DAT;
			}
			set
			{
				this.m_objDataVO.m_strSAMPLING_DATE_DAT = value;
			}
		}
		/// <summary>
		///在数据库中操作这条记录的用户员工号。
		/// </summary>
		public string m_StrOperatorID
		{
			get
			{
				return this.m_objDataVO.m_strOPERATOR_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strOPERATOR_ID_CHR = value;
			}
		}
		/// <summary>
		///
		/// </summary>
		public string m_StrModifyDate
		{
			get
			{
				return this.m_objDataVO.m_strMODIFY_DAT;
			}
		}
		/// <summary>
		///申请医生的员工ID
		/// </summary>
		public string m_StrAppDoctID
		{
			get
			{
				return this.m_objDataVO.m_strAPPL_EMPID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strAPPL_EMPID_CHR = value;
			}
		}
		/// <summary>
		///申请检验的科室部门ID
		/// </summary>
		public string m_StrAppDeptID
		{
			get
			{
				return this.m_objDataVO.m_strAPPL_DEPTID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strAPPL_DEPTID_CHR = value;
			}
		}
		/// <summary>
		///记录状态  -1:历史记录 0 -- 无效 1:初始状态 2:已采集 3:已核收 4:空(备用) 5:已报告 6:已审核 7:已退回
		/// </summary>
		public int m_IntStatus
		{
			get
			{
				return this.m_objDataVO.m_intSTATUS_INT;
			}
			set
			{
				this.m_objDataVO.m_intSTATUS_INT = value;
			}
		}
		/// <summary>
		///样本类型ID,应用T_AID_LIS_SAMPLETYPE表
		/// </summary>
		public string m_StrSampleTypeID
		{
			get
			{
				return this.m_objDataVO.m_strSAMPLE_TYPE_ID_CHR;
			}	
			set
			{
				this.m_objDataVO.m_strSAMPLE_TYPE_ID_CHR = value;

			}
		}
		/// <summary>
		///质控品ID，－1表示非质控品
		/// </summary>
		public string m_strQCSampleID
		{
			get
			{
				return this.m_objDataVO.m_strQCSAMPLEID_CHR;
			}
			set
			{				
				this.m_objDataVO.m_strQCSAMPLEID_CHR = value;					
			}
		}
		/// <summary>
		///样品类别 1－仪器标本 2－手工标本 3－质控标本
		/// </summary>
		public string m_StrSampleKind
		{
			get
			{
				return this.m_objDataVO.m_strSAMPLEKIND_CHR;
			}
			set
			{
				this.m_objDataVO.m_strSAMPLEKIND_CHR = value;
			}
		}
		/// <summary>
		///样品检验日期
		/// </summary>
		public string m_StrCheckDate
		{
			get
			{
				return this.m_objDataVO.m_strCHECK_DATE_DAT;
			}
			set
			{
				this.m_objDataVO.m_strCHECK_DATE_DAT = value;
			}
		}
		/// <summary>
		///核收时间
		/// </summary>
		public string m_StrAcceptDate
		{
			get
			{
				return this.m_objDataVO.m_strACCEPT_DAT;
			}
			set
			{
				this.m_objDataVO.m_strACCEPT_DAT = value;
			}
		}
		/// <summary>
		///核收人员
		/// </summary>
		public string m_StrAcceptorID
		{
			get
			{
				return this.m_objDataVO.m_strACCEPTOR_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strACCEPTOR_ID_CHR = value;
			}
		}
		/// <summary>
		///病人住院号
		/// </summary>
		public string m_StrPatientInhospNO
		{
			get
			{
				return this.m_objDataVO.m_strPATIENT_INHOSPITALNO_CHR;
			}
			set
			{
				this.m_objDataVO.m_strPATIENT_INHOSPITALNO_CHR = value;
			}
		}
		/// <summary>
		///审核时间
		/// </summary>
		public string m_StrConfirmDAte
		{
			get
			{
				return this.m_objDataVO.m_strCONFIRM_DAT;
			}
			set
			{
				this.m_objDataVO.m_strCONFIRM_DAT = value;
			}
		}
		/// <summary>
		///审核者id
		/// </summary>
		public string m_StrConfirmerID
		{
			get
			{
				return this.m_objDataVO.m_strCONFIRMER_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strCONFIRMER_ID_CHR = value;					
			}
		}
		/// <summary>
		/// 采样人员
		/// </summary>
		public string m_StrCollcetorID
		{
			get
			{
				return this.m_objDataVO.m_strCOLLECTOR_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strCOLLECTOR_ID_CHR = value;					
			}
		}
		/// <summary>
		/// 检验人员
		/// </summary>
		public string m_StrCheckerID
		{
			get
			{
				return this.m_objDataVO.m_strCHECKER_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strCHECKER_ID_CHR = value;					
			}
		}
		#endregion

		public event EventHandler evtApplicationIDChanged;
		public event EventHandler evtSampleIDChanged;

		public  enmObjectOperationState m_EnuOprState
		{
			get
			{
				return this.m_enmOprState;
			}
		}


		public clsT_OPR_LIS_SAMPLE_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			} 
		}
		public clsT_OPR_LIS_SAMPLE_VO m_ObjOriginalDataVO
		{
			get
			{
				return this.m_objOriginalDataVO;
			} 
		}


		public clsLIS_AppSampleGroup m_ObjAppSampeGroup{get{return this.m_objAppSampeGroup;} set{this.m_objAppSampeGroup = value;}}

		public clsLIS_DeviceRelation m_ObjDeviceRelation
		{
			get
			{
				return m_objDeviceRelation;
			}
			set
			{
				if(this.m_objDeviceRelation != null && !m_objDeviceRelation.Equals(value))
				{
					this.m_objDeviceRelation.m_ObjSample = null;
				}			
				if(value == null || !value.Equals(this.m_objDeviceRelation))
				{

					this.m_objDeviceRelation = value;
					if(this.m_objDeviceRelation != null)
					{
						this.m_objDeviceRelation.m_ObjSample = this;
					}
				}
			}
		}


		#region 构造函数
		public clsLIS_Sample(clsT_OPR_LIS_SAMPLE_VO p_objDataVO)
		{
			this.m_objDataVO = p_objDataVO;
			m_enmOprState = enmObjectOperationState.New;
		}
		public clsLIS_Sample(clsT_OPR_LIS_SAMPLE_VO p_objDataVO,bool p_blnIsOriginal)
		{
			if(p_blnIsOriginal)
			{
				this.m_objDataVO = p_objDataVO;
				this.m_objOriginalDataVO = new clsT_OPR_LIS_SAMPLE_VO();

				m_mthDataTransfer(m_objDataVO,m_objOriginalDataVO);

				m_enmOprState = enmObjectOperationState.Original;
			}
			else
			{
				this.m_objDataVO = p_objDataVO;
				m_enmOprState = enmObjectOperationState.New;
			}
		}
		#endregion

		/// <summary>
		/// 只有 Original,Modified 状态的使用本方法才有效
		/// </summary>
		public void m_mthDelete()
		{
			if(this.m_enmOprState != enmObjectOperationState.New)
			{
				this.m_enmOprState = enmObjectOperationState.Deleted;
			}
		}

		public void m_mthMatchOpState()
		{
			if(this.m_EnuOprState != enmObjectOperationState.New 
				&& this.m_EnuOprState != enmObjectOperationState.Deleted)
			{
				if(m_objOriginalDataVO.m_intSTATUS_INT == m_objDataVO.m_intSTATUS_INT && 
					m_objOriginalDataVO.m_strACCEPT_DAT == m_objDataVO.m_strACCEPT_DAT && 
					m_objOriginalDataVO.m_strACCEPTOR_ID_CHR == m_objDataVO.m_strACCEPTOR_ID_CHR && 
					m_objOriginalDataVO.m_strAGE_CHR == m_objDataVO.m_strAGE_CHR && 
					m_objOriginalDataVO.m_strAPPL_DAT == m_objDataVO.m_strAPPL_DAT && 
					m_objOriginalDataVO.m_strAPPL_DEPTID_CHR == m_objDataVO.m_strAPPL_DEPTID_CHR && 
					m_objOriginalDataVO.m_strAPPL_EMPID_CHR == m_objDataVO.m_strAPPL_EMPID_CHR && 
					m_objOriginalDataVO.m_strAPPLICATION_ID_CHR == m_objDataVO.m_strAPPLICATION_ID_CHR && 
					m_objOriginalDataVO.m_strBARCODE_VCHR == m_objDataVO.m_strBARCODE_VCHR && 
					m_objOriginalDataVO.m_strBEDNO_CHR == m_objDataVO.m_strBEDNO_CHR && 
					m_objOriginalDataVO.m_strCHECK_DATE_DAT == m_objDataVO.m_strCHECK_DATE_DAT && 
					m_objOriginalDataVO.m_strCOLLECTOR_ID_CHR == m_objDataVO.m_strCOLLECTOR_ID_CHR && 
					m_objOriginalDataVO.m_strCONFIRM_DAT == m_objDataVO.m_strCONFIRM_DAT && 
					m_objOriginalDataVO.m_strCONFIRMER_ID_CHR == m_objDataVO.m_strCONFIRMER_ID_CHR && 
					m_objOriginalDataVO.m_strDIAGNOSE_VCHR == m_objDataVO.m_strDIAGNOSE_VCHR && 
					m_objOriginalDataVO.m_strICD_VCHR == m_objDataVO.m_strICD_VCHR && 
					m_objOriginalDataVO.m_strMODIFY_DAT == m_objDataVO.m_strMODIFY_DAT && 
					m_objOriginalDataVO.m_strOPERATOR_ID_CHR == m_objDataVO.m_strOPERATOR_ID_CHR && 
					m_objOriginalDataVO.m_strPATIENT_INHOSPITALNO_CHR == m_objDataVO.m_strPATIENT_INHOSPITALNO_CHR && 
					m_objOriginalDataVO.m_strPATIENT_NAME_VCHR == m_objDataVO.m_strPATIENT_NAME_VCHR && 
					m_objOriginalDataVO.m_strPATIENT_SUBNO_CHR == m_objDataVO.m_strPATIENT_SUBNO_CHR && 
					m_objOriginalDataVO.m_strPATIENT_TYPE_CHR == m_objDataVO.m_strPATIENT_TYPE_CHR && 
					m_objOriginalDataVO.m_strPATIENTCARDID_CHR == m_objDataVO.m_strPATIENTCARDID_CHR && 
					m_objOriginalDataVO.m_strPATIENTID_CHR == m_objDataVO.m_strPATIENTID_CHR && 
					m_objOriginalDataVO.m_strQCSAMPLEID_CHR == m_objDataVO.m_strQCSAMPLEID_CHR && 
					m_objOriginalDataVO.m_strSAMPLE_ID_CHR == m_objDataVO.m_strSAMPLE_ID_CHR && 
					m_objOriginalDataVO.m_strSAMPLE_TYPE_ID_CHR == m_objDataVO.m_strSAMPLE_TYPE_ID_CHR && 
					m_objOriginalDataVO.m_strSAMPLEKIND_CHR == m_objDataVO.m_strSAMPLEKIND_CHR && 
					m_objOriginalDataVO.m_strSAMPLESTATE_VCHR == m_objDataVO.m_strSAMPLESTATE_VCHR && 
					m_objOriginalDataVO.m_strSAMPLETYPE_VCHR == m_objDataVO.m_strSAMPLETYPE_VCHR && 
					m_objOriginalDataVO.m_strSAMPLING_DATE_DAT == m_objDataVO.m_strSAMPLING_DATE_DAT && 
					m_objOriginalDataVO.m_strSEX_CHR == m_objDataVO.m_strSEX_CHR &&
					m_objOriginalDataVO.m_strCHECKER_ID_CHR == m_objDataVO.m_strCHECKER_ID_CHR)
				{
					m_enmOprState = enmObjectOperationState.Original;
				}
				else
				{
					m_enmOprState = enmObjectOperationState.Modified;
				}
			}
		}
		public void m_mthGenerateDeviceRelation()
		{
			clsT_LIS_DeviceRelationVO obj = new clsT_LIS_DeviceRelationVO();
			clsLIS_DeviceRelation objRelation = new clsLIS_DeviceRelation(obj);
			this.m_ObjDeviceRelation = objRelation;
		}

		public void m_mthAcceptChanges()
		{
			if(this.m_objOriginalDataVO == null)
			{
				this.m_objOriginalDataVO = new clsT_OPR_LIS_SAMPLE_VO();
			}
			this.m_mthDataTransfer(this.m_objDataVO,this.m_objOriginalDataVO);
			this.m_enmOprState = enmObjectOperationState.Original;
		}


		public void m_mthDataTransfer(clsT_OPR_LIS_SAMPLE_VO p_objSource, clsT_OPR_LIS_SAMPLE_VO p_objTarget)
		{
			p_objTarget.m_intSTATUS_INT = p_objSource.m_intSTATUS_INT;
			p_objTarget.m_strACCEPT_DAT = p_objSource.m_strACCEPT_DAT;
			p_objTarget.m_strACCEPTOR_ID_CHR = p_objSource.m_strACCEPTOR_ID_CHR;
			p_objTarget.m_strAGE_CHR = p_objSource.m_strAGE_CHR;
			p_objTarget.m_strAPPL_DAT = p_objSource.m_strAPPL_DAT;
			p_objTarget.m_strAPPL_DEPTID_CHR = p_objSource.m_strAPPL_DEPTID_CHR;
			p_objTarget.m_strAPPL_EMPID_CHR = p_objSource.m_strAPPL_EMPID_CHR;
			p_objTarget.m_strAPPLICATION_ID_CHR = p_objSource.m_strAPPLICATION_ID_CHR;
			p_objTarget.m_strBARCODE_VCHR = p_objSource.m_strBARCODE_VCHR;
			p_objTarget.m_strBEDNO_CHR = p_objSource.m_strBEDNO_CHR;
			p_objTarget.m_strCHECK_DATE_DAT = p_objSource.m_strCHECK_DATE_DAT;
			p_objTarget.m_strCOLLECTOR_ID_CHR = p_objSource.m_strCOLLECTOR_ID_CHR;
			p_objTarget.m_strCONFIRM_DAT = p_objSource.m_strCONFIRM_DAT;
			p_objTarget.m_strCONFIRMER_ID_CHR = p_objSource.m_strCONFIRMER_ID_CHR;
			p_objTarget.m_strDIAGNOSE_VCHR = p_objSource.m_strDIAGNOSE_VCHR;
			p_objTarget.m_strICD_VCHR = p_objSource.m_strICD_VCHR;
			p_objTarget.m_strMODIFY_DAT = p_objSource.m_strMODIFY_DAT;
			p_objTarget.m_strOPERATOR_ID_CHR = p_objSource.m_strOPERATOR_ID_CHR;
			p_objTarget.m_strPATIENT_INHOSPITALNO_CHR = p_objSource.m_strPATIENT_INHOSPITALNO_CHR;
			p_objTarget.m_strPATIENT_NAME_VCHR = p_objSource.m_strPATIENT_NAME_VCHR;
			p_objTarget.m_strPATIENT_SUBNO_CHR = p_objSource.m_strPATIENT_SUBNO_CHR;
			p_objTarget.m_strPATIENT_TYPE_CHR = p_objSource.m_strPATIENT_TYPE_CHR;
			p_objTarget.m_strPATIENTCARDID_CHR = p_objSource.m_strPATIENTCARDID_CHR;
			p_objTarget.m_strPATIENTID_CHR = p_objSource.m_strPATIENTID_CHR;
			p_objTarget.m_strQCSAMPLEID_CHR = p_objSource.m_strQCSAMPLEID_CHR;
			p_objTarget.m_strSAMPLE_ID_CHR = p_objSource.m_strSAMPLE_ID_CHR;
			p_objTarget.m_strSAMPLE_TYPE_ID_CHR = p_objSource.m_strSAMPLE_TYPE_ID_CHR;
			p_objTarget.m_strSAMPLEKIND_CHR = p_objSource.m_strSAMPLEKIND_CHR;
			p_objTarget.m_strSAMPLESTATE_VCHR = p_objSource.m_strSAMPLESTATE_VCHR;
			p_objTarget.m_strSAMPLETYPE_VCHR = p_objSource.m_strSAMPLETYPE_VCHR;
			p_objTarget.m_strSAMPLING_DATE_DAT = p_objSource.m_strSAMPLING_DATE_DAT;
			p_objTarget.m_strSEX_CHR = p_objSource.m_strSEX_CHR;
			p_objTarget.m_strCHECKER_ID_CHR = p_objSource.m_strCHECKER_ID_CHR;

		}

	}
	#endregion
	#region clsLIS_CheckItemResult 刘彬 2004.05.28
	public class clsLIS_CheckItemResult
	{
		private enmObjectOperationState m_enmOprState;

		private com.digitalwave.iCare.ValueObject.clsCheckResult_VO m_objDataVO;
		private com.digitalwave.iCare.ValueObject.clsCheckResult_VO m_objOriginalDataVO;

		private clsLIS_AppCheckItem m_objAppCheckItem;
		
		#region VOManage
		/// <summary>
		/// 修改时间
		/// </summary>
		public string m_StrModifyDate
		{
			get
			{
				return this.m_objDataVO.m_strModify_Dat;
			}			
		}
		/// <summary>
		/// 报告组编号
		/// </summary>
		public string m_StrReportGroupID
		{
			get
			{
				return this.m_objDataVO.m_strGroupID;
			}
			set
			{
				this.m_objDataVO.m_strGroupID = value;
			}
		}
		/// <summary>
		/// 检验项目编号
		/// </summary>
		public string m_StrCheckItemID
		{
			get
			{
				return this.m_objDataVO.m_strCheck_Item_ID;
			}
			set
			{
				this.m_objDataVO.m_strCheck_Item_ID = value;

			}
		}
		/// <summary>
		/// 样本联号：指样本中心的顺序编号
		/// </summary>
		public string m_StrSampleID 
		{
			get
			{
				return this.m_objDataVO.m_strSample_ID;
			}
			set
			{
				this.m_objDataVO.m_strSample_ID = value;

			}
		}
		/// <summary>
		/// 检验结果
		/// </summary>
		public string m_StrResult
		{
			get
			{
				return this.m_objDataVO.m_strResult;
			}
			set
			{
				this.m_objDataVO.m_strResult = value;

			}
		}
		/// <summary>
		/// 结果单位
		/// </summary>
		public string m_StrUnit
		{
			get
			{
				return this.m_objDataVO.m_strUnit;
			}
			set
			{
				this.m_objDataVO.m_strUnit = value;

			}
		}
		/// <summary>
		/// 参考值范围
		/// </summary>
		public string m_StrRefrange 
		{
			get
			{
				return this.m_objDataVO.m_strRefrange;
			}
			set
			{
				this.m_objDataVO.m_strRefrange = value;

			}
		}
		/// <summary>
		/// 最小值
		/// </summary>
		public string m_StrMinValue
		{
			get
			{
				return this.m_objDataVO.m_strMin_Val;
			}
			set
			{
				this.m_objDataVO.m_strMin_Val = value;

			}
		}
		/// <summary>
		/// 最大值
		/// </summary>
		public string m_StrMaxValue
		{
			get
			{
				return this.m_objDataVO.m_strMax_Val;
			}
			set
			{
				this.m_objDataVO.m_strMax_Val = value;

			}
		}
		/// 非正常标志
		/// </summary>
		public string m_StrAbnormalFlag 
		{
			get
			{
				return this.m_objDataVO.m_strAbnormal_Flag;
			}
			set
			{
				this.m_objDataVO.m_strAbnormal_Flag = value;

			}
		}
		/// <summary>
		/// 存放图形结果
		/// </summary>	
		public string m_StrPointListString
		{
			get
			{
				return this.m_objDataVO.m_strPointliststr;
			}
			set
			{
				this.m_objDataVO.m_strPointliststr = value;

			}
		}
		/// <summary>
		/// 检验结果建议
		/// </summary>
		public string m_StrSummary
		{
			get
			{
				return this.m_objDataVO.m_strSummary;
			}
			set
			{
				this.m_objDataVO.m_strSummary = value;

			}
		}
		/// <summary>
		/// 存放图像结果
		/// </summary>
		public byte[] m_BytGraph
		{
			get
			{
				return this.m_objDataVO.m_byaGraph;
			}
			set
			{
				this.m_objDataVO.m_byaGraph = value;

			}
		}
		/// <summary>
		/// 过程状态标识-1--历史痕迹 0--无效记录 1--当前有效记录（初始状态）
		/// </summary>
		public int m_IntStatus
		{
			get
			{
				return this.m_objDataVO.m_intStatus;
			}
			set
			{
				this.m_objDataVO.m_intStatus = value;

			}
		}
		/// <summary>
		/// 操作员工ID
		/// </summary>
		public string m_StrOperatorID
		{
			get
			{
				return this.m_objDataVO.m_strOperator_ID;
			}
			set
			{
				this.m_objDataVO.m_strOperator_ID = value;

			}
		}


		#region OLD
		//		/// <summary>
		//		/// 检验项目名称
		//		/// </summary>
		//		public string m_strCheckItemName
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strCheck_Item_Name;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strCheck_Item_Name != value)
		//				{
		//					this.m_objDataVO.m_strCheck_Item_Name = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//		/// <summary>
		//		/// 英文名称
		//		/// </summary>
		//		public string m_StrCheckItemEnglishName
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strCheck_Item_English_Name;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strCheck_Item_English_Name != value)
		//				{
		//					this.m_objDataVO.m_strCheck_Item_English_Name = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//		/// <summary>
		//		/// 检验日期
		//		/// </summary>
		//		public string  m_StrCheckDate
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strCheck_Dat;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strCheck_Dat != value)
		//				{
		//					this.m_objDataVO.m_strCheck_Dat = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//		/// <summary>
		//		/// 临床印象
		//		/// </summary>
		//		public string m_StrClinicApp
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strClinicApp;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strClinicApp != value)
		//				{
		//					this.m_objDataVO.m_strClinicApp = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//		/// <summary>
		//		/// 备注--建议与解释
		//		/// </summary>
		//		public string m_StrMemo
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strMemo;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strMemo != value)
		//				{
		//					this.m_objDataVO.m_strMemo = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//		/// <summary>
		//		/// 审核日期
		//		/// </summary>
		//		public string m_StrConfirmDate
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strConfirm_Dat;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strConfirm_Dat != value)
		//				{
		//					this.m_objDataVO.m_strConfirm_Dat = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//
		//		/// <summary>
		//		/// 检验员ID
		//		/// </summary>
		//		public string m_StrChecker1
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strChecker1;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strChecker1 != value)
		//				{
		//					this.m_objDataVO.m_strChecker1 = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//		/// <summary>
		//		/// 辅助检验员工ID
		//		/// </summary>
		//		public string m_StrChecker2
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strChecker2;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strChecker2 != value)
		//				{
		//					this.m_objDataVO.m_strChecker2 = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//		/// <summary>
		//		/// 审核员工ID
		//		/// </summary>
		//		public string m_StrConfirmerID
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strConfirm_Person;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strConfirm_Person != value)
		//				{
		//					this.m_objDataVO.m_strConfirm_Person = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//		/// <summary>
		//		/// 检验部门ID
		//		/// </summary>
		//		public string m_StrCheckDeptID
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strCheck_DeptID;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strCheck_DeptID != value)
		//				{
		//					this.m_objDataVO.m_strCheck_DeptID = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//		/// <summary>
		//		/// 检验设备号
		//		/// </summary>
		//		public string m_StrDeviceID 
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strDeviceID;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strDeviceID != value)
		//				{
		//					this.m_objDataVO.m_strDeviceID = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		//		/// <summary>
		//		/// 检验仪器输出的检验结果的名称，或缩写。
		//		/// </summary>
		//		public string m_StrDeviceCheckItemName
		//		{
		//			get
		//			{
		//				return this.m_objDataVO.m_strDevice_Check_Item_Name;
		//			}
		//			set
		//			{
		//				if(this.m_objDataVO.m_strDevice_Check_Item_Name != value)
		//				{
		//					this.m_objDataVO.m_strDevice_Check_Item_Name = value;
		//					if(this.m_EnuOprState == enmObjectOperationState.Original )
		//					{
		//						this.m_EnuOprState = enmObjectOperationState.Modified;
		//					}
		//				}
		//			}
		//		}
		#endregion

		#endregion

		public enmObjectOperationState m_EnuOprState
		{
			get
			{
				return this.m_enmOprState;
			}
		}


		public com.digitalwave.iCare.ValueObject.clsCheckResult_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			}
		}

		public com.digitalwave.iCare.ValueObject.clsCheckResult_VO m_ObjOriginalDataVO
		{
			get
			{
				return this.m_objOriginalDataVO;
			}
		}


		public clsLIS_AppCheckItem m_ObjAppCheckItem
		{
			get
			{
				return m_objAppCheckItem;
			}
			set
			{
				m_objAppCheckItem = value;
			}
		}


		#region 构造函数
		public clsLIS_CheckItemResult(clsCheckResult_VO p_objDataVO)
		{
			this.m_objDataVO = p_objDataVO;
			m_enmOprState = enmObjectOperationState.New;
		}
		public clsLIS_CheckItemResult(clsCheckResult_VO p_objDataVO,bool p_blnIsOriginal)
		{
			if(p_blnIsOriginal)
			{
				this.m_objDataVO = p_objDataVO;
				this.m_objOriginalDataVO = new clsCheckResult_VO();

				m_mthDataTransfer(m_objDataVO,m_objOriginalDataVO);
				m_enmOprState = enmObjectOperationState.Original;
			}
			else
			{
				this.m_objDataVO = p_objDataVO;
				m_enmOprState = enmObjectOperationState.New;
			}
		}
		#endregion

		/// <summary>
		/// 只有 Original,Modified 状态的使用本方法才有效
		/// </summary>
		public void m_mthDelete()
		{
			if(this.m_enmOprState != enmObjectOperationState.New)
			{
				this.m_enmOprState = enmObjectOperationState.Deleted;
			}
		}

		public void m_mthMatchOpState()
		{
			if(this.m_EnuOprState != enmObjectOperationState.New 
				&& this.m_EnuOprState != enmObjectOperationState.Deleted)
			{
				if(m_objOriginalDataVO.m_byaGraph == m_objDataVO.m_byaGraph && 
					m_objOriginalDataVO.m_intStatus == m_objDataVO.m_intStatus && 
					m_objOriginalDataVO.m_strAbnormal_Flag == m_objDataVO.m_strAbnormal_Flag && 
					m_objOriginalDataVO.m_strCheck_Dat == m_objDataVO.m_strCheck_Dat && 
					m_objOriginalDataVO.m_strCheck_DeptID == m_objDataVO.m_strCheck_DeptID && 
					m_objOriginalDataVO.m_strCheck_Item_English_Name == m_objDataVO.m_strCheck_Item_English_Name && 
					m_objOriginalDataVO.m_strCheck_Item_ID == m_objDataVO.m_strCheck_Item_ID && 
					m_objOriginalDataVO.m_strCheck_Item_Name == m_objDataVO.m_strCheck_Item_Name && 
					m_objOriginalDataVO.m_strChecker1 == m_objDataVO.m_strChecker1 && 
					m_objOriginalDataVO.m_strChecker2 == m_objDataVO.m_strChecker2 && 
					m_objOriginalDataVO.m_strClinicApp == m_objDataVO.m_strClinicApp && 
					m_objOriginalDataVO.m_strConfirm_Dat == m_objDataVO.m_strConfirm_Dat && 
					m_objOriginalDataVO.m_strConfirm_Person == m_objDataVO.m_strConfirm_Person && 
					m_objOriginalDataVO.m_strDevice_Check_Item_Name == m_objDataVO.m_strDevice_Check_Item_Name && 
					m_objOriginalDataVO.m_strDeviceID == m_objDataVO.m_strDeviceID && 
					m_objOriginalDataVO.m_strGroupID == m_objDataVO.m_strGroupID && 
					m_objOriginalDataVO.m_strMax_Val == m_objDataVO.m_strMax_Val && 
					m_objOriginalDataVO.m_strMemo == m_objDataVO.m_strMemo && 
					m_objOriginalDataVO.m_strMin_Val == m_objDataVO.m_strMin_Val && 
					m_objOriginalDataVO.m_strModify_Dat == m_objDataVO.m_strModify_Dat && 
					m_objOriginalDataVO.m_strOperator_ID == m_objDataVO.m_strOperator_ID && 
					m_objOriginalDataVO.m_strPointliststr == m_objDataVO.m_strPointliststr && 
					m_objOriginalDataVO.m_strRefrange == m_objDataVO.m_strRefrange && 
					m_objOriginalDataVO.m_strResult == m_objDataVO.m_strResult && 
					m_objOriginalDataVO.m_strSample_ID == m_objDataVO.m_strSample_ID && 
					m_objOriginalDataVO.m_strSummary == m_objDataVO.m_strSummary && 
					m_objOriginalDataVO.m_strUnit == m_objDataVO.m_strUnit)
				{
					m_enmOprState = enmObjectOperationState.Original;
				}
				else
				{
					m_enmOprState = enmObjectOperationState.Modified;
				}
			}
		}
		public void m_mthAcceptChanges()
		{
			if(this.m_objOriginalDataVO == null)
			{
				this.m_objOriginalDataVO = new clsCheckResult_VO();
			}
			this.m_mthDataTransfer(this.m_objDataVO,this.m_objOriginalDataVO);
			this.m_enmOprState = enmObjectOperationState.Original;
		}


		public void m_mthDataTransfer(clsCheckResult_VO p_objSource, clsCheckResult_VO p_objTarget)
		{
			p_objTarget.m_byaGraph = p_objSource.m_byaGraph;
			p_objTarget.m_intStatus = p_objSource.m_intStatus;
			p_objTarget.m_strAbnormal_Flag = p_objSource.m_strAbnormal_Flag;
			p_objTarget.m_strCheck_Dat = p_objSource.m_strCheck_Dat;
			p_objTarget.m_strCheck_DeptID = p_objSource.m_strCheck_DeptID;
			p_objTarget.m_strCheck_Item_English_Name = p_objSource.m_strCheck_Item_English_Name;
			p_objTarget.m_strCheck_Item_ID = p_objSource.m_strCheck_Item_ID;
			p_objTarget.m_strCheck_Item_Name = p_objSource.m_strCheck_Item_Name;
			p_objTarget.m_strChecker1 = p_objSource.m_strChecker1;
			p_objTarget.m_strChecker2 = p_objSource.m_strChecker2;
			p_objTarget.m_strClinicApp = p_objSource.m_strClinicApp;
			p_objTarget.m_strConfirm_Dat = p_objSource.m_strConfirm_Dat;
			p_objTarget.m_strConfirm_Person = p_objSource.m_strConfirm_Person;
			p_objTarget.m_strDevice_Check_Item_Name = p_objSource.m_strDevice_Check_Item_Name;
			p_objTarget.m_strDeviceID = p_objSource.m_strDeviceID;
			p_objTarget.m_strGroupID = p_objSource.m_strGroupID;
			p_objTarget.m_strMax_Val = p_objSource.m_strMax_Val;
			p_objTarget.m_strMemo = p_objSource.m_strMemo;
			p_objTarget.m_strMin_Val = p_objSource.m_strMin_Val;
			p_objTarget.m_strModify_Dat = p_objSource.m_strModify_Dat;
			p_objTarget.m_strOperator_ID = p_objSource.m_strOperator_ID;
			p_objTarget.m_strPointliststr = p_objSource.m_strPointliststr;
			p_objTarget.m_strRefrange = p_objSource.m_strRefrange;
			p_objTarget.m_strResult = p_objSource.m_strResult;
			p_objTarget.m_strSample_ID = p_objSource.m_strSample_ID;
			p_objTarget.m_strSummary = p_objSource.m_strSummary;
			p_objTarget.m_strUnit = p_objSource.m_strUnit;
		}

	}
	#endregion
	#region clsLIS_DeviceRelation 刘彬 2004.05.28
	public class clsLIS_DeviceRelation
	{
		private enmObjectOperationState m_enmOprState;

		private com.digitalwave.iCare.ValueObject.clsT_LIS_DeviceRelationVO m_objDataVO;
		private com.digitalwave.iCare.ValueObject.clsT_LIS_DeviceRelationVO m_objOriginalDataVO;

		private clsLIS_Sample m_objSample;
	
		#region VOManage
		public int m_IntImportReq
		{
			get
			{
				return this.m_objDataVO.m_intIMPORT_REQ_INT;
			}
			set
			{
				this.m_objDataVO.m_intIMPORT_REQ_INT = value;
			}
		}
		/// <summary>
		///设备编号
		/// </summary>
		public string m_StrDeviceID
		{
			get
			{
				return this.m_objDataVO.m_strDEVICEID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strDEVICEID_CHR = value;
			}
		}
		/// <summary>
		///仪器当日核收样本的序号
		/// </summary>
		public string m_StrSeqID
		{
			get
			{
				return this.m_objDataVO.m_strSEQ_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strSEQ_ID_CHR = value;

			}
		}
		/// <summary>
		///核收日期
		/// </summary>
		public string m_StrReceptDate
		{
			get
			{
				return this.m_objDataVO.m_strRECEPTION_DAT;
			}
			set
			{
				this.m_objDataVO.m_strRECEPTION_DAT = value;
			}
		}
		/// <summary>
		///仪器自身的样本编号
		/// </summary>
		public string m_StrDeviceSampleID
		{
			get
			{
				return this.m_objDataVO.m_strDEVICE_SAMPLEID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strDEVICE_SAMPLEID_CHR = value;
			}
		}
		/// <summary>
		///检验日期
		/// </summary>
		public string m_StrCheckDate
		{
			get
			{
				return this.m_objDataVO.m_strCHECK_DAT;
			}
			set
			{
				this.m_objDataVO.m_strCHECK_DAT = value;
			}
		}
		/// <summary>
		///样本联号：指样本中心的顺序编号
		/// </summary>
		public string m_StrSampleID
		{
			get
			{
				return this.m_objDataVO.m_strSAMPLE_ID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strSAMPLE_ID_CHR = value;
			}
		}
		/// <summary>
		///
		/// </summary>
		public string m_StrPositionID
		{
			get
			{
				return this.m_objDataVO.m_strPOSITIONID_CHR;
			}
			set
			{
				this.m_objDataVO.m_strPOSITIONID_CHR = value;
			}
		}
		/// <summary>
		///记录状态2-已绑定 1-未绑定 0-无效
		/// </summary>
		public int m_IntStatus
		{
			get
			{
				return this.m_objDataVO.m_intSTATUS_INT;
			}
			set
			{
				this.m_objDataVO.m_intSTATUS_INT = value;
			}
		}
		/// <summary>
		///仪器核收样本的序号（和核收日期无关）
		/// </summary>
		public string m_StrSeqIDDevice
		{
			get
			{
				return this.m_objDataVO.m_strSEQ_ID_DEVICE_CHR;
			}
			set
			{
				this.m_objDataVO.m_strSEQ_ID_DEVICE_CHR = value;
			}
		}
		/// <summary>
		///绑定仪器样本的方法.0-自动顺序绑定,1-按指定的编号绑定
		/// </summary>
		public int m_IntBindMethod
		{
			get
			{
				return this.m_objDataVO.m_intBIND_METHOD_INT;
			}
			set
			{
				this.m_objDataVO.m_intBIND_METHOD_INT = value;
			}
		}

		
		#endregion

		public enmObjectOperationState m_EnuOprState
		{
			get
			{
				return this.m_enmOprState;
			}
		}


		public com.digitalwave.iCare.ValueObject.clsT_LIS_DeviceRelationVO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			}			
		}

		public com.digitalwave.iCare.ValueObject.clsT_LIS_DeviceRelationVO m_ObjOriginalDataVO
		{
			get
			{
				return this.m_objOriginalDataVO;
			}			
		}


		public clsLIS_Sample m_ObjSample
		{
			get
			{
				return this.m_objSample;
			}	
			set
			{
				this.m_objSample = value;
			}
		}


		#region 构造函数
		public clsLIS_DeviceRelation(clsT_LIS_DeviceRelationVO p_objDataVO)
		{
			this.m_objDataVO = p_objDataVO;
			m_enmOprState = enmObjectOperationState.New;
		}
		public clsLIS_DeviceRelation(clsT_LIS_DeviceRelationVO p_objDataVO,bool p_blnIsOriginal)
		{
			if(p_blnIsOriginal)
			{
				this.m_objDataVO = p_objDataVO;
				this.m_objOriginalDataVO = new clsT_LIS_DeviceRelationVO();

				m_mthDataTransfer(m_objDataVO,m_objOriginalDataVO);

				m_enmOprState = enmObjectOperationState.Original;
			}
			else
			{
				this.m_objDataVO = p_objDataVO;
				m_enmOprState = enmObjectOperationState.New;
			}
		}
		#endregion

		/// <summary>
		/// 只有 Original,Modified 状态的使用本方法才有效
		/// </summary>
		public void m_mthDelete()
		{
			if(this.m_enmOprState != enmObjectOperationState.New)
			{
				this.m_enmOprState = enmObjectOperationState.Deleted;
			}
		}

		public void m_mthMatchOpState()
		{
			if(this.m_EnuOprState != enmObjectOperationState.New 
				&& this.m_EnuOprState != enmObjectOperationState.Deleted)
			{
				if(m_objDataVO.m_intBIND_METHOD_INT == m_objOriginalDataVO.m_intBIND_METHOD_INT
					&& m_objDataVO.m_intSTATUS_INT == m_objOriginalDataVO.m_intSTATUS_INT
					&& m_objDataVO.m_strCHECK_DAT == m_objOriginalDataVO.m_strCHECK_DAT
					&& m_objDataVO.m_strDEVICE_SAMPLEID_CHR == m_objOriginalDataVO.m_strDEVICE_SAMPLEID_CHR
					&& m_objDataVO.m_strDEVICEID_CHR == m_objOriginalDataVO.m_strDEVICEID_CHR
					&& m_objDataVO.m_strPOSITIONID_CHR == m_objOriginalDataVO.m_strPOSITIONID_CHR
					&& m_objDataVO.m_strRECEPTION_DAT == m_objOriginalDataVO.m_strRECEPTION_DAT
					&& m_objDataVO.m_strSAMPLE_ID_CHR == m_objOriginalDataVO.m_strSAMPLE_ID_CHR
					&& m_objDataVO.m_strSEQ_ID_CHR == m_objOriginalDataVO.m_strSEQ_ID_CHR
					&& m_objDataVO.m_intIMPORT_REQ_INT == m_objOriginalDataVO.m_intIMPORT_REQ_INT
					&& m_objDataVO.m_strSEQ_ID_DEVICE_CHR == m_objOriginalDataVO.m_strSEQ_ID_DEVICE_CHR)
				{
					m_enmOprState = enmObjectOperationState.Original;
				}
				else
				{
					m_enmOprState = enmObjectOperationState.Modified;
				}
			}
		}
		public void m_mthAcceptChanges()
		{
			if(this.m_objOriginalDataVO == null)
			{
				this.m_objOriginalDataVO = new clsT_LIS_DeviceRelationVO();
			}
			this.m_mthDataTransfer(this.m_objDataVO,this.m_objOriginalDataVO);
			this.m_enmOprState = enmObjectOperationState.Original;
		}


		public void m_mthDataTransfer(clsT_LIS_DeviceRelationVO p_objSource, clsT_LIS_DeviceRelationVO p_objTarget)
		{
			p_objTarget.m_intBIND_METHOD_INT = p_objSource.m_intBIND_METHOD_INT;
			p_objTarget.m_intSTATUS_INT = p_objSource.m_intSTATUS_INT;
			p_objTarget.m_strCHECK_DAT = p_objSource.m_strCHECK_DAT;
			p_objTarget.m_strDEVICE_SAMPLEID_CHR = p_objSource.m_strDEVICE_SAMPLEID_CHR;
			p_objTarget.m_strDEVICEID_CHR = p_objSource.m_strDEVICEID_CHR;
			p_objTarget.m_strPOSITIONID_CHR = p_objSource.m_strPOSITIONID_CHR;
			p_objTarget.m_strRECEPTION_DAT = p_objSource.m_strRECEPTION_DAT;
			p_objTarget.m_strSAMPLE_ID_CHR = p_objSource.m_strSAMPLE_ID_CHR;
			p_objTarget.m_strSEQ_ID_CHR = p_objSource.m_strSEQ_ID_CHR;
			p_objTarget.m_intIMPORT_REQ_INT = p_objSource.m_intIMPORT_REQ_INT;
			p_objTarget.m_strSEQ_ID_DEVICE_CHR = p_objSource.m_strSEQ_ID_DEVICE_CHR;
		}

	}
	#endregion
	#region clsLIS_CheckItemDeviceResult 刘彬 2004.05.28
	public class clsLIS_CheckItemDeviceResult
	{
		private com.digitalwave.iCare.ValueObject.clsDeviceReslutVO m_objDataVO = new clsDeviceReslutVO();
		public com.digitalwave.iCare.ValueObject.clsDeviceReslutVO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			}
			set
			{
				this.m_objDataVO = value;
			}
		}
		public clsLIS_CheckItemDeviceResult()
		{
		}
	}
	#endregion


	#region clsLIS_Patient 刘彬 2004.05.28
	public class clsLIS_Patient
	{

		public event EventHandler evtValueChanged;

		private string m_strPatientName;
		private string m_strPatientID;
		private string m_strCardID;
		private string m_strInhospNO;
		private string m_strSubNO;
		private string m_strBedNO;
		private string m_strSex;
		private string m_strAge;
		private string m_strDiagnose;
		private string m_strICD;
		private string m_strPatientTypeID;
		private string m_strPatientTypeName;

		public string m_StrPatientName
		{
			get
			{
				return this.m_strPatientName;
			} 
			set
			{
				if(this.m_strPatientName != value)
				{
					this.m_strPatientName = value;
					if(this.evtValueChanged != null)
					{
						evtValueChanged(this,null);
					}
				}
			}
		}
		public string m_StrPatientID{get{return this.m_strPatientID;} set
																	  {
																		  if(this.m_strPatientID != value)
																		  {
																			  this.m_strPatientID = value;
																			  if(this.evtValueChanged != null)
																			  {
																				  evtValueChanged(this,null);
																			  }
																		  }
																	  }
		}
		public string m_StrCardID{get{return this.m_strCardID;} set
																{
																	if(this.m_strCardID != value)
																	{
																		this.m_strCardID = value;
																		if(this.evtValueChanged != null)
																		{
																			evtValueChanged(this,null);
																		}
																	}
																}
		}
		public string m_StrInhospNO{get{return this.m_strInhospNO;} set
																	{
																		if(this.m_strInhospNO != value)
																		{
																			this.m_strInhospNO = value;
																			if(this.evtValueChanged != null)
																			{
																				evtValueChanged(this,null);
																			}
																		}
																	}
		}
		public string m_StrSubNO{get{return this.m_strSubNO;}  set
															   {
																   if(this.m_strSubNO != value)
																   {
																	   this.m_strSubNO = value;
																	   if(this.evtValueChanged != null)
																	   {
																		   evtValueChanged(this,null);
																	   }
																   }
															   }
		}
		public string m_StrBedNO{get{return this.m_strBedNO;} set
															  {
																  if(this.m_strBedNO != value)
																  {
																	  this.m_strBedNO = value;
																	  if(this.evtValueChanged != null)
																	  {
																		  evtValueChanged(this,null);
																	  }
																  }
															  }
		}
		public string m_StrSex{get{return this.m_strSex;} set
														  {
															  if(this.m_strSex != value)
															  {
																  this.m_strSex = value;
																  if(this.evtValueChanged != null)
																  {
																	  evtValueChanged(this,null);
																  }
															  }
														  }
		}
		public string m_StrAge{get{return this.m_strAge;}set
														 {
															 if(this.m_strAge != value)
															 {
																 this.m_strAge = value;
																 if(this.evtValueChanged != null)
																 {
																	 evtValueChanged(this,null);
																 }
															 }
														 }
		}
		public string m_StrDiagnose{get{return this.m_strDiagnose;} set
																	{
																		if(this.m_strDiagnose != value)
																		{
																			this.m_strDiagnose = value;
																			if(this.evtValueChanged != null)
																			{
																				evtValueChanged(this,null);
																			}
																		}
																	}
		}
		public string m_StrICD{get{return this.m_strICD;} set
														  {
															  if(this.m_strICD != value)
															  {
																  this.m_strICD = value;
																  if(this.evtValueChanged != null)
																  {
																	  evtValueChanged(this,null);
																  }
															  }
														  }
		}
		public string m_StrPatientTypeID{get{return this.m_strPatientTypeID;}  set
																			   {
																				   if(this.m_strPatientTypeID != value)
																				   {
																					   this.m_strPatientTypeID = value;
																					   if(this.evtValueChanged != null)
																					   {
																						   evtValueChanged(this,null);
																					   }
																				   }
																			   }
		}
		public string m_StrPatientTypeName{get{return this.m_strPatientTypeName;}  set
																				   {
																					   if(this.m_strPatientTypeName != value)
																					   {
																						   this.m_strPatientTypeName = value;
																						   if(this.evtValueChanged != null)
																						   {
																							   evtValueChanged(this,null);
																						   }
																					   }
																				   }
		}	


		public clsLIS_Patient()
		{
		}
	}
	#endregion

	#region clsLIS_ApplyUnit 刘彬 2004.05.28
	public class clsLIS_ApplyUnit
	{
		private clsApplUnit_VO m_objDataVO = new clsApplUnit_VO();

		public clsApplUnit_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			}
			set
			{
				this.m_objDataVO = value;
			}
		}
		
		public clsLIS_ApplyUnit()
		{
		}
	}
	#endregion
	#region clsLIS_CheckReport 刘彬 2004.05.28
	public class clsLIS_CheckReport
	{
		private clsReportGroup_VO m_objDataVO = new clsReportGroup_VO();
		private clsCheckReportDetailCollection m_objDetails;

		public clsLIS_CheckReport()
		{
			this.m_objDetails = new clsCheckReportDetailCollection();
		}
		public clsReportGroup_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			}
			set
			{
				this.m_objDataVO = value;
			}
		}
		public clsCheckReportDetailCollection m_ObjDetails
		{
			get
			{
				return this.m_objDetails;
			}
		}
	}
	#endregion
	#region clsLIS_CheckReport_Detail 刘彬 2004.05.28
	public class clsLIS_CheckReport_Detail
	{
		private clsReportGroupDetail_VO m_objDataVO = new clsReportGroupDetail_VO();
		public clsReportGroupDetail_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			}
			set
			{
				this.m_objDataVO = value;
			}
		}
	}
	#endregion
	#region clsLIS_SampleGroup 刘彬 2004.05.28
	public class clsLIS_SampleGroup
	{
		private clsSampleGroup_VO m_objDataVO = new clsSampleGroup_VO();
		private clsSampleGroupDetailCollection m_objDetails;
		private string[] m_strDeviceModelArr;
		public string[] m_StrDeviceModelArr
		{
			get
			{
				return m_strDeviceModelArr;
			}
			set
			{
				this.m_strDeviceModelArr = value;
			}
		}
		public clsLIS_SampleGroup()
		{
			this.m_objDetails = new clsSampleGroupDetailCollection();
		}
		public clsSampleGroup_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			}
			set
			{
				this.m_objDataVO = value;
			}
		}
		public clsSampleGroupDetailCollection m_ObjDetails
		{
			get
			{
				return this.m_objDetails;
			}
		}
	}
	#endregion
	#region clsLIS_SampleGroup_Detail 刘彬 2004.05.28
	public class clsLIS_SampleGroup_Detail
	{
		private clsSampleGroupDetail_VO m_objDataVO = new clsSampleGroupDetail_VO();
		public clsSampleGroupDetail_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			}
			set
			{
				if(value == null)
				{
					throw new Exception("clsLIS_Sample:m_ObjDataVO(关键值对象)不能为空.");
				}
				this.m_objDataVO = value;
			}
		}
		public clsLIS_SampleGroup_Detail()
		{
		}
	}
	#endregion
	#region clsLIS_CheckItem 刘彬 2004.05.28
	public class clsLIS_CheckItem
	{
		private clsCheckItem_VO m_objDataVO = new clsCheckItem_VO();
		
		private string m_strDeviceCheckItemName = null;

		public string m_StrDeviceItemName
		{
			get
			{
				return this.m_strDeviceCheckItemName;
			}
			set
			{
				this.m_strDeviceCheckItemName = value;
			}
		}

		public clsCheckItem_VO m_ObjDataVO
		{
			get
			{
				return this.m_objDataVO;
			}
			set
			{
				this.m_objDataVO = value;
			}
		}
		public clsLIS_CheckItem()
		{
		}
		public object Tag;
	}

	#endregion

	#region clsLIS_App 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_App 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28
	/// </summary>
	public class clsAppCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_App)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_App)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_App this[int p_intIndex]
		{
			get
			{
				return (clsLIS_App) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_App p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsAppCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_App obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_App[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_App p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsAppCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_App obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_App RemoveAt(int p_intIndex)
		{
			clsLIS_App objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_App p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_App[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_App p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_App p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region 转为数组
		//		public clsLIS_App[] ToArray()
		//		{
		//			return this.InnerList.ToArray(typeof(clsLIS_App));
		//		}
		#endregion

	}
	#endregion
	#region clsLIS_AppApplyUnit 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_AppApplyUnit 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsAppApplyUnitCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_AppApplyUnit)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_AppApplyUnit)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_AppApplyUnit this[int p_intIndex]
		{
			get
			{
				return (clsLIS_AppApplyUnit) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_AppApplyUnit p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsAppApplyUnitCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_AppApplyUnit obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_AppApplyUnit[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_AppApplyUnit p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsAppApplyUnitCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_AppApplyUnit obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_AppApplyUnit RemoveAt(int p_intIndex)
		{
			clsLIS_AppApplyUnit objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_AppApplyUnit p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_AppApplyUnit[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_AppApplyUnit p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_AppApplyUnit p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_AppCheckReport 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_AppCheckReport 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsAppCheckReportCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_AppCheckReport)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_AppCheckReport)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_AppCheckReport this[int p_intIndex]
		{
			get
			{
				return (clsLIS_AppCheckReport) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_AppCheckReport p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsAppCheckReportCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_AppCheckReport obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_AppCheckReport[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_AppCheckReport p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsAppCheckReportCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_AppCheckReport obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_AppCheckReport RemoveAt(int p_intIndex)
		{
			clsLIS_AppCheckReport objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_AppCheckReport p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_AppCheckReport[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_AppCheckReport p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_AppCheckReport p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_AppSampleGroup 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_AppSampleGroup 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsAppSampleGroupCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_AppSampleGroup)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_AppSampleGroup)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_AppSampleGroup this[int p_intIndex]
		{
			get
			{
				return (clsLIS_AppSampleGroup) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_AppSampleGroup p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsAppSampleGroupCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_AppSampleGroup obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_AppSampleGroup[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_AppSampleGroup p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsAppSampleGroupCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_AppSampleGroup obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_AppSampleGroup RemoveAt(int p_intIndex)
		{
			clsLIS_AppSampleGroup objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_AppSampleGroup p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_AppSampleGroup[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_AppSampleGroup p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_AppSampleGroup p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_AppCheckItem 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_AppCheckItem 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsAppCheckItemCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_AppCheckItem)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_AppCheckItem)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_AppCheckItem this[int p_intIndex]
		{
			get
			{
				return (clsLIS_AppCheckItem) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_AppCheckItem p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsAppCheckItemCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_AppCheckItem obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_AppCheckItem[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_AppCheckItem p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsAppCheckItemCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_AppCheckItem obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_AppCheckItem RemoveAt(int p_intIndex)
		{
			clsLIS_AppCheckItem objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_AppCheckItem p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_AppCheckItem[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_AppCheckItem p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_AppCheckItem p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_Sample 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_Sample 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsSampleCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_Sample)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_Sample)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_Sample this[int p_intIndex]
		{
			get
			{
				return (clsLIS_Sample) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_Sample p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsSampleCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_Sample obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_Sample[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_Sample p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsSampleCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_Sample obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_Sample RemoveAt(int p_intIndex)
		{
			clsLIS_Sample objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_Sample p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_Sample[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_Sample p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_Sample p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_Patient 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_Patient 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsLISPatientCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_Patient)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_Patient)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_Patient this[int p_intIndex]
		{
			get
			{
				return (clsLIS_Patient) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_Patient p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsLISPatientCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_Patient obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_Patient[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_Patient p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsLISPatientCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_Patient obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_Patient RemoveAt(int p_intIndex)
		{
			clsLIS_Patient objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_Patient p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_Patient[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_Patient p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_Patient p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_ApplyUnit 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_ApplyUnit 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsApplyUnitCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_ApplyUnit)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_ApplyUnit)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_ApplyUnit this[int p_intIndex]
		{
			get
			{
				return (clsLIS_ApplyUnit) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_ApplyUnit p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsApplyUnitCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_ApplyUnit obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_ApplyUnit[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_ApplyUnit p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsApplyUnitCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_ApplyUnit obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_ApplyUnit RemoveAt(int p_intIndex)
		{
			clsLIS_ApplyUnit objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_ApplyUnit p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="不抛出异常"> </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_ApplyUnit[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_ApplyUnit p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_ApplyUnit p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_CheckReport 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_CheckReport 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsCheckReportCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_CheckReport)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_CheckReport)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_CheckReport this[int p_intIndex]
		{
			get
			{
				return (clsLIS_CheckReport) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_CheckReport p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsCheckReportCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_CheckReport obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_CheckReport[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_CheckReport p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsCheckReportCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_CheckReport obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_CheckReport RemoveAt(int p_intIndex)
		{
			clsLIS_CheckReport objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_CheckReport p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_CheckReport[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_CheckReport p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_CheckReport p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_CheckReport_Detail 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_CheckReport_Detail 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsCheckReportDetailCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_CheckReport_Detail)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_CheckReport_Detail)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_CheckReport_Detail this[int p_intIndex]
		{
			get
			{
				return (clsLIS_CheckReport_Detail) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_CheckReport_Detail p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsCheckReportDetailCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_CheckReport_Detail obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_CheckReport_Detail[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_CheckReport_Detail p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsCheckReportDetailCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_CheckReport_Detail obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_CheckReport_Detail RemoveAt(int p_intIndex)
		{
			clsLIS_CheckReport_Detail objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_CheckReport_Detail p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_CheckReport_Detail[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_CheckReport_Detail p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_CheckReport_Detail p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_SampleGroup 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_SampleGroup 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsSampleGroupCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_SampleGroup)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_SampleGroup)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_SampleGroup this[int p_intIndex]
		{
			get
			{
				return (clsLIS_SampleGroup) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_SampleGroup p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsSampleGroupCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_SampleGroup obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_SampleGroup[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_SampleGroup p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsSampleGroupCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_SampleGroup obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_SampleGroup RemoveAt(int p_intIndex)
		{
			clsLIS_SampleGroup objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_SampleGroup p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_SampleGroup[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_SampleGroup p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_SampleGroup p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_SampleGroup_Detail 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_SampleGroup_Detail 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsSampleGroupDetailCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_SampleGroup_Detail)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_SampleGroup_Detail)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_SampleGroup_Detail this[int p_intIndex]
		{
			get
			{
				return (clsLIS_SampleGroup_Detail) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_SampleGroup_Detail p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsSampleGroupDetailCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_SampleGroup_Detail obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_SampleGroup_Detail[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_SampleGroup_Detail p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsSampleGroupDetailCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_SampleGroup_Detail obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_SampleGroup_Detail RemoveAt(int p_intIndex)
		{
			clsLIS_SampleGroup_Detail objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_SampleGroup_Detail p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_SampleGroup_Detail[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_SampleGroup_Detail p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_SampleGroup_Detail p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion
	#region clsLIS_CheckItem 的集合类 刘彬 2004.05.28
	/// <summary>
	/// clsLIS_CheckItem 的集合类,一个对象在此集合中只可能存在一个引用. 刘彬 2004.05.28,
	/// </summary>
	public class clsCheckItemCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 在对象加入集合后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemAdded = null;
		/// <summary>
		/// 在对象加入集合前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemAdded = null;
		/// <summary>
		/// 在对象从集合中移除后发生;
		/// </summary>
		public event dlgCollectionContentsChangedEventHandler evtItemRemoved = null;
		/// <summary>
		/// 在对象从集合中移除前发生;
		/// </summary>
		public event dlgCollectionContentsBeforeChangeEventHandler evtBeforeItemRemoved = null;

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_CheckItem)value});

			if(evtItemRemoved != null)
			{
				evtItemRemoved(this,eAfter);
			}
		}
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
			clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{(clsLIS_CheckItem)value});

			if(evtItemAdded != null)
			{
				evtItemAdded(this,eAfter);
			}
		}


		#region this[] 索引器(get)
		/// <summary>
		/// Item 索引器(get)
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		public clsLIS_CheckItem this[int p_intIndex]
		{
			get
			{
				return (clsLIS_CheckItem) List[p_intIndex];
			}
		}

		#endregion

		#region Add 加入一个对象
		/// <summary>
		/// 加入一个对象
		/// 如果这个对象已存在于集合中则不再加入,但返回它的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">要加入的对象</param>
		/// <returns>
		/// -1:加入被阻止;
		/// 其它:返回位置索引
		/// </returns>
		public int Add(clsLIS_CheckItem p_obj)
		{
			int intRet = -1;
			if(this.IsInclude(p_obj))
			{
				intRet = this.IndexOf(p_obj);
			}
			else
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					intRet = List.Add(p_obj);
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			return intRet;				
		}
		#endregion

		#region AddRange 加入另一个集合中的对象
		/// <summary>
		/// 加入另一个集合中的对象,如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void AddRange(clsCheckItemCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			foreach(clsLIS_CheckItem obj in p_clt)
			{
				if(!this.IsInclude(obj))
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{obj});
					if(this.evtBeforeItemAdded != null)
					{
						evtBeforeItemAdded(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						List.Add(obj);
						//						clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{obj});
						//
						//						if(this.evtItemAdded != null)
						//						{
						//							evtItemAdded(this,eAfter);
						//						}
					}
				}				
			}
			//			this.InnerList.AddRange(p_clt);
		}
		#endregion

		#region AddArr 加入一组对象
		/// <summary>
		/// 加入一组对象;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_objArr">一组对象,为空则不进行任何操作</param>
		public void AddArr(clsLIS_CheckItem[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					if(!this.IsInclude(p_objArr[i]))
					{
						clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
						if(this.evtBeforeItemAdded != null)
						{
							evtBeforeItemAdded(this,eBefore);
						}
						if(!eBefore.Handled)
						{
							List.Add(p_objArr[i]);
							//							clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_objArr[i]});
							//
							//							if(this.evtItemAdded != null)
							//							{
							//								evtItemAdded(this,eAfter);
							//							}
						}
					}
				}
			}
		}
		#endregion

		#region Insert 在指定位置插入对象
		/// <summary>
		/// 在指定位置插入对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndex 不是有效索引</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <param name="p_obj">要插入的对象</param>
		/// <returns>
		/// 如果对象已存在集合中则返回它实际的位置索引;
		/// 否则返回参数p_intIndex的值;
		/// -1:插入被阻止
		/// </returns>
		public int Insert(int p_intIndex,clsLIS_CheckItem p_obj)
		{
			int intIndex = -1;
			if(!this.IsInclude(p_obj))
			{
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
				if(this.evtBeforeItemAdded != null)
				{
					evtBeforeItemAdded(this,eBefore);
				}
				if(eBefore.Handled)
				{
					intIndex = -1;
				}
				else
				{
					this.List.Insert(p_intIndex,p_obj);
					intIndex = p_intIndex;
					//					clsObjectArrEventArgs eAfter = new clsObjectArrEventArgs(new object[]{p_obj});
					//
					//					if(this.evtItemAdded != null)
					//					{
					//						evtItemAdded(this,eAfter);
					//					}
				}
			}
			else
			{
				intIndex = this.IndexOf(p_obj);
			}
			return intIndex;
		}
		#endregion

		#region InsertRange 将另一个集合的对象从指定位置开始插入
		/// <summary>
		/// 将另一个集合的对象从指定位置开始插入;
		/// 如果某个对象已存在于集合中则不再加入;
		/// 每加入一个对象之前都产生 evtBeforeItemAdded 事件,故可响应事件阻止任何一个对象的加入;
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">p_intIndexStart 不是有效索引</exception>
		/// <param name="p_intIndexStart">开始插入的位置索引</param>
		/// <param name="p_clt">另一个同类集合,为空则不进行任何操作</param>
		public void InsertRange(int p_intIndexStart,clsCheckItemCollection p_clt)
		{
			if(p_clt == null)
			{
				return;
			}
			int intRet;
			foreach(clsLIS_CheckItem obj in p_clt)
			{
				intRet = this.Insert(p_intIndexStart,obj);
				if(intRet == p_intIndexStart)
				{
					p_intIndexStart++;
				}
			}
			//			this.InnerList.InsertRange(p_intIndex,p_clt);
		}

		#endregion

		#region RemoveAt 移除指定位置的对象
		/// <summary>
		/// 移除指定位置的对象
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">不返回异常</exception>
		/// <param name="p_intIndex">指定位置</param>
		/// <returns>
		///	null: p_intIndex 越界或被阻止移除;
		///	否则为被移除的对象
		/// </returns>
		public new clsLIS_CheckItem RemoveAt(int p_intIndex)
		{
			clsLIS_CheckItem objRet =null;
			if (p_intIndex > Count - 1 || p_intIndex < 0)
			{
				objRet = null;
			}
			else
			{ 
				objRet = this[p_intIndex];
				clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{objRet});
				if(this.evtBeforeItemRemoved != null)
				{
					evtBeforeItemRemoved(this,eBefore);
				}
				if(!eBefore.Handled)
				{
					List.RemoveAt(p_intIndex);
				}
			}
			return objRet;
		}
		#endregion
		#region Remove 从集合中移除指定的对象
		/// <summary>
		/// 从集合中移除指定的对象,可被事件处理器阻止移除
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定的对象</param>
		public void Remove(clsLIS_CheckItem p_obj)
		{
			clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_obj});
			if(this.evtBeforeItemRemoved != null)
			{
				evtBeforeItemRemoved(this,eBefore);
			}
			if(!eBefore.Handled)
			{
				List.Remove(p_obj);
			}
		}
		#endregion

		#region RemoveArr 从集合中移除指定的一组对象
		/// <summary>
		/// 从集合中移除指定的一组对象,可被事件处理器阻止移除某个对象
		/// </summary>
		/// <exception cref="">不抛出异常 </exception>
		/// <param name="p_objArr">指定的一组对象</param>
		public void RemoveArr(clsLIS_CheckItem[] p_objArr)
		{
			if(p_objArr != null)
			{
				for(int i=0;i<p_objArr.Length;i++)
				{
					clsObjectArrHandledEventArgs eBefore = new clsObjectArrHandledEventArgs(new object[]{p_objArr[i]});
					if(this.evtBeforeItemRemoved != null)
					{
						evtBeforeItemRemoved(this,eBefore);
					}
					if(!eBefore.Handled)
					{
						this.Remove(p_objArr[i]);
					}
				}
			}
		}
		#endregion

		#region IndexOf 取得对象在集合中的位置索引
		/// <summary>
		/// 取得对象在集合中的位置索引
		/// </summary>
		/// <exception cref="不抛出异常"></exception>
		/// <param name="p_obj">指定对象</param>
		/// <returns>
		/// 对象在集合中的位置索引;
		/// -1:集合中没有这个对象
		/// </returns>
		public int IndexOf(clsLIS_CheckItem p_obj)
		{
			return this.List.IndexOf(p_obj);
		}
		#endregion
		#region IsInclude 集合中是否包含指定的对象
		/// <summary>
		/// 集合中是否包含指定的对象 
		/// </summary>
		/// <param name="p_obj">指定的对象 </param>
		/// <returns>true:包含 ;false :不包含</returns>
		public bool IsInclude(clsLIS_CheckItem p_obj)
		{
			if(this.IndexOf(p_obj)>=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
	#endregion


    public enum enmObjectOperationState
    {
        Original, New, Deleted, Modified
    }
    public class clsObjectArrHandledEventArgs : System.EventArgs
    {
        private bool blnHandled = false;
        public bool Handled
        {
            get { return this.blnHandled; }
            set { blnHandled = value; }
        }

        private object[] m_objContentsArr;
        public object[] m_ObjContentsArr
        {
            get
            {
                return m_objContentsArr;
            }
        }
        public clsObjectArrHandledEventArgs(object[] p_objContentsArr)
        {
            this.m_objContentsArr = p_objContentsArr;
        }
    }
    public class clsObjectArrEventArgs : System.EventArgs
    {
        private object[] m_objContentsArr;
        public object[] m_ObjContentsArr
        {
            get
            {
                return m_objContentsArr;
            }
        }
        public clsObjectArrEventArgs(object[] p_objContentsArr)
        {
            this.m_objContentsArr = p_objContentsArr;
        }
    }
    public delegate void dlgCollectionContentsBeforeChangeEventHandler(object sender, clsObjectArrHandledEventArgs e);
    public delegate void dlgCollectionContentsChangedEventHandler(object sender, clsObjectArrEventArgs e);


}
