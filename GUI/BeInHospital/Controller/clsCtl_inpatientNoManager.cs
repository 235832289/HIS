using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;


namespace com.digitalwave.iCare.gui.HIS
{
    class clsCtl_inpatientNoManager : com.digitalwave.GUI_Base.clsController_Base
    {
        com.digitalwave.iCare.gui.HIS.clsDcl_Register m_objRegister = null;

        #region 构造函数
        public clsCtl_inpatientNoManager()
        {
            m_objRegister = new com.digitalwave.iCare.gui.HIS.clsDcl_Register();
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.CreateInpatientNo m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (CreateInpatientNo)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// 普通住院
        /// </summary>
        internal void m_strGetInpatientNo()
        {
            string m_strMaxNo = "";
            int m_intSour = -1;
            
            long lngReg = m_objRegister.m_lngGetBigPatientIDNor(ref m_objViewer.m_strHead, out m_strMaxNo,out m_intSour);
            if (lngReg > 0)
            {
                m_objViewer.m_strInpatientid_chr = m_strMaxNo;
                m_objViewer.m_intSour = m_intSour;
                //MessageBox.Show(m_strMaxNo);
            }
        }
        /// <summary>
        /// 非普通住院登记
        /// </summary>
        internal void m_strGetOthInpatientid_chr( )
        {
            string m_strMaxNo = "";
            int m_intSour = -1;
            //string head = m_objViewer.m_strHead.Trim();
            long lngReg = m_objRegister.m_lngGetBigPatientIDOth(ref m_objViewer.m_strHead, out m_strMaxNo, out m_intSour);
            if (lngReg > 0)
            {
                m_objViewer.m_strInpatientid_chr = m_strMaxNo;
                m_objViewer.m_intSour = m_intSour; ;
                //MessageBox.Show(m_strMaxNo);
            }
        }
        /// <summary>
        /// 自由输入住院号
        /// </summary>
        internal long m_lngGetBigPatientIDFree()
        {
            string m_strMaxNo = "";
            int m_intSour = -1;
            string head = m_objViewer.m_strHead.Trim();
            string main = m_objViewer.m_strMain.Trim();
            m_strMaxNo = m_objViewer.textBox1.Text.Trim();
            //long lngReg = m_objRegister.m_lngGetBigPatientIDFree(head, main,out m_strMaxNo, out m_intSour);
            bool m_blHave = true;
            long lngReg = m_objRegister.m_lngCheckInputNoHave(m_strMaxNo,out m_blHave);

            if (lngReg > 0 &&! m_blHave)
            {
                m_objViewer.m_strInpatientid_chr = m_strMaxNo;
                m_objViewer.m_intSour = m_intSour;
                int count = 0;
                lngReg = m_objRegister.m_lngGetInputNoFree(m_strMaxNo, out head, out m_strMaxNo, out m_intSour, m_objViewer.m_intINPATIENTNOTYPE_INT,out count);
                if (count > 0)
                {
                    m_objViewer.m_strHead = head;
                    m_objViewer.m_strInpatientid_chr = m_strMaxNo;
                    m_objViewer.m_intSour = m_intSour;
              
                }
                  //MessageBox.Show(m_strMaxNo);
            }
            else
            {
                return -1;
            }
            return lngReg;
        }

        /// <summary>
        /// 修改结果
        /// </summary>
        /// <returns></returns>
        internal long m_lngAddBigIDTableMax()
        {
          
            //string head = m_objViewer.m_strHead.Trim();
            //string main = m_objViewer.m_strMain.Trim();
            long lngReg = -1;
            if (m_objViewer.m_intSour == 2)
            {
                if (!m_objViewer.m_strHead.Trim().Equals(""))
                {
                    lngReg = m_objRegister.m_lngAddBigIDTableMax(m_objViewer.m_intINPATIENTNOTYPE_INT, this.m_objViewer.m_strInpatientid_chr.Replace(m_objViewer.m_strHead.Trim(), ""));
                }
                else
                {
                    lngReg = m_objRegister.m_lngAddBigIDTableMax(m_objViewer.m_intINPATIENTNOTYPE_INT, this.m_objViewer.m_strInpatientid_chr);
                }
            }
            else if (m_objViewer.m_intSour == 1)
            {
               // lngReg = m_objRegister.m_lngDelInpatientNohis(head, main);
            }
            return lngReg;
        }
    }
}
