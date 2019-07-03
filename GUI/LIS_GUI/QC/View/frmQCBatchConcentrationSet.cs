using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Collections;


namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmQCBatchConcentrationSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private bool m_blnDBErr = false;

        private int m_intQCBatchSeq = DBAssist.NullInt;

        private List<clsLisQCConcentrationVO> m_objQCContrations = new List<clsLisQCConcentrationVO>();

        private List<clsLisQCConcentrationVO> m_objDeletedQCContrations = new List<clsLisQCConcentrationVO>();

        public List<clsLisQCConcentrationVO> QCContrations
        {
            get
            {
                return this.m_objQCContrations;
            }
        }

        bool m_blnNew = false;


        public frmQCBatchConcentrationSet(int p_intQCBatchSeq,clsLisQCConcentrationVO[] p_objQCContrationVOArr)
        {
            InitializeComponent();


            this.m_intQCBatchSeq = p_intQCBatchSeq;
            if (p_objQCContrationVOArr != null)
            {
                foreach (clsLisQCConcentrationVO var in p_objQCContrationVOArr)
                {
                    if (var != null)
                        this.m_objQCContrations.Add(var);
                }
            }
        }

        private void frmQCBatchConcentrationSet_Load(object sender, EventArgs e)
        {
            m_mthLoadDeletedData();
            m_mthShowList();
            this.Text = this.Text + " - 质控批序号:" + this.m_intQCBatchSeq.ToString();
        }

        #region 一般设置

        #region 快捷键设置

        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            //if (p_eumKeyCode == Keys.F4)
            //{
            //    if (this.m_btnQuery.Enabled == true
            //        && this.m_btnQuery.Visible == true)
            //    {
            //        this.m_btnQuery_Click(this.m_btnQuery, null);
            //    }
            //}
            //else if (p_eumKeyCode == Keys.F8)
            //{
            //    if (this.btnPrint.Enabled == true
            //        && this.btnPrint.Visible == true)
            //    {
            //        this.btnPrint_Click(this.btnPrint, null);
            //    }
            //}
            //else if (p_eumKeyCode == Keys.F3 && this.m_btnPreference.Enabled && m_btnPreference.Visible)//保存
            //{
            //    this.m_btnPreference_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F5 && this.m_btnPrintReport.Enabled && m_btnPrintReport.Visible)//读卡
            //{
            //    this.m_btnPrintReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F6 && this.m_btnPreviewReport.Enabled && m_btnPreviewReport.Visible)		//退出
            //{
            //    this.m_btnPreviewReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F9 && this.m_btnConfirmReport.Enabled && m_btnConfirmReport.Visible)		//清除
            //{
            //    this.m_btnConfirmReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F10 && this.m_btnSaveReport.Enabled && m_btnSaveReport.Visible)//手输和读卡机切换
            //{
            //    this.m_btnSaveReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F12 && this.m_btnDelete.Enabled && m_btnDelete.Visible)//手输和读卡机切换
            //{
            //    this.m_btnDelete_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F8 && this.m_btnNewApp.Enabled && m_btnNewApp.Visible)//手输和读卡机切换
            //{
            //    this.m_btnNewApp_Click(null, null);
            //}
            //			else if(p_eumKeyCode==Keys.F12 && this.m_btnInputSwitch.Enabled && m_btnInputSwitch.Visible)//手输和读卡机切换
            //			{
            //				this.m_btnInputSwitch_Click(null,null);
            //			}
        }

        #endregion

        private void frmReportQuery_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthShortCutKey(e.KeyCode);
            base.m_mthSetKeyTab(e);
        }

        #endregion

        //加载已被删除的数据
        private void m_mthLoadDeletedData()
        {
            clsLisQCConcentrationVO[] objs = null;
            long lngRes = clsTmdQCBatchConcentrationSmp.s_object.m_lngFindDeleted(this.m_intQCBatchSeq, out objs);
            {
                if (lngRes > 0)
                {
                    if (objs != null)
                        this.m_objDeletedQCContrations.AddRange(objs);
                }
                else
                {
                    clsCommonDialog.m_mthShowDBError();
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    this.m_blnDBErr = true;
                    this.Close();
                }
            }
        }
        //填充列表
        private void m_mthShowList()
        {
            this.m_lsvConcentration.BeginUpdate();//开始更新列表
            foreach (clsLisQCConcentrationVO qcConcentration in this.m_objQCContrations)
            {
                ListViewItem item = new ListViewItem(qcConcentration.m_intConcentrationSeq.ToString());
                item.SubItems.Add(qcConcentration.m_strConcentration);
                item.SubItems.Add(qcConcentration.m_strDeviceSampleId);
                item.SubItems.Add(DBAssist.ToString(qcConcentration.m_dblAVG));
                item.SubItems.Add(DBAssist.ToString(qcConcentration.m_dblSD));
                item.SubItems.Add(DBAssist.ToString(qcConcentration.m_dblCV));
                item.SubItems.Add("");
                item.Tag = qcConcentration;
                this.m_lsvConcentration.Items.Add(item);
            }
            foreach (clsLisQCConcentrationVO obj in this.m_objDeletedQCContrations)
            {
                ListViewItem item = new ListViewItem(obj.m_intConcentrationSeq.ToString());
                item.SubItems.Add(obj.m_strConcentration);
                item.SubItems.Add(obj.m_strDeviceSampleId);
                item.SubItems.Add(DBAssist.ToString(obj.m_dblAVG));
                item.SubItems.Add(DBAssist.ToString(obj.m_dblSD));
                item.SubItems.Add(DBAssist.ToString(obj.m_dblCV));
                item.SubItems.Add("╳");
                item.Tag = obj;
                item.ForeColor = Color.Red;
                this.m_lsvConcentration.Items.Add(item);
            }
            this.m_lsvConcentration.EndUpdate();//结束更新列表
            if (this.m_lsvConcentration.Items.Count > 0)
            {
                this.m_lsvConcentration.Focus();
                this.m_lsvConcentration.Items[0].Selected = true;
            }
        }


        //列表选定项变更
        private void m_lsvConcentration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_lsvConcentration.SelectedItems.Count <= 0)
                return;
            //变更状态标志
            this.m_blnNew = false;

            clsLisQCConcentrationVO obj = (clsLisQCConcentrationVO)this.m_lsvConcentration.SelectedItems[0].Tag;

            this.m_cboConcentration.Value = obj.m_intConcentrationSeq;
            this.m_txtDeviceSampleID.Text = obj.m_strDeviceSampleId;
            this.m_txtCV.Text = DBAssist.ToString(obj.m_dblCV);
            this.m_txtSD.Text = DBAssist.ToString(obj.m_dblSD);
            this.m_txtX.Text = DBAssist.ToString(obj.m_dblAVG);
            if (obj.m_enmStatus == enmQCStatus.Natrural)
            {
                this.m_cboConcentration.Enabled = false;
                this.m_txtDeviceSampleID.Enabled = true;
                this.m_txtCV.Enabled = true;
                this.m_txtSD.Enabled = true;
                this.m_txtX.Enabled = true;

                this.m_cmdNew.Enabled = true;
                this.m_cmdDelete.Enabled = true;
                this.m_cmdSave.Enabled = true;
                this.m_cmdReturn.Enabled = true;
                this.m_cmdCancelDelete.Enabled = false;
            }
            else
            {
                this.m_cboConcentration.Enabled = false;
                this.m_txtDeviceSampleID.Enabled = false;
                this.m_txtCV.Enabled = false;
                this.m_txtSD.Enabled = false;
                this.m_txtX.Enabled = false;

                this.m_cmdNew.Enabled = true;
                this.m_cmdDelete.Enabled = false;
                this.m_cmdSave.Enabled = false;
                this.m_cmdReturn.Enabled = true;
                this.m_cmdCancelDelete.Enabled = true;
            }

        }             

        //新增
        private void m_cmdNew_Click(object sender, EventArgs e)
        {
            this.m_cboConcentration.Value = DBAssist.NullInt;
            this.m_cboConcentration.Enabled = true;
            this.m_txtDeviceSampleID.Clear();
            this.m_txtDeviceSampleID.Enabled = true;
            this.m_txtCV.Enabled = true;
            this.m_txtSD.Enabled = true;
            this.m_txtX.Enabled = true;

            this.m_cmdNew.Enabled = false;
            this.m_cmdDelete.Enabled = false;
            this.m_cmdSave.Enabled = true;
            this.m_cmdReturn.Enabled = true;
            this.m_cmdCancelDelete.Enabled = false;

            //使当前ListView具有焦点的行失去焦点
            if (this.m_lsvConcentration.FocusedItem != null)
            {
                this.m_lsvConcentration.FocusedItem.Selected = false;
                this.m_lsvConcentration.FocusedItem.Focused = false;
            }

            //设置光标焦点
            this.m_cboConcentration.Focus();

            //设置新增标志
            this.m_blnNew = true;
        }

        //保存
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            if (this.m_lsvConcentration.SelectedItems.Count <= 0
                && !this.m_blnNew)
                return;

            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdSave.Enabled = false;

            if (this.m_blnNew)
            {//新增的保存
                if (this.m_blnNewCheck())
                {
                    clsLisQCConcentrationVO objQCConcentration = new clsLisQCConcentrationVO();
                    objQCConcentration.m_enmStatus = enmQCStatus.Natrural;
                    objQCConcentration.m_intConcentrationSeq = m_cboConcentration.Value;
                    objQCConcentration.m_intQCBatchSeq = m_intQCBatchSeq;
                    objQCConcentration.m_strConcentration = m_cboConcentration.Text;
                    objQCConcentration.m_strDeviceSampleId = m_txtDeviceSampleID.Text.Trim();
                    try { objQCConcentration.m_dblAVG = Convert.ToDouble(m_txtX.Text.Trim()); }
                    catch { objQCConcentration.m_dblAVG = DBAssist.NullDouble; }
                    try { objQCConcentration.m_dblSD = Convert.ToDouble(m_txtSD.Text.Trim()); }
                    catch { objQCConcentration.m_dblSD = DBAssist.NullDouble; }

                    try { objQCConcentration.m_dblCV = Convert.ToDouble(m_txtCV.Text.Trim()); }
                    catch { objQCConcentration.m_dblCV = DBAssist.NullDouble; }

                    long lngRes = clsTmdQCBatchConcentrationSmp.s_object.m_lngInsert(objQCConcentration);

                    if (lngRes > 0)
                    {//成功
                        //更新状态标志
                        this.m_blnNew = false;
                        //加入到集合
                        this.m_objQCContrations.Add(objQCConcentration);
                        //添加新项
                        ListViewItem item = new ListViewItem(objQCConcentration.m_intConcentrationSeq.ToString());
                        item.SubItems.Add(objQCConcentration.m_strConcentration);
                        item.SubItems.Add(objQCConcentration.m_strDeviceSampleId);
                        item.SubItems.Add(DBAssist.ToString(objQCConcentration.m_dblAVG));
                        item.SubItems.Add(DBAssist.ToString(objQCConcentration.m_dblSD));
                        item.SubItems.Add(DBAssist.ToString(objQCConcentration.m_dblCV));
                        item.SubItems.Add("");
                        item.Tag = objQCConcentration;
                        this.m_lsvConcentration.Items.Add(item);
                        this.m_lsvConcentration.Focus();
                        item.Selected = true;
                        item.Focused = true;
                    }
                    else
                    {//失败
                        clsCommonDialog.m_mthShowDBError();
                    }
                }
            }
            else if(this.m_blnModifyCheck())
            {//修改的保存
                clsLisQCConcentrationVO objConcentration = (clsLisQCConcentrationVO)this.m_lsvConcentration.SelectedItems[0].Tag;

                clsLisQCConcentrationVO objTemp = new clsLisQCConcentrationVO();
                objConcentration.m_mthCopyTo(objTemp);
                objTemp.m_strDeviceSampleId = this.m_txtDeviceSampleID.Text.Trim();
                try { objTemp.m_dblAVG = Convert.ToDouble(m_txtX.Text.Trim()); }
                catch { objTemp.m_dblAVG = DBAssist.NullDouble; }
                try { objTemp.m_dblSD = Convert.ToDouble(m_txtSD.Text.Trim()); }
                catch { objTemp.m_dblSD = DBAssist.NullDouble; }

                try { objTemp.m_dblCV = Convert.ToDouble(m_txtCV.Text.Trim()); }
                catch { objTemp.m_dblCV = DBAssist.NullDouble; }

                long lngRes = clsTmdQCBatchConcentrationSmp.s_object.m_lngUpdate(objTemp);

                if (lngRes > 0)
                {//成功
                    objTemp.m_mthCopyTo(objConcentration);
                    this.m_lsvConcentration.SelectedItems[0].SubItems[2].Text = objConcentration.m_strDeviceSampleId;
                    this.m_lsvConcentration.SelectedItems[0].SubItems[3].Text = DBAssist.ToString(objConcentration.m_dblAVG);
                    this.m_lsvConcentration.SelectedItems[0].SubItems[4].Text = DBAssist.ToString(objConcentration.m_dblSD);
                    this.m_lsvConcentration.SelectedItems[0].SubItems[5].Text = DBAssist.ToString(objConcentration.m_dblCV);
                }
                else
                {//失败
                    clsCommonDialog.m_mthShowDBError();
                }
            }
            this.m_cmdSave.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        //新增保存前检查
        private bool m_blnNewCheck()
        {
            if(!this.m_blnModifyCheck())
            {
                return false;
            }
            foreach (clsLisQCConcentrationVO obj in this.m_objQCContrations)
            {
                if (obj.m_intConcentrationSeq == this.m_cboConcentration.Value)
                {
                    MessageBox.Show("不能加入重复的浓度！", "iCare");
                    this.m_cboConcentration.Focus();
                    return false;
                }
            }
            return true;
        }
        //修改的保存前检查
        private bool m_blnModifyCheck()
        {
            if (DBAssist.IsNull(this.m_cboConcentration.Value))
            {
                MessageBox.Show("浓度不能为空！", "iCare");
                this.m_cboConcentration.Focus();
                return false;
            }
            if (this.m_txtX.Text.Trim() != string.Empty)
            {
                double b;
                if (!double.TryParse(this.m_txtX.Text.Trim(), out b))
                {
                    MessageBox.Show("请输入数字!", "iCare");
                    this.m_txtX.Focus();
                    this.m_txtX.SelectAll();
                    return false;
                }
            }
            if (this.m_txtSD.Text.Trim() != string.Empty)
            {
                double b;
                if (!double.TryParse(this.m_txtSD.Text.Trim(), out b))
                {
                    MessageBox.Show("请输入数字!", "iCare");
                    this.m_txtSD.Focus();
                    this.m_txtSD.SelectAll();
                    return false;
                }
            }
            if (this.m_txtCV.Text.Trim() != string.Empty)
            {
                double b;
                if (!double.TryParse(this.m_txtCV.Text.Trim(), out b))
                {
                    MessageBox.Show("请输入数字!", "iCare");
                    this.m_txtCV.Focus();
                    this.m_txtCV.SelectAll();
                    return false;
                }
            }
            return true;
        }

        //删除
        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            if (this.m_lsvConcentration.SelectedItems.Count <= 0)
                return;
            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdDelete.Enabled = false;

            clsLisQCConcentrationVO obj = (clsLisQCConcentrationVO)this.m_lsvConcentration.SelectedItems[0].Tag;
            clsLisQCConcentrationVO objCopy = new clsLisQCConcentrationVO();
            obj.m_mthCopyTo(objCopy);
            objCopy.m_enmStatus = enmQCStatus.Delete;

            long lngRes = clsTmdQCBatchConcentrationSmp.s_object.m_lngUpdate(objCopy);

            if (lngRes > 0)
            {//成功
                obj.m_enmStatus = enmQCStatus.Delete;
                this.m_objQCContrations.Remove(obj);
                this.m_objDeletedQCContrations.Add(obj);
                //
                this.m_lsvConcentration.SelectedItems[0].SubItems[6].Text = "╳";
                this.m_lsvConcentration.SelectedItems[0].ForeColor = Color.Red;
                this.m_lsvConcentration_SelectedIndexChanged(this.m_lsvConcentration, null);
            }
            else
            {//失败
                clsCommonDialog.m_mthShowDBError();
            }

            this.m_cmdDelete.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        //返回
        private void m_cmdReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //取消删除
        private void m_cmdCancelDelete_Click(object sender, EventArgs e)
        {
            if (this.m_lsvConcentration.SelectedItems.Count <= 0)
                return;
            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdCancelDelete.Enabled = false;

            clsLisQCConcentrationVO obj = (clsLisQCConcentrationVO)this.m_lsvConcentration.SelectedItems[0].Tag;
            clsLisQCConcentrationVO objCopy = new clsLisQCConcentrationVO();
            obj.m_mthCopyTo(objCopy);
            objCopy.m_enmStatus = enmQCStatus.Natrural;

            long lngRes = clsTmdQCBatchConcentrationSmp.s_object.m_lngUpdate(objCopy);

            if (lngRes > 0)
            {//成功
                obj.m_enmStatus = enmQCStatus.Natrural;
                this.m_objDeletedQCContrations.Remove(obj);
                this.m_objQCContrations.Add(obj);
                //
                this.m_lsvConcentration.SelectedItems[0].SubItems[6].Text = "";
                this.m_lsvConcentration.SelectedItems[0].ForeColor = this.m_lsvConcentration.ForeColor;
                this.m_lsvConcentration_SelectedIndexChanged(this.m_lsvConcentration, null);
            }
            else
            {//失败
                clsCommonDialog.m_mthShowDBError();
            }

            this.m_cmdCancelDelete.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void frmQCBatchConcentrationSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.m_blnDBErr)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void m_gpbHead_Enter(object sender, EventArgs e)
        {

        }

        private void m_txtCV_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtX.Text.Trim()) || string.IsNullOrEmpty(m_txtSD.Text.Trim()))
                return;

            try
            {
                double dblX = double.Parse(m_txtX.Text.Trim());
                double dblSD = double.Parse(m_txtSD.Text.Trim());

                double dblCV = dblSD * 100 / dblX;
                m_txtCV.Text = dblCV.ToString("0.0");
            }
            catch
            {
                
            }
        }        
    }
}