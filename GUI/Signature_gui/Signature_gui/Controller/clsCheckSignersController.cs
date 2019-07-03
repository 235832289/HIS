using System;
using System.Collections;
using com.digitalwave.emr.DigitalSign;
using com.digitalwave.Emr.Signature_srv;
using System.Windows.Forms;
using iCareData;
//using com.digitalwave.Emr.DigitalSign_srv;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.IO;
namespace com.digitalwave.Emr.Signature_gui
{
	/// <summary>
	/// clsCheckSignersController 的摘要说明。
	/// 保存的检测控制类
	/// 检测通过后保存数字签名
	/// </summary>
	public class clsCheckSignersController
	{
		/// <summary>
		/// 签名集合
		/// </summary>
		ArrayList objSignerArr=new ArrayList();
		/// <summary>
		/// 是否无痕迹
		/// </summary>
		bool blnMark=false;
		/// <summary>
		/// 当前签名验证方式
		/// </summary>
		string strReturnSetting=string.Empty;




		/// <summary>
		/// 构造函数 适用多签名
		/// </summary>
		/// <param name="p_objSignerArr">签名集合</param>
		/// <param name="p_blnMark">多签名时若要无痕迹修改需要验证所有签名者</param>
		public clsCheckSignersController(ArrayList p_objSignerArr,bool p_blnMark)
		{
			objSignerArr=p_objSignerArr;
			blnMark=p_blnMark;
            clsSignature_srv objServ =
                (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

            long lngRes = objServ.m_lngGetConfigBySettingID("3002", out strReturnSetting);
            //objServ.Dispose();

		}
        /// <summary>
        /// 构造函数 适用单签名
        /// </summary>
        public clsCheckSignersController()
        {
            clsSignature_srv objServ =
                (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

            long lngRes = objServ.m_lngGetConfigBySettingID("3002", out strReturnSetting);
            //objServ.Dispose();

        }
		/// <summary>
		/// 保存信息
        /// 包括保存前验证，此调用适用还有多签名的表单
		/// </summary>
		/// <param name="p_byeContent">对象字节</param>
		/// <param name="p_strForm">窗体ID</param>
		/// <param name="p_strRecordID">记录ID，通常为住院号＋住院时间 || 住院号＋记录时间</param>
		/// <returns>返回9不需要电子签名，返回1为成功电子签名，其他均视为失败 返回－1为中止</returns>
		public long CheckSigner(Object p_objContent,clsEmrDigitalSign_VO p_objSign_VO)
		{
			long lngRes=0;

			#region 验证方式 
			if (strReturnSetting!=null)
			{
				switch (strReturnSetting)
				{
					case "0"://无需验证
						break;
					case "1"://密码验证
//						if(!m_blnCheckEmployeeSignByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
//							return;
						break;
					case "2"://key盘验证

						#region 是否检测到key盘
						clsSignCert_VO objCert=new clsSignCert_VO();
						clsDigitalSign obj=new clsDigitalSign();
						long lngR=obj.GetSpecifyCert(out objCert);
						if (objCert==null)
						{
							MessageBox.Show("检测不到Key盘。不能继续进行操作","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
							return -1;
						}
						#endregion

                        #region 根据配置检查是否要与当前登录用户一致
                        clsSignature_srv objServ =
                            (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                        string strCheckLogin = string.Empty;
                        lngRes = objServ.m_lngGetConfigBySettingID("3007", out strCheckLogin);

                        if (strCheckLogin=="1")
                        {
                            if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentEmployee.m_strEMPKEY_VCHR!=objCert.m_strSerialNumber.Trim())
                            {
                                MessageBox.Show("Key持有人" + objCert.m_strCersName.Trim() + "不是当前登录用户，不能继续操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return -1;
                            }   
                        }


                        #endregion

                        #region 检测Key持有者是否在签名集合中
                        //前提一定有签名存在，取值是已做判断
						bool blnConfirmSign=false;
						for (int i=0;i<objSignerArr.Count;i++)
						{
								if (((clsEmrEmployeeBase_VO)objSignerArr[i]).m_strEMPKEY_VCHR.Trim()==objCert.m_strSerialNumber.Trim())
								{	
									blnConfirmSign=true;
									break;
								}
						}
						if (blnConfirmSign!=true)
						{
							MessageBox.Show("Key持有人"+ objCert.m_strCersName.Trim()+"未在签名集合中，不能继续操作","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
							return -1;
						}
						#endregion

						#region 多签名时若要无痕迹修改需要验证所有签名者
						if (blnMark)
						{
							if(objSignerArr.Count>1)
							{
								frmVerifySigners frm=new frmVerifySigners(objSignerArr);
								if (frm.ShowDialog()!=System.Windows.Forms.DialogResult.OK)
								{
									MessageBox.Show("未能验证所有签名者，不能继续无痕迹修改操作","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
									return -1;
								}

							}
						}
						#endregion

						#region 保存签名信息
						try
						{
							if (p_objContent==null )
								return -1;
							bool blncheck=false;
							clsDigitalSign_domain objSvc =new clsDigitalSign_domain();
                            objSvc.m_lngCheckNeedToSign(p_objSign_VO.m_strFORMID_VCHR, out blncheck);
							if (blncheck)
							{
								MemoryStream ms =new MemoryStream();
								BinaryFormatter formatter = new BinaryFormatter();
								formatter.Serialize(ms,p_objContent);
								byte[] bys=ms.ToArray();
								//哈希
								HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
								byte[] Hashbyte = MD5.ComputeHash(bys);

								//数字签名
								string strContent=System.Text.Encoding.UTF8.GetString(Hashbyte);
								string strCode=obj.sign(strContent,0);
								if(strCode==null)
									return -1;
								clsEmrDigitalSign_VO objSign=new clsEmrDigitalSign_VO();
								objSign.m_datSIGNDATE_DAT=DateTime.Now;
								objSign.m_bteCONTENT_TXT=Hashbyte;
								objSign.m_strDSCONTENT_TXT=strCode;
								objSign.m_strSIGNNAME_VCHR=objCert.m_strCersName;//clsEMRLogin.LoginInfo.m_strEmpName;
                                objSign.m_strSIGNIDID_VCHR = p_objSign_VO.m_strSIGNIDID_VCHR;
                                objSign.m_strFORMID_VCHR = p_objSign_VO.m_strFORMID_VCHR;
                                objSign.m_strFORMRECORDID_VCHR = p_objSign_VO.m_strFORMRECORDID_VCHR;
                                objSign.m_strRegisterId = p_objSign_VO.m_strRegisterId;
                                lngRes = objSvc.m_lngAddDigitalSign(objSign);
							}
							else
							{
								lngRes=9;
							}
						}
						catch(Exception exp)
						{
							//异常
							com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
							bool blnRes = objLogger.LogError(exp);
							lngRes=-1;
						}
						#endregion

						break;
					case "3"://指纹验证
//						if (!m_blnCheckEmployeeSignByFinger(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
//							return;
						break;
					default:
						break;

				}
			}
			#endregion

			return lngRes;
		}

        /// <summary>
        /// 保存信息
        /// 适用于不含有多签名的表单，无需验证多签名
        /// </summary>
        /// <param name="p_objContent">对象字节</param>
        /// <param name="p_strForm">窗体ID</param>
        /// <param name="p_strRecordID">记录ID，通常为住院号＋住院时间 || 住院号＋记录时间</param>
        /// <returns>返回9不需要电子签名，返回1为成功电子签名，其他均视为失败 返回－1为中止</returns>
        public long m_lngSign(Object p_objContent, clsEmrDigitalSign_VO p_objSign_VO)
        {
            long lngRes = 0;

            #region 验证方式
            if (strReturnSetting != null)
            {
                switch (strReturnSetting)
                {
                    case "0"://无需验证
                        break;
                    case "1"://密码验证
                        //						if(!m_blnCheckEmployeeSignByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                        //							return;
                        break;
                    case "2"://key盘验证

                        #region 是否检测到key盘
                        clsSignCert_VO objCert = new clsSignCert_VO();
                        clsDigitalSign obj = new clsDigitalSign();
                        long lngR = obj.GetSpecifyCert(out objCert);
                        if (objCert == null)
                        {
                            MessageBox.Show("检测不到Key盘。不能继续进行操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -1;
                        }
                        #endregion

                        #region 根据配置检查是否要与当前登录用户一致
                        clsSignature_srv objServ =
                            (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                        string strCheckLogin = string.Empty;
                        lngRes = objServ.m_lngGetConfigBySettingID("3007", out strCheckLogin);

                        if (strCheckLogin == "1")
                        {
                            if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentEmployee.m_strEMPKEY_VCHR != objCert.m_strSerialNumber.Trim())
                            {
                                MessageBox.Show("Key持有人" + objCert.m_strCersName.Trim() + "不是当前登录用户，不能继续操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return -1;
                            }
                        }


                        #endregion

                        #region 保存签名信息
                        try
                        {
                            if (p_objContent == null)
                                return -1;
                            bool blncheck = false;
                            clsDigitalSign_domain objSvc = new clsDigitalSign_domain();
                            objSvc.m_lngCheckNeedToSign(p_objSign_VO.m_strFORMID_VCHR, out blncheck);
                            if (blncheck)
                            {
                                MemoryStream ms = new MemoryStream();
                                BinaryFormatter formatter = new BinaryFormatter();
                                formatter.Serialize(ms, p_objContent);
                                byte[] bys = ms.ToArray();
                                //哈希
                                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                                byte[] Hashbyte = MD5.ComputeHash(bys);

                                //数字签名
                                string strContent = System.Text.Encoding.UTF8.GetString(Hashbyte);
                                string strCode = obj.sign(strContent, 0);
                                if (strCode == null)
                                    return -1;
                                clsEmrDigitalSign_VO objSign = new clsEmrDigitalSign_VO();
                                objSign.m_datSIGNDATE_DAT = DateTime.Now;
                                objSign.m_bteCONTENT_TXT = Hashbyte;
                                objSign.m_strDSCONTENT_TXT = strCode;
                                objSign.m_strSIGNNAME_VCHR = objCert.m_strCersName;//clsEMRLogin.LoginInfo.m_strEmpName;
                                objSign.m_strSIGNIDID_VCHR = p_objSign_VO.m_strSIGNIDID_VCHR;
                                objSign.m_strFORMID_VCHR = p_objSign_VO.m_strFORMID_VCHR;
                                objSign.m_strFORMRECORDID_VCHR = p_objSign_VO.m_strFORMRECORDID_VCHR;
                                objSign.m_strRegisterId = p_objSign_VO.m_strRegisterId;
                                lngRes = objSvc.m_lngAddDigitalSign(objSign);
                            }
                            else
                            {
                                lngRes = 9;
                            }
                        }
                        catch (Exception exp)
                        {
                            //异常
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(exp);
                            lngRes = -1;
                        }
                        #endregion

                        break;
                    case "3"://指纹验证
                        //						if (!m_blnCheckEmployeeSignByFinger(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                        //							return;
                        break;
                    default:
                        break;

                }
            }
            #endregion

            return lngRes;
        }

        /// <summary>
        /// 保存信息
        /// 适用整体录入
        /// </summary>
        /// <param name="p_byeContent">对象字节</param>
        /// <param name="p_strForm">窗体ID</param>
        /// <param name="p_strRecordID">记录ID，通常为住院号＋住院时间 || 住院号＋记录时间</param>
        /// <param name="intWhole">整体录入标志0</param>
        /// <returns>返回9不需要电子签名，返回1为成功电子签名，其他均视为失败 返回－1为中止</returns>
        public long CheckSigner(Object p_objContent, clsEmrDigitalSign_VO p_objSign_VO, int intWhole)
        {
            long lngRes = 0;

            #region 验证方式
            if (strReturnSetting != null)
            {
                switch (strReturnSetting)
                {
                    case "0"://无需验证
                        break;
                    case "1"://密码验证
                        //						if(!m_blnCheckEmployeeSignByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                        //							return;
                        break;
                    case "2"://key盘验证

                        #region 是否检测到key盘
                        if (clsDigitalSign.currentStaticCerts == null)
                        {
                            MessageBox.Show("检测不到Key盘。不能继续进行操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -1;
                        }
                        #endregion

                        #region 根据配置检查是否要与当前登录用户一致
                        clsSignature_srv objServ =
                            (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                        string strCheckLogin = string.Empty;
                        lngRes = objServ.m_lngGetConfigBySettingID("3007", out strCheckLogin);

                        if (strCheckLogin == "1")
                        {
                            if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentEmployee.m_strEMPKEY_VCHR != clsDigitalSign.currentStaticCerts.m_strSerialNumber.Trim())
                            {
                                MessageBox.Show("Key持有人" + clsDigitalSign.currentStaticCerts.m_strCersName.Trim() + "不是当前登录用户，不能继续操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return -1;
                            }
                        }


                        #endregion

                        #region 保存签名信息
                        try
                        {
                            if (p_objContent == null)
                                return -1;
                            bool blncheck = false;
                            clsDigitalSign_domain objSvc = new clsDigitalSign_domain();
                            objSvc.m_lngCheckNeedToSign(p_objSign_VO.m_strFORMID_VCHR, out blncheck);
                            if (blncheck)
                            {
                                clsDigitalSign obj = new clsDigitalSign();
                                MemoryStream ms = new MemoryStream();
                                BinaryFormatter formatter = new BinaryFormatter();
                                formatter.Serialize(ms, p_objContent);
                                byte[] bys = ms.ToArray();
                                //哈希
                                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                                byte[] Hashbyte = MD5.ComputeHash(bys);

                                //数字签名
                                string strContent = System.Text.Encoding.UTF8.GetString(Hashbyte);
                                string strCode = obj.sign(strContent);
                                if (strCode == null)
                                    return -1;
                                clsEmrDigitalSign_VO objSign = new clsEmrDigitalSign_VO();
                                objSign.m_datSIGNDATE_DAT = DateTime.Now;
                                objSign.m_bteCONTENT_TXT = Hashbyte;
                                objSign.m_strDSCONTENT_TXT = strCode;
                                objSign.m_strSIGNNAME_VCHR = clsDigitalSign.currentStaticCerts.m_strCersName;//clsEMRLogin.LoginInfo.m_strEmpName;
                                objSign.m_strSIGNIDID_VCHR = p_objSign_VO.m_strSIGNIDID_VCHR;
                                objSign.m_strFORMID_VCHR = p_objSign_VO.m_strFORMID_VCHR;
                                objSign.m_strFORMRECORDID_VCHR = p_objSign_VO.m_strFORMRECORDID_VCHR;
                                objSign.m_strRegisterId = p_objSign_VO.m_strRegisterId;
                                lngRes = objSvc.m_lngAddDigitalSign(objSign);
                            }
                            else
                            {
                                lngRes = 9;
                            }
                        }
                        catch (Exception exp)
                        {
                            //异常
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(exp);
                            lngRes = -1;
                        }
                        #endregion

                        break;
                    case "3"://指纹验证
                        //						if (!m_blnCheckEmployeeSignByFinger(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                        //							return;
                        break;
                    default:
                        break;

                }
            }
            #endregion

            return lngRes;
        }



		/// <summary>
		/// 验证数字签名
		/// </summary>
		/// <param name="p_strFormID">窗体ID</param>
        /// <param name="p_strRecordID">记录ID</param>
        /// <param name="p_blnIsOutPatient">(false=未出过院，无须到历史表获取数据)</param>
		/// <returns></returns>
		public  long m_lngSignVerify(string p_strFormID,string p_strRecordID, bool p_blnIsOutPatient)
		{
			long lngRes=0;
			if (strReturnSetting!=null)
			{
				switch (strReturnSetting)
				{
					case "0"://无需验证
						break;
					case "1"://密码验证
 						break;
					case "2"://key盘验证
						try
						{
							if (p_strFormID==null || p_strFormID.Trim().Length==0)
								return 0;
							clsDigitalSign_domain objDomin =new clsDigitalSign_domain();
							clsEmrDigitalSign_VO objSign=new clsEmrDigitalSign_VO();
							clsDigitalSign clsSign=new clsDigitalSign();
							//获取表单数字签名信息
							lngRes=objDomin.m_lngGetDigitalSign(p_strFormID,p_strRecordID,p_blnIsOutPatient,out objSign);
							if (objSign==null)
							{
								MessageBox.Show("尚未数字签名 无需验证","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
								return 0;
							}
							string strContent=System.Text.Encoding.UTF8.GetString(objSign.m_bteCONTENT_TXT);
							//验证
							string strReturn=clsSign.verify(strContent,objSign.m_strDSCONTENT_TXT,0);
							if (strReturn==null)
							{
								MessageBox.Show("签名验证失败,数据不符合","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
							}
							else
							{
								MessageBox.Show(strReturn,"Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
							}						
							//释放
							objDomin=null;

						}
						catch(Exception objEx)
						{
							com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
							bool blnRes = objLogger.LogError(objEx);
							lngRes=0;
						}

						break;
					case "3"://指纹验证
 						break;
					default:
						break;

				}
			}
			return lngRes;
		}
	}
}
