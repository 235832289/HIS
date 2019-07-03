using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    internal partial class ctlSTProjectComboBox : ComboBox
    {
        public ctlSTProjectComboBox()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public ctlSTProjectComboBox(IContainer container)
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
            clsSTCheckProject checkItem = new clsSTCheckProject();
            checkItem.Name = string.Empty;

            this.Items.Add(checkItem);

            List<clsSTCheckProject> lstProjects = clsST360Config.CurrentConfig.Projects;
            foreach (clsSTCheckProject project in lstProjects)
            {
                this.Items.Add(project);
            }
        }

        public clsSTCheckProject SelectProejct 
        {
            get 
            {
                if (this.SelectedItem!=null)
                {
                    clsSTCheckProject project = this.SelectedItem as clsSTCheckProject;
                    if (project!=null)
                    {
                        return project;
                    }
                }
                return null;
            }
        }
    }
}
