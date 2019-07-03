using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.iCare.Template.Client;
using System.Collections;


namespace com.digitalwave.iCare.gui.LIS
{
    #region ctlDataGridTextBoxColumn
    /// <summary>
    /// 检验报告录入->项目结果->单元格组件
    /// </summary>
    public　partial class ctlDataGridTextBoxColumn : System.Windows.Forms.DataGridTextBoxColumn
    {
        public event dlgColumnPaintEventHandler evtColumnPaintEvent;
        public event dlgCellQueryEditableEventHandler evtCellQueryEditable;
        protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)
        {
            clsCellQueryEditableArgs e = new clsCellQueryEditableArgs(source, rowNum, bounds, this.ReadOnly, instantText, cellIsVisible);
            if (this.evtCellQueryEditable != null)
            {
                evtCellQueryEditable(this, e);
            }
            base.Edit(source, rowNum, bounds, e.ReadOnly, instantText, e.CellIsVisible);
            this.TextBox.ReadOnly = e.ReadOnly;
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            clsColumnPaintEventArgs e = new clsColumnPaintEventArgs(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            if (evtColumnPaintEvent != null)
            {
                evtColumnPaintEvent(this, e);
            }
            if (e.BackBrush != null)
            {
                backBrush = e.BackBrush;
            }
            if (e.ForeBrush != null)
            {
                foreBrush = e.ForeBrush;
            }

            alignToRight = e.AlignToRight;

            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        }
    }

    public class clsCellQueryEditableArgs : System.EventArgs
    {
        private bool readOnly;
        private CurrencyManager source;
        private int rowNum;
        private Rectangle bounds;
        private string instantText;
        private bool cellIsVisible;
        public clsCellQueryEditableArgs(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)
        {
            this.readOnly = readOnly;
            this.source = source;
            this.rowNum = rowNum;
            this.bounds = bounds;
            this.instantText = instantText;
            this.cellIsVisible = cellIsVisible;
        }
        /// <summary>
        /// 可读写
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return readOnly;
            }
            set
            {
                readOnly = value;
            }
        }
        /// <summary>
        /// 只读
        /// </summary>
        public CurrencyManager Source
        {
            get
            {
                return source;
            }
        }
        /// <summary>
        /// 只读
        /// </summary>
        public int RowNum
        {
            get
            {
                return rowNum;
            }
        }
        /// <summary>
        /// 只读
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return bounds;
            }
        }
        /// <summary>
        /// 只读
        /// </summary>
        public string InstantText
        {
            get
            {
                return instantText;
            }
        }
        /// <summary>
        /// 可读写
        /// </summary>
        public bool CellIsVisible
        {
            get
            {
                return cellIsVisible;
            }
            set
            {
                this.cellIsVisible = value;
            }
        }
    }
    public class clsColumnPaintEventArgs : System.EventArgs
    {
        private Graphics g;
        private Rectangle bounds;
        private CurrencyManager source;
        private int rowNum;
        private Brush backBrush;
        private Brush foreBrush;
        private bool alignToRight;

        public clsColumnPaintEventArgs(Graphics p_g, Rectangle p_bounds, CurrencyManager p_source, int p_rowNum, Brush p_backBrush, Brush p_foreBrush, bool p_alignToRight)
        {
            this.g = p_g;
            this.bounds = p_bounds;
            this.source = p_source;
            this.rowNum = p_rowNum;
            this.backBrush = p_backBrush;
            this.foreBrush = p_foreBrush;
            this.alignToRight = p_alignToRight;
        }
        /// <summary>
        /// 只读
        /// </summary>
        public Graphics G
        {
            get
            {
                return g;
            }
        }
        /// <summary>
        /// 只读
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return bounds;
            }
        }
        /// <summary>
        /// 只读
        /// </summary>
        public CurrencyManager Source
        {
            get
            {
                return source;
            }
        }
        /// <summary>
        /// 只读
        /// </summary>
        public int RowNum
        {
            get
            {
                return rowNum;
            }
        }
        /// <summary>
        /// 可读写
        /// </summary>
        public Brush BackBrush
        {
            get
            {
                return backBrush;
            }
            set
            {
                this.backBrush = value;
            }
        }

        /// <summary>
        /// 可读写
        /// </summary>
        public Brush ForeBrush
        {
            get
            {
                return foreBrush;
            }
            set
            {
                this.foreBrush = value;
            }
        }
        /// <summary>
        /// 可读写
        /// </summary>
        public bool AlignToRight
        {
            get
            {
                return alignToRight;
            }
            set
            {
                alignToRight = value;
            }
        }
    }
    public delegate void dlgCellQueryEditableEventHandler(System.Object p_sender, clsCellQueryEditableArgs e);
    public delegate void dlgColumnPaintEventHandler(System.Object p_objSender, clsColumnPaintEventArgs e);
    
    #endregion	
}
