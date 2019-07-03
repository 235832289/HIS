using System;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.LIS
{
    public class ctlSampleCheck : com.digitalwave.GUI_Base.clsController_Base
    {
        #region override

        private frmSampleCheck viewer { get; set; }

        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.viewer = (frmSampleCheck)frmMDI_Child_Base_in;
        }

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        internal void Init()
        {
            viewer.Height = Screen.PrimaryScreen.WorkingArea.Height;
            viewer.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - viewer.Width) / 2, 0);
            if (viewer.BizType == 1)
                viewer.Text += " - 住院";
            else
                viewer.Text += " - 体检";
        }
        #endregion

        #region LoadSamplePack
        /// <summary>
        /// LoadSamplePack
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        internal bool LoadSamplePack(string barCode)
        {
            bool isExist = false;
            for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
            {
                if (viewer.dataGridView.Rows[i].Cells["barCode"].Value.ToString() == barCode)
                {
                    isExist = true;
                    break;
                }
            }
            if (isExist == false)
            {
                if (MessageBox.Show("是否读入样本包信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
                try
                {
                    viewer.Cursor = Cursors.WaitCursor;
                    viewer.dataGridView.Rows.Clear();
                    viewer.dataGridView.Refresh();
                    clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
                    List<EntitySamplePack> data = domain.SamplePackQuery(barCode, (viewer.BizType == 1 ? 4 : 3));
                    domain = null;
                    if (data != null && data.Count > 0)
                    {
                        int n = -1;
                        string[] arr = null;
                        foreach (EntitySamplePack vo in data)
                        {
                            n = -1;
                            arr = new string[16];
                            arr[++n] = vo.sortNo.ToString();
                            arr[++n] = vo.barCode;
                            arr[++n] = vo.patName;
                            arr[++n] = vo.sex;
                            arr[++n] = vo.age;
                            arr[++n] = vo.itemName;
                            arr[++n] = vo.itemCode;
                            arr[++n] = vo.packId.ToString();
                            arr[++n] = vo.peNo;
                            arr[++n] = vo.checkerName;
                            arr[++n] = vo.checkDate == null ? "" : vo.checkDate.Value.ToString("yyyy-MM-dd HH:mm");
                            arr[++n] = vo.patientId;
                            arr[++n] = vo.applyEmpId;
                            arr[++n] = vo.applyDeptId;
                            arr[++n] = vo.applyDate.ToString("yyyy-MM-dd HH:mm");
                            arr[++n] = vo.packDate == null ? vo.recordDate.ToString("yyyy-MM-dd HH:mm") : vo.packDate.Value.ToString("yyyy-MM-dd HH:mm");

                            viewer.dataGridView.Rows.Add(arr);
                        }
                        viewer.dataGridView.Refresh();
                        int num = 0;
                        for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(viewer.dataGridView.Rows[i].Cells["checkDate"].Value.ToString()))
                            {
                                viewer.dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                                num++;
                            }
                        }
                        ShowSampleNums();
                    }
                    else
                    {
                        MessageBox.Show("查无记录.", "系统提示");
                        return false;
                    }
                }
                finally
                {
                    viewer.Cursor = Cursors.Default;
                }
            }
            return true;
        }
        #endregion

        #region CheckSample
        /// <summary>
        /// CheckSample
        /// </summary>
        internal void CheckSample()
        {
            int rowNo = -1;
            string barCode = viewer.txtBarCode.Text.Trim();
            if (barCode == string.Empty) return;
            if (barCode != string.Empty && barCode.Length < 9 && viewer.BizType == 0)
            {
                barCode = barCode.PadLeft(9, '0');
                viewer.txtBarCode.Text = barCode;
            }
            if (viewer.BizType == 0 && barCode.Length != 9)
            {
                MessageBox.Show("检验标本条码为9位数，请核对.", "系统提示");
                return;
            }
            if (viewer.BizType == 1 && barCode.Length == 9)
            {
                MessageBox.Show("住院标本条码小于9位数，请核对.", "系统提示");
                return;
            }

            if (LoadSamplePack(barCode) == false) return;
            for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
            {
                if (viewer.dataGridView.Rows[i].Cells["barCode"].Value.ToString() == barCode)
                {
                    if (!string.IsNullOrEmpty(viewer.dataGridView.Rows[i].Cells["checkDate"].Value.ToString()))
                    {
                        MessageBox.Show("此条码样本已核收.", "系统提示");
                        return;
                    }
                    rowNo = i;
                    break;
                }
            }
            if (rowNo < 0)
            {
                MessageBox.Show("此条码数据异常--可能申请科室信息等资料为空，不能核收。", "系统提示");
                return;
            }
            EntitySamplePack sampleVo = new EntitySamplePack();
            sampleVo.barCode = barCode;
            sampleVo.peNo = viewer.dataGridView.Rows[rowNo].Cells["peNo"].Value.ToString();
            sampleVo.patName = viewer.dataGridView.Rows[rowNo].Cells["patName"].Value.ToString();
            sampleVo.sex = viewer.dataGridView.Rows[rowNo].Cells["sex"].Value.ToString();
            sampleVo.age = viewer.dataGridView.Rows[rowNo].Cells["age"].Value.ToString();
            sampleVo.checkerId = viewer.LoginInfo.m_strEmpID;
            sampleVo.itemCode = viewer.dataGridView.Rows[rowNo].Cells["itemCode"].Value.ToString();
            sampleVo.itemName = viewer.dataGridView.Rows[rowNo].Cells["itemName"].Value.ToString();
            sampleVo.patientId = viewer.dataGridView.Rows[rowNo].Cells["patientId"].Value.ToString();
            sampleVo.applyEmpId = viewer.dataGridView.Rows[rowNo].Cells["applyEmpId"].Value.ToString();
            sampleVo.applyDeptId = viewer.dataGridView.Rows[rowNo].Cells["applyDeptId"].Value.ToString();
            sampleVo.applyDate = Convert.ToDateTime(viewer.dataGridView.Rows[rowNo].Cells["applyDate"].Value.ToString());
            sampleVo.packDate = Convert.ToDateTime(viewer.dataGridView.Rows[rowNo].Cells["packDate"].Value.ToString());
            clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
            try
            {
                viewer.Cursor = Cursors.WaitCursor;
                sampleVo.typeId = viewer.BizType;
                if (domain.SamplePackCheck(sampleVo))
                {
                    viewer.dataGridView.Rows[rowNo].Cells["checkerName"].Value = viewer.LoginInfo.m_strEmpName;
                    viewer.dataGridView.Rows[rowNo].Cells["checkDate"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    viewer.dataGridView.Rows[rowNo].DefaultCellStyle.ForeColor = Color.Red;

                    ShowSampleNums();
                    viewer.txtBarCode.Text = string.Empty;
                    viewer.txtBarCode.Focus();
                }
                else
                {
                    MessageBox.Show("核收失败.", "系统提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("核收异常:" + ex.Message, "系统提示");
            }
            finally
            {
                domain = null;
                viewer.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region 显示状态
        /// <summary>
        /// 显示状态
        /// </summary>
        void ShowSampleNums()
        {
            int num = 0;
            for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(viewer.dataGridView.Rows[i].Cells["checkDate"].Value.ToString()))
                {
                    num++;
                }
            }
            viewer.lblInfo.Text = "整包共 " + viewer.dataGridView.Rows.Count + " 支, 已核收 " + num + " 支";
        }
        #endregion

        #endregion
    }
}
