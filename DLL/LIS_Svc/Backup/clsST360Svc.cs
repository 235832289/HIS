using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.HRPService;

namespace com.digitalwave.iCare.middletier.LIS
{

    #region clsST360Svc
    /// <summary>
    /// 酶标360 Svc类
    /// </summary>
    [System.EnterpriseServices.Transaction(TransactionOption.Required)]
    [System.EnterpriseServices.ObjectPooling(Enabled = true)]
    public class clsST360Svc:com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        /// <summary>
        /// 查询仪器酶标(360)做的最新检验结果
        /// </summary>
        /// <returns></returns>
        public long m_lngFindSTGroupResult(out List<clsDeviceReslutVO> lstResult)
        {
            long lngRes = 0;
            lstResult = new List<clsDeviceReslutVO>();
            string sql = @"
                                SELECT IDX_INT,RESULT_VCHR,DEVICE_CHECK_ITEM_NAME_VCHR,DEVICE_SAMPLEID_CHR,DEVICEID_CHR,CHECK_DAT,PSTATUS_INT
                                  FROM t_opr_lis_result
                                 WHERE device_check_item_name_vchr = 'ST360' AND check_dat > SYSDATE - 5
                                 order by check_dat DESC
                            ";
//            string sql = @"
//                                SELECT SAMPLE_ID_CHR,RESULT_VCHR,DEVICE_CHECK_ITEM_NAME_VCHR,MODIFY_DAT,CHECK_DAT,STATUS_INT
//                                  FROM t_opr_lis_check_result
//                                 WHERE STATUS_INT=1 and  modify_dat >sysdate-1 and DEVICE_CHECK_ITEM_NAME_VCHR='ST360'
//                                ORDER BY MODIFY_DAT
//                          ";
            DataTable dtbResult = null;
            clsHRPTableService hrpService = new clsHRPTableService();
            try
            {
                lngRes = hrpService.lngGetDataTableWithoutParameters(sql, ref dtbResult);
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    DateTime dtFirst=DateTime.MinValue;
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        clsDeviceReslutVO checkResult = new clsDeviceReslutVO();
                        ConstructVO(dtbResult.Rows[i], ref checkResult);
                        if (i == 0)
                        {
                            dtFirst = DateTime.Parse(checkResult.m_strCheckDat);
                        }
                        DateTime temp = DateTime.Parse(checkResult.m_strCheckDat);

                        // 是不是同一个结果的
                        bool isSampleBatch = dtFirst.Year == temp.Year && dtFirst.Month == temp.Month && dtFirst.Day == temp.Day && dtFirst.Hour == temp.Hour && Math.Abs(dtFirst.Minute - temp.Minute) < 2;
                        if (isSampleBatch)
                        {
                            lstResult.Add(checkResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new com.digitalwave.Utility.clsLogText().LogError(ex.Message);
            }

            return lngRes;
        }

        //public long m_lngUpdateDeviceResult(clsDeviceReslutVO[] arrDeviceResult) 
        //{
            
        //}

        public long m_lngUpdateDeviceResult(clsDeviceReslutVO deviceResult) 
        {
            long lngRes = 0;
            string sql = @"
                            update  t_opr_lis_result set RESULT_VCHR=?,DEVICE_CHECK_ITEM_NAME_VCHR=?,UNIT_VCHR=?,DEVICE_SAMPLEID_CHR=? where IDX_INT=?
                        ";
            System.Data.IDataParameter[] updateParameters = clsPublicSvc.m_objConstructIDataParameterArr
                (
                    deviceResult.m_strResult,
                    deviceResult.m_strDeviceCheckItemName,
                    deviceResult.m_strUnit,
                    deviceResult.m_strDeviceSampleID,
                    deviceResult.m_strIdx
                );

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                System.Data.IDataParameter[] objODPArr = updateParameters;
                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngRecEff, updateParameters);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
            
        }

        #region ConstructVO
        /// <summary>
        /// 从数据库中构造实体
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objRule"></param>
        [AutoComplete]
        private void ConstructVO(DataRow p_dtrSource, ref clsDeviceReslutVO p_objResult)
        {
            // IDX_INT,DEVICE_CHECK_ITEM_NAME_VCHR,DEVICE_SAMPLEID_CHR,DEVICEID_CHR,CHECK_DAT,PSTATUS_INT

            p_objResult.m_strIdx = p_dtrSource["IDX_INT"].ToString();
            p_objResult.m_strResult = p_dtrSource["RESULT_VCHR"].ToString().Trim();
            p_objResult.m_strDeviceCheckItemName = p_dtrSource["DEVICE_CHECK_ITEM_NAME_VCHR"].ToString().Trim();
            p_objResult.m_strDeviceSampleID = p_dtrSource["DEVICE_SAMPLEID_CHR"].ToString().Trim();
            p_objResult.m_strDeviceID = p_dtrSource["DEVICEID_CHR"].ToString().Trim();
            p_objResult.m_strCheckDat = p_dtrSource["CHECK_DAT"].ToString().Trim();
        }
        #endregion
    }
    #endregion

