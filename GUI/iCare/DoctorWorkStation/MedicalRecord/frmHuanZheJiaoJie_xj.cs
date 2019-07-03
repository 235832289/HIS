using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.emr.BEDExplorer;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.AssistModuleVO;

namespace iCare
{
    /// <summary>
    ///  术后患者交接记录单---新疆
    /// </summary>
    public partial class frmHuanZheJiaoJie_xj : iCare.frmDiseaseTrackBase
    {

        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

        public frmHuanZheJiaoJie_xj()
        {
            InitializeComponent();

            m_mthSetRichTextBoxAttribInControl(this);
            //指明医生工作站表单
            intFormType = 1;
            this.Text = "输血治疗同意书";
            this.m_lblForTitle.Text = this.Text;

            m_objSign = new clsEmrSignToolCollection();

            //麻醉医师
            m_objSign.m_mthBindEmployeeSign(m_cmdRecord, m_txtRecorder, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //交接签字
            m_objSign.m_mthBindEmployeeSign(m_cmdjiaojie, m_txtjiaojie, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //病区护士
            m_objSign.m_mthBindEmployeeSign(m_cmdhushi, m_txthushi, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
           
        }

        /// <summary>
        /// 获取当前的特殊病程记录信息
        /// </summary>
        /// <returns></returns>
        public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            clsShuXueZhiLiaoyesInfo_xj objTrackInfo = new clsShuXueZhiLiaoyesInfo_xj();

            objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;
            //设置m_strTitle和m_dtmRecordTime
            objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
            objTrackInfo.m_StrTitle = "术后患者交接记录单";

            return objTrackInfo;
        }








    }
}