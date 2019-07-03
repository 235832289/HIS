using System;
using System.Collections.Generic;
using System.Text;
using iCareData;
using com.digitalwave.PartogramService;

namespace iCare
{
    public class clsPartogramDomain
    {
        /// <summary>
        /// 添加主记录
        /// </summary>
        /// <param name="p_objMain"></param>
        /// <param name="p_objContent"></param>
        /// <returns></returns>
        public long m_lngAddNewMain(clsPartogramMain_VO p_objMain,clsPartogramContent_VO p_objContent)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngAddNewMain(null,p_objMain,p_objContent);
            return lngRes;
        }
        /// <summary>
        /// 修改主记录
        /// </summary>
        /// <param name="p_objMain"></param>
        /// <param name="p_objContent"></param>
        /// <returns></returns>
        public long m_lngModifyMain(clsPartogramMain_VO p_objMain, clsPartogramContent_VO p_objContent)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngModifyMain(null, p_objMain, p_objContent);
            return lngRes;
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        /// <param name="p_dtmCreatedDate"></param>
        /// <returns></returns>
        public long m_lngDeleteMain(string p_strRegisterId, DateTime p_dtmCreatedDate)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngDeleteMain(null, p_strRegisterId, p_dtmCreatedDate, clsEMRLogin.LoginInfo.m_strEmpID);
            return lngRes;
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        /// <param name="p_objContent"></param>
        /// <returns></returns>
        public long m_lngGetValues(string p_strRegisterId,out clsPartogramAll_VO p_objContent)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngGetValues(null, p_strRegisterId,out p_objContent);
            return lngRes;
        }
        /// <summary>
        /// 获取全部的小时记录
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        /// <param name="p_objContentArr"></param>
        /// <returns></returns>
        public long m_lngGetAllHourValues(string p_strRegisterId, out clsPartogram_VO[] p_objContentArr)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngGetAllHourValues(null, p_strRegisterId, out p_objContentArr);
            return lngRes;
        }
        /// <summary>
        /// 返回一个小时的记录
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        /// <param name="p_dtmCreatedDate"></param>
        /// <param name="p_intSelectedHour"></param>
        /// <param name="p_objContent"></param>
        /// <returns></returns>
        public long m_lngGetOneHourValues(string p_strRegisterId,int p_intSelectedHour, out clsPartogram_VO p_objContent)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngGetOneHourValues(null, p_strRegisterId, p_intSelectedHour, out p_objContent);
            return lngRes;
        }
        /// <summary>
        /// 返回一个小时的点记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterId"></param>
        /// <param name="p_intSelectedHour"></param>
        /// <param name="p_objContentArr"></param>
        /// <returns></returns>
        public long m_lngGetOneHourPointValues( string p_strRegisterId, int p_intSelectedHour, out clsPartogram_Point[] p_objContentArr)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngGetOneHourPointValues(null, p_strRegisterId, p_intSelectedHour, out p_objContentArr);
            return lngRes;
        }
        /// <summary>
        /// 添加一个小时的记录
        /// </summary>
        /// <param name="p_objSub"></param>
        /// <returns></returns>
        public long m_lngAddNewSub(clsPartogram_VO p_objSub)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngAddNewSub(null, p_objSub);
            return lngRes;
        }
        /// <summary>
        /// 修改一个小时的记录
        /// </summary>
        /// <param name="p_objSub"></param>
        /// <returns></returns>
        public long m_lngModifySub(clsPartogram_VO p_objSub, int p_intPartogarm)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngModifySub(null, p_objSub,p_intPartogarm);
            return lngRes;
        }
        /// <summary>
        /// 删除一个小时的记录
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        /// <param name="p_dtmCreatedDate"></param>
        /// <param name="p_intHour"></param>
        /// <param name="p_strEmpId"></param>
        /// <param name="p_dtmDeactiveDate"></param>
        /// <returns></returns>
        public long m_lngDeleteHour(string p_strRegisterId, DateTime p_dtmCreatedDate,int p_intHour,string p_strEmpId,DateTime p_dtmDeactiveDate)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngDeleteHour(null,p_strRegisterId, p_dtmCreatedDate,p_intHour,p_strEmpId,p_dtmDeactiveDate);
            return lngRes;
        }
        /// <summary>
        /// 对一组点记录做处理
        /// m_intSTATUS_INT ＝0为删除
        /// m_intSTATUS_INT ＝ 1 为增加
        /// m_intSTATUS_INT  ＝ 2 为修改（先作废再添加）
        /// </summary>
        /// <param name="p_objPointArr"></param>
        /// <returns></returns>
        public long m_lngSetPointToDb(clsPartogram_Point[] p_objPointArr)
        {
            clsPartogramService objServ =
                (clsPartogramService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPartogramService));

            long lngRes = objServ.m_lngSetPointToDb(null, clsEMRLogin.LoginInfo.m_strEmpID, p_objPointArr);
            return lngRes;
        }
    }
}
