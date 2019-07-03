using System;
using com.digitalwave.InPatientCaseHistoryServ; 
using com.digitalwave.clsRecordsService; 
using iCareData ;
using com.digitalwave.BaseCaseHistorySevice;

namespace iCare
{
	/// <summary>
	/// // 类似住院病历具有相同功能、结构之类模块。使用该类，把具体领域层的生成和界面分离。
	/// </summary>
	public abstract class clsCaseHistoryFactory
	{
		// 获取指定特殊记录的领域层。
        public static clsBaseCaseHistorySevice s_objGetDomain(enmBaseCaseHistoryTypeInfo p_enmProcessType)
		{
			switch(p_enmProcessType)
			{
                case enmBaseCaseHistoryTypeInfo.InPatientCaseHistory:
                    {
                        clsInPatientCaseHistoryServ objServ =
                            (clsInPatientCaseHistoryServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientCaseHistoryServ));
                        return objServ;
                    }
                    //return new clsInPatientCaseHistoryServ();
                case enmBaseCaseHistoryTypeInfo.NewBabyInRoomRecord:
                    {
                        clsNewBabyInRoomRecordService objServ =
                            (clsNewBabyInRoomRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsNewBabyInRoomRecordService));
                        return objServ;
                    }
                    //return new clsNewBabyInRoomRecordService();
                case enmBaseCaseHistoryTypeInfo.RegisterQuantity_VO:
                    {
                        clsRegisterQuantityService objServ =
                            (clsRegisterQuantityService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsRegisterQuantityService));
                        return objServ;
                    }
                    //return new clsRegisterQuantityService();
                case enmBaseCaseHistoryTypeInfo.AYQBabyAssessmentRecord:
                    {
                        clsAYQBabyAssessmenEspRecordService objServ =
                            (clsAYQBabyAssessmenEspRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsAYQBabyAssessmenEspRecordService));
                        return objServ;
                    }
                case enmBaseCaseHistoryTypeInfo.BrothRecords_F2:
                    {
                        clsBrothRecords_F2Service objServ =
                            (clsBrothRecords_F2Service)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2Service));
                        return objServ;
                    }
                case enmBaseCaseHistoryTypeInfo.GestationMisbirthsthreeRec_CS:
                    {
                        clsGestationMisbirthsthreeRelationVOService objServ =
                            (clsGestationMisbirthsthreeRelationVOService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsGestationMisbirthsthreeRelationVOService));
                        return objServ;
                    }
			}
			return null;
		}
	}
}
