using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 输入法锁定消息过滤器, 只在C#2005上测试通过
    /// </summary>
    public class ImeLock : IMessageFilter   
    {
        ImeTool imeTool = new ImeTool();

        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            { 
                case 0xC1C2:
                    Form frm = System.Windows.Forms.Form.ActiveForm;
                    if (frm != null)
                    {
                        frm.Activated += new EventHandler(frm_Activated);
                        imeTool.Attach(frm.Handle);
                        imeTool.ToggleShape(false);//强制转到半角  
                        BindControl(frm.Controls);
                    }                 
                    
                    break;
                default:
                    break;
            }

            return false;
        }

        void frm_Activated(object sender, EventArgs e)
        {
            imeTool.Attach((sender as Form).Handle);
            imeTool.ToggleShape(false);//强制转到半角
        }

        void BindControl(System.Windows.Forms.Control.ControlCollection controls)
        {
            foreach (Control child in controls)
            {
                child.Enter += new EventHandler(child_Enter);
                if (child.Controls.Count > 0)
                    BindControl(child.Controls);                
            }
        }

        void child_Enter(object sender, EventArgs e)
        {
            imeTool.Attach((sender as Control).FindForm().Handle);
            imeTool.ToggleShape(false);//强制转到半角 
        }
    }

    /// <summary>
    /// 输入法设置类，功能待完善
    /// </summary>
   public  class ImeTool
    {
        #region API AND CONSTANTS

        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hWnd, int dw);

        [DllImport("imm32.dll")]
        public static extern int ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);

        [DllImport("Imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("Imm32.dll")]
        public static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);

        [DllImport("Imm32.dll")]
        public static extern bool ImmIsIME(IntPtr hImc);

        const int IME_CHOTKEY_IME_NONIME_TOGGLE = 0x10;
        const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;
        const int IME_CHOTKEY_SYMBOL_TOGGLE = 0x12;

        const int IME_CMODE_FULLSHAPE = 0x0008;
        const int IME_CMODE_SYMBOL = 0x0400;

        #endregion

        private IntPtr hWindow = IntPtr.Zero;
        private bool isFullShape = false;
        private bool isChineseSymbol = false;

        public ImeTool()
        {
           
        }

        public ImeTool(IntPtr hWnd)
        {
            hWindow = hWnd;
        }

        public void Attach(IntPtr hWnd)
        {
            hWindow = hWnd;
        }

        public void Detach()
        {
            hWindow = IntPtr.Zero;
        }

        public bool IsFullShape
        {
            get { GetStat(); return isFullShape; }
        }

        public bool IsChineseSymbol
        {
            get { GetStat(); return isChineseSymbol; }
        }

        /// <summary>
        /// 全角/半角 相互切换
        /// </summary>
        public void ToggleShape()
        {
            if (hWindow == IntPtr.Zero)
                throw new Exception("Please attach the HWND!");

            ImmSimulateHotKey(hWindow, IME_CHOTKEY_SHAPE_TOGGLE);
        }

        /// <summary>
        /// 是否切换到全角，否则是半角
        /// </summary>
        /// <param name="fullShaped"></param>
        public void ToggleShape(bool fullShaped)
        {
            if (this.IsFullShape != fullShaped)
                ToggleShape();
        }

        private void GetStat()
        {
            if (hWindow == IntPtr.Zero)
                throw new Exception("Please attach the HWND!");

            int dwConversion = 0;
            int dwSentence = 0;

            IntPtr hImc = ImmGetContext(hWindow);
            ImmGetConversionStatus(hImc, ref dwConversion, ref dwSentence);

            isFullShape = (dwConversion & IME_CMODE_FULLSHAPE) != 0;
            isChineseSymbol = (dwConversion & IME_CMODE_SYMBOL) != 0;

            ImmReleaseContext(hWindow, hImc);
        }
    }
}
