using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class ctlCheckMethodCombox : System.Windows.Forms.ComboBox
    {
        public ctlCheckMethodCombox()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;           
        }       
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!this.DesignMode)
            {
                try
                {
                    m_mthLoadData();
                }
                catch { }
            }
        }
        public void m_mthLoadData()
        {
            //加入空项
            clsLisCheckMethodVO obj = new clsLisCheckMethodVO();
            obj.m_strName = string.Empty;
            obj.m_intSeq = DBAssist.NullInt;
            this.Items.Add(obj);
            //加载数据
            clsLisCheckMethodVO[] objCheckMethodArr = null;
            long lngRes =  clsTmdCheckMethodSmp.s_object.m_lngFind(out objCheckMethodArr);
            if (lngRes > 0 && objCheckMethodArr != null)
            {
                this.Items.AddRange(objCheckMethodArr);
            }
        }
    }
}
