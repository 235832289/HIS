using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
//新增下面的
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 医嘱上限判断	逻辑控制层
	/// 作者： 
    /// 创建时间： 2006-4-6
	/// </summary>
    class clsDcl_OrderSaveCheck : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取医嘱-全部
        public long ConfirmMaxValue(string EMPNO_CHR, string PSW_CHR, double maxvalue, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService));
            lngRes = objSvc.ConfirmMaxValue(EMPNO_CHR, PSW_CHR, maxvalue, out dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 确认员工/密码
        public long ConfirmPassWord(string EMPNO_CHR, string PSW_CHR, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService));
            lngRes = objSvc.ConfirmPassWord(EMPNO_CHR, PSW_CHR, out dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
    }
}
