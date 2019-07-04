using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.DataCollection.DomainController;
using System.Collections;

namespace com.digitalwave.iCare.gui.DataCollection
{
    /// <summary>
    /// kenny created in 2008.10.14
    /// </summary>
    public class clsCtl_UploadMain
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_UploadMain()
        {
            objDomain = new clsDcl_HisMZReportTo();
        }
        #endregion

        #region 变量
        /// <summary>
        /// 窗体
        /// </summary>
        public frmUploadMain m_objViewer;
        /// <summary>
        /// 领域层对象
        /// </summary>
        private clsDcl_HisMZReportTo objDomain;
        #endregion

        #region 公共上传方法
        /// <summary>
        /// 门诊就诊信息上报
        /// </summary>
        /// <returns>1-上传成功 0-上传失败</returns>
        public long m_lngUploadDiagInfo()
        {
            long lngRes = 0;
            try
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在下载门诊就诊信息，请稍候...");
                this.m_objViewer.Update();
                com.digitalwave.iCare.ValueObject.clsOpDiagInfo_VO[] arrOpdiagInfo_VO = null;
                DateTime datForUpload = this.m_objViewer.dtpTime.Value;
                lngRes = objDomain.m_lngGetOpDiagInfo(datForUpload,out arrOpdiagInfo_VO);

                if (lngRes > 0 && arrOpdiagInfo_VO != null)
                {
                    this.m_mthshowUploadPro(0, arrOpdiagInfo_VO.Length, "正在往前置机上传门诊就诊信息...");
                    clsOpDiagInfo_VO objOf = null;
                    for (int i2 = 0; i2 < arrOpdiagInfo_VO.Length; i2++)
                    {
                        //-------------------------------------------
                        //添加过滤
                        objOf = arrOpdiagInfo_VO[i2];
                        if (objOf == null) continue;
                        Hashtable objHsTable = new Hashtable();
                        try
                        {
                            objHsTable.Add(objOf.m_strCLINICNO+objOf.m_strVISITNO+objOf.m_strDEPTCODE + objOf.m_strCLINICIANCODE, "");
                        }
                        catch
                        {
                            continue;
                        }
                        //------------------------------------------
                        lngRes = objDomain.m_lngUploadDiagInfo(arrOpdiagInfo_VO[i2]);
                        this.m_objViewer.pgbTask.Value += 1;
                        if (Math.IEEERemainder(i2, 10) == 0)
                            this.m_objViewer.Update();//每插入10条记录重绘一下窗体的无效区域
                    }
                }
            }
            catch (Exception objEx)
            {
                System.Windows.Forms.MessageBox.Show(objEx.Message, "异常中断", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            }
            finally
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return lngRes;
        }

        /// <summary>
        /// 门诊费用信息上报
        /// </summary>
        /// <returns>1-上传成功 0-上传失败</returns>
        public long m_lngUploadOpfee()
        {
            long lngRes = 0;
            try
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在下载门诊费用信息，请稍候...");
                this.m_objViewer.Update();
                com.digitalwave.iCare.ValueObject.clsOpfee_VO[] arrOpfee_VO = null;
                DateTime datForUpload = this.m_objViewer.dtpTime.Value;
                lngRes = objDomain.m_lngGetOpfeeInfo(datForUpload, out arrOpfee_VO);

                if (lngRes > 0 && arrOpfee_VO != null)
                {
                    this.m_mthshowUploadPro(0, arrOpfee_VO.Length, "正在往前置机上传门诊费用信息");
                    int intLength=arrOpfee_VO.Length;
                    clsOpfee_VO objOf=null;
                    for (int i2 = 0; i2 < intLength; i2++)
                    {
                        //-------------------------------------------
                        //添加过滤
                        objOf=arrOpfee_VO[i2];
                        if(objOf==null) continue;
                        Hashtable objHsTable = new Hashtable();
                        try
                        {
                            objHsTable.Add(objOf.m_strVISITNO + objOf.m_strBILLNO + objOf.m_strFARECODE + objOf.m_strFARENAME, "");
                        }
                        catch
                        {
                            continue;
                        }
                        //------------------------------------------
                        lngRes = objDomain.m_lngUploadOpfee(objOf);
                        this.m_objViewer.pgbTask.Value += 1;
                        if (Math.IEEERemainder(i2, 10) == 0)
                            this.m_objViewer.Update();
                    }
                }
            }
            catch (Exception objEx)
            {
                System.Windows.Forms.MessageBox.Show(objEx.Message, "异常中断", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            }
            finally
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return lngRes;
        }

