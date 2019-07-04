using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.DataCollection;
using com.digitalwave.iCare.common;
using System.Collections;
using iCare.RIS.FileService;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.DataCollection.DomainController
{
    /// <summary>
    /// 检查数据采集领域层
    /// </summary>
    internal class clsDcl_Check
    {
        /// <summary>
        /// 读取检查信息
        /// </summary>
        /// <param name="p_dtmStartDate">起始日期</param>
        /// <param name="p_dtmEndDate">截止日期</param>
        /// <param name="p_lstRecord"></param>
        /// <returns></returns>
        public long m_lngGetCheckInfo(DateTime p_dtmStartDate, DateTime p_dtmEndDate, out List<clsCheckRecord> p_lstRecord, out List<clsCheckPic> p_lstPic)
        {
            long lngRes = -1;
            p_lstRecord = new List<clsCheckRecord>();            
            p_lstPic = new List<clsCheckPic>();
            clsCheckQuery_Svc objSvc = (clsCheckQuery_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsCheckQuery_Svc));
            List<clsCheckRecord> lstRecord = null;
            List<clsCheckPic> lstPic = null;
            objSvc.m_lngGetPACSRecordInfo(p_dtmStartDate, p_dtmEndDate, out lstRecord);
            objSvc.m_lngGetPACSPicInfo(p_dtmStartDate, p_dtmEndDate, out lstPic);
            p_lstRecord.AddRange(lstRecord);
            p_lstPic.AddRange(lstPic);
            lstRecord = null;
            
            objSvc.m_lngGetRISRecordInfo(p_dtmStartDate, p_dtmEndDate, out lstRecord);
            p_lstRecord.AddRange(lstRecord);
            lstRecord = null;
            
            objSvc.m_lngGetBultraSoundRecordInfo(p_dtmStartDate, p_dtmEndDate, out lstRecord);
            clsImageFileManager objImageManager = new clsImageFileManager();
            string strReportID = string.Empty;
            
            List<string> lstImagePath = null;
            clsLogText log = new clsLogText();
            bool blnMissFile = false;
            foreach (clsCheckRecord objRecord in lstRecord)
            {
                try
                {
                    objSvc.m_lngGetImageList(objRecord.m_strCheckRecordID, out lstImagePath);

                    clsCheckPic pic = null;
                    System.Drawing.Image objImg = null;

                    byte[] bytImage = null;
                    System.IO.MemoryStream objStream2 = null;
                    int i = 1;
                    foreach (string strImagePath in lstImagePath)
                    {
                        objImageManager.m_lngGetImage(strImagePath, out objImg);
                        if (objImg == null)
                        {
                            log.LogError("归档文件丢失" + strImagePath);
                            blnMissFile = true;
                            continue;
                        }
                        pic = new clsCheckPic();
                        pic.m_strCheckRecordID = objRecord.m_strCheckRecordID;
                        pic.m_strPicID = i.ToString();
                        pic.m_intPicType = 3;
                        objStream2 = new MemoryStream();
                        objImg.Save(objStream2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        bytImage = objStream2.ToArray();
                        pic.m_bytPic = bytImage;
                        p_lstPic.Add(pic);
                        objImg = null;
                        i++;
                    }
                }
                catch (Exception ex)
                {                    
                    log.LogError(ex.Message + ex.StackTrace);
                }
            }

            if (blnMissFile)
            {
                //MessageBox.Show(@"发现有归档文件丢失，文件列表记录在D:\code\logerror.txt");
            }
            //objSvc.m_lngGetBultraSoundPicInfo(p_dtmStartDate, p_dtmEndDate, out lstPic);
            p_lstRecord.AddRange(lstRecord);

            //-----------------------------------
            //因为此处为多的合并，故在此处处理数据重复
            //by huafeng.xiao
            Hashtable objHsTable=new Hashtable();
            if (p_lstRecord != null && p_lstRecord.Count > 0)
            {
                lstRecord = new List<clsCheckRecord>();
                int intCount = p_lstRecord.Count;
                for (int intI = 0; intI < intCount; intI++)
                {
                    clsCheckRecord objRecord = p_lstRecord[intI];
                    try
                    {
                        objHsTable.Add(objRecord.m_strCheckRecordID + objRecord.m_strVisitNo + objRecord.m_strInHossSeqNo, "");
                        lstRecord.Add(objRecord);
                    }
                    catch { }
                }
                p_lstRecord.Clear();
                p_lstRecord.AddRange(lstRecord); ;
            }
            //-----------------------------------
            lstRecord = null;
            lstPic = null;
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 上传检查单信息
        /// </summary>
        /// <param name="p_lstRecord"></param>
        /// <returns></returns>
        public long m_lngUploadCheckInfo(List<clsCheckRecord> p_lstRecord)
        {
            long lngRes = -1;
            clsDataUpload_Svc objSvc = (clsDataUpload_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsDataUpload_Svc));
            objSvc.m_lngInsertCheckRecordInfo(p_lstRecord);
            return lngRes;
        }

        /// <summary>
        /// 上传检查图片信息
        /// </summary>
        /// <param name="p_lstPic"></param>
        /// <returns></returns>
        public long m_lngUploadCheckPic(List<clsCheckPic> p_lstPic)
        {
            long lngRes = -1;
            clsDataUpload_Svc objSvc = (clsDataUpload_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsDataUpload_Svc));
            objSvc.m_lngInsertCheckPicInfo(p_lstPic);
            return lngRes;
        }


        /// <summary>
        /// 删除检查单信息
        /// </summary>
        /// <param name="p_lstRecord"></param>
        /// <returns></returns>
        public long m_lngDelCheckInfo(string p_strStardDate, string p_strEndDate)
        {
            long lngRes = -1;
            clsDataUpload_Svc objSvc = (clsDataUpload_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsDataUpload_Svc));
            objSvc.m_lngDelCheckInfo(p_strStardDate, p_strEndDate);
            return lngRes;
        }
        
    }
}
