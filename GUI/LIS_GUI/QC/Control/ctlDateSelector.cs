using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class ctlDateSelector : UserControl
    {
        public enum SelectStyle
        {
            MonthStyle,
            MonthSectStyle,
            DateSectStyle
        }
        private SelectStyle m_selectStyle;
        private DateTime m_datStart;
        private DateTime m_datEnd;
        public DateTime DateStart
        {
            get
            {
                return this.m_datStart;
            }
        }
        public DateTime DateEnd
        {
            get
            {
                return this.m_datEnd;
            }
        }
        public string Text
        {
            get
            {
                return this.m_cmd.Text;
            }
        }
        public void SetDate(DateTime datStart, DateTime datEnd,SelectStyle selectStyle)
        {
            this.m_selectStyle = selectStyle;
            this.m_datStart = datStart;
            this.m_datEnd = datEnd;

            this.m_mthAdjustDat();
            this.m_mthAdjustRad();
            this.m_mthAdjustDtp();
            this.m_mthAdjustText();
        }
        public SelectStyle DateSelectStyle
        {
            get
            {
                return this.m_selectStyle;
            }
            set
            {
                this.m_selectStyle = value;
                this.m_mthAdjustDat();
                this.m_mthAdjustRad();
                this.m_mthAdjustDtp();
                this.m_mthAdjustText();
            }
        }
        public event System.EventHandler ValueChanged;

        Form frm;
        public ctlDateSelector()
        {
            InitializeComponent();
            frm = new Form();
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.Size = new Size(228, 156);
            frm.Controls.Add (this.m_pnlFrm);
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.Manual;
            frm.CancelButton = this.m_cmdCancel;
            //frm.AcceptButton = this.m_cmdConfirm;
            this.m_pnlFrm.Visible = true;
            this.m_pnlFrm.Dock = DockStyle.Fill;

            this.m_datStart = DateTime.Now;
            this.m_datEnd = DateTime.Now;
            this.m_selectStyle = SelectStyle.MonthStyle;
            this.m_mthAdjustDat();
            this.m_mthAdjustRad();
            this.m_mthAdjustDtp();
            this.m_mthAdjustText();
        }
        private void m_mthAdjustRad()
        {
            switch (this.m_selectStyle)
            {
                case SelectStyle.MonthStyle:
                    this.m_radMonth.Checked = true;
                    break;
                case SelectStyle.MonthSectStyle:
                    this.m_radMonthSect.Checked = true;
                    break;
                case SelectStyle.DateSectStyle:
                    this.m_radDateSect.Checked = true;
                    break;
                default:
                    break;
            }
        }
        private void m_mthAdjustDat()
        {
            switch (this.m_selectStyle)
            {
                case SelectStyle.MonthStyle:
                    this.m_datStart = new DateTime(this.m_datStart.Year,this.m_datStart.Month,1);
                    this.m_datEnd = new DateTime(this.m_datStart.Year, this.m_datStart.Month, DateTime.DaysInMonth(this.m_datStart.Year, this.m_datStart.Month));
                    break;
                case SelectStyle.MonthSectStyle:
                    this.m_datStart = new DateTime(this.m_datStart.Year, this.m_datStart.Month, 1);
                    this.m_datEnd = new DateTime(this.m_datEnd.Year, this.m_datEnd.Month, DateTime.DaysInMonth(this.m_datEnd.Year, this.m_datEnd.Month));
                    break;
                case SelectStyle.DateSectStyle:
                    this.m_datStart = new DateTime(this.m_datStart.Year, this.m_datStart.Month, this.m_datStart.Day);
                    this.m_datEnd = new DateTime(this.m_datEnd.Year, this.m_datEnd.Month, this.m_datEnd.Day);
                    break;
                default:
                    break;
            }
        }
        private void m_mthAdjustDtp()
        {
            this.m_dtp1.Value = this.m_datStart;
            this.m_dtp2.Value = this.m_datStart;
            this.m_dtp3.Value = this.m_datEnd;
            this.m_dtp4.Value = this.m_datStart;
            this.m_dtp5.Value = this.m_datEnd;
        }
        private void m_mthAdjustText()
        {
            switch (this.m_selectStyle)
            {
                case SelectStyle.MonthStyle:
                    this.m_cmd.Text = this.m_datStart.ToString("yyyy-MM");
                    break;
                case SelectStyle.MonthSectStyle:
                    this.m_cmd.Text = this.m_datStart.ToString("yyyy-MM") + " - " + this.m_datEnd.ToString("yyyy-MM") ;
                    break;
                case SelectStyle.DateSectStyle:
                    this.m_cmd.Text = this.m_datStart.ToString("yyyy-MM-dd") + " - " + this.m_datEnd.ToString("yyyy-MM-dd");
                    break;
                default:
                    break;
            }
        }

        private void m_cmd_Click(object sender, EventArgs e)
        {
            this.m_mthAdjustRad();
            this.m_mthAdjustDtp();
            Point p = this.Parent.PointToScreen(this.Location);
            frm.Location = new Point(p.X, p.Y); 
            frm.ShowDialog();
        }

        private void m_cmdConfirm_Click(object sender, EventArgs e)
        {
            if (this.m_radMonth.Checked)
            {
                this.m_selectStyle = SelectStyle.MonthStyle;
                this.m_datStart = this.m_dtp1.Value;
                this.m_datEnd = this.m_dtp1.Value;
            }
            else if (this.m_radMonthSect.Checked)
            {
                if (this.m_dtp2.Value > this.m_dtp3.Value)
                    return;
                this.m_selectStyle = SelectStyle.MonthSectStyle;
                this.m_datStart = this.m_dtp2.Value;
                this.m_datEnd = this.m_dtp3.Value;
            }
            else
            {
                if (this.m_dtp4.Value > this.m_dtp5.Value)
                    return;
                this.m_selectStyle = SelectStyle.DateSectStyle;
                this.m_datStart = this.m_dtp4.Value;
                this.m_datEnd = this.m_dtp5.Value;
            }
            this.m_mthAdjustDat();
            this.m_mthAdjustRad();
            this.m_mthAdjustDtp();
            this.m_mthAdjustText();

            frm.Close();
            if (this.ValueChanged != null)
            {
                ValueChanged(this, null);
            }
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            frm.Close();
        }

        private void m_radMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_radMonth.Checked)
            {
                this.m_pnl1.Visible = true;
                this.m_pnl2.Visible = false;
                this.m_pnl3.Visible = false;
            }
        }

        private void m_radMonthSect_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_radMonthSect.Checked)
            {
                this.m_pnl1.Visible = false;
                this.m_pnl2.Visible = true;
                this.m_pnl3.Visible = false;
            }
        }

        private void m_radDateSect_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_radDateSect.Checked)
            {
                this.m_pnl1.Visible = false;
                this.m_pnl2.Visible = false;
                this.m_pnl3.Visible = true;
            }
        }

 
    }
}