        /// <summary>
        /// 门诊处方信息上报
        /// </summary>
        /// <returns>1-上传成功 0-上传失败</returns>
        public long m_lngUploadRecInfo()
        {
            long lngRes = 0;
            try
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在下载门诊处方信息，请稍候...");
                this.m_objViewer.Update();
                com.digitalwave.iCare.ValueObject.clsRecInfo_VO[] arrRecInfo_VO = null;
                DateTime datForUpload = this.m_objViewer.dtpTime.Value;
                lngRes = objDomain.m_lngGetRecInfo(datForUpload, out arrRecInfo_VO);

                if (lngRes > 0 && arrRecInfo_VO != null)
                {
                    this.m_mthshowUploadPro(0, arrRecInfo_VO.Length, "正在往前置机上传门诊处方信息");
                    // 相同处方合并
                    clsRecInfo_VO objRecInfo = null;
                    List<clsRecInfo_VO> lstRecInfoVO = new List<clsRecInfo_VO>();
                    for (int i1 = 0; i1 < arrRecInfo_VO.Length; i1++)
                    {
                        if (i1 > 0)
                        {
                            //处方号,项目编号,单价,用法,频率,天数,用量一致的情况下
                            if (arrRecInfo_VO[i1].m_strVISITNO == arrRecInfo_VO[i1 - 1].m_strVISITNO &&
                                arrRecInfo_VO[i1].m_strMedicineCode == arrRecInfo_VO[i1 - 1].m_strMedicineCode &&
                                arrRecInfo_VO[i1].m_decUnitPrice == arrRecInfo_VO[i1 - 1].m_decUnitPrice &&
                                arrRecInfo_VO[i1].m_intMedicineUsage == arrRecInfo_VO[i1 - 1].m_intMedicineUsage &&
                                arrRecInfo_VO[i1].m_strMedicineFrequency == arrRecInfo_VO[i1 - 1].m_strMedicineFrequency &&
                                arrRecInfo_VO[i1].m_strMedicineDays == arrRecInfo_VO[i1 - 1].m_strMedicineDays &&
                                arrRecInfo_VO[i1].m_strMedicineDosage == arrRecInfo_VO[i1 - 1].m_strMedicineDosage)
                            {
                                lstRecInfoVO[lstRecInfoVO.Count - 1].m_decUnitNumber += arrRecInfo_VO[i1].m_decUnitNumber;
                                lstRecInfoVO[lstRecInfoVO.Count - 1].m_decTotalPrice += arrRecInfo_VO[i1].m_decTotalPrice;
                            }
                            else
                            {
                                objRecInfo = new clsRecInfo_VO();
                                arrRecInfo_VO[i1].m_mthCopyTo(objRecInfo);
                                lstRecInfoVO.Add(objRecInfo);
                            }
                        }
                        else
                        {
                            objRecInfo = new clsRecInfo_VO();
                            arrRecInfo_VO[i1].m_mthCopyTo(objRecInfo);
                            lstRecInfoVO.Add(objRecInfo);
                        }
                    }
                    arrRecInfo_VO = lstRecInfoVO.ToArray();
                    // --                    
                    for (int i2 = 0; i2 < arrRecInfo_VO.Length; i2++)
                    {
                        lngRes = objDomain.m_lngUploadRecInfo(arrRecInfo_VO[i2]);
                        this.m_objViewer.pgbTask.Value += 1;
                        if (Math.IEEERemainder(i2, 10) == 0)
                            this.m_objViewer.Update();
                    }
                }
            }
            catch (Exception objEx)
            {
                System.Windows.Forms.MessageBox.Show(objEx.Message, "异常中断", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            }
            finally
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return lngRes;
        }

