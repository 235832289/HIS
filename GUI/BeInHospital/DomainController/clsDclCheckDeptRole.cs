using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 
    /// </summary>
    class clsDclCheckDeptRole : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region  ����
        /// <summary>
        ///  ����
        /// </summary>
        /// <param name="p_strRoleId"></param>
        /// <param name="p_strApllyType"></param>
        /// <param name="p_strOperatorId"></param>
        /// <returns></returns>
        public long InsertNewRow(string p_strRoleId, string p_strApllyType, string p_strOperatorId, out string p_strSeq)
        {
            com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc));
            return objSvc.InsertNewRow(objPrincipal, p_strRoleId, p_strApllyType, p_strOperatorId, out p_strSeq);
        }
        #endregion

        #region  ɾ��
        /// <summary>
        ///  ɾ��
        /// </summary>
        /// <param name="p_strSeq"></param>
        /// <returns></returns>
        public long DeleteRow(string p_strSeq)
        {
            com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc));
            return objSvc.DeleteRow(objPrincipal, p_strSeq);
        }
        #endregion

        #region  ����Ȩ��ID��ȡ��Ӧ��Ϣ
        /// <summary>
        ///  ����Ȩ��ID��ȡ��Ӧ��Ϣ
        /// </summary>
        /// <param name="p_strRoleId"></param>
        /// <returns></returns>
        public long SelectByRoleId(string p_strRoleId, out DataTable p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc));
            return objSvc.SelectCheckDeptByRoleId(objPrincipal, p_strRoleId, out p_objResult);
        }
        #endregion

        #region  ȡ���н�ɫ��Ϣ
        /// <summary>
        ///  ȡ���н�ɫ��Ϣ
        /// </summary>
        /// <returns></returns>
        public long GetAllRole(out DataTable p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc));
            return objSvc.GetAllRole(objPrincipal, out p_objResult);
        }
        #endregion

        #region  ȡ���м��������Ϣ
        /// <summary>
        ///  ȡ���м��������Ϣ
        /// </summary>
        /// <returns></returns>
        public long GetAllApplyType(out DataTable p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCheckDeptRoleSvc));
            return objSvc.GetAllApplyType(objPrincipal, out p_objResult);
        }
        #endregion
    }
}
