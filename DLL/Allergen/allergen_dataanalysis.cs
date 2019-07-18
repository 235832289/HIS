using System.Collections;
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;

namespace Allergen
{
    public class DataAnalysis_Allergen : clsLISDataAnalysisBase, infLISDataAnalysis
    {
        // Methods
        public long lngDataAnalysis(string p_strRawData, out ArrayList p_arlResult)
        {
            p_arlResult = null;
            return 0L;
        }

        public string[] strGetIntactData(string p_strRawData)
        {
            return null;
        }

        public long lngDataAnalysis(string p_strRawData, out List<clsLIS_Device_Test_ResultVO> p_arlResult)
        {
            p_arlResult = null;
            return 1L;
        }
    }
}