        /// <summary>
        /// 药品信息上报
        /// </summary>
        /// <returns>1-上传成功 0-上传失败</returns>
        public long m_lngUploadDrugInfo()
        {
            long lngRes = 0;
            try
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在下载药品信息，请稍候...");
                this.m_objViewer.Update();
                //com.digitalwave.iCare.ValueObject.clsDrugInfo_VO[] arrDrugInfo_VO = null;
                //DateTime datForUpload = this.m_objViewer.dtpTime.Value;
                //lngRes = objDomain.m_lngGetDrugInfo(datForUpload, out arrDrugInfo_VO);

                //if (lngRes > 0 && arrDrugInfo_VO != null)
                //{
                //    this.m_mthshowUploadPro(0, arrDrugInfo_VO.Length, "正在往前置机上传药品信息");
                //    for (int i2 = 0; i2 < arrDrugInfo_VO.Length; i2++)
                //    {
                //        lngRes = objDomain.m_lngUploadDrugInfo(arrDrugInfo_VO[i2]);
                //        if (m_objViewer.pgbTask.Value < Math.Floor(Convert.ToDouble(this.m_objViewer.pgbTask.Maximum / 3)))
                //        {
                //            this.m_objViewer.pgbTask.Value += 1;
                //        }
                //        if (Math.IEEERemainder(i2, 10) == 0)
                //            this.m_objViewer.Update();
                //    }
                //}
                //20100204:改为上传药库信息，上面是上传应急用药信息，作废之
                com.digitalwave.iCare.ValueObject.clsStorageInfo_VO[] arrStorageInfo_VO = null;
                DateTime datForUpload = this.m_objViewer.dtpTime.Value;
                lngRes = objDomain.m_lngGetStorageInfo(datForUpload, out arrStorageInfo_VO);

                if (lngRes > 0 && arrStorageInfo_VO != null && arrStorageInfo_VO.Length > 0)
                {
                    this.m_mthshowUploadPro(0, 100, "正在往前置机上传药品信息");
                    for (int i2 = 0; i2 < arrStorageInfo_VO.Length; i2++)
                    {
                        lngRes = objDomain.m_lngUploadStorageInfo(arrStorageInfo_VO[i2]);
                        if (m_objViewer.pgbTask.Value < 100)
                        {
                            this.m_objViewer.pgbTask.Value += 1;
                        }
                        if (Math.IEEERemainder(i2, 10) == 0)
                            this.m_objViewer.Update();
                    }
                }
                this.m_objViewer.pgbTask.Value = this.m_objViewer.pgbTask.Maximum;
                //20100115:增加药库入库信息
                com.digitalwave.iCare.ValueObject.clsInStorageInfo_VO[] arrInStorageInfo_VO = null;
                lngRes = objDomain.m_lngGetInStorageInfo(datForUpload, out arrInStorageInfo_VO);

                if (lngRes > 0 && arrInStorageInfo_VO != null && arrInStorageInfo_VO.Length > 0)
                {
                    this.m_mthshowUploadPro(0, 100, "正在往前置机上传入库信息");
                    for (int i2 = 0; i2 < arrInStorageInfo_VO.Length; i2++)
                    {
                        lngRes = objDomain.m_lngUploadInStorageInfo(arrInStorageInfo_VO[i2]);
                        if (m_objViewer.pgbTask.Value < 100)
                        {
                            this.m_objViewer.pgbTask.Value += 1;
                        }
                        if (Math.IEEERemainder(i2, 10) == 0)
                            this.m_objViewer.Update();
                    }
                }
                this.m_objViewer.pgbTask.Value = this.m_objViewer.pgbTask.Maximum;
                //20100115：增加药库出库信息
                com.digitalwave.iCare.ValueObject.clsOutStorageInfo_VO[] arrOutStorageInfo_VO = null;
                lngRes = objDomain.m_lngGetOutStorageInfo(datForUpload, out arrOutStorageInfo_VO);

                if (lngRes > 0 && arrOutStorageInfo_VO != null && arrOutStorageInfo_VO.Length > 0)
                {
                    this.m_mthshowUploadPro(0, 100, "正在往前置机上传出库信息");
                    for (int i2 = 0; i2 < arrOutStorageInfo_VO.Length; i2++)
                    {
                        lngRes = objDomain.m_lngUploadOutStorageInfo(arrOutStorageInfo_VO[i2]);
                        if (m_objViewer.pgbTask.Value < 100)
                        {
                            this.m_objViewer.pgbTask.Value += 1;
                        }
                        if (Math.IEEERemainder(i2, 10) == 0)
                            this.m_objViewer.Update();
                    }
                }
                this.m_objViewer.pgbTask.Value = this.m_objViewer.pgbTask.Maximum;
                //20130630：市统一项目表
                //com.digitalwave.iCare.ValueObject.clsHEALTH_ITEAM_VO[] arrHEALTH_ITEAM_VO_VO = null;
                //lngRes = objDomain.m_lngGetOutStorageInfo(datForUpload, out arrHEALTH_ITEAM_VO_VO);

                //if (lngRes > 0 && arrHEALTH_ITEAM_VO_VO != null && arrHEALTH_ITEAM_VO_VO.Length > 0)
                //{
                //    this.m_mthshowUploadPro(0, 100, "正在往前置机上传出库信息");
                //    for (int i2 = 0; i2 < arrHEALTH_ITEAM_VO_VO.Length; i2++)
                //    {
                //        lngRes = objDomain.m_lngUploadOutStorageInfo(arrHEALTH_ITEAM_VO_VO[i2]);
                //        if (m_objViewer.pgbTask.Value < 100)
                //        {
                //            this.m_objViewer.pgbTask.Value += 1;
                //        }
                //        if (Math.IEEERemainder(i2, 10) == 0)
                //            this.m_objViewer.Update();
                //    }
                //}
                //this.m_objViewer.pgbTask.Value = this.m_objViewer.pgbTask.Maximum;


                this.m_objViewer.lblCurrentInfo.Text = "上传成功!";
                this.m_objViewer.Update();
            }
            catch (Exception objEx)
            {
                System.Windows.Forms.MessageBox.Show(objEx.Message, "异常中断", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                this.m_objViewer.lblCurrentInfo.Text = "上传失败!";
            }
            finally
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return lngRes;
        }

