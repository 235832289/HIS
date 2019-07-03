using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 质控数据管理(新)--支持同时管理多批质控数据
    /// </summary>
    public partial class ctlQCDataEditorNew : UserControl
    {
        #region 私有变量
        public clsQCBatchNew m_objBatch;
        /// <summary>
        /// DatagridView的数据源
        /// </summary>
        private DataView m_dtvSource = new DataView();
        private DataTable m_dtbSource = new DataTable("datalist");
        private List<clsLisQCDataVO> m_lstWorkedData = new List<clsLisQCDataVO>();
        private List<clsLisQCDataVO> m_lstChangedVOS = new List<clsLisQCDataVO>();
        private List<clsLisQCDataVO> m_lstAddedVOS = new List<clsLisQCDataVO>();
        private List<clsLisQCDataVO> m_lstDeletedVOS = new List<clsLisQCDataVO>();
        private clsTmdQCBatchSmp m_objDomain = new clsTmdQCBatchSmp();
        private string m_strFixDeviceSampleID = null;
        private string m_strLocalX = "本室均值";
        private string m_strLocalSD = "标准差";
        private string m_strLocalCV = "变异系数(%)";
        private string m_strLocalConn = "刷新当前浓度?";
        private string m_strFlashConn = "刷新";

        #endregion



        public ctlQCDataEditorNew()
        {
            this.InitializeComponent();
            this.m_dtvSource.Table = this.m_dtbSource;
        }


        internal clsQCBatchNew ObjBatch
        {
            set
            {
                if (value != null)
                {
                    this.m_objBatch = value;
                    if (this.m_objBatch.IsNull)
                    {
                        this.m_objBatch_Reseted(null, null);
                    }
                    else
                    {
                        this.m_objBatch_Loaded(null, null);
                    }
                    this.m_objBatch.Reseted += new EventHandler(this.m_objBatch_Reseted);
                    this.m_objBatch.Loaded += new EventHandler(this.m_objBatch_Loaded);
                    this.m_objBatch.Reloaded += new EventHandler(this.m_objBatch_Reloaded);
                    this.m_objBatch.DataChanged += new EventHandler(this.m_objBatch_DataChanged);
                    return;
                }
                throw new ArgumentNullException();
            }
        }

        private void ctlQCDataEditorNew_Load(object sender, EventArgs e)
        {
            try
            {
                this.m_strFixDeviceSampleID = this.m_objDomain.m_strGetSysParam("6001");
            }
            catch
            {
                this.m_strFixDeviceSampleID = string.Empty;
            }
            if (string.IsNullOrEmpty(this.m_strFixDeviceSampleID))
            {
                this.m_lblDeviceSampleID.Visible = false;
                this.m_txtDeviceSampleID.Visible = false;
                this.m_txtDeviceSampleID.Clear();
            }
            else
            {
                this.m_lblDeviceSampleID.Visible = true;
                this.m_txtDeviceSampleID.Visible = true;
                this.m_txtDeviceSampleID.Clear();
            }
        }


        private void m_objBatch_Reseted(object sender, EventArgs e)
        {
            this.m_lstChangedVOS.Clear();
            this.m_lstAddedVOS.Clear();
            this.m_lstDeletedVOS.Clear();
            this.m_lstWorkedData.Clear();
            this.m_dtgEditor.DataSource = null;
            this.m_dtgEditor.Columns.Clear();
            this.m_dtvSource.Table = null;
            this.m_dtbSource = null;
            this.m_cmdAddRowAfter.Enabled = false;
            this.m_cmdAddRowPrev.Enabled = false;
            this.m_cmdDeleteRow.Enabled = false;
            this.m_cmdSave.Enabled = false;
            this.m_dtgEditor.Enabled = false;
            this.m_dtpStartDate.Value = DateTime.Now.Date;
            this.m_dtpEndDate.Value = DateTime.Now;
            this.m_cmdDataImpot.Enabled = false;
        }
        private void m_objBatch_Loaded(object sender, EventArgs e)
        {
            this.m_lstWorkedData = this.m_objBatch.GetDatas();
            this.m_lstChangedVOS.Clear();
            this.m_lstAddedVOS.Clear();
            this.m_lstDeletedVOS.Clear();
            this.m_cmdAddRowAfter.Enabled = true;
            this.m_cmdAddRowPrev.Enabled = true;
            this.m_cmdDeleteRow.Enabled = true;
            this.m_cmdSave.Enabled = true;
            this.m_dtgEditor.Enabled = true;
            this.m_dtpStartDate.Value = DateTime.Now.Date;
            this.m_dtpEndDate.Value = DateTime.Now;
            this.m_cmdDataImpot.Enabled = true;
            this.m_dtgEditor.DataSource = null;
            this.InitializeStyleEditor();
            this.m_mthConstructDataTable();
            this.m_mthFillDataTable();
            this.m_dtgEditor.DataSource = this.m_dtvSource;
            this.m_dtbSource.ColumnChanged += new DataColumnChangeEventHandler(this.m_dtbSource_ColumnChanged);
        }
        private void m_objBatch_Reloaded(object sender, EventArgs e)
        {
            this.m_objBatch_DataChanged(null, null);
        }
        private void m_objBatch_ConcentrationChanged(object sender, EventArgs e)
        {
            this.m_objBatch_Loaded(null, null);
        }
        private void m_objBatch_DataChanged(object sender, EventArgs e)
        {
            this.m_dtbSource.ColumnChanged -= new DataColumnChangeEventHandler(this.m_dtbSource_ColumnChanged);
            this.m_lstWorkedData = this.m_objBatch.GetDatas();
            this.m_lstChangedVOS.Clear();
            this.m_lstAddedVOS.Clear();
            this.m_lstDeletedVOS.Clear();
            this.m_dtpStartDate.Value = DateTime.Now.Date;
            this.m_dtpEndDate.Value = DateTime.Now;
            this.m_mthFillDataTable();
            this.m_dtbSource.ColumnChanged += new DataColumnChangeEventHandler(this.m_dtbSource_ColumnChanged);
        }

        private void InitializeStyleEditor()
        {
            this.m_dtgEditor.DataSource = null;

            this.m_dtgEditor.Columns.Clear();
            DataGridViewDateTimeColumn dtColumn = new DataGridViewDateTimeColumn();
            dtColumn.DataPropertyName = "date";
            dtColumn.HeaderText = "日期";
            dtColumn.Name = "date";
            dtColumn.Visible = false;
            dtColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            m_dtgEditor.Columns.Add(dtColumn);

            dtColumn = new DataGridViewDateTimeColumn();
            dtColumn.DataPropertyName = "strdate";
            dtColumn.HeaderText = "日期";
            dtColumn.Name = "strdate";
            dtColumn.ReadOnly = true;
            dtColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.m_dtgEditor.Columns.Add(dtColumn);

            foreach (clsLisQCBatchVO objBatch in m_objBatch.GetQCBatchSet())
            {
                DataGridViewTextBoxColumn txtColumn = new DataGridViewTextBoxColumn();
                txtColumn.Name = objBatch.m_intSeq.ToString();
                txtColumn.DataPropertyName = objBatch.m_intSeq.ToString();
                txtColumn.HeaderText = objBatch.m_strCheckItemName;
                txtColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                m_dtgEditor.Columns.Add(txtColumn);

                DataGridViewTextBoxColumn txtColumn1 = new DataGridViewTextBoxColumn();
                txtColumn1.Name = objBatch.m_intSeq.ToString()+ "1";
                txtColumn1.DataPropertyName = objBatch.m_intSeq.ToString() + "1";
                txtColumn1.HeaderText = objBatch.m_strCheckItemName;
                txtColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
                m_dtgEditor.Columns.Add(txtColumn1);

                DataGridViewTextBoxColumn txtColumn2 = new DataGridViewTextBoxColumn();
                txtColumn2.Name = objBatch.m_intSeq.ToString()+ "2";
                txtColumn2.DataPropertyName = objBatch.m_intSeq.ToString() + "2";
                txtColumn2.HeaderText = objBatch.m_strCheckItemName;
                txtColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
                m_dtgEditor.Columns.Add(txtColumn2);

                DataGridViewTextBoxColumn txtColumnCopy = new DataGridViewTextBoxColumn();
                txtColumnCopy.Name = objBatch.m_intSeq.ToString() + "obj";
                txtColumnCopy.DataPropertyName = objBatch.m_intSeq.ToString() + "obj";
                txtColumnCopy.HeaderText = objBatch.m_intSeq + "VO";
                // == 设置 ＝＝
                txtColumnCopy.Visible = false;
                txtColumnCopy.ReadOnly = true;
                txtColumnCopy.SortMode = DataGridViewColumnSortMode.NotSortable;
                m_dtgEditor.Columns.Add(txtColumnCopy);

                DataGridViewTextBoxColumn txtColumnCopy1 = new DataGridViewTextBoxColumn();
                txtColumnCopy1.Name = objBatch.m_intSeq.ToString() + "1" + "obj";
                txtColumnCopy1.DataPropertyName = objBatch.m_intSeq.ToString() + "1" + "obj";
                txtColumnCopy.HeaderText = objBatch.m_intSeq + "VO";
                // == 设置 ＝＝
                txtColumnCopy1.Visible = false;
                txtColumnCopy1.ReadOnly = true;
                txtColumnCopy1.SortMode = DataGridViewColumnSortMode.NotSortable;
                m_dtgEditor.Columns.Add(txtColumnCopy1);

                DataGridViewTextBoxColumn txtColumnCopy2 = new DataGridViewTextBoxColumn();
                txtColumnCopy2.Name = objBatch.m_intSeq.ToString() + "2" + "obj";
                txtColumnCopy2.DataPropertyName = objBatch.m_intSeq.ToString() + "2" + "obj";
                txtColumnCopy2.HeaderText = objBatch.m_intSeq + "VO";
                // == 设置 ＝＝
                txtColumnCopy2.Visible = false;
                txtColumnCopy2.ReadOnly = true;
                txtColumnCopy2.SortMode = DataGridViewColumnSortMode.NotSortable;
                m_dtgEditor.Columns.Add(txtColumnCopy2);
            }
        }
        public void m_mthConstructDataTable()
        {
            this.m_dtbSource = new DataTable("datalist");
            this.m_dtbSource.Columns.Add("date", typeof(DateTime));
            this.m_dtbSource.Columns.Add("strdate", typeof(string));
            this.m_dtvSource.Table = this.m_dtbSource;
            this.m_dtvSource.Sort = "date asc";
            List<clsLisQCBatchVO> qCBatchSet = this.m_objBatch.GetQCBatchSet();
            foreach (clsLisQCBatchVO current in qCBatchSet)
            {
                this.m_dtbSource.Columns.Add(current.m_intSeq.ToString(), typeof(string));
                this.m_dtbSource.Columns.Add(current.m_intSeq.ToString() + "1", typeof(string));
                this.m_dtbSource.Columns.Add(current.m_intSeq.ToString() + "2", typeof(string));
                this.m_dtbSource.Columns.Add(current.m_intSeq.ToString() + "obj", typeof(clsLisQCDataVO));
                this.m_dtbSource.Columns.Add(current.m_intSeq.ToString() + "1" + "obj", typeof(clsLisQCDataVO));
                this.m_dtbSource.Columns.Add(current.m_intSeq.ToString() + "2" + "obj", typeof(clsLisQCDataVO));
            }
        }


        /// <summary>
        /// DataTable数据
        /// </summary>
        private void m_mthFillDataTable()
        {
            List<clsQCDataPairItem> lstDataPair = clsQCDataPairItem.GetQCDataPairItemList(m_lstWorkedData);
            m_dtbSource.Rows.Clear();
            List<int> seqArr = new List<int>();
            DateTime dteBegin = m_objBatch.DateBegin;
            DateTime dteEnd;

            while (true)
            {
                dteEnd = this.m_objBatch.DateEnd;

                if (!(dteBegin <= dteEnd.Date))
                {
                    break;
                }

                DataRow dataRow = this.m_dtbSource.NewRow();
                dataRow["date"] = dteBegin.Date;
                dataRow["strdate"] = dteBegin.Date.ToString("yyyy-MM-dd");

                foreach (clsQCDataPairItem pair in lstDataPair)
                {
                    dteEnd = pair.QCDate;
                    if (dteEnd.Date == dteBegin.Date)
                    {
                        seqArr.Add(this.m_objBatch.SeqArr[0]) ;
                        seqArr.Add(Convert.ToInt16(this.m_objBatch.SeqArr[0].ToString() + "1") );
                        seqArr.Add(Convert.ToInt16(this.m_objBatch.SeqArr[0].ToString() + "2") );

                        for (int i = 0; i < seqArr.Count; i++)
                        {
                            int p_intBatchSeq = seqArr[i];

                            if (pair[p_intBatchSeq] != null)
                            {
                                dataRow[p_intBatchSeq.ToString()] = pair[p_intBatchSeq].m_dlbResult;
                                dataRow[p_intBatchSeq.ToString() + "obj"] = pair[p_intBatchSeq];
                            }
                        }
                    }
                }
                this.m_dtbSource.Rows.Add(dataRow);
                dteBegin = dteBegin.AddDays(1.0);
            }

            dteEnd = this.m_objBatch.DateEnd;
            dteBegin = dteEnd.Date;


            DataRow dataRow2 = this.m_dtbSource.NewRow();
            dataRow2["date"] = dteBegin.AddHours(20.0);
            dataRow2["strdate"] = this.m_strLocalX;
            this.m_dtbSource.Rows.Add(dataRow2);
            DataRow dataRow3 = this.m_dtbSource.NewRow();
            dataRow3["date"] = dteBegin.AddHours(21.0);
            dataRow3["strdate"] = this.m_strLocalSD;
            this.m_dtbSource.Rows.Add(dataRow3);
            DataRow dataRow4 = this.m_dtbSource.NewRow();
            dataRow4["date"] = dteBegin.AddHours(22.0);
            dataRow4["strdate"] = this.m_strLocalCV;
            this.m_dtbSource.Rows.Add(dataRow4);
            DataRow dataRow5 = this.m_dtbSource.NewRow();
            dataRow5["date"] = dteBegin.AddHours(23.0);
            dataRow5["strdate"] = this.m_strLocalConn;
            this.m_dtbSource.Rows.Add(dataRow5);

            List<double> list = null;
            clsLisQCConcentrationVO clsLisQCConcentrationVO = null;
            seqArr.Clear();
            seqArr.Add(this.m_objBatch.SeqArr[0]);
            seqArr.Add(Convert.ToInt16(this.m_objBatch.SeqArr[0].ToString() + "1"));
            seqArr.Add(Convert.ToInt16(this.m_objBatch.SeqArr[0].ToString() + "2"));
            for (int i = 0; i < seqArr.Count; i++)
            {
                int p_intBatchSeq = seqArr[i];
                dataRow5[p_intBatchSeq.ToString()] = this.m_strFlashConn;
                list = this.m_objBatch.m_mthGetDatas(p_intBatchSeq);
                if (list != null && list.Count > 0)
                {
                    List<clsLisQCConcentrationVO> concentrations = this.m_objBatch.GetConcentrations(p_intBatchSeq);
                    if (concentrations != null && concentrations.Count > 0)
                    {
                        clsLisQCConcentrationVO = concentrations[0];
                    }
                    if (clsLisQCConcentrationVO != null)
                    {
                        this.m_mthDataFilter(clsLisQCConcentrationVO.m_dblAVG, clsLisQCConcentrationVO.m_dblSD, ref list);
                    }
                    double num;
                    double num2;
                    double num3;
                    clsLISPublic.m_lngCalculateSDXCV(list.ToArray(), out num, out num2, out num3);
                    dataRow2[p_intBatchSeq.ToString()] = num.ToString("0.00");
                    dataRow3[p_intBatchSeq.ToString()] = num2.ToString("0.000");
                    dataRow4[p_intBatchSeq.ToString()] = num3.ToString("0.00");
                }
            }
            this.m_dtbSource.AcceptChanges();
        }
        private void m_mthComputeSDXCV(string p_strColName)
        {
            if (!string.IsNullOrEmpty(p_strColName))
            {
                if (!p_strColName.Contains("date") && !p_strColName.Contains("obj"))
                {
                    DateTime dateBegin = this.m_objBatch.DateBegin;
                    List<double> list = new List<double>();
                    int i = 0;
                    int num = this.m_dtbSource.Rows.Count - 4;
                    double item = 0.0;
                    for (i = 0; i < num; i++)
                    {
                        DataRow dataRow = this.m_dtbSource.Rows[i];
                        string text = dataRow[p_strColName].ToString().Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            if (double.TryParse(text, out item))
                            {
                                list.Add(item);
                            }
                        }
                    }
                    if (list.Count > 0)
                    {
                        double num2;
                        double num3;
                        double num4;
                        clsLISPublic.m_lngCalculateSDXCV(list.ToArray(), out num2, out num3, out num4);
                        this.m_dtbSource.Rows[i][p_strColName] = num2.ToString("0.00");

                        i++;
                        this.m_dtbSource.Rows[i][p_strColName] = num3.ToString("0.000");

                        i++;
                        this.m_dtbSource.Rows[i][p_strColName] = num4.ToString("0.00");

                    }
                    else
                    {
                        this.m_dtbSource.Rows[i][p_strColName] = "";

                        i++;
                        this.m_dtbSource.Rows[i][p_strColName] = "";

                        i++;
                        this.m_dtbSource.Rows[i][p_strColName] = "";

                    }
                }
            }
        }
        public void m_mthAddDataTable(clsLisQCDataVO[] p_objQCDataArr)
        {
            if (p_objQCDataArr != null && p_objQCDataArr.Length > 0)
            {
                List<clsLisQCDataVO> list = new List<clsLisQCDataVO>();
                list.AddRange(p_objQCDataArr);
                List<clsQCDataPairItem> qCDataPairItemList = clsQCDataPairItem.GetQCDataPairItemList(list);
                foreach (clsQCDataPairItem current in qCDataPairItemList)
                {
                    string strFilter = string.Empty;
                    strFilter = "date >= '";
                    strFilter += current.QCDate.ToString("yyyy-MM-dd 00:00:00");
                    strFilter += "' and date <= '";
                    strFilter += current.QCDate.ToString("yyyy-MM-dd 23:59:59") + "'";

                    DataRow[] drr = this.m_dtbSource.Select(strFilter);
                    if (drr != null && drr.Length > 0)
                    {
                        DataRow dataRow = drr[0];
                        int[] seqArr = this.m_objBatch.SeqArr;
                        for (int i = 0; i < seqArr.Length; i++)
                        {
                            int p_intBatchSeq = seqArr[i];
                            clsLisQCDataVO qcDataVo = current[p_intBatchSeq];
                            if (qcDataVo != null)
                            {
                                if (dataRow[p_intBatchSeq.ToString()] == DBNull.Value)
                                {
                                    dataRow[p_intBatchSeq.ToString()] = qcDataVo.m_dlbResult;
                                }
                            }
                        }
                    }
                    else
                    {
                        DataRow dataRow = this.m_dtbSource.NewRow();
                        dataRow["date"] = current.QCDate.Date;
                        dataRow["strdate"] = current.QCDate.Date.ToString("yyyy-MM-dd");
                        int[] seqArr = this.m_objBatch.SeqArr;

                        for (int i = 0; i < seqArr.Length; i++)
                        {
                            int p_intBatchSeq = seqArr[i];
                            clsLisQCDataVO qcDataVo = current[p_intBatchSeq];
                            if (qcDataVo != null)
                            {
                                dataRow[p_intBatchSeq.ToString()] = qcDataVo.m_dlbResult;
                                dataRow[p_intBatchSeq.ToString() + "obj"] = qcDataVo;
                            }
                        }
                        this.m_dtbSource.Rows.Add(dataRow);
                    }
                }
            }
        }
        private void m_mthAddRowAt(int pos)
        {
            DataGridViewRow currentRow = this.m_dtgEditor.CurrentRow;
            if (currentRow != null)
            {
                DataRow row = this.m_dtbSource.NewRow();
                if (currentRow.Index + pos > -1)
                {
                    this.m_dtbSource.Rows.InsertAt(row, currentRow.Index + pos);
                }
            }
        }
        private bool m_mthUpdateQCData(List<clsLisQCDataVO> p_objArr)
        {
            bool result;
            foreach (clsLisQCDataVO current in p_objArr)
            {
                long num = this.m_objDomain.m_lngUpdateQCData(current);
                if (num <= 0L)
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }
        private bool m_mthAddQCData(List<clsLisQCDataVO> p_objArr)
        {
            bool result;
            foreach (clsLisQCDataVO current in p_objArr)
            {
                long num = this.m_objDomain.m_lngInsertQCData(current, out current.m_intSeq);
                if (num <= 0L)
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }
        private bool m_mthDeleteQCData(List<clsLisQCDataVO> p_objArr)
        {
            bool result;
            foreach (clsLisQCDataVO current in p_objArr)
            {
                long num = this.m_objDomain.m_lngDeleteQCData(current.m_intSeq);
                if (num <= 0L)
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }
        private bool m_mthIsDataUnchanged(List<clsLisQCDataVO> p_lstPrev, List<clsLisQCDataVO> p_lstAfter)
        {
            bool result;
            if (p_lstPrev == null && p_lstAfter == null)
            {
                result = true;
            }
            else
            {
                if ((p_lstPrev == null && p_lstAfter != null) || (p_lstAfter == null && p_lstPrev != null))
                {
                    result = false;
                }
                else
                {
                    if (p_lstPrev.Count != p_lstAfter.Count)
                    {
                        result = false;
                    }
                    else
                    {
                        for (int i = 0; i < p_lstPrev.Count; i++)
                        {
                            if (p_lstPrev[i] != null || p_lstAfter[i] != null)
                            {
                                if ((p_lstPrev[i] == null && p_lstAfter[i] != null) || (p_lstAfter[i] == null && p_lstPrev[i] != null))
                                {
                                    result = false;
                                    return result;
                                }
                                if (!p_lstPrev[i].m_mthEquals(p_lstAfter[i]))
                                {
                                    result = false;
                                    return result;
                                }
                            }
                        }
                        result = true;
                    }
                }
            }
            return result;
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            clsLisQCDataVO[] array = null;
            clsLisQCDataVO[] p_objUpdateArr = null;
            int[] array2 = null;
            int[] array3 = null;
            if (this.m_lstAddedVOS != null && this.m_lstAddedVOS.Count > 0)
            {
                array = this.m_lstAddedVOS.ToArray();
            }
            if (this.m_lstChangedVOS != null && this.m_lstChangedVOS.Count > 0)
            {
                p_objUpdateArr = this.m_lstChangedVOS.ToArray();
            }
            if (this.m_lstDeletedVOS != null && this.m_lstDeletedVOS.Count > 0)
            {
                array2 = new int[this.m_lstDeletedVOS.Count];
                for (int i = 0; i < this.m_lstDeletedVOS.Count; i++)
                {
                    array2[i] = this.m_lstDeletedVOS[i].m_intSeq;
                }
            }
            long num = this.m_objDomain.m_lngSaveAllQCData(array, p_objUpdateArr, array2, out array3);
            if (num > 0L)
            {
                if (array3 != null && array3.Length > 0)
                {
                    for (int i = 0; i < array3.Length; i++)
                    {
                        array[i].m_intSeq = array3[i];
                    }
                    this.m_lstWorkedData.AddRange(array);
                    this.m_lstAddedVOS.Clear();
                }
                if (this.m_lstChangedVOS != null)
                {
                    this.m_lstChangedVOS.Clear();
                }
                if (this.m_lstDeletedVOS != null)
                {
                    foreach (clsLisQCDataVO current in this.m_lstDeletedVOS)
                    {
                        this.m_lstWorkedData.Remove(current);
                    }
                    this.m_lstDeletedVOS.Clear();
                }
                this.m_objBatch.DataChanged -= new EventHandler(this.m_objBatch_DataChanged);
                this.m_objBatch.UpdateDatas(this.m_lstWorkedData);
                this.m_objBatch.DataChanged += new EventHandler(this.m_objBatch_DataChanged);
            }
            else
            {
                MessageBox.Show("保存失败！", "保存操作", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void m_cmdAddRowPrev_Click(object sender, EventArgs e)
        {
            this.m_mthAddRowAt(0);
        }
        private void m_cmdAddRowAfter_Click(object sender, EventArgs e)
        {
            this.m_mthAddRowAt(1);
        }
        private void m_cmdDeleteRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = this.m_dtgEditor.CurrentRow;
            DataRow row = ((DataRowView)currentRow.DataBoundItem).Row;
            if (row != null)
            {
                string s = row["strdate"].ToString().Trim();
                DateTime minValue = DateTime.MinValue;
                if (DateTime.TryParse(s, out minValue))
                {
                    DialogResult dialogResult = MessageBox.Show(this, "确定删除整行吗？", "删除操作", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int[] seqArr = this.m_objBatch.SeqArr;
                        for (int i = 0; i < seqArr.Length; i++)
                        {
                            int num = seqArr[i];
                            clsLisQCDataVO clsLisQCDataVO = row[num.ToString() + "obj"] as clsLisQCDataVO;
                            if (clsLisQCDataVO != null)
                            {
                                if (clsLisQCDataVO.m_intSeq != -1)
                                {
                                    row[num.ToString() + "obj"] = DBNull.Value;
                                    this.m_lstDeletedVOS.Add(clsLisQCDataVO);
                                }
                                else
                                {
                                    this.m_lstAddedVOS.Remove(clsLisQCDataVO);
                                }
                            }
                            row[num.ToString()] = DBNull.Value;
                            row[num.ToString() + "obj"] = DBNull.Value;
                        }
                    }
                }
            }
        }

        private void m_dtbSource_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            string a = e.Row["strdate"].ToString().Trim();
            if (a == this.m_strLocalX || a == this.m_strLocalSD || a == this.m_strLocalCV || a == this.m_strLocalConn)
            {
                e.Row.CancelEdit();
            }
            else
            {
                string columnName = e.Column.ColumnName;
                this.m_dtbSource.ColumnChanged -= new DataColumnChangeEventHandler(this.m_dtbSource_ColumnChanged);
                if (!columnName.Contains("date") && !columnName.Contains("obj"))
                {
                    string columnName2 = e.Column.ColumnName;
                    clsLisQCDataVO clsLisQCDataVO = e.Row[columnName2 + "obj"] as clsLisQCDataVO;
                    if (clsLisQCDataVO != null)
                    {
                        if (clsLisQCDataVO.m_intSeq == -1)
                        {
                            if (e.Row[e.Column].ToString() == string.Empty)
                            {
                                this.m_lstAddedVOS.Remove(clsLisQCDataVO);
                            }
                            else
                            {
                                try
                                {
                                    double dlbResult = Convert.ToDouble(e.Row[e.Column]);
                                    clsLisQCDataVO.m_dlbResult = dlbResult;
                                }
                                catch
                                {
                                }
                            }
                        }
                        else
                        {
                            if (e.Row[e.Column].ToString() != string.Empty)
                            {
                                try
                                {
                                    double dlbResult = Convert.ToDouble(e.Row[e.Column]);
                                    clsLisQCDataVO.m_dlbResult = dlbResult;
                                }
                                catch
                                {
                                }
                                this.m_lstChangedVOS.Add(clsLisQCDataVO);
                            }
                            else
                            {
                                try
                                {
                                    clsLisQCDataVO item = e.Row[columnName2 + "obj"] as clsLisQCDataVO;
                                    this.m_lstDeletedVOS.Add(item);
                                    e.Row[columnName2 + "obj"] = DBNull.Value;
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    if (clsLisQCDataVO == null && e.Row[e.Column].ToString() != string.Empty)
                    {
                        if (e.Row["date"].ToString() == string.Empty)
                        {
                            MessageBox.Show("请先输入日期！");
                            e.Row[e.Column] = DBNull.Value;
                        }
                        else
                        {
                            clsLisQCDataVO clsLisQCDataVO2 = new clsLisQCDataVO();
                            clsLisQCDataVO2.m_intSeq = -1;
                            clsLisQCDataVO2.m_intQCBatchSeq = Convert.ToInt32(columnName2);
                            clsLisQCDataVO2.m_intConcentrationSeq = -1;
                            try
                            {
                                clsLisQCDataVO2.m_dlbResult = Convert.ToDouble(e.Row[e.Column]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                clsLisQCDataVO2.m_datQCDate = Convert.ToDateTime(e.Row["date"]);
                            }
                            catch
                            {
                            }
                            e.Row[columnName2 + "obj"] = clsLisQCDataVO2;
                            this.m_lstAddedVOS.Add(clsLisQCDataVO2);
                        }
                    }
                }
                if (e.Column.ColumnName == "date")
                {
                    DateTime dateTime = DBAssist.ToDateTime(e.Row["date"]);
                    if (dateTime != DBAssist.NullDateTime)
                    {
                        int[] seqArr = this.m_objBatch.SeqArr;
                        for (int i = 0; i < seqArr.Length; i++)
                        {
                            int num = seqArr[i];
                            clsLisQCDataVO clsLisQCDataVO3 = e.Row[num.ToString() + "obj"] as clsLisQCDataVO;
                            if (clsLisQCDataVO3 != null)
                            {
                                clsLisQCDataVO3.m_datQCDate = dateTime;
                                e.Row[num.ToString() + "obj"] = clsLisQCDataVO3;
                                this.m_lstChangedVOS.Add(clsLisQCDataVO3);
                            }
                        }
                    }
                }
                if (!columnName.Contains("date") && !columnName.Contains("obj"))
                {
                    this.m_mthComputeSDXCV(columnName);
                }
                this.m_dtbSource.ColumnChanged += new DataColumnChangeEventHandler(this.m_dtbSource_ColumnChanged);
            }
        }

        private void m_cmdDataImpot_Click(object sender, EventArgs e)
        {
            if (!this.m_objBatch.IsNull)
            {
                string str = string.Empty;
                DateTime dteEnd = this.m_dtpEndDate.Value;
                DateTime dteBegin = this.m_objBatch.DateBegin;
                bool result;
                if (!(dteEnd < dteBegin))
                    result = !(this.m_dtpStartDate.Value > this.m_objBatch.DateEnd.Date);
                else
                    result = false;

                if (!result)
                {
                    str = "请选择 ";
                    dteBegin = this.m_objBatch.DateBegin;
                    str += dteBegin.ToString("yyyy-MM-dd");
                    str += " -- ";
                    dteEnd = this.m_objBatch.DateEnd;
                    str += dteEnd.ToString("yyyy-MM-dd");
                    str += " 范围内的接收日期！";
                    MessageBox.Show(str, "接收数据操作", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    string p_strStartDat = null;
                    string p_strEndDat = null;
                    dteBegin = this.m_objBatch.DateBegin;
                    if (this.m_dtpStartDate.Value >= this.m_objBatch.DateBegin)
                    {
                        dteBegin = this.m_dtpStartDate.Value;
                        p_strStartDat = dteBegin.ToString("yyyy-MM-dd 00:00:00");
                    }
                    else
                    {
                        dteBegin = this.m_objBatch.DateBegin;
                        p_strStartDat = dteBegin.ToString("yyyy-MM-dd 00:00:00");
                    }
                    dteEnd = this.m_dtpEndDate.Value;
                    if (dteEnd.Date <= this.m_objBatch.DateEnd.Date)
                    {
                        p_strEndDat = this.m_dtpEndDate.Value.ToString("yyyy-MM-dd 23:59:59");
                    }
                    else
                    {
                        p_strEndDat = this.m_objBatch.DateEnd.ToString("yyyy-MM-dd 23:59:59");
                    }

                    clsLisQCDataVO[] array2 = null;
                    long num = 0L;
                    if (string.IsNullOrEmpty(this.m_strFixDeviceSampleID))
                    {
                        num = this.m_objDomain.m_lngReceiveDeviceQCData(p_strStartDat, p_strEndDat, this.m_objBatch.SeqArr, out array2);
                    }
                    else
                    {
                        string text2 = this.m_txtDeviceSampleID.Text.Trim();
                        if (string.IsNullOrEmpty(text2))
                        {
                            text2 = this.m_strFixDeviceSampleID;
                        }
                        num = this.m_objDomain.m_lngReceiveDeviceQCDataBySampleID(text2, p_strStartDat, p_strEndDat, this.m_objBatch.SeqArr, out array2);
                    }
                    if (num <= 0L)
                    {
                        MessageBox.Show("接收数据失败！", "接收数据操作", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        if (array2 != null && array2.Length > 0)
                        {
                            this.m_mthAddDataTable(array2);
                        }
                    }
                }
            }
        }
        public void m_mthDataFilter(double p_dblX, double p_dblSD, ref List<double> p_lisDblData)
        {
        }
        private void m_dtgEditor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int count = this.m_dtgEditor.Rows.Count;
            for (int i = e.RowIndex; i < count; i++)
            {
                DataGridViewRow dgvRow = this.m_dtgEditor.Rows[i];
                if((DataRowView)dgvRow.DataBoundItem != null)
                {
                    DataRow row = ((DataRowView)dgvRow.DataBoundItem).Row;
                    if (row != null)
                    {
                        string a = row["strdate"].ToString().Trim();
                        if (a == this.m_strLocalX || a == this.m_strLocalSD || a == this.m_strLocalCV)
                        {
                            dgvRow.DefaultCellStyle.ForeColor = Color.Magenta;
                        }
                        if (a == this.m_strLocalConn)
                        {
                            dgvRow.DefaultCellStyle.BackColor = Color.Gray;
                            dgvRow.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                            dgvRow.DefaultCellStyle.ForeColor = Color.Blue;
                        }
                    }
                }
            }
        }
        private void m_dtgEditor_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dtgEditor_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            this.m_dtgEditor.Rows[e.RowIndex].ErrorText = "";
            if (!this.m_dtgEditor.Rows[e.RowIndex].IsNewRow)
            {
                DataRow row = ((DataRowView)this.m_dtgEditor.Rows[e.RowIndex].DataBoundItem).Row;
                if (row != null)
                {
                    string a = row["strdate"].ToString().Trim();
                    if (!(a == this.m_strLocalConn))
                    {
                        string name = this.m_dtgEditor.Columns[e.ColumnIndex].Name;
                        if (!name.Contains("date") && !name.Contains("obj"))
                        {
                            double num;
                            if ((!double.TryParse(e.FormattedValue.ToString(), out num) || num < 0.0) && e.FormattedValue.ToString() != string.Empty)
                            {
                                e.Cancel = true;
                                this.m_dtgEditor.Rows[e.RowIndex].ErrorText = "输入的数不是整数！";
                            }
                        }
                    }
                }
            }
        }
        private void m_dtgEditor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataRow row = ((DataRowView)this.m_dtgEditor.Rows[e.RowIndex].DataBoundItem).Row;
                if (row["strdate"].ToString().Trim() == this.m_strLocalConn)
                {
                    string name = this.m_dtgEditor.Columns[e.ColumnIndex].Name;
                    if (!name.Contains("date"))
                    {
                        row = ((DataRowView)this.m_dtgEditor.Rows[e.RowIndex - 1].DataBoundItem).Row;
                        if (row[name] != DBNull.Value)
                        {
                            double dblCV = Convert.ToDouble(row[name]);
                            row = ((DataRowView)this.m_dtgEditor.Rows[e.RowIndex - 2].DataBoundItem).Row;
                            if (row[name] != DBNull.Value)
                            {
                                double dblSD = Convert.ToDouble(row[name]);
                                row = ((DataRowView)this.m_dtgEditor.Rows[e.RowIndex - 3].DataBoundItem).Row;
                                if (row[name] != DBNull.Value)
                                {
                                    double dblAVG = Convert.ToDouble(row[name]);
                                    if (MessageBox.Show("是否刷新当前浓度！", "质控管理", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                    {
                                        int num = 0;
                                        int.TryParse(name, out num);
                                        List<clsLisQCConcentrationVO> concentrations = this.m_objBatch.GetConcentrations(num);
                                        if (concentrations != null && concentrations.Count > 0)
                                        {
                                            clsLisQCConcentrationVO clsLisQCConcentrationVO = concentrations[0];
                                            clsLisQCConcentrationVO.m_enmStatus = enmQCStatus.Natrural;
                                            clsLisQCConcentrationVO.m_dblCV = dblCV;
                                            clsLisQCConcentrationVO.m_dblAVG = dblAVG;
                                            clsLisQCConcentrationVO.m_dblSD = dblSD;
                                            long num2 = this.m_objDomain.m_lngUpdateSDXCV(clsLisQCConcentrationVO);
                                            if (num2 > 0L)
                                            {
                                                concentrations[0] = clsLisQCConcentrationVO;
                                                this.m_objBatch.UpdateConcentrations(concentrations, num);
                                                MessageBox.Show("刷新当前浓度成功！", "质控管理", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            }
                                            else
                                            {
                                                MessageBox.Show("刷新当前浓度失败！", "质控管理", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("刷新当前浓度失败！原因是未设置浓度。", "质控管理", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        }
                                    }
                                }
                            }
                        }
                        this.m_dtgEditor.CurrentCell = this.m_dtgEditor[e.ColumnIndex, e.RowIndex - 1];
                    }
                }
            }
        }

    }
}
