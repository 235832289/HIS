

using System;

namespace iCare
{
    /// <summary>
    /// 专科病历打印工具类工厂
    /// </summary>
    public class clsInpatMedRecPrintToolFactory
    {
        public clsInpatMedRecPrintToolFactory()
        {
        }


        /// <summary>
        /// 生产打印工具
        /// </summary>
        /// <param name="p_strTypeID"></param>
        /// <returns></returns> 
        public static clsInpatMedRecPrintBase s_objGeneratePrintTool(string p_strTypeID)
        {
            switch (p_strTypeID)
            {
                case "frmIMR_ChestSurgery_I":
                case "frmIMR_ChestSurgery_II":
                case "frmIMR_ChestSurgery_III":
                    return new clsIMR_ChestSurgeryPrintTool(p_strTypeID);
                case "frmIMR_Cardiovascular":
                    return new clsIMR_CardiovascularPrintTool(p_strTypeID);
                case "frmIMR_Gynecology":
                    return new clsIMR_GynecologyPrintTool(p_strTypeID);
                case "frmIMR_Obstetric":
                    return new clsIMR_ObstetricPrintTool(p_strTypeID);
                case "frmIMR_Ophthalmology":
                    return new clsIMR_OphthalmologyPrintTool(p_strTypeID);
                case "frmIMR_Neurosurgery":
                    return new clsIMR_NeurosurgeryPrintTool(p_strTypeID);
                case "frmIMR_Herbalism":
                    return new clsIMR_HerbalismPrintTool(p_strTypeID);
                case "frmIMR_Herbalist_Western":
                    return new clsIMR_Herbalist_WestPrintTool(p_strTypeID);
                case "frmIMR_Paediatrics":
                    return new clsIMR_PaediatricsPrintTool(p_strTypeID);
                case "frmIMR_Neonatal":
                    return new clsIMR_NeonatalPrintTool(p_strTypeID);
                case "frmIMR_BurnSuergery":
                    return new clsIMR_BurnSuergeryPrintTool(p_strTypeID);
                case "frmIMR_StoIntesChirurgeryl":
                    return new clsIMR_StoIntesChirurgerylPrintTool(p_strTypeID);
                case "frmIMR_Neuromedicine":
                    return new clsIMR_NeuromedicinePrintTool(p_strTypeID);
                case "frmIMR_GestationMisbirth_1": 
                    return new clsIMR_GestationMisbirth_1PrintTool(p_strTypeID);
                case "frmIMR_GestationMisbirth_2":
                    return new clsIMR_GestationMisbirth_2PrintTool(p_strTypeID);
                case "frmIMR_GestationMisbirth_3":
                    return new clsIMR_GestationMisbirth_3PrintTool(p_strTypeID);
                case "frmIMR_Breath":
                    return new clsIMR_BreathPrintTool(p_strTypeID);
                case "frmIMR_NerveSystem"://神经肿瘤病历
                    return new clsIMR_NerveSystemPrintTool(p_strTypeID);
                case "frmIMR_NerveMedicineCerebrovascular"://神经内科脑血管病病历
                    return new clsIMR_NerveMedicineCerebrovascularPrintTool(p_strTypeID);
                case "frmIMR_Cerebrovascular"://脑血管病病历
                    return new clsIMR_CerebrovascularPrintTool(p_strTypeID);
                case "frmIMR_HeadInjure"://颅内损伤病历
                    return new clsIMR_HeadInjurePrintTool(p_strTypeID);
                case "frmIMR_NerveMedicineRecord"://神经内科住院病历
                    return new clsIMR_NerveMedicineRecordPrintTool(p_strTypeID);
                case "frmIMR_Neuromedicine_F2"://神经内科住院病历---新疆
                    return new clsIMR_Neuromedicine_F2PrintTool(p_strTypeID);
                case "frmIMR_NutrientRecord":
                    return new clsIMR_NutrientRecordPrintTool(p_strTypeID); 

                //weiling.huang
                case "frmChildbearingRecord":               //新生儿出生时记录
                    return new clsChildbearingRecordPrintTool(p_strTypeID);
                case "frmIMR_childbirth":                     //分娩记录
                    return new clsIMR_childbirthPrintTool(p_strTypeID);
                case "frmBloodAcadInHospitalCaseHistoryOne":  //血液专科住院病历
                    return new clsBloodAcadInHospitalCaseHistoryOnePrintTool(p_strTypeID);
                case "frmIMR_PalaceBirthControlLaySkill":  //宫内节育器放置术记录表
                    return new clsIMR_PalaceBirthControlLaySkillPrintTool(p_strTypeID);
                case "frmManpowerAbortion":               //人工流产及结扎输卵管记录表
                    return new clsManpowerAbortionPrintTool(p_strTypeID);
                case "frmKidneyMedicineBeInHospital":     //肾内科住院病历
                    return new clsKidneyMedicineBeInHospitalPrintTool(p_strTypeID);
                case "frmIMR_RheumatismImmunity":        //风湿免疫内科住院病历
                    return new clsIMR_RheumatismImmunityPrintTool(p_strTypeID);
                case "frmIMR_ChildbirthTransitSection":  // 新生儿转科记录
                    return new clsIMR_ChildbirthTransitSectionPrintTool(p_strTypeID);
                case "frmIMR_DiabetesHospital":  // 糖尿病住院病历
                    return new clsIMR_DiabetesHospitalPrintTool(p_strTypeID);

                //xigui.peng
                case "frmIMR_CesareanRecord":  // 剖宫产记录
                    return new clsIMR_CesareanRecordPrintTool(p_strTypeID);
                case "frmIMR_ForpecsRecord":  // 产钳手术记录
                    return new clsIMR_ForpecsRecordPrintTool(p_strTypeID);
                case "frmIMR_MedcineMiscarryRecord":  //药物流产记录表
                    return new clsIMR_MedcineMiscarryRecordPrintTool(p_strTypeID);
                case "frmIMR_WombBirthControlRecord": //宫内节育器取出术记录表
                    return new clsIMR_WombBirthControlRecordPrintTool(p_strTypeID);
                case "frmIMR_HeartHospitalRecord":
                    return new clsIMR_HeartHospitalRecordPrintTool(p_strTypeID);

                case "frmIMR_Obstetric_Criterion":
                    return new clsIMR_Obstetric_CriterionPrintTool(p_strTypeID);
                //新生儿科入院记录打印
                case "frmIMR_NewChild":
                    return new clsIMR_NewChildPrintTool(p_strTypeID);
                //儿科入院记录打印
                case "frmIMR_Paediatrics01":
                    return new clsIMR_PaediatricsPrintTool01(p_strTypeID);
                case "frmGynecologyCaseHis":
                    return new clsGynecologyCaseHisPrintTool(p_strTypeID);
                case "frmObstetricCaseHis":
                    return new clsObstetricCaseHisPrintTool(p_strTypeID);
                case "frmIMR_OrthopaedicsSuffererAprrove"://骨科(创伤与显微手术外科)手术知情同意书
                    return new clsIMR_OrthopaedicsSuffererAprrovePrintTool(p_strTypeID);
                case "frmIMR_CataractSuffererApprove"://白内障手术患者知情同意书
                    return new clsIMR_CataractSuffererApprovePrintTool(p_strTypeID);
                case "frm_MODS_ApparatusObserve":  //  MODS器官系统功能临床研究观察登记表
                    return new cls_MODS_ApparatusObservePrintTool(p_strTypeID);
                case "frmIMR_Neonatal_GX":  // 新生儿住院病历
                    return new clsIMR_Neonatal_GXPrintTool(p_strTypeID);
                //急诊病历
                case "frm_EmergencyCall":
                    return new cls_EmergencyCallPrintTool(p_strTypeID);
                case "frmIMR_IllnessHistoryRecord":  // 耳鼻喉科专科病历
                    return new clsIMR_IllnessHistoryRecordPrintTool(p_strTypeID);
                case "frmChildHospitalHistory":  // 儿科专科病历
                    return new clsChildHospitalHistoryPrintTool(p_strTypeID);
                case "frmIMR_InHospitalMarks":
                    return new clsIMR_InHospitalMarksPrintTool(p_strTypeID);
                case "frmIMR_PrePostOperateSee": //术前术后访视单
                    return new clsIMR_PrePostOperateSeePrintTool(p_strTypeID);
                case "frmIMR_EmergencyCallWound":
                    return new clsIMR_EmergenceWoundPrintTool(p_strTypeID);
                case "frmIMR_NasopharyngelCarcinoma":  // 鼻咽癌病历
                    return new clsIMR_NasopharyngelCarcinomaPrintTool(p_strTypeID);
                case "frmIMR_CardiovascularDPS"://心脏血管手术记录
                    return new clsIMR_CardiovascularDPSPrintTool(p_strTypeID);
                case "frmIMR_RetinaDeviate"://视网膜脱离手术记录
                    return new clsIMR_RetinaDeviatePrintTool(p_strTypeID);
                case "frmIMR_AskanceDPS"://斜视手术记录
                    return new clsIMR_AskanceDPSPrintTool(p_strTypeID);
                case "frmIMR_GlassAblate"://玻璃体切除手术记录
                    return new clsIMR_GlassAblatePrintTool(p_strTypeID);
                case "frmIMR_GlaucomaEye"://青光眼手术记录
                    return new clsIMR_GlaucomaEyePrintTool(p_strTypeID);
                case "frmIMR_EmbeddedOPS"://人工晶体植入手术记录
                    return new clsIMR_EmbeddedOPSPrintTool(p_strTypeID);
                case "frmIMR_Ab_abbortion": //流产住院病历  
                    return new clsIMR_AB_abbortionPrintTool(p_strTypeID);
                case "frmIMR_Derivation"://中孕引产住院病历
                    return new clsIMR_DerivationPrintTool(p_strTypeID);
                case "frmIMR_InternalMedicineZY"://内科住院记录
                    return new clsIMR_InternalMedicineZYPrintTool(p_strTypeID);
                case "frmIMR_DeliverRecord"://分娩记录（东莞）
                    return new clsIMR_DeliverRecordPrintTool(p_strTypeID);
                case "frmIMR_Derivation_DG"://中孕引产入院记录（东莞）
                    return new clsIMR_Derivation_DGPrintTool(p_strTypeID);
                case "frmIMR_ObstetricOutRecord_DG": //产科出院记录（东莞）
                    return new clsIMR_ObstetricOutRecord_DGPrintTool(p_strTypeID);
                case "frmObstetricOutRecord": //产科出院记录
                    return new clsIMR_CKOutHospitalRecPrintTool(p_strTypeID);
                case "frmIMR_GynaecologyInHospitalRecord": //妇科入院记录
                    return new clsIMR_GynaecologyInHospitalRecordPrintTool(p_strTypeID);
                case "frmObstetricOutHospital":  //产科出院小结
                    return new clsIMR_OutHosptialResultPrintTool(p_strTypeID);
                case "frmIMR_ObstetricOutHosptial_LJ": //伦教产科出院记录
                    return new clsIMR_ObstetricOutHosptialPrintTool_LJ(p_strTypeID);
                case "frmShuLuanGuanJieZaShouShu_LJ"://伦教输卵管结扎手术记录表
                    return new clsIMR_ShuLuanGuanJieZaPrintTool(p_strTypeID);
                case "frmIMR_GynecologyF2"://妇科住院病历佛山版
                    return new clsIMR_GynecologyF2PrintTool(p_strTypeID);
                case "frmIMR_Obstetric_F2"://产科住院病历佛山版
                    return new clsIMR_Obstetric_F2PrintTool(p_strTypeID);
                case "frmChildbearingRecord_F2"://新生儿出生时记录佛山版
                    return new clsChildbearingRecord_F2PrintTool(p_strTypeID);
                case "frmInducedLaborRecord":
                    return new clsIMR_InducedLaborRecordPrintTool(p_strTypeID);
                case "frmIMR_ManpowerAbortionRecord"://产后，人流后，取环后，月经后腹部输卵管结扎记录
                        return new clsIMR_ManpowerAbortionRecordPrintTool(p_strTypeID);
                    case "frmEMR_PullDeliverRecord_F2"://阴道胎头吸引器助产手术记录
                        return new clsEMR_PullDeliverRecord_F2PrintTool(p_strTypeID);
                    case "frmEMR_PullDeliverRecord_CS":// 阴道胎头吸引器助产手术记录（茶山）
                        return new clsIMR_PullDeliverRecord_CS(p_strTypeID);
                case "frmEyeCataract"://白内障
                    return new clsEyeCataractPrintTool(p_strTypeID);
                case "frmIMR_SkinRecord": //皮肤科病历
                    return new clsSkinRcreadPrintTool(p_strTypeID);
                case "frmIMR_Ophthalmology_F2": // 眼科住院病历（佛二）
                    return new clsIMR_OphthalmologyPrintTool_F2(p_strTypeID);
               // case "frmIMR_StubbornDisease": //疑难病例
               //    return new clsIMR_StubbornDiseasePrint(p_strTypeID);
               //case "frmIMR_OutHospitall": // 出院病例（新疆）
               //     return new clsIMG_OutHospitallPrint(p_strTypeID);
               // case "frmIMR_BonehurtHurt": // 骨伤科（创伤新疆）
               //     return new clsIMR_BonehurtHurtPrint(p_strTypeID);
               // case "frmIMG_Bonehurtcervical": // 骨伤科（颈椎病新疆）
               //     return new clsIMR_Bonehurtcervicalprint(p_strTypeID);
               // case "frmIMR_Bonearthropathy": // 骨伤科（关节病新疆）
               //     return new clsIMR_BonearthropathyPrint(p_strTypeID);
               // case "frmIMR_Bonelumbocruralpain": // 骨伤科（腰腿痛新疆）
               //     return new clsIMR_Bonelumbocruralpain(p_strTypeID);
               // case "frmIMG_familyplanningRecord": // 计划生育住院记录（新疆版）
               //     return new clsIMR_familyplanningPrint(p_strTypeID);
               // case "frmIMG_familyplaningoper": // 计划生育手术记录（新疆版）
               //     return new clsIMR_familyplaningoperPrint(p_strTypeID);
               // case "frmIMG_Tongwater": // 通水手术记录（新疆版）
               //     return new clsIMR_TongwaterPrint(p_strTypeID);
               // case "frmIMR_peopleLostlay": // 人工流产手术记录（新疆版）
               //     return new clsIMR_peopleLostlayPrint(p_strTypeID);
               // case "frmIMR_middlelay": // 中期引产手术记录（新疆版）
               //     return new clsIMR_middlelayPrint(p_strTypeID);
               // case "frmIMR_inthospitalpinggu": // 入院评估表（新疆版）
               //     return new clsIMR_inthospitalpingguPrint(p_strTypeID);
               // case "frmIMR_intHosptalrecord": // 入院记录--->改成体格检查（新疆版）
               //     return new clsIMR_intHosptalrecordPrint(p_strTypeID);
                case "frmIMR_Neurosurgery_F2": // 神经外科入院纪录
                    return new clsIMR_Neurosurgery_F2PrintTool(p_strTypeID);
                case "frmIMR_IllnessInHospitalRecord"://耳鼻喉科住院病历
                    return new clsIMR_IllnessInHospitalRecordPrintTool(p_strTypeID);
                case "frmIMR_HeartVasSurgeryRecord"://心血管外科入院记录
                    return new clsIMR_HeartVasSurgeryRecordPrintTool(p_strTypeID);
                case "frmIMR_EyeTakecare"://眼科护理记录（佛二）
                    return new clsIMR__EyeTakecarePrint(p_strTypeID);

                default:
                    return new clsInpatMedRecPrintToolFactory2().m_objSubGeneratePrintTool(p_strTypeID);
            }
             
            return null;
        }


    }
}
