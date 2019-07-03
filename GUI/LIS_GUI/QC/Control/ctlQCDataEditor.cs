using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class ctlQCDataEditor : UserControl
    {
        public ctlQCDataEditor()
        {
            InitializeComponent();
            m_dtvSource.Table = this.m_dtbSource;
        }

        internal clsQCBatch ObjBatch
        {
            set
            {
                if (value != null)
                {
                    m_objBatch = value;
                    if (m_objBatch.IsNull)
                    {
                        m_objBatch_Reseted(null,null);
                    }
                    else
                    {
                        this.m_objBatch_Loaded(null, null);
                    }

                    m_objBatch.Reseted += new EventHandler(m_objBatch_Reseted);
                    m_objBatch.Loaded += new EventHandler(m_objBatch_Loaded);
                    m_objBatch.Reloaded += new EventHandler(m_objBatch_Reloaded);
                    m_objBatch.ConcentrationChanged += new EventHandler(m_objBatch_ConcentrationChanged);
                    m_objBatch.DataChanged += new EventHandler(m_objBatch_DataChanged);

                }
                else
                {
                    throw new System.ArgumentNullException();
                }
            }
        }

        void m_objBatch_Reseted(object sender, EventArgs e)
        {
            m_lstChangedVOS.Clear();
            m_lstAddedVOS.Clear();
            m_lstDeletedVOS.Clear();
            m_lstWorkedData.Clear();

            m_dtgEditor.DataSource = null;
            m_dtgEditor.Columns.Clear();

            m_dtvSource.Table = null;
            m_dtbSource = null;

            this.m_cmdAddRowAfter.Enabled = false;
            this.m_cmdAddRowPrev.Enabled = false;
            this.m_cmdDeleteRow.Enabled = false;
            this.m_cmdSave.Enabled = false;
            this.m_dtgEditor.Enabled = false;
        }

        void m_objBatch_Loaded(object sender, EventArgs e)
        {
            m_lstWorkedData = m_objBatch.GetDatas();
            m_lstChangedVOS.Clear();
            m_lstAddedVOS.Clear();
            m_lstDeletedVOS.Clear();

            this.m_cmdAddRowAfter.Enabled = true;
            this.m_cmdAddRowPrev.Enabled = true;
            this.m_cmdDeleteRow.Enabled = true;
            this.m_cmdSave.Enabled = true;
            this.m_dtgEditor.Enabled = true;

            //初始化Editor
            m_dtgEditor.DataSource = null;
            InitializeStyleEditor();
            m_mthConstructDataTable();
            m_mthFillDataTable();
            m_dtgEditor.DataSource = m_dtvSource;
            m_dtbSource.ColumnChanged += new DataColumnChangeEventHandler(m_dtbSource_ColumnChanged);
        }

        void m_objBatch_Reloaded(object sender, EventArgs e)
        {
            m_objBatch_DataChanged(null, null);
        }

        private void m_objBatch_ConcentrationChanged(object sender, EventArgs e)
        {
            this.m_objBatch_Loaded(null, null);
        }

        private void m_objBatch_DataChanged(object sender, EventArgs e)
        {
            m_dtbSource.ColumnChanged -= new DataColumnChangeEventHandler(m_dtbSource_ColumnChanged);
            m_lstWorkedData = m_objBatch.GetDatas();
            m_lstChangedVOS.Clear();
            m_lstAddedVOS.Clear();
            m_lstDeletedVOS.Clear();

            m_mthFillDataTable();
            m_dtbSource.ColumnChanged += new DataColumnChangeEventHandler(m_dtbSource_ColumnChanged);
        }



        #region 私有变量
        private clsQCBatch m_objBatch = new clsQCBatch();
        // DatagridView的数据源
        private DataView m_dtvSource = new DataView();
        private DataTable m_dtbSource = new DataTable("datalist");
        private List<clsLisQCDataVO> m_lstWorkedData = new List<clsLisQCDataVO>();

        private List<clsLisQCDataVO> m_lstChangedVOS = new List<clsLisQCDataVO>();
        private List<clsLisQCDataVO> m_lstAddedVOS = new List<clsLisQCDataVO>();
        private List<clsLisQCDataVO> m_lstDeletedVOS = new List<clsLisQCDataVO>();
        #endregion

        #region Editor的样式和数据

        // 设置Viewer的格式


        private void InitializeStyleEditor()
        {
            this.m_dtgEditor.DataSource = null;

            this.m_dtgEditor.Columns.Clear();
            DataGridViewDateTimeColumn dtColumn = new DataGridViewDateTimeColumn();
            dtColumn.DataPropertyName = "date";
            dtColumn.HeaderText = "日期";
            dtColumn.Name = "date";
            dtColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            m_dtgEditor.Columns.Add(dtColumn);

            foreach (clsLisQCConcentrationVO con in m_objBatch.GetConcentrations())
            {
                DataGridViewTextBoxColumn txtColumn = new DataGridViewTextBoxColumn();
                txtColumn.Name = con.m_intConcentrationSeq.ToString();
                txtColumn.DataPropertyName = con.m_intConcentrationSeq.ToString();
                txtColumn.HeaderText = con.m_strConcentration;
                txtColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                m_dtgEditor.Columns.Add(txtColumn);

                DataGridViewTextBoxColumn txtColumnCopy = new DataGridViewTextBoxColumn();
                txtColumnCopy.Name = con.m_intConcentrationSeq.ToString();
                txtColumnCopy.DataPropertyName = con.m_intConcentrationSeq.ToString() + "obj";
                txtColumnCopy.HeaderText = con.m_strConcentration + "VO";
                // == 设置 ＝＝
                txtColumnCopy.Visible = false;
                txtColumnCopy.ReadOnly = true;
                txtColumnCopy.SortMode = DataGridViewColumnSortMode.NotSortable;
                m_dtgEditor.Columns.Add(txtColumnCopy);
            }
        }

        // 构建DataTable的结构


        private void m_mthConstructDataTable()
        {
            m_dtbSource = new DataTable("datalist");
            m_dtbSource.Columns.Add("date", typeof(System.DateTime));
            m_dtvSource.Table = m_dtbSource;
            m_dtvSource.Sort = "date asc";

            List<clsLisQCConcentrationVO> list = m_objBatch.GetConcentrations();

            foreach (clsLisQCConcentrationVO vo in list)
            {
                m_dtbSource.Columns.Add(vo.m_intConcentrationSeq.ToString(), typeof(System.Double));
                m_dtbSource.Columns.Add(vo.m_intConcentrationSeq.ToString() + "obj", typeof(clsLisQCDataVO));
            }
        }

        // DataTable数据
        private void m_mthFillDataTable()
        {
            List<clsQCDataPair> lstDataPair = clsQCDataPair.GetQCDataPairList(m_lstWorkedData);
            m_dtbSource.Rows.Clear();
            foreach (clsQCDataPair pair in lstDataPair)
            {
                DataRow newRow = m_dtbSource.NewRow();
                newRow["date"] = pair.QCDate;
                foreach (clsLisQCConcentrationVO con in m_objBatch.GetConcentrations())
                {
                    if (pair[con.m_intConcentrationSeq] != null)
                    {
                        newRow[con.m_intConcentrationSeq.ToString()] = pair[con.m_intConcentrationSeq].m_dlbResult;
                        newRow[con.m_intConcentrationSeq.ToString() + "obj"] = pair[con.m_intConcentrationSeq];
                    }
                }
                this.m_dtbSource.Rows.Add(newRow);
            }
        }
        #endregion

        #region 增加、删除、修改



        private void m_mthAddRowAt(int pos)
        {
            DataGridViewRow viewRow = m_dtgEditor.CurrentRow;
            if (viewRow != null)
            {
                DataRow row = m_dtbSource.NewRow();
                if (viewRow.Index + pos > -1)
                {
                    m_dtbSource.Rows.InsertAt(row, viewRow.Index + pos);
                }
            }
        }

        private bool m_mthUpdateQCData(List<clsLisQCDataVO> p_objArr)
        {
            foreach (clsLisQCDataVO vo in p_objArr)
            {
                long lngReg = clsTmdQCDataSmp.s_object.m_lngUpdate(vo);
                if (lngReg <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool m_mthAddQCData(List<clsLisQCDataVO> p_objArr)
        {
            foreach (clsLisQCDataVO vo in p_objArr)
            {
                long lngReg = clsTmdQCDataSmp.s_object.m_lngInsert(vo);
                if (lngReg <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool m_mthDeleteQCData(List<clsLisQCDataVO> p_objArr)
        {
            foreach (clsLisQCDataVO vo in p_objArr)
            {
                long lngReg = clsTmdQCDataSmp.s_object.m_lngDelete(vo.m_intSeq);
                if (lngReg <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        //数据是否发生改变
        private bool m_mthIsDataUnchanged(List<clsLisQCDataVO> p_lstPrev, List<clsLisQCDataVO> p_lstAfter)
        {
            if (p_lstPrev == null && p_lstAfter == null)
                return true;
            if ((p_lstPrev == null && p_lstAfter != null) || (p_lstAfter == null && p_lstPrev != null))
                return false;

            if (p_lstPrev.Count != p_lstAfter.Count)
            {
                return false;
            }

            for (int i = 0; i < p_lstPrev.Count; i++)
            {
                if (p_lstPrev[i] == null && p_lstAfter[i] == null)
                    continue;
                if ((p_lstPrev[i] == null && p_lstAfter[i] != null) || (p_lstAfter[i] == null && p_lstPrev[i] != null))
                    return false;

                if (!p_lstPrev[i].m_mthEquals(p_lstAfter[i]))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 事件实现
        // 保存
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            //更新
            if (m_lstChangedVOS.Count != 0)
            {
                m_mthUpdateQCData(m_lstChangedVOS);
                m_lstChangedVOS.Clear();
            }
            //新增
            if (m_lstAddedVOS.Count != 0)
            {
                m_mthAddQCData(m_lstAddedVOS);
                foreach (clsLisQCDataVO vo in m_lstAddedVOS)
                {
                    m_lstWorkedData.Add(vo);
                }
                m_lstAddedVOS.Clear();
            }
            //删除
            if (m_lstDeletedVOS.Count != 0)
            {
                m_mthDeleteQCData(m_lstDeletedVOS);
                foreach (clsLisQCDataVO vo in m_lstDeletedVOS)
                {
                    m_lstWorkedData.Remove(vo);
                }
                m_lstDeletedVOS.Clear();
            }

            //更新数据模型
            this.m_objBatch.DataChanged -= new EventHandler(m_objBatch_DataChanged);
            this.m_objBatch.UpdateDatas(m_lstWorkedData);
            this.m_objBatch.DataChanged += new EventHandler(m_objBatch_DataChanged);

        }

        //数据发生改变
        private void m_dtbSource_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName != "date" && !e.Column.ColumnName.Contains("obj"))
            {
                string strConcentrationSeq = e.Column.ToString();
                clsLisQCDataVO qcData = e.Row[strConcentrationSeq + "obj"] as clsLisQCDataVO;
                if (qcData != null)
                {
                    //新增的，还未添加到数据库中的
                    if (qcData.m_intSeq == -1)
                    {
                        if (e.Row[e.Column].ToString() == string.Empty)
                        {
                            this.m_lstAddedVOS.Remove(qcData);
                        }
                        else
                        {
                            try
                            {
                                double dlbNewResult = Convert.ToDouble(e.Row[e.Column]);
                                qcData.m_dlbResult = dlbNewResult;
                            }
                            catch { }
                        }


                    }
                    // 数据库中有，更新
                    else
                    {
                        if (e.Row[e.Column].ToString() != string.Empty)
                        {
                            try
                            {
                                double dlbNewResult = Convert.ToDouble(e.Row[e.Column]);
                                qcData.m_dlbResult = dlbNewResult;
                            }
                            catch { }
                            this.m_lstChangedVOS.Add(qcData);
                        }
                        // 数据库中有的数据置为空后，


                        // 数据从数据库中删除


                        else
                        {
                            try
                            {
                                clsLisQCDataVO delQCData = e.Row[strConcentrationSeq + "obj"] as clsLisQCDataVO;
                                this.m_lstDeletedVOS.Add(delQCData);
                                e.Row[strConcentrationSeq + "obj"] = System.DBNull.Value;
                            }
                            catch { }
                        }
                    }
                }
                //qcData=null
                if (qcData == null && e.Row[e.Column].ToString() != string.Empty)
                {
                    //日期为空
                    if (e.Row["date"].ToString() == string.Empty)
                    {
                        MessageBox.Show("请先输入日期！");
                        e.Row[e.Column] = System.DBNull.Value;
                    }
                    else
                    {
                        //新增表中无,数据库中没有
                        clsLisQCDataVO newQCData = new clsLisQCDataVO();
                        newQCData.m_intSeq = -1;
                        newQCData.m_intQCBatchSeq = this.m_objBatch.GetQCBatchSet().m_intSeq;
                        try
                        {
                            newQCData.m_intConcentrationSeq = Convert.ToInt32(strConcentrationSeq);
                        }
                        catch { }
                        try
                        {
                            newQCData.m_dlbResult = Convert.ToDouble(e.Row[e.Column]);
                        }
                        catch { }
                        try
                        {
                            newQCData.m_datQCDate = Convert.ToDateTime(e.Row["date"]);
                        }
                        catch { }
                        e.Row[strConcentrationSeq + "obj"] = newQCData;
                        this.m_lstAddedVOS.Add(newQCData);
                    }
                }
            }
            if (e.Column.ColumnName == "date")
            {
                DateTime dt = DBAssist.ToDateTime(e.Row["date"]);
                if (dt != DBAssist.NullDateTime)
                {
                    foreach (clsLisQCConcentrationVO vo in m_objBatch.GetConcentrations())
                    {
                        clsLisQCDataVO data = e.Row[vo.m_intConcentrationSeq + "obj"] as clsLisQCDataVO;

                        if (data != null)
                        {
                            data.m_datQCDate = dt;
                            e.Row[vo.m_intConcentrationSeq.ToString() + "obj"] = data;
                            this.m_lstChangedVOS.Add(data);
                        }
                    }
                }
            }
        }

        private void m_dtgEditor_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            m_dtgEditor.Rows[e.RowIndex].ErrorText = "";
            double newDouble;
            DateTime dt;

            if (m_dtgEditor.Rows[e.RowIndex].IsNewRow) { return; }
            string columnName = m_dtgEditor.Columns[e.ColumnIndex].Name;

            if (!(columnName == "date") && !columnName.Contains("obj"))
            {
                if ((!double.TryParse(e.FormattedValue.ToString(),
                out newDouble) || newDouble < 0) && e.FormattedValue.ToString() != string.Empty)
                {
                    e.Cancel = true;
                    m_dtgEditor.Rows[e.RowIndex].ErrorText = "输入的数不是整数！";
                }
            }
        }

        private void m_cmdAddRowPrev_Click(object sender, EventArgs e)
        {

            m_mthAddRowAt(0);
        }

        private void m_cmdAddRowAfter_Click(object sender, EventArgs e)
        {
            m_mthAddRowAt(1);
        }

        private void m_cmdDeleteRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow viewRow = m_dtgEditor.CurrentRow;
            if (viewRow != null)
            {
                DialogResult result = MessageBox.Show(this, "确定删除整行吗？", "删除操作", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DataRow row = m_dtbSource.Rows[viewRow.Index];
                    foreach (clsLisQCConcentrationVO con in m_objBatch.GetConcentrations())
                    {
                        clsLisQCDataVO vo = row[con.m_intConcentrationSeq + "obj"] as clsLisQCDataVO;
                        if (vo != null)
                        {
                            if (vo.m_intSeq != -1)
                            {
                                row[con.m_intConcentrationSeq + "obj"] = System.DBNull.Value;
                                this.m_lstDeletedVOS.Add(vo);
                            }
                            else
                            {
                                this.m_lstAddedVOS.Remove(vo);
                            }
                        }
                    }
                    m_dtbSource.Rows.RemoveAt(viewRow.Index);
                }
            }
        }

        private void m_dtgEditor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.m_dtgEditor.BeginEdit(true);
        }
        #endregion
    }
}