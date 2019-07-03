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
	/// clsCheckSignersController ��ժҪ˵����
	/// ����ļ�������
	/// ���ͨ���󱣴�����ǩ��
	/// </summary>
	public class clsCheckSignersController
	{
		/// <summary>
		/// ǩ������
		/// </summary>
		ArrayList objSignerArr=new ArrayList();
		/// <summary>
		/// �Ƿ��޺ۼ�
		/// </summary>
		bool blnMark=false;
		/// <summary>
		/// ��ǰǩ����֤��ʽ
		/// </summary>
		string strReturnSetting=string.Empty;




		/// <summary>
		/// ���캯�� ���ö�ǩ��
		/// </summary>
		/// <param name="p_objSignerArr">ǩ������</param>
		/// <param name="p_blnMark">��ǩ��ʱ��Ҫ�޺ۼ��޸���Ҫ��֤����ǩ����</param>
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
        /// ���캯�� ���õ�ǩ��
        /// </summary>
        public clsCheckSignersController()
        {
            clsSignature_srv objServ =
                (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

            long lngRes = objServ.m_lngGetConfigBySettingID("3002", out strReturnSetting);
            //objServ.Dispose();

        }
		/// <summary>
		/// ������Ϣ
        /// ��������ǰ��֤���˵������û��ж�ǩ���ı�
		/// </summary>
		/// <param name="p_byeContent">�����ֽ�</param>
		/// <param name="p_strForm">����ID</param>
		/// <param name="p_strRecordID">��¼ID��ͨ��ΪסԺ�ţ�סԺʱ�� || סԺ�ţ���¼ʱ��</param>
		/// <returns>����9����Ҫ����ǩ��������1Ϊ�ɹ�����ǩ������������Ϊʧ�� ���أ�1Ϊ��ֹ</returns>
		public long CheckSigner(Object p_objContent,clsEmrDigitalSign_VO p_objSign_VO)
		{
			long lngRes=0;

			#region ��֤��ʽ 
			if (strReturnSetting!=null)
			{
				switch (strReturnSetting)
				{
					case "0"://������֤
						break;
					case "1"://������֤
//						if(!m_blnCheckEmployeeSignByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
//							return;
						break;
					case "2"://key����֤

						#region �Ƿ��⵽key��
						clsSignCert_VO objCert=new clsSignCert_VO();
						clsDigitalSign obj=new clsDigitalSign();
						long lngR=obj.GetSpecifyCert(out objCert);
						if (objCert==null)
						{
							MessageBox.Show("��ⲻ��Key�̡����ܼ������в���","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
							return -1;
						}
						#endregion

                        #region �������ü���Ƿ�Ҫ�뵱ǰ��¼�û�һ��
                        clsSignature_srv objServ =
                            (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                        string strCheckLogin = string.Empty;
                        lngRes = objServ.m_lngGetConfigBySettingID("3007", out strCheckLogin);

                        if (strCheckLogin=="1")
                        {
                            if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentEmployee.m_strEMPKEY_VCHR!=objCert.m_strSerialNumber.Trim())
                            {
                                MessageBox.Show("Key������" + objCert.m_strCersName.Trim() + "���ǵ�ǰ��¼�û������ܼ�������", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return -1;
                            }   
                        }


                        #endregion

                        #region ���Key�������Ƿ���ǩ��������
                        //ǰ��һ����ǩ�����ڣ�ȡֵ�������ж�
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
							MessageBox.Show("Key������"+ objCert.m_strCersName.Trim()+"δ��ǩ�������У����ܼ�������","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
							return -1;
						}
						#endregion

						#region ��ǩ��ʱ��Ҫ�޺ۼ��޸���Ҫ��֤����ǩ����
						if (blnMark)
						{
							if(objSignerArr.Count>1)
							{
								frmVerifySigners frm=new frmVerifySigners(objSignerArr);
								if (frm.ShowDialog()!=System.Windows.Forms.DialogResult.OK)
								{
									MessageBox.Show("δ����֤����ǩ���ߣ����ܼ����޺ۼ��޸Ĳ���","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
									return -1;
								}

							}
						}
						#endregion

						#region ����ǩ����Ϣ
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
								//��ϣ
								HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
								byte[] Hashbyte = MD5.ComputeHash(bys);

								//����ǩ��
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
							//�쳣
							com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
							bool blnRes = objLogger.LogError(exp);
							lngRes=-1;
						}
						#endregion

						break;
					case "3"://ָ����֤
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
        /// ������Ϣ
        /// �����ڲ����ж�ǩ���ı���������֤��ǩ��
        /// </summary>
        /// <param name="p_objContent">�����ֽ�</param>
        /// <param name="p_strForm">����ID</param>
        /// <param name="p_strRecordID">��¼ID��ͨ��ΪסԺ�ţ�סԺʱ�� || סԺ�ţ���¼ʱ��</param>
        /// <returns>����9����Ҫ����ǩ��������1Ϊ�ɹ�����ǩ������������Ϊʧ�� ���أ�1Ϊ��ֹ</returns>
        public long m_lngSign(Object p_objContent, clsEmrDigitalSign_VO p_objSign_VO)
        {
            long lngRes = 0;

            #region ��֤��ʽ
            if (strReturnSetting != null)
            {
                switch (strReturnSetting)
                {
                    case "0"://������֤
                        break;
                    case "1"://������֤
                        //						if(!m_blnCheckEmployeeSignByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                        //							return;
                        break;
                    case "2"://key����֤

                        #region �Ƿ��⵽key��
                        clsSignCert_VO objCert = new clsSignCert_VO();
                        clsDigitalSign obj = new clsDigitalSign();
                        long lngR = obj.GetSpecifyCert(out objCert);
                        if (objCert == null)
                        {
                            MessageBox.Show("��ⲻ��Key�̡����ܼ������в���", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -1;
                        }
                        #endregion

                        #region �������ü���Ƿ�Ҫ�뵱ǰ��¼�û�һ��
                        clsSignature_srv objServ =
                            (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                        string strCheckLogin = string.Empty;
                        lngRes = objServ.m_lngGetConfigBySettingID("3007", out strCheckLogin);

                        if (strCheckLogin == "1")
                        {
                            if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentEmployee.m_strEMPKEY_VCHR != objCert.m_strSerialNumber.Trim())
                            {
                                MessageBox.Show("Key������" + objCert.m_strCersName.Trim() + "���ǵ�ǰ��¼�û������ܼ�������", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return -1;
                            }
                        }


                        #endregion

                        #region ����ǩ����Ϣ
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
                                //��ϣ
                                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                                byte[] Hashbyte = MD5.ComputeHash(bys);

                                //����ǩ��
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
                            //�쳣
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(exp);
                            lngRes = -1;
                        }
                        #endregion

                        break;
                    case "3"://ָ����֤
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
        /// ������Ϣ
        /// ��������¼��
        /// </summary>
        /// <param name="p_byeContent">�����ֽ�</param>
        /// <param name="p_strForm">����ID</param>
        /// <param name="p_strRecordID">��¼ID��ͨ��ΪסԺ�ţ�סԺʱ�� || סԺ�ţ���¼ʱ��</param>
        /// <param name="intWhole">����¼���־0</param>
        /// <returns>����9����Ҫ����ǩ��������1Ϊ�ɹ�����ǩ������������Ϊʧ�� ���أ�1Ϊ��ֹ</returns>
        public long CheckSigner(Object p_objContent, clsEmrDigitalSign_VO p_objSign_VO, int intWhole)
        {
            long lngRes = 0;

            #region ��֤��ʽ
            if (strReturnSetting != null)
            {
                switch (strReturnSetting)
                {
                    case "0"://������֤
                        break;
                    case "1"://������֤
                        //						if(!m_blnCheckEmployeeSignByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                        //							return;
                        break;
                    case "2"://key����֤

                        #region �Ƿ��⵽key��
                        if (clsDigitalSign.currentStaticCerts == null)
                        {
                            MessageBox.Show("��ⲻ��Key�̡����ܼ������в���", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -1;
                        }
                        #endregion

                        #region �������ü���Ƿ�Ҫ�뵱ǰ��¼�û�һ��
                        clsSignature_srv objServ =
                            (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                        string strCheckLogin = string.Empty;
                        lngRes = objServ.m_lngGetConfigBySettingID("3007", out strCheckLogin);

                        if (strCheckLogin == "1")
                        {
                            if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentEmployee.m_strEMPKEY_VCHR != clsDigitalSign.currentStaticCerts.m_strSerialNumber.Trim())
                            {
                                MessageBox.Show("Key������" + clsDigitalSign.currentStaticCerts.m_strCersName.Trim() + "���ǵ�ǰ��¼�û������ܼ�������", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return -1;
                            }
                        }


                        #endregion

                        #region ����ǩ����Ϣ
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
                                //��ϣ
                                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                                byte[] Hashbyte = MD5.ComputeHash(bys);

                                //����ǩ��
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
                            //�쳣
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(exp);
                            lngRes = -1;
                        }
                        #endregion

                        break;
                    case "3"://ָ����֤
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
		/// ��֤����ǩ��
		/// </summary>
		/// <param name="p_strFormID">����ID</param>
        /// <param name="p_strRecordID">��¼ID</param>
        /// <param name="p_blnIsOutPatient">(false=δ����Ժ�����뵽��ʷ���ȡ����)</param>
		/// <returns></returns>
		public  long m_lngSignVerify(string p_strFormID,string p_strRecordID, bool p_blnIsOutPatient)
		{
			long lngRes=0;
			if (strReturnSetting!=null)
			{
				switch (strReturnSetting)
				{
					case "0"://������֤
						break;
					case "1"://������֤
 						break;
					case "2"://key����֤
						try
						{
							if (p_strFormID==null || p_strFormID.Trim().Length==0)
								return 0;
							clsDigitalSign_domain objDomin =new clsDigitalSign_domain();
							clsEmrDigitalSign_VO objSign=new clsEmrDigitalSign_VO();
							clsDigitalSign clsSign=new clsDigitalSign();
							//��ȡ������ǩ����Ϣ
							lngRes=objDomin.m_lngGetDigitalSign(p_strFormID,p_strRecordID,p_blnIsOutPatient,out objSign);
							if (objSign==null)
							{
								MessageBox.Show("��δ����ǩ�� ������֤","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
								return 0;
							}
							string strContent=System.Text.Encoding.UTF8.GetString(objSign.m_bteCONTENT_TXT);
							//��֤
							string strReturn=clsSign.verify(strContent,objSign.m_strDSCONTENT_TXT,0);
							if (strReturn==null)
							{
								MessageBox.Show("ǩ����֤ʧ��,���ݲ�����","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
							}
							else
							{
								MessageBox.Show(strReturn,"Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
							}						
							//�ͷ�
							objDomin=null;

						}
						catch(Exception objEx)
						{
							com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
							bool blnRes = objLogger.LogError(objEx);
							lngRes=0;
						}

						break;
					case "3"://ָ����֤
 						break;
					default:
						break;

				}
			}
			return lngRes;
		}
	}
}
