using System;
using com.digitalwave.InPatientArchivingService;
using iCareData;
namespace iCare
{
    /// <summary>
    /// Summary description for clsInPatientArchivingDomain.
    /// </summary>
    public class clsInPatientArchivingDomain
    {

        //		clsInPatientArchivingService m_objServ=new clsInPatientArchivingService();
        public clsInPatientArchivingDomain()
        {
        }
        //
        // TODO: Add constructor logic here
        //

        //		public long lngGetOneRecord(string p_strInPatientID,string p_strInPatientDate,out clsInPatientArchivingValue p_objArchivingValue)
        //		{
        //			return m_objServ.lngGetOneRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,out p_objArchivingValue);
        //		}

        /// <summary>
        /// 按住院号查询病人出院状态
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_intStatus">如果p_intStatus=0则查询未归档的病人，>=1则查询已归档病人,= -1查询全部</param>
        /// <param name="p_objArchivingValueArr"></param>
        /// <returns></returns>
        public long lngGetRecordByInPatientIDArr(string p_strInPatientID, string p_strInPatientDate, int p_intStatus, out clsInPatientArchivingValue p_objArchivingValue)
        {
            clsInPatientArchivingService objServ =
                (clsInPatientArchivingService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientArchivingService));

            return objServ.lngGetRecordByInPatientIDArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_intStatus, out p_objArchivingValue);
        }

        /// <summary>
        /// 按住院号模糊查询特定科室下7天那出院病人
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strDeptIDArr">临床科室列表，查询全院的置</param>
        /// <param name="p_intStatus">如果p_intStatus=0则查询未归档的病人，>=1则查询已归档病人,= -1查询全部</param>
        /// <param name="p_objArchivingValueArr"></param>
        /// <returns></returns>
        public long lngGetArchiveByInPatientIDLikeArr(string p_strInPatientID, string[] p_strDeptIDArr, int p_intStatus, out clsInPatientArchivingValue[] p_objArchivingValueArr)
        {
            clsInPatientArchivingService objServ =
                (clsInPatientArchivingService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientArchivingService));

            return objServ.lngGetRecordByInPatientIDLikeArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strDeptIDArr, p_intStatus, out p_objArchivingValueArr);
        }
        /// <summary>
        /// 按病人姓名模糊查询特定科室下7天那出院病人
        /// </summary>
        /// <param name="p_strInPatientName"></param>
        /// <param name="p_strDeptIDArr">临床科室列表，查询全院的置null</param>
        /// <param name="p_intStatus">如果p_intStatus=0则查询未归档的病人，>=1则查询已归档病人,= -1查询全部</param>
        /// <param name="p_objArchivingValueArr"></param>
        /// <returns></returns>
        public long lngGetArchiveByInPatientNameLikeArr(string p_strInPatientName, string[] p_strDeptIDArr, int p_intStatus, out clsInPatientArchivingValue[] p_objArchivingValueArr)
        {

            clsInPatientArchivingService objServ =
                    (clsInPatientArchivingService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientArchivingService));

            return objServ.lngGetRecordByInPatientNameLikeArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientName, p_strDeptIDArr, p_intStatus, out p_objArchivingValueArr);
        }
        /// <summary>
        /// 获取特定临床科室下7天内出院病人列表
        /// </summary>
        /// <param name="p_strDeptIDArr">临床科室列表，查询全院的置null</param>
        /// <param name="p_intStatus">如果p_intStatus=0则查询未归档的病人，>=1则查询已归档病人,= -1查询全部</param>
        /// <param name="p_objArchivingValueArr"></param>
        /// <returns></returns>
        public long lngGetRecordWithin7DayByEmpDeptArr(string[] p_strDeptIDArr, int p_intStatus, out clsInPatientArchivingValue[] p_objArchivingValueArr)
        {
            clsInPatientArchivingService objServ =
                (clsInPatientArchivingService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientArchivingService));

            return objServ.lngGetRecordWithin7DayByEmpDeptArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strDeptIDArr, p_intStatus, out p_objArchivingValueArr);
        }

        /// <summary>
        /// 让窗体在打开病人的单时作判断。此判断要查数据库，现在只在frmHRPBaseForm中调用此函数
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_blnIsReadOnly"></param>
        /// <param name="p_strTimeRemaining"></param>
        /// <returns></returns>
        public long lngIsReadOnly(string p_strInPatientID, string p_strInPatientDate, out bool p_blnIsReadOnly, out string p_strTimeRemaining)
        {
            p_strTimeRemaining = null;
            p_blnIsReadOnly = false;
            //超时未归档或已归档的都应设为只读
            clsInPatientArchivingValue objValue = null;

            clsInPatientArchivingService objServ =
                (clsInPatientArchivingService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientArchivingService));

            long lngRes = objServ.m_lngCheckFormReadOnly(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, out objValue);
            if (lngRes <= 0) return lngRes;
            if (objValue != null)
            {
                if (objValue.m_strIfArchived == "1")
                {
                    p_blnIsReadOnly = true;
                }
                else
                {
                    //int intLeaveDay = int.Parse(objValue.m_strLeaveDay);
                    if (objValue.m_intLeaveDay < 0 || (objValue.m_intLeaveDay == 0 && objValue.m_intLeaveHour <= 0))
                        p_blnIsReadOnly = true;
                    else
                        p_blnIsReadOnly = false;
                    p_strTimeRemaining = objValue.m_intLeaveDay.ToString() + "天" + objValue.m_intLeaveHour.ToString() + "小时";
                }

            }

            return lngRes;
        }

        /// <summary>
        /// 归档
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_blnSetArchived"></param>
        /// <returns></returns>
        public long lngSetArchived(string p_strInPatientID, string p_strInPatientDate, out string[] p_strIsArchived)
        {
            clsInPatientArchivingService objServ =
                (clsInPatientArchivingService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientArchivingService));

            long lngRes = objServ.lngSetArchived(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, clsEMRLogin.LoginInfo.m_strEmpID, out p_strIsArchived);

            return lngRes;
        }
        public long lngCancelArchived(string p_strInPatientID, string p_strInPatientDate)
        {
            clsInPatientArchivingService objServ =
                (clsInPatientArchivingService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientArchivingService));

            long lngRes = objServ.lngUnsetArchived(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, clsEMRLogin.LoginInfo.m_strEmpID);

            return lngRes;
        }
        /// <summary>
        /// 判断该病案是否超时未归档，要查数据库。
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_blnIsOverTime"></param>
        /// <returns></returns>
        public long lngIfOverTime(string p_strInPatientID, string p_strInPatientDate, out bool p_blnIsOverTime)
        {
            p_blnIsOverTime = false;
            //			clsInPatientArchivingValue objValue=null;
            //			long lngRes=new clsInPatientArchivingService().lngGetOneRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,out objValue);
            //			if(lngRes<=0)return lngRes;
            //			if(objValue!=null)
            //			{
            //				if(objValue.m_strIfArchived=="1")
            //				{
            //					p_blnIsOverTime=false;
            //				}
            //				else if(objValue.m_strEndReason=="0" || objValue.m_strEndReason=="2")
            //				{
            //					TimeSpan objSpan= DateTime.Parse( new clsPublicDomain().m_strGetServerTime())-DateTime.Parse( objValue.m_strInPatientEndDate);
            //					if(objSpan.TotalHours>24) p_blnIsOverTime=true;	
            //					else
            //					{
            //						p_blnIsOverTime=false;
            //					}															   
            //				}
            //				else if(objValue.m_strEndReason=="1" )
            //				{
            //					TimeSpan objSpan= DateTime.Parse( new clsPublicDomain().m_strGetServerTime())-DateTime.Parse( objValue.m_strInPatientEndDate);
            //					if(objSpan.TotalHours>6) p_blnIsOverTime= true;	
            //					else
            //					{
            //						p_blnIsOverTime=false;
            //					}
            //				}
            //				
            //			}

            return 0;//lngRes;
        }
        /// <summary>
        /// 判断该病案是否超时，这个函数不查数据库
        /// </summary>
        /// <param name="p_objArchivingValue"></param>
        /// <returns></returns>
        public bool m_blnIfOverTime(clsInPatientArchivingValue p_objArchivingValue)
        {
            if (p_objArchivingValue == null || p_objArchivingValue.m_strIfArchived == "1") return false;
            if (p_objArchivingValue.m_strEndReason == "0" || p_objArchivingValue.m_strEndReason == "2")
            {
                TimeSpan objSpan = DateTime.Parse(new clsPublicDomain().m_strGetServerTime()) - DateTime.Parse(p_objArchivingValue.m_strInPatientEndDate);
                if (objSpan.TotalHours > (24 * 7)) return true;
            }
            else if (p_objArchivingValue.m_strEndReason == "1")
            {
                TimeSpan objSpan = DateTime.Parse(new clsPublicDomain().m_strGetServerTime()) - DateTime.Parse(p_objArchivingValue.m_strInPatientEndDate);
                if (objSpan.TotalHours > 6) return true;
            }
            return false;

        }

    }
}

