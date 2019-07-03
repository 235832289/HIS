using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
//using iCare;

namespace com.digitalwave.Utility.Controls
{
    /// <summary>
    /// 选中时高亮度的工具
    /// </summary>
    public class ctlCtl_HighLightFocus
    {
        private Color m_clrHighLight;

        private Hashtable m_hasControlOldBackColor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_clrHighLight"></param>
        public ctlCtl_HighLightFocus(Color p_clrHighLight)
        {
            m_clrHighLight = p_clrHighLight;

            m_hasControlOldBackColor = new Hashtable();
        }

        /// <summary>
        /// 添加容器内容的控件
        /// </summary>
        /// <param name="p_ctlContainerControl"></param>
        public void m_mthAddControlInContainer(Control p_ctlContainerControl)
        {

            clsHRPColor.s_mthChangeColorInContainer(p_ctlContainerControl);

            m_mthAddControl(p_ctlContainerControl);
        }
        private void m_mthAddControl(Control p_ctlContainerControl)
        {


            foreach (Control ctlChild in p_ctlContainerControl.Controls)
            {
                ctlChild.GotFocus += new EventHandler(m_mthGotFocus);
                ctlChild.LostFocus += new EventHandler(m_mthLostFocus);

                m_hasControlOldBackColor[ctlChild] = m_clrGetControlBackColor(ctlChild);

                switch (ctlChild.GetType().FullName)
                {
                    case "com.digitalwave.Utility.Controls.ctlComboBox":

                        ((com.digitalwave.Utility.Controls.ctlComboBox)ctlChild).evtGotFocus += new EventHandler(m_mthGotFocus);

                        ((com.digitalwave.Utility.Controls.ctlComboBox)ctlChild).evtLostFocus += new EventHandler(m_mthLostFocus);
                        break;
                    default:
                        m_mthAddControl(ctlChild);
                        break;
                }
            }
        }

        private void m_mthGotFocus(object p_objSender, EventArgs p_objArg)
        {

            m_mthSetControlBackColor((Control)p_objSender, m_clrHighLight);
        }

        private void m_mthLostFocus(object p_objSender, EventArgs p_objArg)
        {

         m_mthSetControlBackColor((Control)p_objSender,(Color)m_hasControlOldBackColor[p_objSender]);
         }

        private Color m_clrGetControlBackColor(Control p_ctlControl)
        {
            switch (p_ctlControl.GetType().FullName)
            {
                case
                "com.digitalwave.Utility.Controls.ctlComboBox":
                    return
                    ((com.digitalwave.Utility.Controls.ctlComboBox)p_ctlControl).TextBackColor;

                case "System.Windows.Forms.DataGrid":
                    DataGrid dtgControl =
                    (DataGrid)p_ctlControl;
                    if (dtgControl.TableStyles.Count > 0)
                        return
                        dtgControl.TableStyles[0].SelectionBackColor;
                    else
                        return
                        dtgControl.BackColor;
                default:
                    return
                    p_ctlControl.BackColor;
            }
        }

        private void m_mthSetControlBackColor(Control p_ctlControl, Color p_clrBackColor)
        {
            switch (p_ctlControl.GetType().FullName)
            {
                case "System.Windows.Forms.Label":
                    break;
                case "System.Windows.Forms.DataGrid":

                    if (((DataGrid)p_ctlControl).TableStyles != null && ((DataGrid)p_ctlControl).TableStyles.Count > 0)
                    {

                        ((DataGrid)p_ctlControl).TableStyles[0].SelectionBackColor = p_clrBackColor;

                    }
                    break;
                case "com.digitalwave.Utility.Controls.ctlComboBox":

                    ((com.digitalwave.Utility.Controls.ctlComboBox)p_ctlControl).TextBackColor =p_clrBackColor;
                    break;
                case "iCare.ctlAnaesthesiaRecord": //自定义控件不显示高亮 xzhou 2003-12-21
                    break;
                case "System.Windows.Forms.TextBox":
                    if (((TextBox)p_ctlControl).Enabled == true && ((TextBox)p_ctlControl).ReadOnly == false)
                    {
                        p_ctlControl.BackColor = p_clrBackColor;
                    }
                    break;
                default:
                    p_ctlControl.BackColor = p_clrBackColor;
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void m_mthClear()
        {
            if (m_hasControlOldBackColor != null)
            {
                m_hasControlOldBackColor.Clear();
                m_hasControlOldBackColor = null;
            }
        }
    }
}


