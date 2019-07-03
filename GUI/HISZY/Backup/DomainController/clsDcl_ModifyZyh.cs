using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 修改住院号Domain类
    /// </summary>
    public class clsDcl_ModifyZyh : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        /// <summary>
        /// 修改住院号Domain类
        /// </summary>
        public clsDcl_ModifyZyh()
        {
        }

        #region 根据住院号或诊疗卡号获取当前在院病人信息
        /// <summary>
        /// 根据住院号或诊疗卡号获取当前在院病人信息
        /// </summary>
        /// <param name="no"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetPatientinfoByZyh(string no, out DataTable dt, int type)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngGetPatientinfoByZyh(no, out dt, type);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 判断新号是否已存在
        /// <summary>
        /// 判断新号是否已存在
        /// </summary>
        /// <param name="newno"></param>
        /// <returns></returns>
        public bool m_blnCheckNewNO(string newno)
        {
            com.digitalwave.iCare.middletier.HIS.clsModifyZyh objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsModifyZyh)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsModifyZyh));

            bool b = objSvc.m_blnCheckNewNO(newno);
            objSvc.Dispose();

            return b;
        }
        #endregion

        #region 将当前住院(留观)号改为一新号
        /// <summary>
        /// 将当前住院(留观)号改为一新号
        /// </summary>
        /// <param name="patientid">病人编号</param>
        /// <param name="regid">入院登记号</param>
        /// <param name="currno">当前号</param>
        /// <param name="newno">flag=1 新号 2 自动生成号 3 旧号</param>
        /// <param name="zycs">flag=3时旧号次数+1</param>
        /// <param name="miflag">多次住院标志</param>
        /// <param name="sameflag">同一病人标志</param>
        /// <param name="type">0 住院号->住院号 1 住院号->留观号 2 留观号->留观号 3 留观号->住院号</param>
        /// <param name="flag">1 新建 2 自动 3 合并</param>
        /// <param name="operid">修改操作员ID</param>
        /// <returns>true 成功 false 失败</returns>
        public bool m_blnModifyNewNO(string patientid, string regid, string currno, ref string newno, int zycs, bool miflag, bool sameflag, int type, int flag, string operid)
        {
            com.digitalwave.iCare.middletier.HIS.clsModifyZyh objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsModifyZyh)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsModifyZyh));

            bool b = objSvc.m_blnModifyNewNO(patientid, regid, currno, ref newno, zycs, miflag, sameflag, type, flag, operid);
            objSvc.Dispose();

            return b;
        }
        #endregion

        #region 根据病人ID和当前入院性质(普通住院、留观住院)获取对应得(留观、住院)历史记录
        /// <summary>
        /// 根据病人ID和当前入院性质(普通住院、留观住院)获取对应得(留观、住院)历史记录
        /// </summary>
        /// <param name="pid">病人ID</param>
        /// <param name="type">入院类型 1 普通住院 2 留观住院</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetHistoryinfoByPID(string pid, int type, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsModifyZyh objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsModifyZyh)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsModifyZyh));

            long l = objSvc.m_lngGetHistoryinfoByPID(pid, type, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion
    }
}
