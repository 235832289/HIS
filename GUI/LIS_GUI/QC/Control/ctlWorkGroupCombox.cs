using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class ctlWorkGroupCombox : System.Windows.Forms.ComboBox
    {
        public ctlWorkGroupCombox()
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
            clsLisWorkGroupVO obj = new clsLisWorkGroupVO();
            obj.m_strName = string.Empty;
            obj.m_intSeq = DBAssist.NullInt;
            obj.m_enmStatus = enmQCStatus.Natrural;
            this.Items.Add(obj);
            //加载数据
            clsLisWorkGroupVO[] objGroupArr = null;
            long lngRes = clsTmdWorkGroupSmp.s_object.m_lngFind(out objGroupArr);
            if (lngRes > 0 && objGroupArr != null)
            {
                foreach (clsLisWorkGroupVO  objGroup in objGroupArr)
                {
                    if (objGroup.m_enmStatus == enmQCStatus.Natrural)
                    {
                        this.Items.Add(objGroup);
                    }
                }
            }
        }
        public int Value
        {
            get
            {
                if (this.SelectedItem != null)
                    return ((clsLisWorkGroupVO)this.SelectedItem).m_intSeq;
                return DBAssist.NullInt;
            }
            set
            {
                this.SelectedItem = null;
                foreach (clsLisWorkGroupVO objGroup in this.Items)
                {
                    if (objGroup.m_intSeq == value)
                    {
                        this.SelectedItem = objGroup;
                        break;
                    }
                }
            }
        }
        public clsLisWorkGroupVO SelectedWorkGroup
        {
            get
            {
                if (this.SelectedItem != null && (((clsLisWorkGroupVO)this.SelectedItem).m_intSeq != -1))
                    return (clsLisWorkGroupVO)this.SelectedItem;
                return null;
            }
        }
    }
}
