using System;
using System.Collections.Generic;
using System.Text;

namespace iCare
{
    public class clsInpatMedRecPrintToolFactory2
    {        
        /// <summary>
        /// 生产打印工具
        /// </summary>
        /// <param name="p_strTypeID"></param>
        /// <returns></returns>
        public virtual clsInpatMedRecPrintBase m_objSubGeneratePrintTool(string p_strTypeID)
        {
            switch (p_strTypeID)
            {
                case "frmIMR_NutrientRecord":
                    return new clsIMR_NutrientPrintTool(p_strTypeID);

                case "frmIMR_Ophthalmology_F2":   // 眼科专科病历（佛二）
                    return new clsIMR_OphthalmologyPrintTool_F2(p_strTypeID);

                case "frmIMR_OphthalmologyNurseRecord": // 眼科手术护理记录单
                    return new clsIMR_OphthalmologyNurseRecordPrintTool(p_strTypeID);

                case "frmIMR_CesareanRecord_LJ":    // 剖宫产手术记录（伦教）
                    return new clsIMR_CesareanRecordPrintTool_LJ(p_strTypeID);

                case "frmInducedLaborRecord_LJ":    // 引产登记表（伦教）
                    return new clsIMR_InducedLaborRecordPrintTool_LJ(p_strTypeID);

                default:
                    break;
            }

            return null;
        }

    }
}