    #region clsST360CheckResultSvc

    /// <summary>
    /// 酶标仪历史记录 Svc类
    /// </summary>
    [System.EnterpriseServices.Transaction(TransactionOption.Supported)]
    [System.EnterpriseServices.ObjectPooling(Enabled=true)]
    public class clsST360CheckResultSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        #region 公开方法

        public long m_lngInsert(clsST360CheckResultVO m_objResult)
        {
            long lngRes = 0;

            string sql = @"
                            INSERT INTO t_opr_lis_st360_result
                                        (sampleid_int, sampletype_int, boardno_vchr, templateno_int,
                                         check_item_id_int, check_item_name_vchr,
                                         check_item_english_name_vchr, modify_dat, operator_dat,
                                         device_send_dat, resultnum_vchr, resulttext_vchr, status_int,
                                         deviceid_chr, operator_id_chr, summary_vchr,Positive_INT
                                        )
                                 VALUES (?, ?, ?, ?,
                                         ?, ?,
                                         ?, ?, ?,
                                         ?, ?, ?, ?,
                                         ?, ?, ?,?
                                        )
                          ";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService hrpService = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            try
            {


                System.Data.IDataParameter[] objODPArr = GetInsertDataParameterArr(m_objResult);

                long lngRecEff = -1;
                //往表增加记录

                lngRes = 0;
                lngRes = hrpService.lngExecuteParameterSQL(sql, ref lngRecEff, objODPArr);
                hrpService.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 查找历史记录中所有的微板编号
        /// </summary>
        /// <param name="arrBoardName"></param>
        /// <returns></returns>
        public long m_lngFindBoardName(out string[] arrBoardName,DateTime begin,DateTime end)
        {
            long lngRes = 0;
            arrBoardName = null;
            string sql = @"
                              select distinct BoardNO_VCHR from t_opr_lis_st360_result  where Modify_DAT between ? and ?
                          ";

            DataTable dtbResult = null;
            clsHRPTableService hrpService = new clsHRPTableService();
            try
            {

                IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(begin, end);

                lngRes = hrpService.lngGetDataTableWithParameters(sql, ref dtbResult,objODPArr);
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    arrBoardName=new string[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        arrBoardName[i] = dtbResult.Rows[i]["BoardNO_VCHR"].ToString();
                    }
                }
                else
                {
                    arrBoardName = new string[0];
                }
            }
            catch (Exception ex)
            {

                new com.digitalwave.Utility.clsLogText().LogError(ex.Message);
            }

            return lngRes;
        }

        /// <summary>
        /// 查找历史记录中所有的微板编号
        /// </summary>
        /// <param name="arrBoardName"></param>
        /// <returns></returns>
        public long m_lngFindBoardName(out string[] arrBoardName)
        {
            long lngRes = 0;
            arrBoardName = null;
            string sql = @"
                                select distinct BoardNO_VCHR from t_opr_lis_st360_result
                          ";

            DataTable dtbResult = null;
            clsHRPTableService hrpService = new clsHRPTableService();
            try
            {
                lngRes = hrpService.lngGetDataTableWithoutParameters(sql, ref dtbResult);
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    arrBoardName = new string[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        arrBoardName[i] = dtbResult.Rows[i]["BoardNO_VCHR"].ToString();
                    }
                }
                else
                {
                    arrBoardName = new string[0];
                }
            }
            catch (Exception ex)
            {

                new com.digitalwave.Utility.clsLogText().LogError(ex.Message);
            }

            return lngRes;
        }

        /// <summary>
        /// 根据微孔板编号查询
        /// </summary>
        /// <param name="boardNo"></param>
        /// <param name="arrCheckResult"></param>
        /// <returns></returns>
        public long m_lngFind(string boardNo, out clsST360CheckResultVO[] arrCheckResult)
        {
            long lngRes = 0;
            arrCheckResult = null;

            string sql = @"
                              select * from t_opr_lis_st360_result where boardno_vchr=?
                          ";
            DataTable dtbResult = null;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService hrpService = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr(boardNo);

            try
            {
                lngRes = hrpService.lngGetDataTableWithParameters(sql, ref dtbResult, objODPArr);
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    arrCheckResult = new clsST360CheckResultVO[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        clsST360CheckResultVO checkResult = new clsST360CheckResultVO();
                        ConstructVO(dtbResult.Rows[i], ref checkResult);
                        arrCheckResult[i] = checkResult;
                    }
                }
                else
                {
                    arrCheckResult = new clsST360CheckResultVO[0];
                }
            }
            catch (Exception ex)
            {

                new com.digitalwave.Utility.clsLogText().LogError(ex.Message);
            }

