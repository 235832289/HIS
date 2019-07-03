using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 医保试算逻辑控制CLASS
    /// </summary>
    public class clsCtl_YBCharge
    {
        #region 变量
        /// <summary>
        /// 医院编号
        /// </summary>
        private string HospCode = "A-02";
        /// <summary>
        ///  结算类
        /// </summary>
        private clsDcl_Charge objCharge;
        #endregion      

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_YBCharge()
        {
            objCharge = new clsDcl_Charge();

            // 获取连接医保前置数据库参数
            string tmpfs = clsPublic.XMLFile;
            clsPublic.XMLFile = Application.StartupPath + @"\HISYB.xml";
            HospCode = clsPublic.m_strReadXML("FOSHAN.NO2", "HospitalNO", "AnyOne");
            clsPublic.XMLFile = tmpfs;
        }
        #endregion

        #region 试算接口
        /// <summary>
        /// 试算接口
        /// </summary>
        /// <param name="vyydm">医院代码</param>
        /// <param name="vzyhm">住院号</param>
        /// <param name="vzych">住院次数</param>
        /// <param name="verdm">返回值代码</param>
        /// <param name="verms">返回值信息</param>
        /// <returns></returns>
        [DllImport("ado_zyss.dll")]
        public static extern bool ZYSS(string vyydm, string vzyhm, int vzych, ref string verdm, ref string verms);
                
        #endregion

        #region 试算
        /// <summary>
        /// 试算
        /// </summary>
        /// <param name="RegID">入院登记ID</param>
        /// <param name="Zyh">住院号</param>
        /// <param name="Zycs">住院次数</param>
        /// <param name="Mode">1 模式一：全部未清项目 2 模式二：指定项目</param>
        /// <param name="TotalMoney">试算项目总费用</param>
        /// <param name="InsuredMoney">试算项目医保合计金额</param>
        public bool m_blnBudget(string RegID, string Zyh, int Zycs, int Mode, out decimal TotalMoney, out decimal InsuredMoney)
        {
            string OutDm = "";
            string OutMs = "";
            
            bool ret = false;

            TotalMoney = 0;
            InsuredMoney = 0;

            try
            {
                long l = this.objCharge.m_lngBudgetSendData(HospCode, RegID, Mode);

                if (l > 0)
                {
                    ret = ZYSS(HospCode, Zyh, Zycs, ref OutDm, ref OutMs);

                    if (ret)
                    {
                        DataTable dtMain, dtDet;
                        l = this.objCharge.m_lngBudgetGetData(RegID, out dtMain, out dtDet);
                        if (l > 0 && dtMain.Rows.Count == 1)
                        {
                            TotalMoney = clsPublic.ConvertObjToDecimal(dtMain.Rows[0]["zl19"]);
                            InsuredMoney = clsPublic.ConvertObjToDecimal(dtMain.Rows[0]["yb02"]);
                        }
                        else
                        {
                            ret = false;
                            MessageBox.Show("接收医保试算数据失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        //接口函数出错信息
                        MessageBox.Show("原因: " + OutDm + "  " + OutMs, "试算失败...", MessageBoxButtons.OK, MessageBoxIcon.Stop);        
                    }
                }
                else
                {
                    MessageBox.Show("传送收费项目失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);        
                }
            }
            catch (Exception ex)
            {    
                ret = false;
                MessageBox.Show(ex.Message);
            }

            return ret;
        }
        #endregion

        #region 试算
        /// <summary>
        /// 试算
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="Zyh"></param>
        /// <param name="Zycs"></param>
        /// <param name="TotalMoney"></param>
        /// <param name="InsuredMoney"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        public bool m_blnBudget(string RegID, string Zyh, int Zycs, out decimal TotalMoney, out decimal InsuredMoney, out string ErrMsg)
        {
            long l = this.objCharge.m_lngYBBudget(HospCode, RegID, Zyh, Zycs, out TotalMoney, out InsuredMoney, out ErrMsg);

            if (l == 0)
            {                
                return false;
            }

            return true;
        }
        #endregion
    }
}
