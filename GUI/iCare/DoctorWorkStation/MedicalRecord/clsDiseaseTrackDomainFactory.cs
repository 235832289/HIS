using System;
using iCareData;
using com.digitalwave.DiseaseTrackService;

namespace iCare
{
	/// <summary>
	/// 生成病程记录领域层的类。使用该类，把具体领域层的生成和界面分离。
	/// </summary>
	public abstract class clsDiseaseTrackDomainFactory
	{

		/// <summary>
		/// 获取指定特殊记录的领域层。
		/// </summary>
		/// <param name="p_enmProcessType"></param>
		/// <returns></returns>
        public static clsDiseaseTrackService s_objGetDiseaseTrackDomain(enmDiseaseTrackType p_enmProcessType)
		{
			switch(p_enmProcessType)
			{
                case enmDiseaseTrackType.GeneralDisease:
                    {
                        clsGeneralDiseaseService objServ =
                            (clsGeneralDiseaseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsGeneralDiseaseService));
                        return objServ;
                    }
                    //return new clsGeneralDiseaseService();
                case enmDiseaseTrackType.IntensiveTend:
                    {
                        com.digitalwave.IntensiveTendRecordService.clsIntensiveTendRecordService objServ =
                            (com.digitalwave.IntensiveTendRecordService.clsIntensiveTendRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.IntensiveTendRecordService.clsIntensiveTendRecordService));
                        return objServ;
                    }
                    //return new com.digitalwave.IntensiveTendRecordService.clsIntensiveTendRecordService();
                case enmDiseaseTrackType.GeneralNurseRecord:
                    {
                        clsGeneralNurseRecordService objServ =
                            (clsGeneralNurseRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsGeneralNurseRecordService));
                        return objServ;
                    }
                    //return new clsGeneralNurseRecordService();					
                case enmDiseaseTrackType.WatchItem:
                    {
                        com.digitalwave.clsSubWatchItemRecordService.clsSubWatchItemRecordService objServ =
                            (com.digitalwave.clsSubWatchItemRecordService.clsSubWatchItemRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsSubWatchItemRecordService.clsSubWatchItemRecordService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsSubWatchItemRecordService.clsSubWatchItemRecordService();					
                case enmDiseaseTrackType.HandOver:
                    {
                        clsHandOverService objServ =
                            (clsHandOverService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHandOverService));
                        return objServ;
                    }
                    //return new clsHandOverService();
                case enmDiseaseTrackType.TakeOver:
                    {
                        clsTakeOverService objServ =
                            (clsTakeOverService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsTakeOverService));
                        return objServ;
                    }
                    //return new clsTakeOverService();
                case enmDiseaseTrackType.Consultation:
                    {
                        clsConsultationService objServ =
                            (clsConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsConsultationService));
                        return objServ;
                    }
                    //return new clsConsultationService();
                case enmDiseaseTrackType.Convey:
                    {
                        clsConveyService objServ =
                            (clsConveyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsConveyService));
                        return objServ;
                    }
                    //return new clsConveyService();
                case enmDiseaseTrackType.TurnIn:
                    {
                        clsTurnInService objServ =
                            (clsTurnInService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsTurnInService));
                        return objServ;
                    }
                    //return new clsTurnInService();
                case enmDiseaseTrackType.DiseaseSummary:
                    {
                        clsDiseaseSummaryService objServ =
                            (clsDiseaseSummaryService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDiseaseSummaryService));
                        return objServ;
                    }
                    //return new clsDiseaseSummaryService();
                case enmDiseaseTrackType.CheckRoom:
                    {
                        clsCheckRoomService objServ =
                            (clsCheckRoomService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCheckRoomService));
                        return objServ;
                    }
                    //return new clsCheckRoomService();
                case enmDiseaseTrackType.CaseDiscuss:
                    {
                        clsCaseDiscussService objServ =
                            (clsCaseDiscussService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseDiscussService));
                        return objServ;
                    }
                    //return new clsCaseDiscussService();
                case enmDiseaseTrackType.BeforeOperationDiscuss:
                    {
                        clsBeforeOperationDiscussService objServ =
                            (clsBeforeOperationDiscussService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationDiscussService));
                        return objServ;
                    }
                    //return new clsBeforeOperationDiscussService();
                case enmDiseaseTrackType.Dead:
                    {
                        clsDeadRecordService objServ =
                            (clsDeadRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDeadRecordService));
                        return objServ;
                    }
                    //return new clsDeadRecordService();
                case enmDiseaseTrackType.Death:
                    {
                        clsDeathRecordService objServ =
                            (clsDeathRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDeathRecordService));
                        return objServ;
                    }
                    //return new clsDeathRecordService();
                case enmDiseaseTrackType.OutHospital:
                    {
                        clsOutHospitalService objServ =
                            (clsOutHospitalService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOutHospitalService));
                        return objServ;
                    }
                    //return new clsOutHospitalService();
				case  enmDiseaseTrackType.DeadCaseDiscuss:
                    {
                        clsDeadCaseDiscussService objServ =
                            (clsDeadCaseDiscussService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDeadCaseDiscussService));
                        return objServ;
                    }
                    //return new clsDeadCaseDiscussService();
				case enmDiseaseTrackType.DeathCaseDiscuss:
                    {
                        clsDeathCaseDiscussService objServ =
                            (clsDeathCaseDiscussService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDeathCaseDiscussService));
                        return objServ;
                    }
                    //return new clsDeathCaseDiscussService();
				case  enmDiseaseTrackType.AfterOperation:
                    {
                        clsAfterOperationService objServ =
                            (clsAfterOperationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsAfterOperationService));
                        return objServ;
                    }
                    //return new clsAfterOperationService();
				case  enmDiseaseTrackType.Save:
                    {
                        clsSaveRecordService objServ =
                            (clsSaveRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSaveRecordService));
                        return objServ;
                    }
                    //return new clsSaveRecordService();
				case  enmDiseaseTrackType.ICUIntensiveTend:
                    {
                        com.digitalwave.clsSubICUIntensiveTendService.clsSubICUIntensiveTendService objServ =
                            (com.digitalwave.clsSubICUIntensiveTendService.clsSubICUIntensiveTendService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsSubICUIntensiveTendService.clsSubICUIntensiveTendService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsSubICUIntensiveTendService.clsSubICUIntensiveTendService();			
				case  enmDiseaseTrackType.ICUBreath:
                    {
                        com.digitalwave.clsSubICUBreathService.clsSubICUBreathService objServ =
                            (com.digitalwave.clsSubICUBreathService.clsSubICUBreathService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsSubICUBreathService.clsSubICUBreathService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsSubICUBreathService.clsSubICUBreathService();			
				case  enmDiseaseTrackType.AnaesthesiaPlan:
                    {
                        com.digitalwave.iCare.middletier.Anaesthesia.clsAnaesthesia_PlanService objServ =
                            (com.digitalwave.iCare.middletier.Anaesthesia.clsAnaesthesia_PlanService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.Anaesthesia.clsAnaesthesia_PlanService));
                        return objServ;
                    }
                    //return new com.digitalwave.Anaesthesia_PlanService.clsAnaesthesia_PlanService();			
				case  enmDiseaseTrackType.AnaesthesiaConfirm:
                    {
                        com.digitalwave.iCare.middletier.Anaesthesia.clsAnaesthesia_ConfirmService objServ =
                            (com.digitalwave.iCare.middletier.Anaesthesia.clsAnaesthesia_ConfirmService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.Anaesthesia.clsAnaesthesia_ConfirmService));
                        return objServ;
                    }
                    //return new com.digitalwave.Anaesthesia_ConfirmService.clsAnaesthesia_ConfirmService();			
				case  enmDiseaseTrackType.OperationRequisition:
                    {
                        com.digitalwave.iCare.middletier.Anaesthesia.clsOperationRequisitionService objServ =
                            (com.digitalwave.iCare.middletier.Anaesthesia.clsOperationRequisitionService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.Anaesthesia.clsOperationRequisitionService));
                        return objServ;
                    }
                    //return new com.digitalwave.OperationRequisitionService.clsOperationRequisitionService();			
				case enmDiseaseTrackType.AnaCollection:
                    {
                        com.digitalwave.iCare.middletier.Anaesthesia.clsAnaParamSettingService objServ =
                            (com.digitalwave.iCare.middletier.Anaesthesia.clsAnaParamSettingService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.Anaesthesia.clsAnaParamSettingService));
                        return objServ;
                    }
                    //return new com.digitalwave.AnaParamSettingService.clsAnaParamSettingService();
				case enmDiseaseTrackType.PCARegister:
                    {
                        com.digitalwave.iCare.middletier.Anaesthesia.clsAnaPCARegisterService objServ =
                            (com.digitalwave.iCare.middletier.Anaesthesia.clsAnaPCARegisterService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.Anaesthesia.clsAnaPCARegisterService));
                        return objServ;
                    }
                    //return new com.digitalwave.AnaPCARegisterService.clsAnaPCARegisterService();
