using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    internal partial class ctlSTSampleComboBox : ComboBox
    {
        public ctlSTSampleComboBox()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public ctlSTSampleComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!DesignMode)
            {
                try
                {
                    LoadData();
                }
                catch
                {

                }
            }
        }

        private void LoadData()
        {
            clsSTCheckSample checkSample = new clsSTCheckSample();
            checkSample.BatchNo = string.Empty;
            this.Items.Add(checkSample);

            List<clsSTCheckSample> lstSamples = clsST360Config.CurrentConfig.Samples;
            foreach (clsSTCheckSample Sample in lstSamples)
            {
                this.Items.Add(Sample);
            }
        }

        public clsSTCheckSample SelectSample
        {
            get
            {
                if (this.SelectedItem != null)
                {
                    clsSTCheckSample Sample = this.SelectedItem as clsSTCheckSample;
                    if (Sample != null)
                    {
                        return Sample;
                    }
                }
                return null;
            }
        }
    }
}
