using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.LIS
{
    public partial class ctlVendorCombox : System.Windows.Forms.ComboBox
    {
        public ctlVendorCombox()
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
                    this.m_mthLoadData();
                }
                catch { }
            }
        }
        private void m_mthLoadData()
        {
            //加入空项
            clsLisVendorVO obj = new clsLisVendorVO();
            obj.m_strVendor = string.Empty;
            obj.m_intSeq = DBAssist.NullInt;
            this.Items.Add(obj);
            //加载数据
            clsLisVendorVO[] objVendorArr = null;
            long lngRes = clsTmdVendorSmp.s_object.m_lngFind(out objVendorArr);
            if (lngRes > 0 && objVendorArr != null)
            {
                this.Items.AddRange(objVendorArr);
            }
        }
    }
}
