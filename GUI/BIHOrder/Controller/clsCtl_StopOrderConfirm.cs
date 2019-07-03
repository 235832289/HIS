using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.BIHOrder.Control;
using System.Collections;
using com.digitalwave.iCare.gui.LIS;
using System.Drawing;

namespace com.digitalwave.iCare.BIHOrder
{
    class clsCtl_StopOrderConfirm : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量声名
        clsDcl_ExecuteOrder m_objManage = null;
        clsDcl_InputOrder m_objInputOrder = null;
        DataTable m_dtChargeList;
        #endregion

        #region 构造函数
        public clsCtl_StopOrderConfirm()
        {
            m_objManage = new clsDcl_ExecuteOrder();
            m_objInputOrder = new clsDcl_InputOrder();

        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmStopOrderConfirm m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmStopOrderConfirm)frmMDI_Child_Base_in;

        }
        #endregion
        
        /// <summary>
        /// 根据病人登记流水号查相关已停用的诊疗项目
        /// </summary>
        /// <param name="m_strRegisterID"></param>
        internal void LoadTheOrders(string m_strRegisterID)
        {
            this.m_objViewer.m_dtvOrder.Rows.Clear();
            //停用项目，或停药项目列表
            DataTable m_dtOrderSign = null;
            ArrayList m_arrRecipenNo = new ArrayList();
            long ret = m_objInputOrder.m_lngGetOrderStopSignByRegisterId(m_strRegisterID, out m_dtOrderSign);
            if (m_dtOrderSign != null && m_dtOrderSign.Rows.Count > 0)
            {
                m_arrRecipenNo = GetTheAllStopOrders(m_dtOrderSign);
                if (m_arrRecipenNo.Count > 0)
                {
                    clsBIHOrder[] arrOrder=null;
                     ret=m_objInputOrder.m_lngGetOrderStopByRECIPENO_INT(m_arrRecipenNo,m_strRegisterID, out  arrOrder,out m_dtChargeList);
                    if ((ret > 0) && (arrOrder != null))
                    {
                        //上一个医嘱的方号
                        int m_intNo = 0;
                        for (int i = 0; i < arrOrder.Length; i++)
                        {
                            // 同方号的子医嘱不用再显示：长/临、类别、用法、频率、状态、下嘱医生
                            this.m_objViewer.m_dtvOrder.Rows.Add();
                            DataGridViewRow objRow = this.m_objViewer.m_dtvOrder.Rows[this.m_objViewer.m_dtvOrder.RowCount - 1];
                            m_intNo = this.m_objViewer.m_dtvOrder.RowCount;
                            m_objGetDataViewRow(arrOrder[i], objRow, m_intNo);
                            /*<===========================*/
                        }
                        //m_mthRefreshGridColor();
                        //刷新同方医嘱的方号颜色
                        m_mthRefreshSameReqNoColor();
                        //编程触发事件
                        if (this.m_objViewer.m_dtvOrder.RowCount > 0)
                        {
                            this.m_objViewer.m_dtvOrder.CurrentCell = this.m_objViewer.m_dtvOrder.Rows[0].Cells[4];
                        }
                        else
                        {
                            this.m_objViewer.m_dtvChangeList.Rows.Clear();
                        }
                    }
                }
            }
            this.m_objViewer.m_dtvChangeList.CurrentCell = null;
            /*<=============================*/
            //选中该病人要处理的医嘱方号           
        }

        /// <summary>
        /// 刷新同方医嘱的方号颜色并隐藏相同性质的字段
        /// </summary>
        public void m_mthRefreshSameReqNoColor()
        {
            for (int i = 1; i < this.m_objViewer.m_dtvOrder.Rows.Count; i++)
            {
                clsBIHOrder order = (clsBIHOrder)m_objViewer.m_dtvOrder.Rows[i - 1].Tag;
                DataGridViewRow objRow = m_objViewer.m_dtvOrder.Rows[i];

                if (order.m_intRecipenNo == ((clsBIHOrder)m_objViewer.m_dtvOrder.Rows[i].Tag).m_intRecipenNo)
                {
                    //m_objViewer.m_dtvOrder.Rows[i - 1].Cells["dtv_RecipeNo"].Style.ForeColor = Color.SkyBlue;
                    //objRow.Cells["dtv_RecipeNo"].Style.ForeColor = Color.SkyBlue;
                    //隐藏的字段
                    //方号dtv_RecipeNo
                    objRow.Cells["dtv_RecipeNo"].Value = "";
                    //类型dtv_ExecuteType
                    objRow.Cells["dtv_ExecuteType"].Value = "";
                    //下嘱时间m_dtStartDate
                    //objRow.Cells["m_dtStartDate"].Value = "";
                    objRow.Cells["m_dtPOSTDATE_DAT"].Value = "";
                    //开医嘱者CREATOR_CHR
                    objRow.Cells["CREATOR_CHR"].Value = "";
                    //过医嘱者ASSESSORFOREXEC_CHR
                    objRow.Cells["ASSESSORFOREXEC_CHR"].Value = "";
                    //中药的同方也显示用法
                    if (this.m_objViewer.m_objSpecateVo.m_strMID_MEDICINE_CHR.Trim().Equals(((clsBIHOrder)objRow.Tag).m_strOrderDicCateID))//中药类型逻辑
                    {
                        //用法dtv_UseType
                        objRow.Cells["dtv_UseType"].Value = ((clsBIHOrder)objRow.Tag).m_strDosetypeName;
                        objRow.Cells["dtv_REMARK"].Value = "";
                    }
                    else
                    {
                        //用法dtv_UseType
                        objRow.Cells["dtv_UseType"].Value = "";

                    }


                    // 频率dtv_Freq
                    objRow.Cells["dtv_Freq"].Value = "";
                    //说明dtv_ENTRUST
                    //objRow.Cells["dtv_ENTRUST"].Value = "";
                    //停嘱时间dtv_FinishDate
                    objRow.Cells["dtv_FinishDate"].Value = "";
                    //停医嘱者dtv_Stoper
                    objRow.Cells["dtv_Stoper"].Value = "";
                    //过医嘱者 
                    //objRow.Cells[""].Value = "";
                    //补次ATTACHTIMES_INT
                    objRow.Cells["ATTACHTIMES_INT"].Value = "";
                    //医嘱状态STATUS_INT
                    objRow.Cells["STATUS_INT"].Value = "";
                    //执行时间dtv_StartDate
                    objRow.Cells["dtv_StartDate"].Value = "";

                    //执行人dtv_Executor
                    objRow.Cells["dtv_Executor"].Value = "";
                    //作废时间dtv_DELETE_DAT
                    objRow.Cells["dtv_DELETE_DAT"].Value = "";
                    //作废时间dtv_DELETE_DAT
                    objRow.Cells["dtv_DELETE_DAT"].Value = "";
                    //作废人dtv_DELETERNAME_VCHR
                    objRow.Cells["dtv_DELETERNAME_VCHR"].Value = "";

                    /*<=================================*/
                    //皮试
                    string m_strFeel = "";
                    if (((clsBIHOrder)objRow.Tag).m_intISNEEDFEEL == 1)
                    {

                        switch (((clsBIHOrder)objRow.Tag).m_intFEEL_INT)
                        {
                            case 0:
                                m_strFeel = " AST( ) ";
                                break;
                            case 1:
                                m_strFeel = " AST(-) ";
                                break;
                            case 2:
                                m_strFeel = " AST(+) ";
                                break;
                        }

                    }

                    //名称  同一方号的医嘱，子医嘱的用法与频率不用显示
                    objRow.Cells["dtv_Name"].Value = ((clsBIHOrder)objRow.Tag).m_strName + " " + objRow.Cells["dtv_Dosage"].Value.ToString() + "  " + objRow.Cells["dtv_UseType"].Value.ToString() + " " + m_strFeel;


                }

                //已停或正在停的医嘱,已执行过的临嘱用红色显示(包括执行出院带药)

                if (order.m_intStatus == 3 || order.m_intStatus == 6 || (order.m_intExecuteType == 2 && order.m_intStatus == 2) || (order.m_intExecuteType == 3 && order.m_intStatus == 2))
                {
                    m_objViewer.m_dtvOrder.Rows[i - 1].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (order.m_intStatus == -1)
                {
                    m_objViewer.m_dtvOrder.Rows[i - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));

                }

            }
            if (m_objViewer.m_dtvOrder.RowCount > 0)
            {
                //已停或正在停的医嘱,已执行过的临嘱用红色显示(最后一条的处理)
                clsBIHOrder order2 = (clsBIHOrder)m_objViewer.m_dtvOrder.Rows[m_objViewer.m_dtvOrder.RowCount - 1].Tag;
                if (order2.m_intStatus == 3 || order2.m_intStatus == 6 || (order2.m_intExecuteType == 2 && order2.m_intStatus == 2) || (order2.m_intExecuteType == 3 && order2.m_intStatus == 2))
                {
                    m_objViewer.m_dtvOrder.Rows[m_objViewer.m_dtvOrder.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (order2.m_intStatus == -1)
                {
                    m_objViewer.m_dtvOrder.Rows[m_objViewer.m_dtvOrder.RowCount - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));

                }
            }

        }

        /// <summary>
        /// 医嘱填充DATAGRIDVIEW
        /// </summary>
        /// <param name="objOrder">医嘱对像</param>
        /// <param name="m_intRecipenNoUp">上一条医嘱的方号(同方号的子医嘱不用再显示：长/临、类别、用法、频率、状态、下嘱医生)</param>
        public void m_objGetDataViewRow(clsBIHOrder objOrder, DataGridViewRow objRow, int m_intNo)
        {
            objRow.Height = 20;
            decimal m_dmlOneUse = 0;//补一次的领量
            //序
            objRow.Cells["dtv_NO"].Value = m_intNo;
            //医嘱类型
            clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)this.m_objViewer.m_htOrderCate[objOrder.m_strOrderDicCateID];
            if (p_objItem == null)
            {
                
                if (objOrder.m_intTYPE_INT > 0)
                {
                    objRow.Cells["dtv_Name"].Value = objOrder.m_strName.ToString();
                    objRow.Cells["dtv_Name"].Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    objRow.Tag = objOrder;
                    return;
                }
            }
            if (objOrder.m_intExecuteType == 1)
            {
                //方
                objRow.Cells["dtv_RecipeNo"].Value = " " + objOrder.m_intRecipenNo2.ToString();
            }
            //价格
            //objRow["Price"] =objOrder.m_dmlPrice.ToString("0.0000");

            //“方法”列。用于显示检验医嘱的样本类型，和检查医嘱的部位信息
            if (!objOrder.m_strPARTID_VCHR.Trim().Equals(""))
            {
                objRow.Cells["dtv_method"].Value = objOrder.m_strPARTNAME_VCHR;
            }
            else if (!objOrder.m_strSAMPLEID_VCHR.Trim().Equals(""))
            {
                objRow.Cells["dtv_method"].Value = objOrder.m_strSAMPLEName_VCHR;
            }



            //开始执行时间
            objRow.Cells["dtv_StartDate"].Value = DateTimeToString(objOrder.m_dtExecutedate);
            //停嘱者
            objRow.Cells["dtv_Stoper"].Value = objOrder.m_strStoper;
            //审核停止者
            objRow.Cells["ASSESSORFORSTOP_CHR"].Value = objOrder.m_strASSESSORFORSTOP_CHR;
            //停嘱时间
            objRow.Cells["dtv_FinishDate"].Value = DateTimeToCutYearDateString(objOrder.m_dtFinishDate);
            //objRow.Cells["dtv_ParentName"].Value = objOrder.m_strParentName;
            //执行时间/嘱托
            objRow.Cells["dtv_REMARK"].Value = objOrder.m_strREMARK_VCHR;
            //自备药 (1-全计费 1-否)( 2-用法收费 2-是)(3 不计费 作废)
            switch (objOrder.RateType)
            {
                case 0:
                    objRow.Cells["RATETYPE_INT"].Value = "否";
                    break;
                case 1:
                    objRow.Cells["RATETYPE_INT"].Value = "是";
                    break;
                case 2:
                    objRow.Cells["RATETYPE_INT"].Value = "";
                    break;

            }


            //校对护士
            objRow.Cells["ASSESSORFOREXEC_CHR"].Value = objOrder.m_strASSESSORFOREXEC_CHR;
            //录入时间
            objRow.Cells["CREATEDATE_DAT"].Value = DateTimeToString(objOrder.m_dtCreatedate); 
            //下嘱时间(开始时间）
            objRow.Cells["m_dtPOSTDATE_DAT"].Value = DateTimeToCutYearDateString(objOrder.m_dtPostdate);
            objRow.Cells["m_dtStartDate"].Value = DateTimeToCutYearDateString(objOrder.m_dtStartDate);

            /*<===============================*/
            //皮试
            string m_strFeel = "";
            if (objOrder.m_intISNEEDFEEL == 1)
            {

                switch (objOrder.m_intFEEL_INT)
                {
                    case 0:
                        m_strFeel = " AST( ) ";
                        break;
                    case 1:
                        m_strFeel = " AST(-) ";
                        break;
                    case 2:
                        m_strFeel = " AST(+) ";
                        break;
                }

            }
            /*<==================================*/
            #region 医嘱类型控制列表界面
            if (p_objItem != null)
            {
                objOrder.m_strOrderDicCateName = p_objItem.m_strVIEWNAME_VCHR;

                if (!objOrder.m_strExecFreqID.Trim().Equals(this.m_objViewer.m_objSpecateVo.m_strCONFREQID_CHR.Trim()))//连续性医嘱不显示剂量
                {
                    if (p_objItem.m_intDOSAGEVIEWTYPE == 1)
                    {
                        //用量
                        if (objOrder.m_dmlDosage > 0)
                        {
                            objRow.Cells["dtv_Dosage"].Value = objOrder.m_dmlDosage.ToString() + "" + objOrder.m_strDosageUnit;
                        }
                        else
                        {
                            objRow.Cells["dtv_Dosage"].Value = "";

                        }
                    }
                    else
                    {
                        objRow.Cells["dtv_Dosage"].Value = "";
                    }
                }
                else
                {
                    objRow.Cells["dtv_Dosage"].Value = "";
                }
                if (!objOrder.m_strExecFreqID.Trim().Equals(this.m_objViewer.m_objSpecateVo.m_strCONFREQID_CHR.Trim()))//连续性医嘱不显示用法
                {
                    if (p_objItem.m_intUSAGEVIEWTYPE == 1)
                    {
                        //用法
                        objRow.Cells["dtv_UseType"].Value = objOrder.m_strDosetypeName;
                    }
                    else
                    {
                        //用法
                        objRow.Cells["dtv_UseType"].Value = "";
                    }
                }
                else
                {
                    //用法
                    objRow.Cells["dtv_UseType"].Value = "";
                }
                if (objOrder.m_intExecuteType == 1)//长临才显示频率，临嘱不显示
                {
                    if (p_objItem.m_intExecuFrenquenceType == 1)
                    {
                        //频率
                        objRow.Cells["dtv_Freq"].Value = objOrder.m_strExecFreqName;
                    }
                    else
                    {
                        //当不显示时，医嘱表中的为修改标志=1时也显示出来 (0-普通状态,1-频率修改)
                        if (objOrder.m_intCHARGE_INT == 1)
                        {
                            objRow.Cells["dtv_Freq"].Value = objOrder.m_strExecFreqName;//频率
                        }
                        else
                        {
                            objRow.Cells["dtv_Freq"].Value = "";//频率
                        }
                    }
                }
                else
                {
                    //当不显示时，医嘱表中的为修改标志=1时也显示出来 (0-普通状态,1-频率修改)
                    if (objOrder.m_intCHARGE_INT == 1)
                    {
                        objRow.Cells["dtv_Freq"].Value = objOrder.m_strExecFreqName;//频率
                    }
                    else
                    {
                        objRow.Cells["dtv_Freq"].Value = "";//频率
                    }

                }

                if (p_objItem.m_intAPPENDVIEWTYPE_INT == 1)
                {
                    //补次
                    objRow.Cells["ATTACHTIMES_INT"].Value = objOrder.m_intATTACHTIMES_INT;
                    m_dmlOneUse = objOrder.m_dmlOneUse * objOrder.m_intATTACHTIMES_INT;
                }
                else
                {
                    //补次
                    objRow.Cells["ATTACHTIMES_INT"].Value = "";
                    m_dmlOneUse = 0;
                }
                //领量
                if (p_objItem.m_intQTYVIEWTYPE_INT == 1)
                {
                    if (objOrder.m_dmlGet > 0)
                    {
                        objRow.Cells["dtv_Get"].Value = objOrder.m_dmlGet.ToString() + " " + objOrder.m_strGetunit;

                    }
                    else
                    {
                        objRow.Cells["dtv_Get"].Value = "";

                    }
                }
                else
                {
                    //领量
                    objRow.Cells["dtv_Get"].Value = "";
                }
            }
            else
            {
                //用量
                objRow.Cells["dtv_Dosage"].Value = "";
                //频率
                objRow.Cells["dtv_Freq"].Value = "";
                //用法
                objRow.Cells["dtv_UseType"].Value = "";
                //补次
                objRow.Cells["ATTACHTIMES_INT"].Value = "";
                //领量
                objRow.Cells["dtv_Get"].Value = "";

            }
            #endregion
            //出院带药天数
            string m_strOUTGETMEDDAYS_INT = "";
            //总量字段的控制
            if (objOrder.m_strOrderDicCateID.Equals(this.m_objViewer.m_objSpecateVo.m_strMID_MEDICINE_CHR))//中药类型逻辑
            {
                objRow.Cells["dtv_sum"].Value = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "服共" + Convert.ToString(objOrder.m_dmlGet + m_dmlOneUse) + objOrder.m_strGetunit;
                m_strOUTGETMEDDAYS_INT = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "服"; ;
            }
            else
            {

                if (objOrder.m_intExecuteType == 3)
                {
                    objRow.Cells["dtv_sum"].Value = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天共" + Convert.ToString(objOrder.m_dmlGet + m_dmlOneUse) + objOrder.m_strGetunit;
                    m_strOUTGETMEDDAYS_INT = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天";
                    //objRow.Cells["dtv_OUTGETMEDDAYS_INT"].Value = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天";
                }
                else
                {
                    objRow.Cells["dtv_sum"].Value = "共" + Convert.ToString(objOrder.m_dmlGet + m_dmlOneUse) + objOrder.m_strGetunit;
                    m_strOUTGETMEDDAYS_INT = "";
                    //objRow.Cells["dtv_OUTGETMEDDAYS_INT"].Value = "";
                }
                objRow.Cells["dtv_OUTGETMEDDAYS_INT"].Value = m_strOUTGETMEDDAYS_INT;
            }

            //名称
            objRow.Cells["dtv_Name"].Value = objOrder.m_strName + " " + objRow.Cells["dtv_Dosage"].Value.ToString() + " " + objRow.Cells["dtv_UseType"].Value.ToString() + " " + objRow.Cells["dtv_Freq"].Value.ToString() + m_strFeel + " " + m_strOUTGETMEDDAYS_INT;
            //名称格式控制
            if (p_objItem != null)
            {
                if (p_objItem.m_strVIEWNAME_VCHR.ToString().Trim() == "文字医嘱")
                {
                    objRow.Cells["dtv_Name"].Value = "   " + objRow.Cells["dtv_Name"].Value.ToString();

                }
            }

            /*<=====================================================================*/
            //医保
            objRow.Cells["MedicareTypeName"].Value = objOrder.m_strMedicareTypeName;
            //医生名称 
            objRow.Cells["dtv_DOCTOR_VCHR"].Value = objOrder.m_strDOCTOR_VCHR;
            //开单科室 
            objRow.Cells["dtv_CREATEAREA_Name"].Value = objOrder.m_strCREATEAREA_Name;
            //作废人 
            objRow.Cells["dtv_DELETERNAME_VCHR"].Value = objOrder.m_strDELETERNAME_VCHR;
            //作废时间 
            objRow.Cells["dtv_DELETE_DAT"].Value = objOrder.m_strDELETE_DAT;
            //修改人姓名
            objRow.Cells["dtv_ChangedID"].Value = objOrder.m_strChangedName_CHR;
            //修改人时间
            objRow.Cells["dtv_ChangedDate"].Value = DateTimeToString(objOrder.m_dtChanged_DAT);

            // 同方号的子医嘱不用再显示：长/临、类别、用法、频率、状态、下嘱医生
            //长/临
            if (objOrder.m_intExecuteType == 1)
            {
                objRow.Cells["dtv_ExecuteType"].Value = "长期";

            }
            else if (objOrder.m_intExecuteType == 2)
            {
                objRow.Cells["dtv_ExecuteType"].Value = "临时";

            }
            else if (objOrder.m_intExecuteType == 3)
            {
                objRow.Cells["dtv_ExecuteType"].Value = "带药";

            }
            else
            {
                objRow.Cells["dtv_ExecuteType"].Value = "";
            }


            //医嘱类型名称
            objRow.Cells["viewname_vchr"].Value = objOrder.m_strOrderDicCateName.ToString().Trim();
            //医嘱状态 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
            switch (objOrder.m_intStatus)
            {
                case -1:
                    objRow.Cells["STATUS_INT"].Value = "作废";
                    break;
                case 0:
                    objRow.Cells["STATUS_INT"].Value = "新开";
                    break;
                case 1:
                    objRow.Cells["STATUS_INT"].Value = "提交";
                    break;
                case 2:
                    objRow.Cells["STATUS_INT"].Value = "执行";
                    break;
                case 3:
                    objRow.Cells["STATUS_INT"].Value = "停止";
                    break;
                case 4:
                    objRow.Cells["STATUS_INT"].Value = "重整";
                    break;
                case 5:
                    objRow.Cells["STATUS_INT"].Value = "转抄";
                    break;
                case 6:
                    objRow.Cells["STATUS_INT"].Value = "审核停止";
                    break;
                case 7:
                    objRow.Cells["STATUS_INT"].Value = "退回";
                    break;
                default:
                    objRow.Cells["STATUS_INT"].Value = "";
                    break;
            }
            //下嘱医生
            objRow.Cells["CREATOR_CHR"].Value = objOrder.m_strCreator;
            //执行人
            objRow.Cells["dtv_Executor"].Value = objOrder.m_strExecutor;
            ////医生签名dtv_DOCTOR_SIGN
            //if (this.m_frmInput.m_blDoctorSign)
            //{
            //    if (objOrder.SIGN_GRP != null && objOrder.SIGN_INT == 1)
            //    {
            //        System.IO.MemoryStream ms = new System.IO.MemoryStream(objOrder.SIGN_GRP);
            //        Bitmap m_bpSign = new Bitmap(ms);
            //        objRow.Cells["dtv_DOCTOR_SIGN"].Value = m_bpSign;
            //        ms.Close();
            //    }
            //    else if (objOrder.SIGN_INT == 0)
            //    {

            //        Bitmap m_bpSign = new Bitmap("Picture//unsign.bmp");
            //        objRow.Cells["dtv_DOCTOR_SIGN"].Value = m_bpSign;

            //    }
            //    else
            //    {

            //        objRow.Cells["dtv_DOCTOR_SIGN"].Style.NullValue = null;
            //    }

            //    if (this.m_frmInput.m_blDoctorSign && objOrder.SIGN_INT != 1)
            //    {
            //        objRow.DefaultCellStyle.ForeColor = Color.Red;
            //    }
            //}
            //退回人
            objRow.Cells["m_dtvSENDBACKER_CHR"].Value = objOrder.m_strSENDBACKER_CHR;



            /*<==================================================================*/
            objRow.Tag = objOrder;

        }

        /// <summary>
        /// 时间输入转换
        /// </summary>
        /// <param name="dtValue"></param>
        /// <returns></returns>
        public string DateTimeToString(DateTime dtValue)
        {
            //if(dtValue.Date==clsBIHOrder.m_dtNullDate.Date)
            if (dtValue.Date == DateTime.MinValue)
                return "";
            else
                return dtValue.ToString("yy-MM-dd HH:mm");
        }

        public string DateTimeToCutYearDateString(DateTime dtValue)
        {
            //if(dtValue.Date==clsBIHOrder.m_dtNullDate.Date)
            if (dtValue.Date == DateTime.MinValue)
                return "";
            else
                return dtValue.ToString("MM-dd HH:mm");
        }


        /// <summary>
        /// 返回当前所有停用或停药的医嘱流水数组
        /// </summary>
        /// <param name="m_arrOrderIDs"></param>
        /// <returns></returns>
        private ArrayList GetTheAllStopOrders(DataTable m_dtOrderSign)
        {
            ArrayList m_arrStopOrderIds = new ArrayList();
            ArrayList m_arrRECIPENO_INT = new ArrayList();
            if (m_dtOrderSign != null)
            {
                string m_strRECIPENO_INT = "";
                string STATUS_INT = "";//(诊疗项目状态 0-停用 1-正常)
                string IFSTOP_INT = "";//停用标志 1-停用 0-正常
                string ITEMSRCTYPE_INT = "";//项目来源类型1－药品表
                string IPNOQTYFLAG_INT = "";//中心药房缺药标志 0-有药 1－缺药
                bool m_blStop = false;
                for (int i = 0; i < m_dtOrderSign.Rows.Count; i++)
                {
                    m_blStop = false;
                    DataRow row = m_dtOrderSign.Rows[i];
                    m_strRECIPENO_INT = row["RECIPENO_INT"].ToString().Trim();
                    STATUS_INT = row["STATUS_INT"].ToString().Trim();//(诊疗项目状态 0-停用 1-正常)
                    IFSTOP_INT = row["IFSTOP_INT"].ToString().Trim();//停用标志 1-停用 0-正常
                    ITEMSRCTYPE_INT = row["ITEMSRCTYPE_INT"].ToString().Trim();//项目来源类型1－药品表
                    IPNOQTYFLAG_INT = row["IPNOQTYFLAG_INT"].ToString().Trim();//中心药房缺药标志 0-有药 1－缺药
                    if ((STATUS_INT.Equals("0") || IFSTOP_INT.Equals("1")))
                    {
                        if (!this.m_objViewer.m_blStopControl)
                        {
                            m_blStop = true;
                        }
                    }

                    if (!this.m_objViewer.m_blDeableMedControl)
                    {
                        if (ITEMSRCTYPE_INT.Equals("1") && IPNOQTYFLAG_INT.Equals("1"))
                        {
                            m_blStop = true;
                        }
                    }


                    if (m_blStop)
                    {
                        if (!m_arrStopOrderIds.Contains(m_strRECIPENO_INT))
                        {
                            m_arrStopOrderIds.Add(m_strRECIPENO_INT);
                        }
                    }

                }
              
            }
            return m_arrStopOrderIds;

        }

        #region 为费用datagridview填值
        /// <summary>
        /// 为费用datagridview填值
        /// </summary>
        /// <param name="order"></param>
        private void filltheChargeList(clsBIHOrder order)
        {
            this.m_objViewer.m_dtvChangeList.Rows.Clear();
            if (m_dtChargeList != null && m_dtChargeList.Rows.Count > 0)
            {

                DataView myDataView = new DataView(m_dtChargeList);
                myDataView.RowFilter = "orderid_chr='" + order.m_strOrderID + "'";
                myDataView.Sort = "FLAG_INT";
                if (myDataView.Count <= 0)
                {
                    return;
                }
                clsChargeForDisplay[] m_arrObjItem;
                m_mthGetChargeListFromDateTable(myDataView, out m_arrObjItem);
                int k = 0;
                for (int i = 0; i < m_arrObjItem.Length; i++)
                {

                    k++;
                    this.m_objViewer.m_dtvChangeList.Rows.Add();
                    DataGridViewRow row1 = this.m_objViewer.m_dtvChangeList.Rows[this.m_objViewer.m_dtvChangeList.RowCount - 1];
                    row1.Cells["seq"].Value = Convert.ToString(k);
                    row1.Cells["chargeName"].Value = m_arrObjItem[i].m_strName;
                    row1.Cells["ITEMSPEC_VCHR"].Value = m_arrObjItem[i].m_strSPEC_VCHR;
                    row1.Cells["ChargeClass"].Value = "";
                    switch (m_arrObjItem[i].m_intType)
                    {
                        case 0:
                            row1.Cells["ChargeClass"].Value = "主项目";
                            break;
                        case 1:
                            row1.Cells["ChargeClass"].Value = "辅助项目";
                            break;
                        case 2:
                            row1.Cells["ChargeClass"].Value = "用法带出";
                            break;
                        case 3:
                            row1.Cells["ChargeClass"].Value = "补充录入";
                            break;
                    }

                    row1.Cells["ChargePrice"].Value = m_arrObjItem[i].m_dblPrice.ToString();
                    row1.Cells["get_count"].Value = m_arrObjItem[i].m_dblDrawAmount.ToString() + " " + m_arrObjItem[i].m_strUNIT_VCHR;
                    row1.Cells["countSum"].Value = m_arrObjItem[i].m_dblMoney.ToString();
                    switch (m_arrObjItem[i].m_intCONTINUEUSETYPE_INT)
                    {
                        case 1:
                            row1.Cells["xuClass"].Value = "首次用";
                            break;
                        case 0:
                            row1.Cells["xuClass"].Value = "连续用";
                            break;
                        default:
                            row1.Cells["xuClass"].Value = " -- ";
                            break;
                    }

                    row1.Cells["excuteDept"].Value = m_arrObjItem[i].m_strClacareaName_chr;
                    row1.Cells["YBClass"].Value = m_arrObjItem[i].m_strYBClass;
                    row1.Cells["IPNOQTYFLAG_INT"].Value = "";
                    if (m_arrObjItem[i].m_intITEMSRCTYPE_INT == 1)
                    {
                        if (m_arrObjItem[i].m_intIPNOQTYFLAG_INT == 1)
                        {
                            row1.Cells["IPNOQTYFLAG_INT"].Value = "缺药";
                            row1.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    if (m_arrObjItem[i].m_intIFSTOP_INT == 1)
                    {
                        row1.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    }
                    row1.Tag = m_arrObjItem[i];

                    //序号 seq
                    //项目名称 chargeName
                    //费用类型 ChargeClass
                    //单价 ChargePrice
                    //数量 get_count
                    //总金额 countSum
                    //续用类型 xuClass
                    //执行科室 excuteDept
                    //医保类型 YBClass
                }
                this.m_objViewer.m_dtvChangeList.CurrentCell=null;
            }

        }

       
        #endregion

        #region 费用表转换为费用明细对象
        /// <summary>
        /// 费用表转换为费用明细对象
        /// </summary>
        /// <param name="objRow"></param>
        /// <param name="m_arrObjItem"></param>
        private void m_mthGetChargeListFromDateTable(DataView objRow, out clsChargeForDisplay[] m_arrObjItem)
        {
            m_arrObjItem = new clsChargeForDisplay[objRow.Count];
            for (int i = 0; i < objRow.Count; i++)
            {
                m_arrObjItem[i] = new clsChargeForDisplay();
                m_arrObjItem[i].m_strChargeID = clsConverter.ToString(objRow[i]["CHARGEITEMID_CHR"]).Trim();
                //收费项目名称
                m_arrObjItem[i].m_strName = clsConverter.ToString(objRow[i]["CHARGEITEMNAME_CHR"]).Trim();
                double dblNum = 0;
                //if (objMedicineItemArr[i1].m_objChargeItem.m_strITEMID_CHR.Trim() == objMedicineItemArr[i1].m_strChiefItemID.Trim())//是否主收费项目
                //{
                //    dblNum = p_dblDraw;
                //    //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                //    m_arrObjItem[i].m_intType = 2;
                //}
                //else
                //{
                //    dblNum = System.Convert.ToDouble(m_dmlGetChargeNotMainItem(objRecipeFreq, objMedicineItemArr[i1]));
                //    //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                //    m_arrObjItem[i].m_intType = 1;
                //}
                //单价
                if (!objRow[i]["UNITPRICE_DEC"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_dblPrice = double.Parse(clsConverter.ToString(objRow[i]["UNITPRICE_DEC"]).Trim());
                }
                if (!objRow[i]["AMOUNT_DEC"].ToString().Trim().Equals(""))
                {
                    dblNum = double.Parse(clsConverter.ToString(objRow[i]["AMOUNT_DEC"]).Trim());
                }
                /*<---------------------------------*/
                //领量
                m_arrObjItem[i].m_dblDrawAmount = dblNum;

                //合计金额
                m_arrObjItem[i].m_dblMoney = m_arrObjItem[i].m_dblPrice * dblNum;
                //续用类型 {-1=非用法收费（药品收费等）;0=不续用;1=全部续用;2-长嘱续用}
                if (!objRow[i]["CONTINUEUSETYPE_INT"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intCONTINUEUSETYPE_INT = int.Parse(objRow[i]["CONTINUEUSETYPE_INT"].ToString().Trim());
                }

                //是否连续性医嘱	{0=否；1=是} 连续性医嘱不提示药品费用信息；
                // m_arrObjItem[i].m_intIsContinueOrder = (blnIsConOrder) ? (1) : (0);
                //是否缺药
                // m_arrObjItem[i].m_strNoqtyFLag = objMedicineItemArr[i1].m_strNoqtyFLag;
                // 加上科室名称
                m_arrObjItem[i].m_strClacarea_chr = clsConverter.ToString(objRow[i]["CLACAREA_CHR"]).Trim();
                m_arrObjItem[i].m_strClacareaName_chr = clsConverter.ToString(objRow[i]["deptname_vchr"]).Trim();
                //暂存住院诊疗项目收费项目执行客户表的流水号
                m_arrObjItem[i].m_strSeq_int = clsConverter.ToString(objRow[i]["SEQ_INT"]).Trim(); ;
                m_arrObjItem[i].m_strYBClass = clsConverter.ToString(objRow[i]["INSURACEDESC_VCHR"]).Trim();
                m_arrObjItem[i].m_strUNIT_VCHR = clsConverter.ToString(objRow[i]["UNIT_VCHR"]).Trim();
                //收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
                if (!objRow[i]["FLAG_INT"].ToString().Trim().Equals(""))
                    m_arrObjItem[i].m_intType = clsConverter.ToInt(objRow[i]["FLAG_INT"].ToString().Trim());
                // 住院诊疗项目收费项目执行客户表VO
                //objItem.m_objORDERCHARGEDEPT_VO = objMedicineItemArr[i1].m_objORDERCHARGEDEPT_VO;
                if (!objRow[i]["ITEMSRCTYPE_INT"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intITEMSRCTYPE_INT = int.Parse(objRow[i]["ITEMSRCTYPE_INT"].ToString().Trim());
                }
                if (!objRow[i]["IPNOQTYFLAG_INT"].ToString().Trim().Equals(""))
                {
                    m_arrObjItem[i].m_intIPNOQTYFLAG_INT = int.Parse(objRow[i]["IPNOQTYFLAG_INT"].ToString().Trim());
                }
                m_arrObjItem[i].m_strSPEC_VCHR = clsConverter.ToString(objRow[i]["ITEMSPEC_VCHR"].ToString().Trim());
                m_arrObjItem[i].m_intIFSTOP_INT = clsConverter.ToInt(objRow[i]["IFSTOP_INT"].ToString().Trim());
            }
        }
        #endregion

        internal void OrderListSelect()
        {
            if (this.m_objViewer.m_dtvOrder.CurrentCell != null && this.m_objViewer.m_dtvOrder.RowCount > 0)
            {

                clsBIHOrder order = (clsBIHOrder)this.m_objViewer.m_dtvOrder.Rows[this.m_objViewer.m_dtvOrder.CurrentCell.RowIndex].Tag;

                if (order != null)
                {
                     filltheChargeList(order);
                    TheSameNoRowSelect(order);
                }
            }
        }

        private void TheSameNoRowSelect(clsBIHOrder order)
        {
            string m_strID = order.m_strRegisterID + "," + order.m_intRecipenNo.ToString()+";";
            string m_strTemp = "";

            for (int i = 0; i < this.m_objViewer.m_dtvOrder.Rows.Count; i++)
            {
                clsBIHOrder Exeorder = (clsBIHOrder)this.m_objViewer.m_dtvOrder.Rows[i].Tag;
                m_strTemp = Exeorder.m_strRegisterID + "," + Exeorder.m_intRecipenNo.ToString()+";";
                if (m_strTemp.Equals(m_strID))
                {
                    this.m_objViewer.m_dtvOrder.Rows[i].Selected = true;
                }

            }
            /*<====================================*/
      
        }

        internal void OrderStop()
        {
            ArrayList m_arrOrder = new ArrayList();
            ArrayList m_arrOrderIdCan=new ArrayList();
            GetTheSelectOrders(ref m_arrOrder);
            #region 刷新当前医嘱数据，然后再判断

            ArrayList m_arrORDERID_CHR = new ArrayList();
            string m_strOrderID = "";
            for (int i = 0; i < m_arrOrder.Count; i++)
            {
                m_strOrderID = ((clsBIHOrder)m_arrOrder[i]).m_strOrderID;
                if (!m_arrORDERID_CHR.Contains(m_strOrderID))
                {
                    m_arrORDERID_CHR.Add(m_strOrderID);
                }
            }

            clsBIHOrder[] arrOrder = null;
            //com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService m_objService = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            m_objService.m_lngGetArrOrderByOrderID(m_arrORDERID_CHR, out arrOrder);
            if (arrOrder != null && arrOrder.Length > 0)
            {
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    clsBIHOrder order = arrOrder[i];
                    DataGridViewRow row = GetTheGridRowByOrder(order.m_strOrderID);
                    this.m_objGetDataViewRow(order, row, row.Index + 1);
                }

            }
            this.m_mthRefreshSameReqNoColor();
            m_arrOrder.Clear();
            GetTheSelectOrders(ref m_arrOrder);
            #endregion

            if (m_arrOrder.Count <= 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                bool m_blCan=false;
                for (int i = 0; i < m_arrOrder.Count; i++)
                {
                    clsBIHOrder order = (clsBIHOrder)m_arrOrder[i];
                    if (order.m_intExecuteType == 1 && order.m_intStatus == 2)
                    {
                        m_arrOrderIdCan.Add(order.m_strOrderID);
                        m_blCan = true;
                    }
                }
                if (!m_blCan)
                {
                    MessageBox.Show("当前操作中没有符合可停止的执行中的长嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (m_arrOrderIdCan.Count>0)
                {
                    if (MessageBox.Show("确认进行停嘱操作吗?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string[] m_strOrderIDs = (string[])(m_arrOrderIdCan.ToArray(typeof(string)));

                        long m_lngRef = this.m_objInputOrder.m_lngStopOrder(m_strOrderIDs, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);

                        MessageBox.Show("操作成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTheOrders(this.m_objViewer.m_strRegisterID);
                    }
                }
            }

        }

        private void GetTheSelectOrders(ref ArrayList m_arrOrder)
        {
            ArrayList m_arrSelectOrders=new ArrayList();
            string temp="";
            for (int i = 0; i < this.m_objViewer.m_dtvOrder.SelectedRows.Count; i++)
            {
                clsBIHOrder order = (clsBIHOrder)this.m_objViewer.m_dtvOrder.SelectedRows[i].Tag;
                temp=order.m_strRegisterID+","+order.m_intRecipenNo+";";
                if (!m_arrSelectOrders.Contains(temp))
                {
                    m_arrSelectOrders.Add(temp);
                }
            }
        
            for (int i = 0; i < this.m_objViewer.m_dtvOrder.RowCount; i++)
            {
                clsBIHOrder order = (clsBIHOrder)this.m_objViewer.m_dtvOrder.Rows[i].Tag;
                temp = order.m_strRegisterID + "," + order.m_intRecipenNo + ";";
                if (m_arrSelectOrders.Contains(temp))
                {
                    m_arrOrder.Add(order);
                }
            }
        }

        internal void OrderDelete()
        {
            ArrayList m_arrOrder = new ArrayList();
            ArrayList m_arrOrderIdCan = new ArrayList();
            GetTheSelectOrders(ref m_arrOrder);
            if (m_arrOrder.Count <= 0)
            {
                MessageBox.Show("请先选择医嘱!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                #region 刷新当前医嘱数据，然后再判断

                ArrayList m_arrORDERID_CHR = new ArrayList();
                string m_strOrderID = "";
                for (int i = 0; i < m_arrOrder.Count; i++)
                {
                    m_strOrderID = ((clsBIHOrder)m_arrOrder[i]).m_strOrderID;
                    if (!m_arrORDERID_CHR.Contains(m_strOrderID))
                    {
                        m_arrORDERID_CHR.Add(m_strOrderID);
                    }
                }

                clsBIHOrder[] arrOrder = null;
                //com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService m_objService = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
                clsBIHOrderService m_objService = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                m_objService.m_lngGetArrOrderByOrderID(m_arrORDERID_CHR, out arrOrder);
                if (arrOrder != null && arrOrder.Length > 0)
                {
                    for (int i = 0; i < arrOrder.Length; i++)
                    {
                        clsBIHOrder order = arrOrder[i];
                        DataGridViewRow row = GetTheGridRowByOrder(order.m_strOrderID);
                        this.m_objGetDataViewRow(order, row, row.Index + 1);
                    }

                }
                this.m_mthRefreshSameReqNoColor();
                m_arrOrder.Clear();
                GetTheSelectOrders(ref m_arrOrder);
                #endregion

                string m_strMessage = "",m_strMessage2 = "", m_strMessage3 = "";
                for (int i = 0; i < m_arrOrder.Count; i++)
                {
                    clsBIHOrder BihOrder = (clsBIHOrder)m_arrOrder[i];
                    if (BihOrder.m_strCreatorID == this.m_objViewer.LoginInfo.m_strEmpID || BihOrder.m_strDOCTORID_CHR == this.m_objViewer.LoginInfo.m_strEmpID)
                    {

                    }
                    else
                    {
                        m_strMessage2 += "\r\n" + "  { " + BihOrder.m_strName + " }";

                    }
                    if (BihOrder.m_intStatus == 0 || BihOrder.m_intStatus == 1 || BihOrder.m_intStatus == 7)
                    {

                    }
                    else if (BihOrder.m_intTYPE_INT == 3 || BihOrder.m_intTYPE_INT == 4)
                    {
                    }
                    else
                    {
                        m_strMessage3 += "\r\n" + "  { " + BihOrder.m_strName + " }";

                    }
                    if (!m_arrOrderIdCan.Contains(BihOrder.m_strOrderID))
                    {
                        m_arrOrderIdCan.Add(BihOrder.m_strOrderID);
                    }

                }
                if (!m_strMessage2.Trim().Equals(""))
                {
                    m_strMessage2 = "\r\n" + " 没有足够权限删除以下医嘱" + m_strMessage2;
                }
                if (!m_strMessage3.Trim().Equals(""))
                {
                    m_strMessage3 = "\r\n" + " 不能删除当前状态的医嘱" + m_strMessage3;
                }
                m_strMessage = m_strMessage2 + m_strMessage3;
                if (!m_strMessage.Trim().Equals(""))
                {
                    MessageBox.Show(m_strMessage, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //删除医嘱
                if (m_arrOrderIdCan.Count <= 0)
                {
                    return;
                }
                else
                {
                    if (MessageBox.Show("确认进行删除操作吗?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.m_objViewer.Cursor = Cursors.WaitCursor;
                        ArrayList m_arrContinue = new ArrayList();//连续性医嘱要删除费用
                        for (int i = 0; i < m_arrOrder.Count; i++)
                        {
                            clsBIHOrder order = (clsBIHOrder)m_arrOrder[i];
                            if (this.m_objViewer.m_objSpecateVo.m_strCONFREQID_CHR.Trim().Equals(order.m_strExecFreqID.Trim()))
                            {
                                m_arrContinue.Add(order.m_strOrderID);
                            }
                        }
                        string[] m_strOrderID2 = null;
                        if (m_arrContinue.Count > 0)
                        {
                            m_strOrderID2 = (string[])m_arrContinue.ToArray(typeof(string));
                        }
                        string[] m_strOrderIDs = (string[])(m_arrOrderIdCan.ToArray(typeof(string)));
                        long m_lngRef = m_objInputOrder.m_lngDeleteOrder(m_strOrderIDs, m_strOrderID2);
                        this.m_objViewer.Cursor = Cursors.Default;
                        MessageBox.Show("操作成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTheOrders(this.m_objViewer.m_strRegisterID);
                    }
                }
            }

        }

        /// <summary>
        /// 根据当前医嘱号获得所在的行
        /// </summary>
        /// <param name="m_strOrderID"></param>
        /// <returns></returns>
        public DataGridViewRow GetTheGridRowByOrder(string m_strOrderID)
        {
            DataGridViewRow row = null;
            for (int i = 0; i < this.m_objViewer.m_dtvOrder.RowCount; i++)
            {
                if (((clsBIHOrder)this.m_objViewer.m_dtvOrder.Rows[i].Tag).m_strOrderID.Equals(m_strOrderID))
                {
                    row = this.m_objViewer.m_dtvOrder.Rows[i];
                }
            }
            return row;
        }
    }
}
