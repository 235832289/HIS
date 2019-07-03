using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    internal partial class ctlSTTemplateCombox : ComboBox
    {
        public ctlSTTemplateCombox()
        {
            InitializeComponent();
        }

        public ctlSTTemplateCombox(IContainer container)
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
            clsBoardTemplate template = new clsBoardTemplate("",new List<clsSTBoardItem>());
            this.Items.Add(template);

            List<clsBoardTemplate> lstTemplates = clsST360Config.CurrentConfig.Templates;
            foreach (clsBoardTemplate boardTemplate in lstTemplates)
            {
                this.Items.Add(boardTemplate);
            }
        }

        public clsBoardTemplate SelectTemplate
        {
            get
            {
                if (this.SelectedItem != null)
                {
                    clsBoardTemplate template = this.SelectedItem as clsBoardTemplate;
                    if (template != null)
                    {
                        return template;
                    }
                }
                return null;
            }
        }
    }
}
