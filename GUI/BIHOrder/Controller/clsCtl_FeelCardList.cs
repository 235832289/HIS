using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 皮试录入框	逻辑控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-12-23 
	/// </summary>
	public class clsCtl_FeelCardList: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
        clsDcl_FeelCardList m_objManage = null;
        clsDcl_InputOrder m_objInputOrder = null;
		public string m_strReportID;
		/// <summary>
		/// 登陆用户ID
		/// </summary>
		public string m_strOperatorID;
		/// <summary>
		/// 当前皮试结果表流水号
		/// </summary>
		internal string m_strOrderFeelID="";
        /// <summary>
        /// 打印的医嘱项目
        /// </summary>
        private clsBIHCanExecOrder[] arrExec; 

		#endregion 
		#region 构造函数
        public clsCtl_FeelCardList()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            m_objManage = new clsDcl_FeelCardList();
            m_objInputOrder = new clsDcl_InputOrder();
			m_strReportID = null;
		}
		#endregion 
		#region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmFeelCardList m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmFeelCardList)frmMDI_Child_Base_in;
		}
		#endregion


        #region 病区事件
        public void m_txtAreaInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Columns.Add("病区编号", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("病区名称", 90, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 170;
        }
        public void m_txtAreaFindItem(string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            clsBIHArea[] objItemArr;
            long lngRes = m_objInputOrder.m_lngFindArea(strFindCode, out objItemArr);
            if (lngRes > 0 && objItemArr != null && objItemArr.Length > 0)
            {
                //获取有权限访问的病区ID集合
                if (m_objViewer.LoginInfo != null)
                {
                    System.Collections.IList ilUsableAreaID = m_objViewer.LoginInfo.m_ilUsableAreaID;
                    clsDcl_InputOrder objInputOrder = new clsDcl_InputOrder();
                    objItemArr = (clsBIHArea[])(objInputOrder.GetUsableAreaObject(objItemArr, ilUsableAreaID)).ToArray(typeof(clsBIHArea));
                }
                for (int i = 0; i < objItemArr.Length; i++)
                {
                    /** @update by xzf (05-09-20) 
                     * 
                     */
                    //@ListViewItem lvi=lvwList.Items.Add(objItemArr[i].m_strAreaID);
                    ListViewItem lvi = lvwList.Items.Add(objItemArr[i].code);
                    lvi.SubItems.Add(objItemArr[i].m_strAreaName);
                    lvi.Tag = objItemArr[i].m_strAreaID;
                    /* <<======================== */
                }
            }
        }
        public void m_txtAreaSelectItem(System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_objViewer.m_txtArea.Text = lviSelected.SubItems[1].Text;
                m_objViewer.m_txtArea.Tag = lviSelected.Tag;
                m_cmdSearch();

            }
        }
        #endregion


        internal void m_cmdSearch()
        {
            LoadData();
        }


        internal void LoadData()
        {

            this.m_objViewer.dw_1.Reset();
            int newRow;
            if (m_objViewer.m_txtArea.Tag == null)
            {
                return;
            }
            string m_strAreaId = (string)m_objViewer.m_txtArea.Tag;
            DataTable m_dtExecOrder = null;
            m_objManage.m_lngGetFeelOrderByAreaID(m_strAreaId,out m_dtExecOrder);
            DataView myDataView = new DataView(m_dtExecOrder);
            filltheExecOrderTable(myDataView,out arrExec);
            //DateTime executedate_dat, INPATIENT_DAT;
            
            //dw_1.Modify("execute_dat.text='" + DateTime.Now.ToString("yyyy.MM.dd") + "'");
            if (arrExec != null)
            {
                this.m_objViewer.dw_1.Modify("areatext.text='" + m_objViewer.m_txtArea.Text.Trim() + "'");
         
                for (int i = 0; i < arrExec.Length; i++)
                {
                    newRow = this.m_objViewer.dw_1.InsertRow();
                    this.m_objViewer.dw_1.SetItemString(newRow, "bedname", arrExec[i].m_strBedName);
                    this.m_objViewer.dw_1.SetItemString(newRow, "patientname", arrExec[i].m_strPatientName);
                    this.m_objViewer.dw_1.SetItemString(newRow, "patientsex", arrExec[i].m_strPatientSex);
                    this.m_objViewer.dw_1.SetItemString(newRow, "ordername", arrExec[i].m_strName.Trim());
                    this.m_objViewer.dw_1.SetItemString(newRow, "inpatientid", arrExec[i].m_strInpatientID.Trim());
                }
            }
            this.m_objViewer.dw_1.AcceptText();

            //dw_1.Sort();
            //dw_1.CalculateGroups();
            //dw_1.Visible = true;
        }

        #region 给执行医嘱对象付值
        /// <summary>
        /// 给执行医嘱对象付值
        /// </summary>
        /// <param name="objDT"></param>
        /// <param name="arrExecOrder"></param>
        private void filltheExecOrderTable(DataView objRow, out clsBIHCanExecOrder[] arrExecOrder)
        {
            //医嘱执行对象数组
            arrExecOrder = new clsBIHCanExecOrder[0];
            if (objRow.Count <= 0)
            {
                return;
            }
            arrExecOrder = new clsBIHCanExecOrder[objRow.Count];
            for (int i = 0; i < objRow.Count; i++)
            {
                arrExecOrder[i] = new clsBIHCanExecOrder();
                arrExecOrder[i].m_strBedID = Convert.ToString(objRow[i]["bedid_chr"].ToString().Trim());
                arrExecOrder[i].m_strBedName = Convert.ToString(objRow[i]["code_chr"].ToString().Trim());
                arrExecOrder[i].m_strCURBEDID_CHR = Convert.ToString(objRow[i]["bedid_chr"].ToString().Trim());
                arrExecOrder[i].m_strCURBEDName = Convert.ToString(objRow[i]["code_chr"].ToString().Trim());
                arrExecOrder[i].m_strRegisterID = Convert.ToString(objRow[i]["registerid_chr"].ToString().Trim());
                arrExecOrder[i].m_strPatientName = Convert.ToString(objRow[i]["LASTNAME_VCHR"].ToString().Trim());//姓名
                arrExecOrder[i].m_strPatientSex = Convert.ToString(objRow[i]["SEX_CHR"].ToString().Trim());//姓名

                if (!objRow[i]["RECIPENO_INT"].ToString().Trim().Equals(""))
                    arrExecOrder[i].m_intRecipenNo = int.Parse(objRow[i]["RECIPENO_INT"].ToString().Trim()); //方号
                if (!objRow[i]["RECIPENO2_INT"].ToString().Trim().Equals(""))
                    arrExecOrder[i].m_intRecipenNo2 = int.Parse(objRow[i]["RECIPENO2_INT"].ToString().Trim()); //方号(用于外部显示)

                if (!objRow[i]["EXECUTETYPE_INT"].ToString().Trim().Equals(""))
                    arrExecOrder[i].m_intExecuteType = int.Parse(objRow[i]["EXECUTETYPE_INT"].ToString().Trim());//医嘱（医嘱方式）
                arrExecOrder[i].m_strOrderDicCateID = Convert.ToString(objRow[i]["ordercateid_chr"].ToString().Trim());//类别ID
                
                arrExecOrder[i].m_strName = Convert.ToString(objRow[i]["NAME_VCHR"].ToString().Trim());//项目名称
                if (!objRow[i]["Dosage_Dec"].ToString().Trim().Equals(""))
                    arrExecOrder[i].m_dmlDosage = decimal.Parse(objRow[i]["Dosage_Dec"].ToString().Trim()); ;//剂量
                arrExecOrder[i].m_strDosageUnit = Convert.ToString(objRow[i]["dosageunit_chr"].ToString().Trim());//剂量单位
                arrExecOrder[i].m_strExecFreqID = Convert.ToString(objRow[i]["EXECFREQID_CHR"].ToString().Trim());
                arrExecOrder[i].m_strExecFreqName = Convert.ToString(objRow[i]["EXECFREQNAME_CHR"].ToString().Trim());
                if (!objRow[i]["GET_DEC"].ToString().Trim().Equals(""))
                    arrExecOrder[i].m_dmlGet = decimal.Parse(objRow[i]["GET_DEC"].ToString().Trim());
                arrExecOrder[i].m_strGetunit = Convert.ToString(objRow[i]["getunit_chr"].ToString().Trim());
                arrExecOrder[i].m_strEntrust = Convert.ToString(objRow[i]["ENTRUST_VCHR"].ToString().Trim());//嘱托
                arrExecOrder[i].m_strDOCTOR_VCHR = Convert.ToString(objRow[i]["DOCTOR_VCHR"].ToString().Trim());//主管医生
                if (!objRow[i]["POSTDATE_DAT"].ToString().Trim().Equals(""))
                    arrExecOrder[i].m_dtPostdate = Convert.ToDateTime(objRow[i]["POSTDATE_DAT"].ToString().Trim());
                arrExecOrder[i].m_strASSESSORFOREXEC_CHR = Convert.ToString(objRow[i]["CONFIRMER_VCHR"].ToString().Trim());//审核人-
                arrExecOrder[i].m_strASSESSORFOREXEC_DAT = Convert.ToString(objRow[i]["CONFIRM_DAT"].ToString().Trim());//审核时间
                arrExecOrder[i].m_strDosetypeID = Convert.ToString(objRow[i]["DOSETYPEID_CHR"].ToString().Trim());//用法ID
                arrExecOrder[i].m_strDosetypeName = Convert.ToString(objRow[i]["DOSETYPENAME_CHR"].ToString().Trim());//用法名称
                arrExecOrder[i].m_strOrderID = Convert.ToString(objRow[i]["orderid_chr"].ToString().Trim());//医嘱表流水号
                if (!objRow[i]["STATUS_INT"].ToString().Trim().Equals(""))
                    arrExecOrder[i].m_intStatus = int.Parse(objRow[i]["STATUS_INT"].ToString().Trim());//当前医嘱状态
                arrExecOrder[i].m_strCreatorID = Convert.ToString(objRow[i]["CREATORID_CHR"].ToString().Trim());//开医嘱单医生ID
                arrExecOrder[i].m_strCreator = Convert.ToString(objRow[i]["CREATOR_CHR"].ToString().Trim());//开医嘱单医生
                
                arrExecOrder[i].m_strOrderDicID = Convert.ToString(objRow[i]["ORDERDICID_CHR"].ToString().Trim());//诊疗项目流水号
                arrExecOrder[i].m_strParentID = Convert.ToString(objRow[i]["patientid_chr"].ToString().Trim());//病人ID
                arrExecOrder[i].m_strCREATEAREA_ID = Convert.ToString(objRow[i]["createareaid_chr"].ToString().Trim());//开单科室ID
                arrExecOrder[i].m_strCURAREAID_CHR = Convert.ToString(objRow[i]["CURAREAID_CHR"].ToString().Trim());//下医嘱时病人所在病区ID
                arrExecOrder[i].m_strCURAREAName = Convert.ToString(objRow[i]["CURAREAName"].ToString().Trim());//下医嘱时病人所在病区名称
                if (!objRow[i]["OUTGETMEDDAYS_INT"].ToString().Trim().Equals(""))
                {
                    arrExecOrder[i].m_intOUTGETMEDDAYS_INT = int.Parse(objRow[i]["OUTGETMEDDAYS_INT"].ToString().Trim());//出院带药天数(当执行类型为3=出院带药})
                }
                arrExecOrder[i].m_strSAMPLEID_VCHR = Convert.ToString(objRow[i]["SAMPLEID_VCHR"].ToString().Trim());
                arrExecOrder[i].m_strSAMPLEName_VCHR = Convert.ToString(objRow[i]["sample_type_desc_vchr"].ToString().Trim());
                arrExecOrder[i].m_strPARTID_VCHR = Convert.ToString(objRow[i]["PARTID_VCHR"].ToString().Trim());
                arrExecOrder[i].m_strPARTNAME_VCHR = Convert.ToString(objRow[i]["partname"].ToString().Trim());
                //皮试相关字段
                arrExecOrder[i].m_intISNEEDFEEL = int.Parse(objRow[i]["ISNEEDFEEL"].ToString().Trim());//是否需要皮试
                arrExecOrder[i].m_intFEEL_INT = int.Parse(objRow[i]["FEEL_INT"].ToString().Trim());//皮试结果
                arrExecOrder[i].m_strFEELRESULT_VCHR = Convert.ToString(objRow[i]["FEELRESULT_VCHR"].ToString().Trim());//皮试结果备注
                if (!objRow[i]["CHARGE_INT"].ToString().Trim().Equals(""))
                    arrExecOrder[i].m_intCHARGE_INT = int.Parse(objRow[i]["CHARGE_INT"].ToString().Trim());
                if (!objRow[i]["ATTACHTIMES_INT"].ToString().Trim().Equals(""))
                    arrExecOrder[i].m_intATTACHTIMES_INT = int.Parse(objRow[i]["ATTACHTIMES_INT"].ToString().Trim());
                arrExecOrder[i].m_strREMARK_VCHR = objRow[i]["REMARK_VCHR"].ToString().Trim();//医嘱说明
                arrExecOrder[i].m_strInpatientID = objRow[i]["inpatientid_chr"].ToString().Trim();//住院号
            }

         
        }

        #endregion    
    }
}
