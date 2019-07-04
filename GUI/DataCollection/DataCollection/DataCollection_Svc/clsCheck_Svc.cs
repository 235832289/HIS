using System;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.DataCollection;
using System.Data.OracleClient;
using System.IO;
using System.Text;

namespace com.digitalwave.iCare.middletier.DataCollection
{
    /// <summary>
    /// 检查数据采集读取中间件
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsCheckQuery_Svc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        /// <summary>
        /// 获取PACS数据
        /// </summary>
        /// <param name="p_dtmStartDate"></param>
        /// <param name="p_dtmEndDate"></param>
        /// <param name="p_lstRecord"></param>
        /// <param name="p_lstPic"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPACSRecordInfo(DateTime p_dtmStartDate, DateTime p_dtmEndDate, out List<clsCheckRecord> p_lstRecord)
        {
            p_lstRecord = new List<clsCheckRecord>();
            string strSql = @"select t1.order_no_vchr,
       t2.examinedate,
       t1.modify_dat,
       t1.doctor_id_chr,
       t1.doctor_name_vchr,
       t2.reportdoctorid,
       t2.reportdoctorname,
       t4.machine_name_vhar,
       case
         when t3.category_id_chr = '0000' then
          '5'
         when t3.category_id_chr = '0001' then
          '3'
         when t3.category_id_chr = '0002' then
          '3'
       end as category_id_chr,
       t1.part_vchr,
       t2.examineprompt,
       case
         when t2.positive_int = 0 then
          '1'
         when t2.positive_int = 1 then
          '2'
         else
          '0'
       end as checkrecordresult,
       t1.dept_id_chr,
       t1.dept_name_vchr,
       t7.paytypeid_chr,
       t8.sysfrom_int,
       t8.sourceitemid_vchr,
       t9.registerid_chr,
       decode(t1.pstatus_int,0,'1','0') pstatus
  from t_opr_pacs_booking_order t1,
       imagereport t2,
       t_bse_pacs_check_category t3,
       t_bse_pacs_machine t4,
       t_bse_patient t7,
       (select a.applyid, b.sysfrom_int, max(b.sourceitemid_vchr) sourceitemid_vchr
          from ar_common_apply a, t_opr_attachrelation b
         where a.applyid = b.attachid_vchr
           and a.applydate between
               ? and
               ?           
         group by a.applyid, b.sysfrom_int) t8,
       (select registerid_chr, a1.inpatientid_chr,a1.patientid_chr
          from t_opr_bih_register a1,
               (select inpatientid_chr,
                       max(inpatientcount_int) as incount
                  from t_opr_bih_register
                 group by inpatientid_chr) b1
         where a1.inpatientcount_int = b1.incount
           and a1.inpatientid_chr = b1.inpatientid_chr)  t9
 where t1.reportid = t2.reportid
   and t1.machine_id = t4.machine_id_chr
   and t4.category_id_chr = t3.category_id_chr
   and t1.patient_id_chr = t7.patientid_chr
   and t1.app_order_id_chr = t8.applyid(+)
   and t1.pstatus_int <> -1
   and t2.status = 2
   and t1.inpatient_no_chr = t9.inpatientid_chr(+)
   and t2.examinedate between ? and
       ?";
            long lngRes = 1;
            clsHRPTableService objHRPSvc = null;
            try
            {
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();               
                objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_dtmStartDate;
                objDPArr[1].Value = p_dtmEndDate;
                objDPArr[2].Value = p_dtmStartDate;
                objDPArr[3].Value = p_dtmEndDate;
                DataTable dtResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, objDPArr);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    clsCheckRecord record = null;
                    int intSource = 0;
                    foreach (DataRow row in dtResult.Rows)
                    {
                        record = new clsCheckRecord();


                        record.m_strCheckRecordID = row[0].ToString().Trim() + Convert.ToDateTime(row[2]).ToString("yyyyMMddHHmmss");
                        record.m_dtmCheckRecordAppDate = Convert.ToDateTime(row[1]);
                        record.m_dtmCheckRecordDate = Convert.ToDateTime(row[2]);
                        record.m_strClinicianCode = row[3].ToString().Trim();
                        record.m_strClinicianName = row[4].ToString().Trim();
                        record.m_strClinicianAppCode = row[5].ToString().Trim();
                        record.m_strClinicianAppName = row[6].ToString().Trim();
                        record.m_strCheckReocrdApparatus = row[7].ToString().Trim();
                        record.m_strCheckRecordType = row[8].ToString().Trim();
                        record.m_strCheckRecordSubName = "放射科检查";
                        record.m_strCheckSite = row[9].ToString();
                        record.m_strCheckRecordContent = row[10].ToString();
                        record.m_strCheckRecordResult = row[11].ToString();
                        record.m_strCheckRecordDeptCode = row[12].ToString();
                        record.m_strCheckRecordDeptName = row[13].ToString();
                        //record.m_strCheckRecordAppDeptCode = row[16].ToString();
                        //record.m_strCheckRecordAppDeptName = row[17].ToString();
                        if (!Convert.IsDBNull(row[14]))
                        {
                            record.m_strKind = clsDataUpload_Svc.m_strConvertValue("kind", row[14].ToString(), "");
                        }
                        if (!Convert.IsDBNull(row[15]))
                        {
                            try
                            {
                                intSource = Convert.ToInt32(row[15]);
                            }
                            catch
                            {
                            }
                        }
                        if (intSource == 1 && !Convert.IsDBNull(row[16]))
                        {
                            record.m_strVisitNo = row[16].ToString().Trim();
                        }
                        else if (intSource == 2 && !Convert.IsDBNull(row[17]))
                        {
                            record.m_strInHossSeqNo = row[17].ToString().Trim();
                        }
                        record.m_strInvalid = row[18].ToString().Trim();
                        p_lstRecord.Add(record);
                    }
                }

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
            }
            return lngRes;
        }

        /// <summary>
        /// 获取影像图片
        /// </summary>
        /// <param name="p_dtmStartDate"></param>
        /// <param name="p_dtmEndDate"></param>
        /// <param name="p_lstPic"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPACSPicInfo(DateTime p_dtmStartDate, DateTime p_dtmEndDate, out List<clsCheckPic> p_lstPic)
        {            
            p_lstPic = new List<clsCheckPic>();
//            string strSql = @"select t4.order_id_chr, t1.seriesuid, t1.imagenumber, t1.smallimage,
//                    t4.part_id_chr,t4.machine_id,t4.check_date_dat,t4.modify_dat
//  from dicom.images t1,
//       dicom.series t2,
//       dicom.studies t3,
//       t_opr_pacs_booking_order t4,
//       imagereport t5
// where t1.seriesuid = t2.seriesuid(+)
//   and t2.studyuid = t3.studyuid(+)
//   and t3.patientid = t4.order_no_vchr(+)
//   and t4.reportid = t5.reportid
//   and t5.status = 2
//   and t5.aduitdate between ? and ?";

            string strSql = @"select '' order_id_chr, t1.seriesuid, t1.imagenumber, t1.smallimage,
                    '' part_id_chr,'' machine_id,'' check_date_dat,'' modify_dat ,t3.patientid
  from images t1,
       series t2,
       studies t3
 where t1.seriesuid = t2.seriesuid(+)
   and t2.studyuid = t3.studyuid(+)   --查询pacs
   and t3.patientid in ";

            string strSql1 = @"select t4.order_id_chr,t4.part_id_chr,t4.machine_id,t4.check_date_dat,t4.modify_dat,t4.order_no_vchr
  from t_opr_pacs_booking_order t4,
       imagereport t5
 where t4.reportid = t5.reportid(+)
   and t5.status = 2
   and t5.aduitdate between ? and ? --查询icare";
            long lngRes = 1;
            clsHRPTableService objHRPSvc = null;
            clsHRPTableService objHRPSvcPacs = null;
            objHRPSvcPacs = new clsHRPTableService();
            try
            {
                //查询icare
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_dtmStartDate;
                objDPArr[1].Value = p_dtmEndDate;
                DataTable dtResultIcare = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql1, ref dtResultIcare, objDPArr);

                StringBuilder sb = new StringBuilder();
                if (dtResultIcare.Rows.Count > 0)
                {
                    sb.Append("(");
                    foreach (DataRow dricare in dtResultIcare.Rows)
                    {
                        sb.Append("'" + dricare["order_no_vchr"].ToString() + "',");
                    }
                    sb.Append("'ABC')");
                }
                else
                    return -1;

                strSql += sb.ToString();
                //查询pacs
                //objHRPSvcPacs = new clsHRPTableService();
                objHRPSvcPacs.m_bytSetOtherDSN = (byte)com.digitalwave.iCare.middletier.HRPService.clsHRPTableService.enumDatabase.bytPACS;
                DataTable dtResultPacs = null;
                lngRes = objHRPSvcPacs.lngGetDataTableWithoutParameters(strSql, ref dtResultPacs);

                if (dtResultPacs.Rows.Count > 0)
                {
                    foreach (DataRow dricare in dtResultIcare.Rows)
                    {
                        DataRow[] drArr = dtResultPacs.Select("patientid = '" + dricare["order_no_vchr"].ToString() + "'");
                        int i= 0;
                        foreach (DataRow drpacs in drArr)
                        {
                            drArr[i]["order_id_chr"] = dricare["order_id_chr"].ToString();
                            drArr[i]["part_id_chr"] = dricare["part_id_chr"].ToString();
                            drArr[i]["machine_id"] = dricare["machine_id"].ToString();
                            drArr[i]["check_date_dat"] = dricare["check_date_dat"].ToString();
                            drArr[i]["modify_dat"] = dricare["modify_dat"].ToString();
                            i++;
                        }
                    }

                }
                else
                    return -1;


                if (dtResultPacs != null && dtResultPacs.Rows.Count > 0)
                {


                    clsCheckPic pic = null;
                    System.Drawing.Image objImg = null;
                    System.IO.MemoryStream objStream = null;
                    byte[] bytImage = null;
                    System.IO.MemoryStream objStream2 = null;
                    foreach (DataRow row in dtResultPacs.Rows)
                    {                        
                        pic = new clsCheckPic();
                        pic.m_strCheckRecordID = row[0].ToString() + Convert.ToDateTime(row[7]).ToString("yyyyMMddHHmmss");
                        pic.m_strPicID = row[2].ToString();
                        pic.m_intPicType = 3;

                        pic.m_strCheckSite = row[4].ToString();
                        pic.m_strCheckRecordAppAratus = row[5].ToString();
                        DateTime dtTime;
                        if (DateTime.TryParse(row[6].ToString(), out dtTime))
                            pic.m_strSystemTime = dtTime;

                        objStream = new MemoryStream((byte[])row[3]);
                        objStream2 = new MemoryStream();
                        objImg = new System.Drawing.Bitmap(objStream);
                        objImg = new System.Drawing.Bitmap(objImg, objImg.Width*2, objImg.Height*2);
                        objImg.Save(objStream2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        bytImage = objStream2.ToArray();
                        pic.m_bytPic = bytImage;
                        p_lstPic.Add(pic);
                    }
                }

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvcPacs.Dispose();
            }
            return lngRes;
        }

        private System.Drawing.Image m_mthConvertByte2Image(byte[] p_bytImage)
        {
            System.Drawing.Image objImg = null;

            if (p_bytImage != null)
            {
                System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])p_bytImage);
                objImg = new System.Drawing.Bitmap(objStream);
            }
            return objImg;
        }

        /// <summary>
        /// 根据报告ID获取报告所包含的图像
        /// </summary>
        /// <param name="p_strReportID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetImageList(string p_strOtherID, out List<string> p_lstImage)
        {
            string strSql = @"select filename_vchr
  from t_ris_image t1, t_ris_us_report t2
 where t1.reportid_vchr = t2.reportid_chr
   and t1.modality_vchr = 'US'
   and t2.otherid_chr = ?
   and t2.status_int = 1";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            p_lstImage = null;
            long lngRes = 0;
            try
            {
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strOtherID;
                DataTable dtValue = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtValue, objDPArr);
                if (lngRes > 0)
                {
                    p_lstImage = new List<string>(dtValue.Rows.Count);
                    foreach (DataRow row in dtValue.Rows)
                    {
                        if (row[0] != DBNull.Value)
                        {
                            p_lstImage.Add(row[0].ToString());
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
            }
            return lngRes;
        }


        /// <summary>
        /// 获取B超图片
        /// </summary>
        /// <param name="p_dtmStartDate"></param>
        /// <param name="p_dtmEndDate"></param>
        /// <param name="p_lstPic"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBultraSoundPicInfo(DateTime p_dtmStartDate, DateTime p_dtmEndDate, out List<clsCheckPic> p_lstPic)
        {
            p_lstPic = new List<clsCheckPic>();
            string strSql = @"select d.ctl_content, a.imageid, 3, a.imagecontent
  from ar_image a,
       (select b1.recordid
          from ar_apply_report b1
         where b1.opendate between
               ? and ?
           and b1.delstatus = 0
           and b1.sendstatus = 1) b,
       (select c.recordid, c.ctl_content
          from ar_content c
         where c.controlid = 'm_txtBultraSoundID') d
 where b.recordid = a.recordid
   and b.recordid = d.recordid";
            long lngRes = 1;
            clsHRPTableService objHRPSvc = null;
            try
            {
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.m_bytSetOtherDSN = (byte)com.digitalwave.iCare.middletier.HRPService.clsHRPTableService.enumDatabase.bytPACS;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_dtmStartDate;
                objDPArr[1].Value = p_dtmEndDate;
                DataTable dtResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, objDPArr);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    clsCheckPic pic = null;
                    System.Drawing.Image objImg = null;
                    System.IO.MemoryStream objStream = null;
                    byte[] bytImage = null;
                    System.IO.MemoryStream objStream2 = null;
                    foreach (DataRow row in dtResult.Rows)
                    {
                        pic = new clsCheckPic();
                        pic.m_strCheckRecordID = row[0].ToString();
                        pic.m_strPicID = row[1].ToString();
                        pic.m_intPicType = 3;
                        objStream = new MemoryStream((byte[])row[3]);
                        objStream2 = new MemoryStream();
                        objImg = new System.Drawing.Bitmap(objStream);
                        objImg.Save(objStream2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        bytImage = objStream2.ToArray();
                        pic.m_bytPic = bytImage;
                        p_lstPic.Add(pic);
                        objImg = null;
                    }
                }

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
            }
            return lngRes;
        }


        /// <summary>
        /// 获取心电图数据
        /// </summary>
        /// <param name="p_dtmStartDate"></param>
        /// <param name="p_dtmEndDate"></param>
        /// <param name="p_lstRecord"></param>
        /// <param name="p_lstPic"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRISRecordInfo(DateTime p_dtmStartDate, DateTime p_dtmEndDate, out List<clsCheckRecord> p_lstRecord)
        {
            p_lstRecord = new List<clsCheckRecord>();
            string strSql = @"select t.patient_no_chr,
       t.inpatient_no_chr,
       t.report_id_chr,
       t.report_dat,
       a.applydate,
       a.doctorid_chr,
       a.doctorname,
       t.reportor_id_chr,
       t.reportor_name_vchr,
       a.diagnosepart,
       t.summary2_vchr,
       a.deptid_chr,
       a.department,
       t1.paytypeid_chr,
       t2.sysfrom_int,
       t2.sourceitemid_vchr,
       t3.registerid_chr
  from t_opr_ris_cardiogram_report t,
       ar_common_apply a,
       t_bse_patient t1,
       (select a.applyid, b.sysfrom_int, max(b.sourceitemid_vchr) sourceitemid_vchr
          from ar_common_apply a, t_opr_attachrelation b
         where a.applyid = b.attachid_vchr
           and a.applydate between
               ? and
               ?
         group by a.applyid, b.sysfrom_int) t2, 
       (select registerid_chr, a1.inpatientid_chr
          from t_opr_bih_register a1,
               (select inpatientid_chr,
                       max(inpatientcount_int) as incount
                  from t_opr_bih_register 
                 group by inpatientid_chr) b1
         where a1.inpatientcount_int = b1.incount
           and a1.inpatientid_chr = b1.inpatientid_chr) t3
 where t.applyid_int = a.applyid(+)
   and t.patient_id_chr = t1.patientid_chr
   and t.applyid_int = t2.applyid(+)
   and t.inpatient_no_chr = t3.inpatientid_chr(+)
   and t.status_int = 1
   and t.report_dat between
       ? and
       ?";
            long lngRes = 1;
            clsHRPTableService objHRPSvc = null;
            try
            {
                IDataParameter[] objDPArr = null;
                DataTable dtResult = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_dtmStartDate;
                objDPArr[1].Value = p_dtmEndDate;
                objDPArr[2].Value = p_dtmStartDate;
                objDPArr[3].Value = p_dtmEndDate;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, objDPArr);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    clsCheckRecord record = null;
                    int intSource = 0;
                    foreach (DataRow row in dtResult.Rows)
                    {
                        
                        record = new clsCheckRecord();
                        //record.m_strVisitNo = row[0].ToString().Trim();
                        //record.m_strInHossSeqNo = row[1].ToString().Trim();
                        record.m_strCheckRecordID = row[2].ToString().Trim();
                        if (!Convert.IsDBNull(row[3]))
                        {
                            record.m_dtmCheckRecordAppDate = Convert.ToDateTime(row[3]);
                        }                       
                        if (!Convert.IsDBNull(row[4]))
                        {
                            record.m_dtmCheckRecordDate = Convert.ToDateTime(row[4]);
                        }                        
                        record.m_strClinicianCode = row[5].ToString().Trim();
                        record.m_strClinicianName = row[6].ToString().Trim();
                        record.m_strClinicianAppCode = row[7].ToString().Trim();
                        record.m_strClinicianAppName = row[8].ToString().Trim();
                        record.m_strCheckReocrdApparatus = "";
                        record.m_strCheckRecordType = "2";
                        record.m_strCheckRecordSubName = "心电图检查";
                        record.m_strCheckSite = row[9].ToString();
                        record.m_strCheckRecordContent = row[10].ToString();
                        record.m_strCheckRecordResult = "0";
                        record.m_strCheckRecordDeptCode = row[11].ToString();
                        record.m_strCheckRecordDeptName = row[12].ToString();
                        record.m_strCheckRecordAppDeptCode = "0000253";
                        record.m_strCheckRecordAppDeptName = "心电图室";
                        record.m_strInvalid = "1";

                        if (!Convert.IsDBNull(row[13]))
                        {
                            clsDataUpload_Svc.m_strConvertValue("kind", row[13].ToString(), "");
                        }
                        if (!Convert.IsDBNull(row[14]))
                        {
                            try
                            {
                                intSource = Convert.ToInt32(row[14]);
                            }
                            catch
                            {
                            }
                        }

                        if (intSource == 1 && !Convert.IsDBNull(row[15]))
                        {
                            record.m_strVisitNo = row[15].ToString().Trim();
                        }
                        else if (intSource == 2 && !Convert.IsDBNull(row[16]))
                        {
                            record.m_strInHossSeqNo = row[16].ToString().Trim();
                        }

                        p_lstRecord.Add(record);
                    }
                }


                //strSql = @"";
                //objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                //objDPArr[0].Value = p_dtmStartDate;
                //objDPArr[1].Value = p_dtmEndDate;
                //lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, objDPArr);
                //if (dtResult != null && dtResult.Rows.Count > 0)
                //{
                //    clsCheckRecord record = null;
                //    foreach (DataRow row in dtResult.Rows)
                //    {
                //        record = new clsCheckRecord();
                //        record.m_strVisitNo = row[0].ToString().Trim();
                //        record.m_strInHossSeqNo = row[1].ToString().Trim();
                //        record.m_strCheckRecordID = row[2].ToString().Trim();
                //        record.m_dtmCheckRecordAppDate = Convert.ToDateTime(row[3]);
                //        record.m_dtmCheckRecordDate = Convert.ToDateTime(row[4]);
                //        record.m_strClinicianCode = row[5].ToString().Trim();
                //        record.m_strClinicianName = row[6].ToString().Trim();
                //        record.m_strClinicianAppCode = row[7].ToString().Trim();
                //        record.m_strClinicianAppName = row[8].ToString().Trim();
                //        record.m_strCheckReocrdApparatus = "";
                //        record.m_strCheckRecordType = "2";
                //        record.m_strCheckRecordSubName = "心电图检查";
                //        record.m_strCheckSite = row[9].ToString();
                //        record.m_strCheckRecordContent = row[10].ToString();
                //        record.m_strCheckRecordResult = "0";
                //        record.m_strCheckRecordDeptCode = row[11].ToString();
                //        record.m_strCheckRecordDeptName = row[12].ToString();
                //        record.m_strCheckRecordAppDeptCode = "0000253";
                //        record.m_strCheckRecordAppDeptName = "心电图室";
                //        p_lstRecord.Add(record);
                //    }
                //}

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
            }
            return lngRes;
        }

        /// <summary>
        /// 获取B超数据
        /// </summary>
        /// <param name="p_dtmStartDate"></param>
        /// <param name="p_dtmEndDate"></param>
        /// <param name="p_lstRecord"></param>
        /// <param name="p_lstPic"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBultraSoundRecordInfo(DateTime p_dtmStartDate, DateTime p_dtmEndDate, out List<clsCheckRecord> p_lstRecord)
        {
            p_lstRecord = new List<clsCheckRecord>();
            string strSql = @"select t.patientcardid_chr,
       t.inpatientid_chr,
       t.otherid_chr,
       t.checkdate_dat,
       t.reportdate_dat,
       t.reportdoctorid_chr,
       t.reportdoctor_chr,
       t.applydoctorid_chr,
       t.applydoctor_chr,
       '1',
       '超声检查',
       t.checkpart_chr,
       t.ultrasoundprompts_chr,
       case
         when t.positivenumber_int > 0 then
          '2'
         else
          '1'
       end,
       '0000252',
       '超声科',
       t.applydeptid_chr,
       t.applydepartment_chr,
       t2.sysfrom_int,
       t2.sourceitemid_vchr,
       t3.paytypeid_chr,
       t4.registerid_chr
  from t_ris_us_report t,
       (select a.applyid, b.sysfrom_int, max(b.sourceitemid_vchr) sourceitemid_vchr
          from ar_common_apply a, t_opr_attachrelation b
         where a.applyid = b.attachid_vchr
           and a.applydate between
               ? and
               ?
         group by a.applyid, b.sysfrom_int) t2,
       t_bse_patient t3,
       (select registerid_chr, a1.inpatientid_chr
          from t_opr_bih_register a1,
               (select inpatientid_chr,
                       max(inpatientcount_int) as incount
                  from t_opr_bih_register
                 group by inpatientid_chr) b1
         where a1.inpatientcount_int = b1.incount
           and a1.inpatientid_chr = b1.inpatientid_chr) t4
 where t.status_int = 1
   and t.applyid_chr = t2.applyid
   and t.patientid_chr = t3.patientid_chr
   and t.inpatientid_chr = t4.inpatientid_chr(+)
   and t.checkdate_dat between
       ? and
       ?";
            long lngRes = 1;
            clsHRPTableService objHRPSvc = null;
            try
            {
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();                
                objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_dtmStartDate;
                objDPArr[1].Value = p_dtmEndDate;
                objDPArr[2].Value = p_dtmStartDate;
                objDPArr[3].Value = p_dtmEndDate;
                DataTable dtResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, objDPArr);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    int intSource = 0;
                    clsCheckRecord record = null;
                    foreach (DataRow row in dtResult.Rows)
                    {
                        record = new clsCheckRecord();
                        record.m_strVisitNo = row[0].ToString().Trim();
                        record.m_strInHossSeqNo = row[1].ToString().Trim();
                        record.m_strCheckRecordID = row[2].ToString().Trim();
                        record.m_dtmCheckRecordAppDate = Convert.ToDateTime(row[3]);
                        record.m_dtmCheckRecordDate = Convert.ToDateTime(row[4]);
                        record.m_strClinicianCode = row[5].ToString().Trim();
                        record.m_strClinicianName = row[6].ToString().Trim();
                        record.m_strClinicianAppCode = row[7].ToString().Trim();
                        record.m_strClinicianAppName = row[8].ToString().Trim();
                        record.m_strCheckReocrdApparatus = "";
                        record.m_strCheckRecordType = row[9].ToString().Trim(); ;
                        record.m_strCheckRecordSubName = row[10].ToString().Trim();
                        record.m_strCheckSite = row[11].ToString();
                        record.m_strCheckRecordContent = row[12].ToString();
                        record.m_strCheckRecordResult = row[13].ToString().Trim(); ;
                        record.m_strCheckRecordDeptCode = row[14].ToString();
                        record.m_strCheckRecordDeptName = row[15].ToString();
                        record.m_strCheckRecordAppDeptCode = row[16].ToString();
                        record.m_strCheckRecordAppDeptName = row[17].ToString();
                        if (!Convert.IsDBNull(row[20]))
                        {
                            record.m_strKind = clsDataUpload_Svc.m_strConvertValue("kind", row[20].ToString(), "");
                        }
                        if (!Convert.IsDBNull(row[18]))
                        {
                            try
                            {
                                intSource = Convert.ToInt32(row[18]);
                            }
                            catch
                            {
                            }
                        }
                        if (intSource == 1 && !Convert.IsDBNull(row[19]))
                        {
                            record.m_strVisitNo = row[19].ToString().Trim();
                        }
                        else if (intSource == 2 && !Convert.IsDBNull(row[21]))
                        {
                            record.m_strInHossSeqNo = row[21].ToString().Trim();
                        }
                        record.m_strInvalid = "1";
                        p_lstRecord.Add(record);
                    }
                }

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
            }
            return lngRes;
        }














        /// <summary>
        /// 获取影像图片
        /// </summary>
        /// <param name="p_dtmStartDate"></param>
        /// <param name="p_dtmEndDate"></param>
        /// <param name="p_lstPic"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUploadCheckPic()
        {
           
            long lngRes = 0;

            string strSql = @"select * from t_ris_us_report";


            clsHRPTableService objHRPSvcPacs = null;
            try
            {

                //查询pacs
                objHRPSvcPacs = new clsHRPTableService();
                objHRPSvcPacs.m_bytSetOtherDSN = (byte)com.digitalwave.iCare.middletier.HRPService.clsHRPTableService.enumDatabase.bytPACS;
                DataTable dtResultPacs = null;
                lngRes = objHRPSvcPacs.lngGetDataTableWithoutParameters(strSql, ref dtResultPacs);


            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvcPacs.Dispose();
            }
            return lngRes;
        }
    }
}
