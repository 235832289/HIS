using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmQCSetup : frmMDI_Child_Base
    {
        public frmQCSetup()
        {
            InitializeComponent();
        }

        #region 变量
        private DataTable dtbResult;
        private clsTmdQCBatchSmp m_objDomain = new clsTmdQCBatchSmp();
        private int idConcentration = 0;
        private string m_strDeviceSampleID = null;
        private clsLisQCConcentrationVO objConcentrations;
        #endregion 

        

        #region 方法

        public void m_mthReset()
        {
            this.txtUnit.Clear();
            this.txtBValue.Clear();
            this.txtCV.Clear();
            this.txtGroupNum.Clear();
            this.txtSD.Clear();
            this.txtCode.Clear();
            this.txtSortNum.Clear();
            this.txtWaveLength.Clear();
            this.cboApparatusType.Text = "";
            this.cboConcentration.Text = "";
            this.cboExamineMethod.Text = "";
            this.cboManOrigin.Text = "";
            this.txtSeq.Clear();
            this.dtpBegindate.Value = DateTime.Now;
            this.dtpEnddate.Value = DateTime.Now;
        }

        public void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            if (p_eumKeyCode == Keys.F4)
            {
                this.cmdSave_Click(null, null);
            }
            if (p_eumKeyCode == Keys.Escape)
            {
                this.cmdExit_Click(null, null);
            }
        }

        public void CreateDataTable(List<clsLisQCBatchVO> m_objBatchSets, List<clsLisQCConcentrationVO> m_objConcentrations)
        {
            DataColumn[] columns = new DataColumn[]{new DataColumn("itemsname", typeof(string)), 
		                                                new DataColumn("unit", typeof(string)), 
		                                                new DataColumn("sortnum", typeof(int)), 
		                                                new DataColumn("method", typeof(string)), 
		                                                new DataColumn("type", typeof(string)), 
		                                                new DataColumn("wavelength", typeof(string)), 
		                                                new DataColumn("source", typeof(string)), 
		                                                new DataColumn("groupnum", typeof(string)), 
		                                                new DataColumn("Concentration", typeof(string)), 
		                                                new DataColumn("code", typeof(string)), 
		                                                new DataColumn("begindate", typeof(string)), 
		                                                new DataColumn("enddate", typeof(string)), 
		                                                new DataColumn("BValue", typeof(string)), 
		                                                new DataColumn("sd", typeof(string)), 
		                                                new DataColumn("cv", typeof(string)), 
		                                                new DataColumn("intSeq", typeof(string)), 
		                                                new DataColumn("checkitemsid", typeof(string)), 
		                                                new DataColumn("m_strDeviceId", typeof(string)) };
            this.dtbResult = new DataTable();
            this.dtbResult.Columns.AddRange(columns);
            for (int i = 0; i < m_objBatchSets.Count; i++)
            {
                DataRow dr = this.dtbResult.NewRow();
                dr["itemsname"] = m_objBatchSets[i].m_strCheckItemName;
                dr["unit"] = m_objBatchSets[i].m_strResultUnit;
                dr["sortnum"] = m_objBatchSets[i].m_strSortNum;
                dr["method"] = m_objBatchSets[i].m_strCheckmethodName;
                dr["type"] = m_objBatchSets[i].m_strDeviceName;
                dr["wavelength"] = m_objBatchSets[i].m_dblWaveLength;
                dr["source"] = m_objBatchSets[i].m_strSampleSource;
                dr["groupnum"] = m_objBatchSets[i].m_strSampleLotNo;
                dr["begindate"] = m_objBatchSets[i].m_dtBegin.ToShortDateString();
                dr["enddate"] = m_objBatchSets[i].m_dtEnd.ToShortDateString();
                dr["intSeq"] = m_objBatchSets[i].m_intSeq;
                dr["checkitemsid"] = m_objBatchSets[i].m_strCheckItemId;
                dr["m_strDeviceId"] = m_objBatchSets[i].m_strDeviceId;
                for (int j = 0; j < m_objConcentrations.Count; j++)
                {
                    if (m_objBatchSets[i].m_intSeq == m_objConcentrations[j].m_intQCBatchSeq)
                    {
                        dr["Concentration"] = m_objConcentrations[j].m_strConcentration;
                        dr["code"] = m_objConcentrations[j].m_strDeviceSampleId;
                        dr["BValue"] = m_objConcentrations[j].m_dblAVG;
                        dr["sd"] = m_objConcentrations[j].m_dblSD;
                        dr["cv"] = m_objConcentrations[j].m_dblCV;
                        this.dtbResult.Rows.Add(dr);
                        break;
                    }
                }
                if (!(dr["Concentration"].ToString() != ""))
                {
                    dr["Concentration"] = "";
                    dr["code"] = "";
                    dr["BValue"] = "";
                    dr["sd"] = "";
                    dr["cv"] = "";
                    this.dtbResult.Rows.Add(dr);
                }
            }
            this.dtbResult.DefaultView.Sort = "sortnum asc";
            this.dgvSetup.DataSource = this.dtbResult;
        }


        #endregion

        #region 事件

        private void frmQCSetup_Load(object sender, EventArgs e)
        {
            this.dgvSetup.AutoGenerateColumns = false;
            base.m_mthSetEnter2Tab(new Control[] { this.dgvSetup, this.lblNotice, this.txtItems, this.txtGroupNum, this.txtSeq });
        }

        private void lblNotice_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void lblNotice_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSeq.Text))
            {
                MessageBox.Show("请选择一个质控项目！");
            }
            else
            {
                this.idConcentration = this.cboConcentration.SelectedIndex;
                this.m_strDeviceSampleID = this.txtCode.Text;
                Cursor.Current = Cursors.WaitCursor;
                if (this.txtSortNum.Text == "")
                {
                    MessageBox.Show("排序号没填!");
                    this.txtSortNum.Focus();
                }
                else
                {
                    if (string.IsNullOrEmpty(this.cboConcentration.Text) || this.cboConcentration.Value < 0)
                    {
                        MessageBox.Show("浓度没填!");
                        this.cboConcentration.Focus();
                    }
                    else
                    {
                        if (this.txtBValue.Text.Trim() != string.Empty)
                        {
                            double num;
                            if (!double.TryParse(this.txtBValue.Text.Trim(), out num))
                            {
                                MessageBox.Show("请输入数字!", this.lblBValue.Text);
                                this.txtBValue.Focus();
                                this.txtBValue.SelectAll();
                                return;
                            }
                        }
                        if (this.txtSD.Text.Trim() != string.Empty)
                        {
                            double num;
                            if (!double.TryParse(this.txtSD.Text.Trim(), out num))
                            {
                                MessageBox.Show("请输入数字!", this.lblCV.Text);
                                this.txtSD.Focus();
                                this.txtSD.SelectAll();
                                return;
                            }
                        }
                        if (this.txtCV.Text.Trim() != string.Empty)
                        {
                            double num;
                            if (!double.TryParse(this.txtCV.Text.Trim(), out num))
                            {
                                MessageBox.Show("请输入数字!", this.lblCV.Text);
                                this.txtCV.Focus();
                                this.txtCV.SelectAll();
                                return;
                            }
                        }
                        int num2 = 0;
                        int.TryParse(this.txtSeq.Text, out num2);
                        int num3 = -1;
                        for (int i = 0; i < this.m_objBatchSets.Count; i++)
                        {
                            if (this.m_objBatchSets[i].m_intSeq == num2)
                            {
                                num3 = i;
                                break;
                            }
                        }
                        if (num3 < 0)
                        {
                            MessageBox.Show("没有找到与之相对应的质控批！");
                            Cursor.Current = Cursors.Default;
                        }
                        else
                        {
                            this.m_objBatchSets[num3].m_intSeq = int.Parse(this.txtSeq.Text.ToString().Trim());
                            this.m_objBatchSets[num3].m_strDeviceId = this.cboApparatusType.SelectedValue.ToString().Trim();
                            this.m_objBatchSets[num3].m_strCheckItemName = this.txtItems.Text.ToString().Trim();
                            this.m_objBatchSets[num3].m_strSampleLotNo = this.txtGroupNum.Text.ToString().Trim();
                            this.m_objBatchSets[num3].m_strSampleSource = this.cboManOrigin.Text.ToString().Trim();
                            this.m_objBatchSets[num3].m_strCheckmethodName = this.cboExamineMethod.Text.ToString().Trim();
                            double dblWaveLength = 0.0;
                            double.TryParse(this.txtWaveLength.Text.ToString(), out dblWaveLength);
                            this.m_objBatchSets[num3].m_dblWaveLength = dblWaveLength;
                            this.m_objBatchSets[num3].m_strResultUnit = this.txtUnit.Text.ToString().Trim();
                            this.m_objBatchSets[num3].m_dtBegin = this.dtpBegindate.Value;
                            this.m_objBatchSets[num3].m_dtEnd = this.dtpEnddate.Value;
                            this.m_objBatchSets[num3].m_strSortNum = this.txtSortNum.Text.ToString().Trim();
                            this.m_objBatchSets[num3].m_strCheckItemId = this.m_txtCheckItemsID.Text.ToString();
                            this.m_objBatchSets[num3].m_strDeviceId = this.m_txtDeviceId.Text.ToString();
                            num3 = -1;
                            for (int i = 0; i < this.m_objConcentrations.Count; i++)
                            {
                                if (this.m_objConcentrations[i].m_intQCBatchSeq == num2)
                                {
                                    num3 = i;
                                    break;
                                }
                            }
                            if (num3 < 0)
                            {
                                this.objConcentrations = new clsLisQCConcentrationVO();
                                this.m_objConcentrations.Add(this.objConcentrations);
                            }
                            else
                            {
                                this.objConcentrations = this.m_objConcentrations[num3];
                            }
                            this.objConcentrations.m_intQCBatchSeq = num2;
                            this.objConcentrations.m_strConcentration = this.cboConcentration.Text.ToString().Trim();
                            if (!string.IsNullOrEmpty(this.objConcentrations.m_strConcentration))
                            {
                                this.objConcentrations.m_intConcentrationSeq = this.cboConcentration.Value;
                            }
                            this.objConcentrations.m_strDeviceSampleId = this.txtCode.Text.ToString().Trim();
                            double num4 = 0.0;
                            double.TryParse(this.txtBValue.Text.ToString(), out num4);
                            this.objConcentrations.m_dblAVG = num4;
                            double.TryParse(this.txtSD.Text.ToString(), out num4);
                            this.objConcentrations.m_dblSD = num4;
                            double.TryParse(this.txtCV.Text.ToString(), out num4);
                            this.objConcentrations.m_dblCV = num4;
                            this.CreateDataTable(this.m_objBatchSets, this.m_objConcentrations);
                            this.m_mthReset();
                            Cursor.Current = Cursors.Default;
                        }
                    }
                }
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            if (this.dtbResult != null && this.dtbResult.Rows.Count > 0)
            {
                long num = this.m_objDomain.m_lngInsertBatchSet(this.m_objBatchSets, this.m_objConcentrations);
                if (num > 0L)
                {
                    MessageBox.Show("保存成功!", "质控管理", MessageBoxButtons.OK);
                    base.DialogResult = DialogResult.OK;
                    base.Close();
                }
                else
                {
                    MessageBox.Show("保存失败！", "质控管理", MessageBoxButtons.OK);
                }
            }
        }
        #endregion

        private void txtCV_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtBValue.Text.Trim()) && !string.IsNullOrEmpty(this.txtSD.Text.Trim()))
            {
                try
                {
                    double num = double.Parse(this.txtBValue.Text.Trim());
                    double num2 = double.Parse(this.txtSD.Text.Trim());
                    double num3 = num2 * 100.0 / num;
                    this.txtCV.Text = num3.ToString("0.0");
                }
                catch
                {
                }
            }
        }

        private void frmQCSetup_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_mthShortCutKey(e.KeyCode);
            base.m_mthSetKeyTab(e);
        }

        private void dgvSetup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvSetup.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)this.dgvSetup.SelectedRows[0].DataBoundItem).Row;
                this.txtSeq.Text = row["intSeq"].ToString();
                this.txtItems.Text = row["itemsname"].ToString();
                this.txtBValue.Text = row["Bvalue"].ToString();
                this.txtCode.Text = row["code"].ToString();
                this.txtCV.Text = row["cv"].ToString();
                this.txtGroupNum.Text = row["groupnum"].ToString();
                this.txtSD.Text = row["sd"].ToString();
                this.txtSortNum.Text = row["sortnum"].ToString();
                this.txtUnit.Text = row["unit"].ToString();
                this.txtWaveLength.Text = row["wavelength"].ToString();
                this.cboApparatusType.Text = row["type"].ToString();
                if (string.IsNullOrEmpty(row["Concentration"].ToString().Trim()))
                {
                    this.cboConcentration.SelectedIndex = this.idConcentration;
                }
                else
                {
                    this.cboConcentration.Text = row["Concentration"].ToString();
                }
                if (string.IsNullOrEmpty(row["code"].ToString().Trim()))
                {
                    this.txtCode.Text = this.m_strDeviceSampleID;
                }
                else
                {
                    this.txtCode.Text = row["code"].ToString();
                }
                this.m_txtCheckItemsID.Text = row["checkitemsid"].ToString();
                this.cboExamineMethod.Text = row["method"].ToString();
                this.cboManOrigin.Text = row["source"].ToString();
                this.m_txtDeviceId.Text = row["m_strDeviceId"].ToString();
                DateTime value;
                DateTime.TryParse(row["begindate"].ToString(), out value);
                DateTime value2;
                DateTime.TryParse(row["enddate"].ToString(), out value2);
                try
                {
                    this.dtpBegindate.Value = value;
                    this.dtpEnddate.Value = value2;
                }
                catch
                {
                    this.dtpBegindate.Value = DateTime.Now;
                    this.dtpEnddate.Value = DateTime.Now;
                }
            }
        }

        private void dgvSetup_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvSetup.SelectedRows.Count >= 1)
            {
                DataRow row = ((DataRowView)this.dgvSetup.SelectedRows[0].DataBoundItem).Row;
                this.txtSeq.Text = row["intSeq"].ToString();
                this.txtItems.Text = row["itemsname"].ToString();
                this.txtBValue.Text = row["Bvalue"].ToString();
                this.txtCode.Text = row["code"].ToString();
                this.txtCV.Text = row["cv"].ToString();
                this.txtGroupNum.Text = row["groupnum"].ToString();
                this.txtSD.Text = row["sd"].ToString();
                this.txtSortNum.Text = row["sortnum"].ToString();
                this.txtUnit.Text = row["unit"].ToString();
                this.txtWaveLength.Text = row["wavelength"].ToString();
                this.cboApparatusType.Text = row["type"].ToString();
                this.cboConcentration.Text = row["Concentration"].ToString();
                this.txtCode.Text = row["code"].ToString();
                this.m_txtCheckItemsID.Text = row["checkitemsid"].ToString();
                this.cboExamineMethod.Text = row["method"].ToString();
                this.cboManOrigin.Text = row["source"].ToString();
                this.m_txtDeviceId.Text = row["m_strDeviceId"].ToString();
                DateTime value;
                DateTime.TryParse(row["begindate"].ToString(), out value);
                DateTime value2;
                DateTime.TryParse(row["enddate"].ToString(), out value2);
                try
                {
                    this.dtpBegindate.Value = value;
                    this.dtpEnddate.Value = value2;
                }
                catch
                {
                    this.dtpBegindate.Value = DateTime.Now;
                    this.dtpEnddate.Value = DateTime.Now;
                }
            }
        }
    }
}
