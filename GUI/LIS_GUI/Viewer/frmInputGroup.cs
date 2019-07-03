using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmInputGroup : Form
    {
        clsDomain_InputGroup objDomain = new clsDomain_InputGroup();
        string[] strApplyUnits;
        DataTable dtbList = new DataTable("List");
        DataView dtvInputGroupSelector = new DataView();

        public string[] strSelectedCheckItems;
        public frmInputGroup(string[] p_strApplyUnits)
        {
            InitializeComponent();
            this.strApplyUnits = p_strApplyUnits;
            

            DataTable dtb = new DataTable("Selector");
            dtb.Columns.Add("apply_unit_id_chr",typeof(string));
            dtb.Columns.Add("input_group_id_chr", typeof(string));
            dtb.Columns.Add("input_group_name_vchr", typeof(string));
            dtb.Rows.Add(new object[] {System.DBNull.Value,"nullvalue","全部" });
            dtvInputGroupSelector.Table = dtb;
            this.dtvInputGroupSelector.Sort = "input_group_id_chr";
            this.clmInputGroup.DataSource = this.dtvInputGroupSelector;
            this.clmInputGroup.DisplayMember = "input_group_name_vchr";
            this.clmInputGroup.ValueMember = "input_group_id_chr";

            this.clmApplyUnit.DataPropertyName = "apply_unit_id_chr";
            this.clmInputGroup.DataPropertyName = "input_group_id_chr";
            this.clmApplyName.DataPropertyName = "apply_unit_name_vchr";
            this.dtbList.Columns.Add("apply_unit_id_chr", typeof(string));
            this.dtbList.Columns.Add("apply_unit_name_vchr", typeof(string));
            this.dtbList.Columns.Add("input_group_id_chr", typeof(string));
            this.dtgList.DataSource = this.dtbList;
        }

        private void frmInputGroup_Load(object sender, EventArgs e)
        {
            
            if (this.strApplyUnits == null)
                return;

            DataTable dtbApplyInfo = null;
            long lngRes = this.objDomain.m_lngGetApplyUnitInfo(this.strApplyUnits, out dtbApplyInfo);
            if (lngRes > 0)
            {
                dtbApplyInfo.TableName = "List";
                this.dtgList.DataSource = dtbApplyInfo;
                this.dtbList = dtbApplyInfo;
            }

            DataTable dtbSelector = null;
            lngRes = 0;
            lngRes = objDomain.m_lngGetInputGroupsByUnit(this.strApplyUnits, out dtbSelector);
            if (lngRes > 0)
            {
                foreach (DataRow dtr in dtbSelector.Rows)
                {
                    this.dtvInputGroupSelector.Table.ImportRow(dtr);
                }
            }
        }

        private void dtgList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string strUnitID = ((DataTable)this.dtgList.DataSource).Rows[e.RowIndex]["apply_unit_id_chr"].ToString();
                ((DataView)clmInputGroup.DataSource).RowFilter = "apply_unit_id_chr = '" + strUnitID + "' OR apply_unit_id_chr is null";
            }
        }
        private void dtgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                string strInputGroupID = ((DataTable)this.dtgList.DataSource).Rows[e.RowIndex]["input_group_id_chr"].ToString();
                e.Value = ((DataView)clmInputGroup.DataSource).Table.Select("input_group_id_chr = '" + strInputGroupID + "'")[0]["input_group_name_vchr"].ToString();
                e.FormattingApplied = true;
            }
        }
        private void dtgList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            System.Collections.ArrayList arlAll = new System.Collections.ArrayList();
            System.Collections.ArrayList arlInputGroup = new System.Collections.ArrayList();
            foreach (DataRow dtr in this.dtbList.Rows)
            {
                if (dtr["input_group_id_chr"].ToString() == "nullvalue")
                {
                    arlAll.Add(dtr["apply_unit_id_chr"].ToString());
                }
                else
                {
                    arlInputGroup.Add(dtr["input_group_id_chr"].ToString());
                }
            }

            string[] strUnits = (string[])arlAll.ToArray(typeof(string));
            string[] strGroups = (string[])arlInputGroup.ToArray(typeof(string));

            string[] strCheckItems = null;
            long lngRes = this.objDomain.m_lngGetFiltedItems(strUnits, strGroups, out strCheckItems);
            if (lngRes > 0)
            {
                this.strSelectedCheckItems = strCheckItems;
            }
            else
            {
                MessageBox.Show("数据库操作失败!", "iCare");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }      
    }
}