//				case enmDiseaseTrackType.AnaesthesiaConfirm:
//					return new com.digitalwave.Anaesthesia_ConfirmService.clsAnaesthesia_ConfirmService();
                case enmDiseaseTrackType.FirstIllnessNote:
                    {
                        clsFirstIllnessNoteService objServ =
                            (clsFirstIllnessNoteService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsFirstIllnessNoteService));
                        return objServ;
                    }
                    //return new clsFirstIllnessNoteService();
				case enmDiseaseTrackType.GeneralNurseRecord_GX:
                    {
                        com.digitalwave.clsGeneralNurseRecord_GXService.clsGeneralNurseRecord_GXService objServ =
                            (com.digitalwave.clsGeneralNurseRecord_GXService.clsGeneralNurseRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsGeneralNurseRecord_GXService.clsGeneralNurseRecord_GXService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsGeneralNurseRecord_GXService.clsGeneralNurseRecord_GXService();
                case enmDiseaseTrackType.ICUNurseRecord_GX:
                    {
                        com.digitalwave.clsICUNurseRecord_GXService.clsICUNurseRecord_GXService objServ =
                            (com.digitalwave.clsICUNurseRecord_GXService.clsICUNurseRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsICUNurseRecord_GXService.clsICUNurseRecord_GXService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsICUNurseRecord_GXService.clsICUNurseRecord_GXService();
                case enmDiseaseTrackType.IntensiveTendRecord_GX:
                    {
                        com.digitalwave.clsIntensiveTendRecord_GXService.clsIntensiveTendRecord_GXService objServ =
                            (com.digitalwave.clsIntensiveTendRecord_GXService.clsIntensiveTendRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsIntensiveTendRecord_GXService.clsIntensiveTendRecord_GXService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsIntensiveTendRecord_GXService.clsIntensiveTendRecord_GXService();
                case enmDiseaseTrackType.CardiovascularTend_GX:
                    {
                        com.digitalwave.clsCardiovascularTend_GXService.clsCardiovascularTend_GXService objServ =
                            (com.digitalwave.clsCardiovascularTend_GXService.clsCardiovascularTend_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsCardiovascularTend_GXService.clsCardiovascularTend_GXService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsCardiovascularTend_GXService.clsCardiovascularTend_GXService();
                case enmDiseaseTrackType.SURGERYICUWARDSHIP:
                    {
                        com.digitalwave.clsSURGERYICUWARDSHIPService.clsSURGERYICUWARDSHIPService objServ =
                            (com.digitalwave.clsSURGERYICUWARDSHIPService.clsSURGERYICUWARDSHIPService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsSURGERYICUWARDSHIPService.clsSURGERYICUWARDSHIPService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsSURGERYICUWARDSHIPService.clsSURGERYICUWARDSHIPService();
                case enmDiseaseTrackType.FirstIllnessNote_ZY:
                    {
                        clsFirstIllnessNote_ZYService objServ =
                            (clsFirstIllnessNote_ZYService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsFirstIllnessNote_ZYService));
                        return objServ;
                    }
                    //return new clsFirstIllnessNote_ZYService();
					//
                case enmDiseaseTrackType.WaitLayRecord_Acad:
                    {
                        com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService objServ =
                            (com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService();
					
					//候产记
                case enmDiseaseTrackType.PostPartum_Acad:
                    {
                        com.digitalwave.clsRecordsService.clsIcuAcad_PostPartumRecord_contentService objServ =
                            (com.digitalwave.clsRecordsService.clsIcuAcad_PostPartumRecord_contentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsIcuAcad_PostPartumRecord_contentService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsRecordsService.clsIcuAcad_PostPartumRecord_contentService();
                case enmDiseaseTrackType.HurryVeinRecord:
                    {
                        com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService objServ =
                            (com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService();
					//胎动监护表
                case enmDiseaseTrackType.QuickeningTutelar_Acad:
                    {
                        com.digitalwave.clsRecordsService.clsQuickeningTutelar_AcadService objServ =
                            (com.digitalwave.clsRecordsService.clsQuickeningTutelar_AcadService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsQuickeningTutelar_AcadService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsRecordsService.clsQuickeningTutelar_AcadService();
					///中期妊娠引产后观察记录
                case enmDiseaseTrackType.PostartumSeeRecord:
                    {
                        com.digitalwave.clsRecordsService.clsPostartumSeeRecordService objServ =
                            (com.digitalwave.clsRecordsService.clsPostartumSeeRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsPostartumSeeRecordService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsRecordsService.clsPostartumSeeRecordService();
                case enmDiseaseTrackType.OutHospitalIn24Hours:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_OutHospitalIn24HoursService objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_OutHospitalIn24HoursService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_OutHospitalIn24HoursService));
                        return objServ;
                    }
                    //return new com.digitalwave.DiseaseTrackService.clsEMR_OutHospitalIn24HoursService();
					///静脉特殊化疗用药观察记录表(广西)
                case enmDiseaseTrackType.VeinSpecialUseDrug:
                    {
                        com.digitalwave.clsRecordsService.clsVeinSpecialUseDrug_ConService objServ =
                            (com.digitalwave.clsRecordsService.clsVeinSpecialUseDrug_ConService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsVeinSpecialUseDrug_ConService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsRecordsService.clsVeinSpecialUseDrug_ConService();
					///入院24小时内死亡记录
                case enmDiseaseTrackType.DeathHospitalIn24Hours:
                    {
                        com.digitalwave.EMR_DeathRecorIn24HoursService.clsEMR_DeathRecorIn24HoursService objServ =
                            (com.digitalwave.EMR_DeathRecorIn24HoursService.clsEMR_DeathRecorIn24HoursService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.EMR_DeathRecorIn24HoursService.clsEMR_DeathRecorIn24HoursService));
                        return objServ;
                    }
                    //return new com.digitalwave.EMR_DeathRecorIn24HoursService.clsEMR_DeathRecorIn24HoursService();
                    //手术器械、敷料点数表
                case enmDiseaseTrackType.OPInstrumentQty:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_OPInstrumentService objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_OPInstrumentService));
                        return objServ;
                    }

                    //return new com.digitalwave.DiseaseTrackService.clsEMR_OPInstrumentService();
                case enmDiseaseTrackType.EMR_OPNurseRecord:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_OperationRecord_GXService objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_OperationRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_OperationRecord_GXService));
                        return objServ;
                    }

                    //return new com.digitalwave.DiseaseTrackService.clsEMR_OperationRecord_GXService();
                case enmDiseaseTrackType.EMR_PullDeliverRecord:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_PullDeliverRecordServ objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_PullDeliverRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_PullDeliverRecordServ));
                        return objServ;
                    }

                    //return new com.digitalwave.DiseaseTrackService.clsEMR_PullDeliverRecordServ();
                case enmDiseaseTrackType.EMR_CesareanRecord:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_CesareanRecordServ objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_CesareanRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_CesareanRecordServ));
                        return objServ;
                    }
                    //return new com.digitalwave.DiseaseTrackService.clsEMR_CesareanRecordServ();

                case enmDiseaseTrackType.EMR_SummaryBeforeOP:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_SummaryBeforeOPServ objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_SummaryBeforeOPServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_SummaryBeforeOPServ));
                        return objServ;
                    }
                    //return new com.digitalwave.DiseaseTrackService.clsEMR_SummaryBeforeOPServ();

                case enmDiseaseTrackType.ICUNurseRecord:
                    {
                        com.digitalwave.DiseaseTrackService.clsICUNurseService objServ =
                            (com.digitalwave.DiseaseTrackService.clsICUNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsICUNurseService));
                        return objServ;
                    }
                    //return new com.digitalwave.DiseaseTrackService.clsICUNurseService();

                case enmDiseaseTrackType.EMR_WAITLAYRECORD_GX:
                    {
                        com.digitalwave.clsEMR_WAITLAYRECORD_GXServ.clsEMR_WAITLAYRECORD_GXServ objServ =
                            (com.digitalwave.clsEMR_WAITLAYRECORD_GXServ.clsEMR_WAITLAYRECORD_GXServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsEMR_WAITLAYRECORD_GXServ.clsEMR_WAITLAYRECORD_GXServ));
                        return objServ;
                    }
                    //return new com.digitalwave.clsEMR_WAITLAYRECORD_GXServ.clsEMR_WAITLAYRECORD_GXServ();

                case enmDiseaseTrackType.EMR_OXTIntravenousDrip:
                    {
                        com.digitalwave.clsEMR_OXTIntravenousDripService.clsEMR_OXTIntravenousDripService objServ =
                            (com.digitalwave.clsEMR_OXTIntravenousDripService.clsEMR_OXTIntravenousDripService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsEMR_OXTIntravenousDripService.clsEMR_OXTIntravenousDripService));
                        return objServ;
                    }
                    //return new com.digitalwave.clsEMR_OXTIntravenousDripService.clsEMR_OXTIntravenousDripService();

                case enmDiseaseTrackType.EMR_VaginalExamination:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_VaginalExaminationServ objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_VaginalExaminationServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_VaginalExaminationServ));
                        return objServ;
                    }
                    //return new com.digitalwave.DiseaseTrackService.clsEMR_VaginalExaminationServ();

                case enmDiseaseTrackType.EMR_IntakeAndOutputVolumeSum:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeSumServ objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeSumServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeSumServ));
                        return objServ;
                    }
                    //return new com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeSumServ();

                case enmDiseaseTrackType.EMR_IntakeAndOutputVolume:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeServ objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeServ));
                        return objServ;
                    }
                    //return new com.digitalwave.DiseaseTrackService.clsEMR_IntakeAndOutputVolumeServ();

                case enmDiseaseTrackType.EMR_MicroBooldSugarCheck:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_MicroBooldSugarCheckService objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_MicroBooldSugarCheckService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_MicroBooldSugarCheckService));
                        return objServ;
                    }
                    //return new com.digitalwave.DiseaseTrackService.clsEMR_MicroBooldSugarCheckService();

                case enmDiseaseTrackType.LargeConsultation:
                    {
                        com.digitalwave.DiseaseTrackService.clsLargeConsultationService objServ =
                            (com.digitalwave.DiseaseTrackService.clsLargeConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsLargeConsultationService));
                        return objServ;
                    }
                    //return new com.digitalwave.DiseaseTrackService.clsLargeConsultationService();
                case enmDiseaseTrackType.GeneralNurseRecord_CS://危重患者护理记录茶山版（内科、妇产科、普儿科、急诊科、手术室）
                    {
                        com.digitalwave.clsGeneralNurseRecord_CSService.clsGeneralNurseRecord_CSService objServ =
                            (com.digitalwave.clsGeneralNurseRecord_CSService.clsGeneralNurseRecord_CSService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsGeneralNurseRecord_CSService.clsGeneralNurseRecord_CSService));
                        return objServ;
                    }
                case enmDiseaseTrackType.NewBorthBabyGeneralNurseRecord_CS://新生儿科一般患者护理记录
                    {
                        com.digitalwave.clsNewBorthBabyGeneralNurseRecord_CSService.clsNewBorthBabyGeneralNurseRecord_CSService objServ =
                            (com.digitalwave.clsNewBorthBabyGeneralNurseRecord_CSService.clsNewBorthBabyGeneralNurseRecord_CSService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsNewBorthBabyGeneralNurseRecord_CSService.clsNewBorthBabyGeneralNurseRecord_CSService));
                        return objServ;
                    }
                case enmDiseaseTrackType.GeneralNurseRecordWK_CS://一般患者护理记录（外科）
                    {
                        com.digitalwave.clsGeneralNurseRecordWK_CSService.clsGeneralNurseRecordWK_CSService objServ =
                            (com.digitalwave.clsGeneralNurseRecordWK_CSService.clsGeneralNurseRecordWK_CSService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsGeneralNurseRecordWK_CSService.clsGeneralNurseRecordWK_CSService));
                        return objServ;
                    }
                case enmDiseaseTrackType.FetalCustodialRecord://胎儿电子监护记录
                    {
                        com.digitalwave.DiseaseTrackService.clsFetalCustodialRecordService objServ =
                            (com.digitalwave.DiseaseTrackService.clsFetalCustodialRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsFetalCustodialRecordService));
                        return objServ;
                    }
                case enmDiseaseTrackType.IntensivetendRecord_CS://新生儿科危重患者护理记录
                    {
                        com.digitalwave.clsIntensivetendRecord_CSService.clsIntensivetendRecord_CSService objServ =
                            (com.digitalwave.clsIntensivetendRecord_CSService.clsIntensivetendRecord_CSService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsIntensivetendRecord_CSService.clsIntensivetendRecord_CSService));
                        return objServ;
                    }
                case enmDiseaseTrackType.IntensiveTendMain_CSWK://危重患者护理记录（茶山外科）
                    {
                        com.digitalwave.clsIntensiveTendMain_CSWKService.clsIntensiveTendMain_CSWKService objServ =
                            (com.digitalwave.clsIntensiveTendMain_CSWKService.clsIntensiveTendMain_CSWKService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsIntensiveTendMain_CSWKService.clsIntensiveTendMain_CSWKService));
                        return objServ;
                    }
                case enmDiseaseTrackType.GeneralNurseRecord_DGCS://一般患者护理记录茶山版（内科、妇产科、普儿科）
                    {
                        com.digitalwave.clsGeneralNurseRecord_DGCSService.clsGeneralNurseRecord_DGCSService objServ =
                            (com.digitalwave.clsGeneralNurseRecord_DGCSService.clsGeneralNurseRecord_DGCSService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsGeneralNurseRecord_DGCSService.clsGeneralNurseRecord_DGCSService));
                        return objServ;
                    }
                case enmDiseaseTrackType.GeneralNurseRecord_ObstetricNewChild://一般患者护理记录茶山版（产科新生儿）
                    {
                        com.digitalwave.clsGeneralNurseRecord_CSObstetricNewChildService.clsGeneralNurseRecord_CSObstetricNewChildService objServ =
                            (com.digitalwave.clsGeneralNurseRecord_CSObstetricNewChildService.clsGeneralNurseRecord_CSObstetricNewChildService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsGeneralNurseRecord_CSObstetricNewChildService.clsGeneralNurseRecord_CSObstetricNewChildService));
                        return objServ;
                    }
                case enmDiseaseTrackType.AYQBabyAssessmentRecord://爱婴区婴儿评估表
                    {
                        com.digitalwave.InPatientCaseHistoryServ.clsAYQBabyAssessmentRecordService objServ =
                            (com.digitalwave.InPatientCaseHistoryServ.clsAYQBabyAssessmentRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InPatientCaseHistoryServ.clsAYQBabyAssessmentRecordService));
                        return objServ;
                    }
                    //血糖观察表
                case enmDiseaseTrackType.EMR_IntBloodSugarWatch:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_intbloodsugarwatchServ objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_intbloodsugarwatchServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_intbloodsugarwatchServ));
                        return objServ;
                    }
                    //佛二肾内风湿科血液净化记录表
                case enmDiseaseTrackType.frmBloodCleanseRecord:
                    {
                        com.digitalwave.clsRecordsService.clsBloodCleanseRecord_contentService objServ =
                            (com.digitalwave.clsRecordsService.clsBloodCleanseRecord_contentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsBloodCleanseRecord_contentService));
                        return objServ;
                    }
                //佛二妊娠糖尿病治疗表
                case enmDiseaseTrackType.EMR_GestationDiabetesCure:
                    {
                        com.digitalwave.DiseaseTrackService.clsEMR_GestationDiabetesCureService objServ =
                            (com.digitalwave.DiseaseTrackService.clsEMR_GestationDiabetesCureService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_GestationDiabetesCureService));
                        return objServ;
                    }
                //佛二妊娠糖尿病治疗表
                case enmDiseaseTrackType.GestationMisbirthsthree_CS:
                    {
                        com.digitalwave.InPatientCaseHistoryServ.clsGestationMisbirthsthreeRecService objServ =
                            (com.digitalwave.InPatientCaseHistoryServ.clsGestationMisbirthsthreeRecService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InPatientCaseHistoryServ.clsGestationMisbirthsthreeRecService));
                        return objServ;
                    }
			}
			return null;
		}

	}// END CLASS DEFINITION clsDiseaseTrackDomainFactory
}
