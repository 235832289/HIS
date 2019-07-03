using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    class clsCommonDialog
    {
        public static void m_mthShowDBError()
        {
            MessageBox.Show("数据库访问出错！", "iCare");
        }
        public static void m_mthShowNoAccordantResult()
        {
            MessageBox.Show("没有符合条件的记录！", "iCare");
        }
    }
}
