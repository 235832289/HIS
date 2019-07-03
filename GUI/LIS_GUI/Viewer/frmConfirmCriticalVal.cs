using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Diagnostics;
using com.digitalwave.GUI_Base;
using com.digitalwave.Utility;
using com.digitalwave.controls;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.Template.Client;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmConfirmCriticalVal : Form
    {
        EntityCriticalMain mainVo { get; set; }
        List<EntityCriticalLis> lstItems { get; set; }

        public frmConfirmCriticalVal(EntityCriticalMain _mainVo, List<EntityCriticalLis> _lstItems)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                mainVo = _mainVo;
                lstItems = _lstItems;
            }
        }

        private void frmConfirmCriticalVal_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            int index = 0;
            this.dvItem.Rows.Clear();
            foreach (EntityCriticalLis item in lstItems)
            {
                index = this.dvItem.Rows.Add();
                if (string.IsNullOrEmpty(item.checkitemengname))
                    this.dvItem.Rows[index].Cells[0].Value = item.checkitemname;
                else
                    this.dvItem.Rows[index].Cells[0].Value = ((!string.IsNullOrEmpty(item.checkitemengname) && item.checkitemname.IndexOf(item.checkitemengname) >= 0) ? item.checkitemname : item.checkitemname + "(" + item.checkitemengname + ")");
                this.dvItem.Rows[index].Cells[1].Value = item.unit;
                this.dvItem.Rows[index].Cells[2].Value = item.alarmlowval + "~" + item.alarmupval;
                this.dvItem.Rows[index].Cells[3].Value = item.resultvalue;
                this.dvItem.Rows[index].Cells[4].Value = item.alertflag;
            }
        }

        private void frmConfirmCriticalVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #region Save
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="isValid"></param>
        bool Save(bool isValid)
        {
            int ret = 0;
            bizCriticalValue svc = (bizCriticalValue)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(bizCriticalValue));
            ret = svc.DelCriticalValue(mainVo.applyid);
            if (ret < 0)
            {
                return false;
            }
            else
            {
                ret = svc.SaveCriticalValue(mainVo.applyid, mainVo.recorderid, mainVo.recorddate, lstItems, (mainVo.patsubno == "YG" ? true : false), isValid);
                if (ret > 0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;
            if (this.Save(true))
            {
                MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("保存失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.btnSave.Enabled = true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.btnReturn.Enabled = false;
            if (this.Save(false))
            {
                //MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.btnReturn.Enabled = true;            
        }

    }
}