        #region 检验信息上报
        /// <summary>
        /// 检验信息上报
        /// </summary>
        /// <returns>1-上传成功 0-上传失败</returns>
        public long m_lngUploadLisInfo()
        {
            long lngRes = 1;
            try
            {
                this.m_objViewer.pgbTask.Minimum = 0;
                this.m_objViewer.pgbTask.Maximum = 100;

                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在准备上报信息，请稍候...");
                this.m_objViewer.Update();

                string strStardDate = this.m_objViewer.dtpTime.Value.ToString("yyyy-MM-dd 00:00:00");
                string strEndDate = this.m_objViewer.dtpTime.Value.ToString("yyyy-MM-dd 23:59:59");

                objDomain.m_lngDelLISUpdateLoadDataByDate(strStardDate, strEndDate);


                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在下载检验信息，请稍候...");
                this.m_objViewer.pgbTask.Value = 15;
                this.m_objViewer.Update();
                List<clsLISAppl_VO> lstLISApp = new List<clsLISAppl_VO>();
                clsLISAppl_VO[] objLISAppArr = null;

                lngRes = objDomain.m_lngQueryLISAppByDate(strStardDate, strEndDate, out objLISAppArr);
                if (lngRes <= 0)
                {
                    throw new Exception("下载检验信息失败!");
                }
                if (objLISAppArr != null)
                    lstLISApp.AddRange(objLISAppArr);

                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在上传检验信息，请稍候...");
                this.m_objViewer.pgbTask.Value = 30;
                this.m_objViewer.Update();

                if (lstLISApp != null && lstLISApp.Count > 0)
                {
                    objDomain.m_lngInsertLisAppDataByDate(lstLISApp.ToArray());
                }
                lstLISApp = null;
                objLISAppArr = null;

                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在下载检验明细信息，请稍候...");
                this.m_objViewer.pgbTask.Value = 45;
                this.m_objViewer.Update();

                clsLISApplItem_VO[] objLisAppItemArr = null;
                lngRes = objDomain.m_lngQueryLISAppItemByDate(strStardDate, strEndDate, out objLisAppItemArr);
                if (lngRes <= 0)
                {
                    throw new Exception("下载检验明细信息失败!");
                }
                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在上报检验明细信息，请稍候...");
                this.m_objViewer.pgbTask.Value = 60;
                this.m_objViewer.Update();
                if (objLisAppItemArr != null && objLisAppItemArr.Length > 0)
                    lngRes = objDomain.m_lngInsertLisAppItemDataByDate(objLisAppItemArr);
                objLisAppItemArr = null;

                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在下载检验子明细信息，请稍候...");
                this.m_objViewer.pgbTask.Value = 75;
                this.m_objViewer.Update();
                clsLISApplDetial_VO[] objLISAppDetlArr = null;
                lngRes = objDomain.m_lngQueryLISAppDetialByDate(strStardDate, strEndDate, out objLISAppDetlArr);
                if (lngRes <= 0)
                {
                    throw new Exception("下载检验子明细信息失败!");
                }

                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在上报检验子明细信息，请稍候...");
                this.m_objViewer.pgbTask.Value = 90;
                this.m_objViewer.Update();
                objDomain.m_lngInsertLisAppItemDetialDataByDate(objLISAppDetlArr);
                objLISAppDetlArr = null;
            }
            catch (Exception objEx)
            {
                System.Windows.Forms.MessageBox.Show(objEx.Message, "异常中断", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                lngRes = 0;
            }
            finally
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return lngRes;
        } 
        #endregion

        public long m_lngUploadCheckInfo()
        {
            long lngRes = 1;
            try
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在准备上报信息，请稍候...");
                this.m_objViewer.Update();
                string strStardDate = this.m_objViewer.dtpTime.Value.ToString("yyyy-MM-dd 00:00:00");
                string strEndDate = this.m_objViewer.dtpTime.Value.ToString("yyyy-MM-dd 23:59:59");
                clsDcl_Check objDomain = new clsDcl_Check();
                objDomain.m_lngDelCheckInfo(strStardDate, strEndDate);

                List<clsCheckRecord> lstCheck = null;
                List<clsCheckPic> lstPic = null;
              
                objDomain.m_lngGetCheckInfo(Convert.ToDateTime(strStardDate), Convert.ToDateTime(strEndDate), out lstCheck, out lstPic);
                this.m_objViewer.pgbTask.Value = 50;
                this.m_objViewer.Update();
                m_mthshowDownLoadPro("正在上报检查单信息，请稍候...");
                objDomain.m_lngUploadCheckInfo(lstCheck);
                this.m_objViewer.pgbTask.Value = 75;
                this.m_objViewer.Update();

                m_mthshowDownLoadPro("正在上报检查图片信息，请稍候...");
                objDomain.m_lngUploadCheckPic(lstPic);
                this.m_objViewer.pgbTask.Value = 100;
                this.m_objViewer.Update();
                lstCheck = null;
                lstPic = null;

                //clsDcl_Check objDomain = new clsDcl_Check();
                //objDomain.m_lngUploadCheckPic();

            }
            catch (Exception objEx)
            {
                System.Windows.Forms.MessageBox.Show(objEx.Message, "异常中断", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                lngRes = 0;
            }
            finally
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return lngRes;
        }

        /// <summary>
        /// 收费标准信息上报
        /// </summary>
        /// <returns></returns>
        public long m_lngUploadChargeStd()
        {
            long lngRes = 0;
            try
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在下载收费标准信息，请稍候...");
                this.m_objViewer.Update();
                string strStardDate = this.m_objViewer.dtpTime.Value.ToString("yyyy-MM-dd 00:00:00");
                string strEndDate = this.m_objViewer.dtpTime.Value.ToString("yyyy-MM-dd 23:59:59");
                com.digitalwave.iCare.ValueObject.clsChargeStandard_VO[] arrChargeitem_VO = null;
                DateTime datForUpload = this.m_objViewer.dtpTime.Value;
                lngRes = objDomain.m_lngGetChargeItemInfo(Convert.ToDateTime(strStardDate), Convert.ToDateTime(strEndDate), datForUpload, out arrChargeitem_VO);

                if (lngRes > 0 && arrChargeitem_VO != null)
                {
                    this.m_mthshowUploadPro(0, arrChargeitem_VO.Length, "正在往前置机上传收费标准信息");
                    for (int i2 = 0; i2 < arrChargeitem_VO.Length; i2++)
                    {
                        lngRes = objDomain.m_lngUploadChargeitemInfo(arrChargeitem_VO[i2]);
                        this.m_objViewer.pgbTask.Value += 1;
                        if (Math.IEEERemainder(i2, 10) == 0)
                            this.m_objViewer.Update();
                    }
                }
            }
            catch (Exception objEx)
            {
                System.Windows.Forms.MessageBox.Show(objEx.Message, "异常中断", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            }
            finally
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return lngRes;
        }

        /// <summary>
        /// 项目对照信息上传
        /// </summary>
        /// <returns></returns>
        public long m_lngUploadItemControlInfo()
        {
            long lngRes = 0;
            try
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在下载项目对照信息，请稍候...");
                this.m_objViewer.Update();
                string strStardDate = this.m_objViewer.dtpTime.Value.ToString("yyyy-MM-dd 00:00:00");
                string strEndDate = this.m_objViewer.dtpTime.Value.ToString("yyyy-MM-dd 23:59:59");
                com.digitalwave.iCare.ValueObject.clsItemControl_VO[] arrItemControl_VO = null;
                DateTime datForUpload = this.m_objViewer.dtpTime.Value;
                lngRes = objDomain.m_lngGetItemControlInfo(Convert.ToDateTime(strStardDate), Convert.ToDateTime(strEndDate), out arrItemControl_VO);

                if (lngRes > 0 && arrItemControl_VO != null)
                {
                    this.m_mthshowUploadPro(0, arrItemControl_VO.Length, "正在往前置机上传项目对照信息");
                    for (int i2 = 0; i2 < arrItemControl_VO.Length; i2++)
                    {
                        lngRes = objDomain.m_lngUploadItemControl(arrItemControl_VO[i2]);
                        this.m_objViewer.pgbTask.Value += 1;
                        if (Math.IEEERemainder(i2, 10) == 0)
                            this.m_objViewer.Update();
                    }
                    this.m_mthshowUploadPro(0, arrItemControl_VO.Length, "上传成功！");
                }
            }
            catch (Exception objEx)
            {
                System.Windows.Forms.MessageBox.Show(objEx.Message, "异常中断", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            }
            finally
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return lngRes;
        }

        //====qinhong====添加上传病案首页接口==================Start
        /// <summary>
        /// 上传病案首页接口
        /// </summary>
        /// <returns></returns>
        public long m_lngUploadInHospitalInfo()
        {
            long lngRes = 1;
            try
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.m_objViewer.Invalidate(true);
                m_mthshowDownLoadPro("正在准备上报信息，请稍候...");
                this.m_objViewer.Update();
                string strStardDate = this.m_objViewer.dtpTime.Value.AddDays(-7).ToString("yyyy-MM-dd  00:00:00");//("yyyy-MM-dd 00:00:00");
                string strEndDate = this.m_objViewer.dtpTime.Value.AddDays(-7).ToString("yyyy-MM-dd 23:59:59");//
                clsDcl_ZY objDomain = new clsDcl_ZY();
                objDomain.m_lngDelFirstPageDataByDate(strStardDate, strEndDate);

                m_mthshowDownLoadPro("正在下载上报信息，请稍候...");
                this.m_objViewer.Update();
                List<clsFirstPageVO> lstFirstPage = null;
                List<clsOperationVO> lstOperation = null;
                objDomain.m_lngGetInHospitalInfo(Convert.ToDateTime(strStardDate), Convert.ToDateTime(strEndDate), out lstFirstPage, out lstOperation);
                this.m_objViewer.pgbTask.Value = 50;
                this.m_objViewer.Update();
                m_mthshowDownLoadPro("正在上报病案首页信息，请稍候...");
                objDomain.m_lngUploadFirstPageInfo(lstFirstPage);
                this.m_objViewer.pgbTask.Value = 75;
                this.m_objViewer.Update();

                m_mthshowDownLoadPro("正在上报手术信息，请稍候...");  //手术暂时注释
                objDomain.m_lngUploadOperationInfo(lstOperation);
                this.m_objViewer.pgbTask.Value = 100;
                this.m_objViewer.Update();
                lstFirstPage = null;
                lstOperation = null;
            }
            catch (Exception objEx)
            {
                System.Windows.Forms.MessageBox.Show(objEx.Message, "异常中断", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                lngRes = 0;
            }
            finally
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return lngRes;
        }
        //====qinhong====添加上传病案首页接口===================End
        #endregion

        #region 私有方法

        #region 下载数据显示进度条
        /// <summary>
        /// 下载数据显示进度条
        /// </summary>
        /// <param name="strInfo"></param>
        private void m_mthshowDownLoadPro(string strInfo)
        {
            this.m_objViewer.lblCurrentInfo.Text = strInfo;
            this.m_objViewer.pgbTask.Value = 0;
            //this.m_objViewer.pgbTask.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        }
        #endregion

        #region 上传数据显示进度条
        /// <summary>
        /// 上传数据显示进度条
        /// </summary>
        /// <param name="minmun"></param>
        /// <param name="maxmum"></param>
        /// <param name="strInfo"></param>
        private void m_mthshowUploadPro(int minmun, int maxmum, string strInfo)
        {
            this.m_objViewer.lblCurrentInfo.Text = strInfo;
            this.m_objViewer.pgbTask.Value = minmun;
            this.m_objViewer.pgbTask.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.m_objViewer.pgbTask.Minimum = minmun;
            this.m_objViewer.pgbTask.Maximum = maxmum;
        }
        #endregion

        #endregion
    }
}