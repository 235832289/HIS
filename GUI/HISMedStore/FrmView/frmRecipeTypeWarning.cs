using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmRecipeTypeWarning : Form
    {
        private static frmRecipeTypeWarning RecipeTypeWarning = null;
        /// <summary>
        /// 判断是否创建窗体
        /// </summary>
        /// <returns></returns>
        public static frmRecipeTypeWarning RecipeTypeWaringForm()
        {
            if (RecipeTypeWarning == null)
            {
                return new frmRecipeTypeWarning();
            }
            return RecipeTypeWarning;
        }
        /// <summary>
        /// 
        /// </summary>
        public frmRecipeTypeWarning()
        {
            InitializeComponent();
        }
        /// <summary>
        ///　界面控制层
        /// </summary>
        public  clsControlOPMedStore m_objControlOPMedStore = null;
        private void frmRecipeTypeWarning_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        ///绑定数据
        /// </summary>
        /// <param name="m_objTable"></param>
        public void m_mthFillDataGridView(DataTable m_objTable)
        {
            if (m_objTable != null && m_objTable.Rows.Count > 0)
            {
                this.m_dgvPatient.DataSource = m_objTable;
                this.ShowInTaskbar = false;
                this.Show();
            }
        }

        private void frmRecipeTypeWarning_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frmRecipeTypeWarning_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_objControlOPMedStore.m_objfrmRecipeType = null;
        }
    }
}