            return lngRes;
        } 

        #endregion

        #region 辅助方法
         
        private System.Data.IDataParameter[] GetInsertDataParameterArr(clsST360CheckResultVO m_objResult)
        {
            System.Data.IDataParameter[] objODPArr = clsPublicSvc.m_objConstructIDataParameterArr
                (
                    m_objResult.m_intSampleId,
                    GetSampleType(m_objResult.m_enmSampelType),
                    m_objResult.m_strBoardNo,
                    m_objResult.m_intTemplateNo,
                    m_objResult.m_intItemId,
                    m_objResult.m_strItemName,
                    m_objResult.m_strItemEnglishName,
                    m_objResult.m_dtModify,
                    m_objResult.m_dtOperator,
                    m_objResult.m_dtDeviceSend,
                    m_objResult.m_strResultNum,
                    m_objResult.m_strResultText,
                    m_objResult.m_blnStatus ? 1 : 0,
                    m_objResult.m_strDeviceId,
                    m_objResult.m_strOperatorId,
                    m_objResult.m_strSummary,
                    m_objResult.m_IsPositive?1:0
                );
            return objODPArr;
        }

        #region ConstructVO
        /// <summary>
        /// 从数据库中构造实体
        /// </summary>
        /// <param name="p_dtrSource"></param>
        /// <param name="p_objRule"></param>
        [AutoComplete]
        private void ConstructVO(DataRow p_dtrSource, ref clsST360CheckResultVO p_objResult)
        {
            //DEVICEID_CHR                  
            //SampleId_int                  
            //SampleType_int                
            //BoardNo_VCHR                  
            //TemplateNo_int                
            //CHECK_ITEM_ID_INT             
            //CHECK_ITEM_NAME_VCHR          
            //CHECK_ITEM_ENGLISH_NAME_VCHR  
            //MODIFY_DAT                    
            //DEVICE_SEND_DAT               
            //OPERATOR_DAT                  
            //ResultNum_VCHR                
            //ResultText_VCHR               
            //OPERATOR_ID_CHR               
            //Status_int                    
            //Summary_VCHR                  

            p_objResult.m_strDeviceId = p_dtrSource["DEVICEID_CHR"].ToString().Trim();
            p_objResult.m_intSampleId = DBAssist.ToInt32(p_dtrSource["SampleId_int"]);
            p_objResult.m_enmSampelType = GetSampleType(DBAssist.ToInt32(p_dtrSource["SampleType_int"]));
            p_objResult.m_strBoardNo = p_dtrSource["BoardNo_VCHR"].ToString().Trim();
            p_objResult.m_intTemplateNo = DBAssist.ToInt32(p_dtrSource["TemplateNo_int"]);
            p_objResult.m_strItemName = p_dtrSource["CHECK_ITEM_NAME_VCHR"].ToString().Trim();
            p_objResult.m_strItemEnglishName = p_dtrSource["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim();
            p_objResult.m_dtModify = DBAssist.ToDateTime(p_dtrSource["MODIFY_DAT"]);
            p_objResult.m_dtDeviceSend = DBAssist.ToDateTime(p_dtrSource["DEVICE_SEND_DAT"]);
            p_objResult.m_dtOperator = DBAssist.ToDateTime(p_dtrSource["OPERATOR_DAT"]);
            p_objResult.m_strResultNum = p_dtrSource["ResultNum_VCHR"].ToString().Trim();
            p_objResult.m_strResultText = p_dtrSource["ResultText_VCHR"].ToString().Trim();
            p_objResult.m_strOperatorId = p_dtrSource["OPERATOR_ID_CHR"].ToString().Trim();
            p_objResult.m_blnStatus = DBAssist.ToInt32(p_dtrSource["Status_int"]) == 1 ? true : false;
            p_objResult.m_strSummary = p_dtrSource["Summary_VCHR"].ToString().Trim();
            p_objResult.m_IsPositive = DBAssist.ToInt32(p_dtrSource["Positive_INT"].ToString())==1 ? true : false;
            
        }

        #endregion

        private enmSTSampleStyle GetSampleType(int typeId)
        {
            enmSTSampleStyle result = enmSTSampleStyle.NONE;
            switch (typeId)
            {
                case 0: result = enmSTSampleStyle.NONE; break;
                case 1: result = enmSTSampleStyle.Common; break;
                case 2: result = enmSTSampleStyle.Blank; break;
                case 3: result = enmSTSampleStyle.Negative; break;
                case 4: result = enmSTSampleStyle.Positive; break;
                case 5: result = enmSTSampleStyle.Standard; break;
                case 6: result = enmSTSampleStyle.Quality; break;
                default:
                    break;
            }
            return result;
        }

        private int GetSampleType(enmSTSampleStyle type)
        {
            int result = 0;
            switch (type)
            {
                case enmSTSampleStyle.Blank:
                    result = 2;
                    break;
                case enmSTSampleStyle.Common:
                    result = 1;
                    break;
                case enmSTSampleStyle.NONE:
                    result = 0;
                    break;
                case enmSTSampleStyle.Negative:
                    result = 3;
                    break;
                case enmSTSampleStyle.Positive:
                    result = 4;
                    break;
                case enmSTSampleStyle.Quality:
                    result = 6;
                    break;
                case enmSTSampleStyle.Standard:
                    result = 5;
                    break;
                default:
                    break;
            }
            return result;
        }

        #endregion
    }

    #endregion
}