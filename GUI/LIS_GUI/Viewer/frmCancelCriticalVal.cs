using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui
{
    public partial class frmCancelCritalVal : Form
    {
        EntityCriMonitorType criMonitorTypeVo { get; set; }
        List<EntityCriticalMain> lstMain { get; set; }

        public frmCancelCritalVal(EntityCriMonitorType _criMonitorTypeVo, List<EntityCriticalMain> _lstMain)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                criMonitorTypeVo = _criMonitorTypeVo;
                lstMain = _lstMain;
                this.Text += " --- 姓名：" + lstMain[0].patname;
            }
        }

        private void frmCancelCritalVal_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (lstMain != null && lstMain.Count > 0)
            {
                this.lvItem.BeginUpdate();
                foreach (EntityCriticalMain item in lstMain)
                {
                    ListViewItem obj = new ListViewItem();
                    obj.Text = item.applydate.ToString("yyyy-MM-dd") + " " + item.applyitem;
                    obj.ImageIndex = 0;
                    obj.Tag = item;
                    this.lvItem.Items.Add(obj);
                }
                this.lvItem.EndUpdate();
                this.timer.Enabled = true;
            }
        }

        private void frmCriValResponse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal cvmId = 0;
            if (this.lblCardNo.Tag != null && Convert.ToDecimal(this.lblCardNo.Tag) > 0)
            {
                cvmId = Convert.ToDecimal(this.lblCardNo.Tag);
            }
            else
            {
                MessageBox.Show("请选择危急值记录。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string response = this.txtResponse.Text.Trim();
            if (string.IsNullOrEmpty(response))
            {
                MessageBox.Show("请输入撤销原因，撤销原因不能为空。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtResponse.Focus();
                return;
            }
            DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfimByDefault(this.criMonitorTypeVo.empNo);
            if (dlg == DialogResult.Yes)
            {
                EntityCriCancel cancelVo = new EntityCriCancel();
                cancelVo.cvmid = cvmId;
                cancelVo.cancelempid = this.criMonitorTypeVo.empId;
                cancelVo.cancelreason = response;
                cancelVo.canceldate = DateTime.Now;
                bizCriticalValue svc = (bizCriticalValue)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(bizCriticalValue));
                int ret = svc.CancelCriticalValue(cancelVo);
                svc = null;
                if (ret > 0)
                {
                    MessageBox.Show("危急值报告撤销成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show("危急值报告撤销失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvItem.SelectedItems.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                EntityCriticalMain vo = lvItem.SelectedItems[0].Tag as EntityCriticalMain;
                this.lblCardNo.Text = vo.cardno;
                this.lblCardNo.Tag = vo.cvmid.ToString();
                this.lblIpNo.Text = vo.ipno;
                this.lblItemName.Text = vo.applyitem;
                this.lblPatName.Text = vo.patname;
                this.lblSex.Text = vo.patsex;
                this.lblAge.Text = vo.patage;
                this.lblApplyDate.Text = vo.applydate.ToString("yyyy-MM-dd HH:mm:ss");

                bizCriticalValue svc = (bizCriticalValue)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(bizCriticalValue));
                List<EntityCriticalLis> lstDet = svc.GetCriDetail(vo.cvmid);
                svc = null;
                this.dvItem.Rows.Clear();
                if (lstDet != null && lstDet.Count > 0)
                {
                    int index = 0;
                    foreach (EntityCriticalLis item in lstDet)
                    {
                        index = this.dvItem.Rows.Add();
                        this.dvItem.Rows[index].Cells[0].Value = ((!string.IsNullOrEmpty(item.checkitemengname) && item.checkitemname.IndexOf(item.checkitemengname) >= 0) ? item.checkitemname : item.checkitemname + "(" + item.checkitemengname + ")");
                        this.dvItem.Rows[index].Cells[1].Value = item.unit;
                        this.dvItem.Rows[index].Cells[2].Value = item.alarmlowval + "~" + item.alarmupval;
                        this.dvItem.Rows[index].Cells[3].Value = item.resultvalue;
                        this.dvItem.Rows[index].Cells[4].Value = item.alertflag;
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.lblCardNo.Tag = string.Empty;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timer.Enabled = false;
            this.lvItem.Items[0].Selected = true;
        }
    }
}
