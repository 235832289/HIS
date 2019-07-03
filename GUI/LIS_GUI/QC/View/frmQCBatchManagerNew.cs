using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 质控管理
    /// </summary>
    public partial class frmQCBatchManagerNew : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 质控批类
        /// </summary>
        List<clsLisQCBatchVO> m_lstQCBachVO = null;
        /// <summary>
        /// 质控数据管理类
        /// </summary>
        private clsQCBatchNew m_objCurrentBatch = new clsQCBatchNew();


        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmQCBatchManagerNew()
        {
            InitializeComponent();

            m_objCurrentBatch.LoadFailed += new clsQCBatchNew.DataLoadFailedEventHandler(m_objCurrentBatch_LoadFailed);
            m_objCurrentBatch.SetChanged += new EventHandler(m_objCurrentBatch_SetChanged);
            m_ctlQCBatchReportEditor.QCBatch = m_objCurrentBatch;
            m_ctlDataEditor.ObjBatch = this.m_objCurrentBatch;
            m_ctlChart.ObjBatch = this.m_objCurrentBatch;
        }

        #endregion

        #region 主体数据模型 m_objCurrentBatch
        void m_objCurrentBatch_SetChanged(object sender, EventArgs e)
        {
            //if (this.m_lsvQCBatch.SelectedItems.Count > 0)
            //{
            //    this.m_mthListViewItemChange(this.m_objCurrentBatch.GetQCBatchSet(), this.m_lsvQCBatch.SelectedItems[0]);
            //}
        }

        void m_objCurrentBatch_LoadFailed(object sender, clsQCBatchNew.DataLoadFailedEventArgs e)
        {
            MessageBox.Show(e.FailedMessage, "iCare");
        }
        #endregion

        #region 显示质控批

        /// <summary>
        /// 显示质控批
        /// </summary>
        /// <param name="p_tv"></param>
        /// <param name="p_lstQCBachVO"></param>
        private void m_mthShowQCBatch(TreeView p_tv, List<clsLisQCBatchVO> p_lstQCBachVO)
        {

            if (p_tv != null)
            {
                p_tv.Nodes.Clear();
                if (p_lstQCBachVO != null && p_lstQCBachVO.Count > 0)
                {
                    p_lstQCBachVO.Sort(new Comparison<clsLisQCBatchVO>(clsQCBatchNew.CompareQCBatchVO));
                    Dictionary<string, List<clsLisQCBatchVO>> dictionary = new Dictionary<string, List<clsLisQCBatchVO>>();
                    foreach (clsLisQCBatchVO current in p_lstQCBachVO)
                    {
                        if (dictionary.ContainsKey(current.m_strDeviceId))
                        {
                            dictionary[current.m_strDeviceId].Add(current);
                        }
                        else
                        {
                            List<clsLisQCBatchVO> list = new List<clsLisQCBatchVO>();
                            list.Add(current);
                            dictionary.Add(current.m_strDeviceId, list);
                        }
                    }
                    TreeNode tnLotNo = null;
                    if (dictionary != null && dictionary.Count > 0)
                    {
                        foreach (string current2 in dictionary.Keys)
                        {
                            TreeNode tnDevice = new TreeNode(dictionary[current2][0].m_strDeviceName);
                            tnDevice.Name = current2;
                            tnDevice.ImageIndex = 1;
                            tnDevice.SelectedImageIndex = 1;
                            tnDevice.Tag = current2;
                            p_tv.Nodes.Add(tnDevice);
                            foreach (clsLisQCBatchVO current in dictionary[current2])
                            {
                                if (!string.IsNullOrEmpty(current.m_strSampleLotNo))
                                {
                                    TreeNode[] array = tnDevice.Nodes.Find(current.m_strSampleLotNo, false);
                                    if (array == null || array.Length <= 0)
                                    {
                                        tnLotNo = new TreeNode(current.m_strSampleLotNo);
                                        tnLotNo.Name = current.m_strSampleLotNo;
                                        tnLotNo.Tag = "质控批";
                                        tnLotNo.ImageIndex = 0;
                                        tnLotNo.SelectedImageIndex = 0;
                                        tnDevice.Nodes.Add(tnLotNo);
                                        TreeNode tnCheckItemName = new TreeNode(current.m_strCheckItemName);
                                        tnCheckItemName.Name = current.m_intSeq.ToString();
                                        tnCheckItemName.ImageIndex = 2;
                                        tnCheckItemName.SelectedImageIndex = 2;
                                        tnCheckItemName.Tag = current;
                                        tnLotNo.Nodes.Add(tnCheckItemName);
                                    }
                                    else
                                    {
                                        TreeNode tnCheckItemName = new TreeNode(current.m_strCheckItemName);
                                        tnCheckItemName.Name = current.m_intSeq.ToString();
                                        tnCheckItemName.ImageIndex = 2;
                                        tnCheckItemName.SelectedImageIndex = 2;
                                        tnCheckItemName.Tag = current;
                                        array[0].Nodes.Add(tnCheckItemName);
                                    }
                                }
                                else
                                {
                                    TreeNode tnCheckItemName = new TreeNode(current.m_strCheckItemName);
                                    tnCheckItemName.Name = current.m_intSeq.ToString();
                                    tnCheckItemName.ImageIndex = 2;
                                    tnCheckItemName.SelectedImageIndex = 2;
                                    tnCheckItemName.Tag = current;
                                    tnLotNo.Nodes.Add(tnCheckItemName);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdNewQCBatch_Click(object sender, EventArgs e)
        {
            frmQCBatchSet frm = new frmQCBatchSet();
            frm.M_blnCanReturnArr = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.QCBatchVOArr != null)
                {
                    if (m_lstQCBachVO == null)
                        m_lstQCBachVO = new List<clsLisQCBatchVO>();
                    m_lstQCBachVO.AddRange(frm.QCBatchVOArr);

                    m_mthShowQCBatch(m_trvQCBatch, m_lstQCBachVO);

                    TreeNode[] tnArr = m_trvQCBatch.Nodes.Find(frm.QCBatchVOArr[0].m_intSeq.ToString(), true);
                    if (tnArr != null && tnArr.Length > 0)
                        m_trvQCBatch.SelectedNode = tnArr[0];
                }
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_ctlQCBatchQuery_QuerySucceed(object sender, ctlQCBatchQuery.QuerySucceedEventArgs e)
        {
            if (m_lstQCBachVO == null)
                m_lstQCBachVO = new List<clsLisQCBatchVO>();

            if (this.m_rdbReplace.Checked)
            {
                m_lstQCBachVO.Clear();
            }

            m_lstQCBachVO.AddRange(e.Result);

            m_mthShowQCBatch(m_trvQCBatch, m_lstQCBachVO);

            m_tabList.SelectedTab = m_tbpQCBatchList;
            m_trvQCBatch.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_trvQCBatch_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.m_trvQCBatch.SelectedNode != null)
            {
                TreeNode selectedNode = this.m_trvQCBatch.SelectedNode;
                string node = selectedNode.Tag as string;
                DateTime dateTime = this.m_ctlDateSelector.DateStart;
                DateTime date = dateTime.Date;
                dateTime = this.m_ctlDateSelector.DateEnd;
                dateTime = dateTime.Date;
                dateTime = dateTime.AddDays(1.0);
                DateTime dateTime2 = dateTime.AddSeconds(-1.0);
                clsLisQCDataVO[] qcDataVo = null;
                string strSampleId = null;
                clsLisQCBatchSchVO qcBatchSchVo = new clsLisQCBatchSchVO();
                if (string.IsNullOrEmpty(node))
                {
                    int num = Convert.ToInt32(selectedNode.Name);
                    this.m_objCurrentBatch.Reset();
                    this.m_objCurrentBatch.Load(num, date, dateTime2);
                    int[] batchSeq = new int[] { num };
                    long num2 = this.m_objCurrentBatch.m_lngQueryDeviceSampleID(batchSeq[0], out strSampleId);
                    dateTime = this.m_ctlDataEditor.m_dtpStartDate.Value;
                    string p_strStartDat = dateTime.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateTime = this.m_ctlDataEditor.m_dtpEndDate.Value;
                    string p_strEndDat = dateTime.ToString("yyyy-MM-dd")+ " 23:59:59";
                    if (!string.IsNullOrEmpty(strSampleId))
                    {
                        num2 = m_objCurrentBatch.m_lngReceiveDeviceQCDataBySampleID(strSampleId, p_strStartDat, p_strEndDat, batchSeq, out qcDataVo);
                        if (num2 > 0L && qcDataVo != null && qcDataVo.Length > 0)
                        {
                            this.m_ctlDataEditor.m_mthAddDataTable(qcDataVo);
                        }
                    }
                }
                else
                {
                    if (node != "质控批")
                    {
                        this.m_objCurrentBatch.Reset();
                    }
                    else
                    {
                        if (selectedNode.Nodes != null && selectedNode.Nodes.Count > 0)
                        {
                            List<int> list = new List<int>();
                            int num3 = 0;
                            foreach (TreeNode treeNode in selectedNode.Nodes)
                            {
                                int.TryParse(treeNode.Name, out num3);
                                if (num3 > 0)
                                {
                                    list.Add(num3);
                                    list.Add(Convert.ToInt16(num3.ToString() +　"1"));
                                    list.Add(Convert.ToInt16(num3.ToString() + "2"));
                                }
                            }
                            if (list.Count > 0)
                            {
                                int[] array2 = new int[list.Count];
                                array2 = list.ToArray();
                                qcBatchSchVo.m_strQCSampleLotNO = selectedNode.Text;
                                long num2 = this.m_objCurrentBatch.m_lngQueryDeviceSampleID(array2[0], out strSampleId);
                                dateTime = this.m_ctlDataEditor.m_dtpStartDate.Value;
                                string p_strStartDat = dateTime.ToString("yyyy-MM-dd 00:00:00");
                                dateTime = this.m_ctlDataEditor.m_dtpEndDate.Value;
                                string p_strEndDat = dateTime.ToString("yyyy-MM-dd 23:59:59");
                                this.m_objCurrentBatch.Reset();
                                this.m_objCurrentBatch.Load(list.ToArray(), date, dateTime2);
                                if (!string.IsNullOrEmpty(strSampleId))
                                {
                                    num2 = this.m_objCurrentBatch.m_lngReceiveDeviceQCDataBySampleID(strSampleId, p_strStartDat, p_strEndDat, array2, out qcDataVo);

                                    if (num2 > 0L && qcDataVo != null && qcDataVo.Length > 0)
                                    {
                                        this.m_ctlDataEditor.m_mthAddDataTable(qcDataVo);
                                    }
                                }
                            }
                            else
                            {
                                this.m_objCurrentBatch.Reset();
                            }
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }


        private void m_ctlDateSelector_ValueChanged(object sender, EventArgs e)
        {
            //this.m_objCurrentBatch.Reload(this.m_ctlDateSelector.DateStart, this.m_ctlDateSelector.DateEnd);
            DateTime dteStart = this.m_ctlDateSelector.DateStart.Date;
            DateTime dteEnd  = this.m_ctlDateSelector.DateEnd.Date;
            dteEnd = dteStart.AddDays(1.0);
            this.m_objCurrentBatch.Reload(dteStart, dteEnd.AddSeconds(-1.0));
        }

        private void m_cmdConcentrationSet_Click(object sender, EventArgs e)
        {
            if (this.m_objCurrentBatch.IsNull)
                return;
            if (this.m_objCurrentBatch.Count != 1)
                return;

            List<clsLisQCConcentrationVO> objs = this.m_objCurrentBatch.GetConcentrations();
            int intSeq = this.m_objCurrentBatch.SeqArr[0];

            frmQCBatchConcentrationSet frm = new frmQCBatchConcentrationSet(intSeq, objs.ToArray());
            if (frm.ShowDialog() == DialogResult.OK)
                this.m_objCurrentBatch.UpdateConcentrations(frm.QCContrations);
        }

        private void m_cmdQCBatchSet_Click(object sender, EventArgs e)
        {
            if (this.m_objCurrentBatch.IsNull || m_objCurrentBatch.Count != 1)
                return;
            frmQCBatchSet frm = new frmQCBatchSet();
            frm.QCBatchVO = this.m_objCurrentBatch.GetQCBatchSet()[0];
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.m_objCurrentBatch.UpdateSet(new clsLisQCBatchVO[] { frm.QCBatchVO });
            }
        }

        #endregion

        private void frmQCBatchManagerNew_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            m_tabList.SelectedTab = m_tbpQuery;
        }

        private void m_cmdBatchSet_Click(object sender, EventArgs e)
        {
            if (this.m_trvQCBatch.SelectedNode != null)
            {
                frmQCSetup frmQCSetup = new frmQCSetup();
                frmQCSetup.m_objBatchSets = this.m_objCurrentBatch.GetQCBatchSet();
                frmQCSetup.m_objConcentrations = this.m_objCurrentBatch.GetConcentrations();
                if (frmQCSetup.m_objBatchSets != null)
                {
                    frmQCSetup.CreateDataTable(frmQCSetup.m_objBatchSets, frmQCSetup.m_objConcentrations);
                    if (frmQCSetup.ShowDialog() == DialogResult.OK)
                    {
                        this.m_objCurrentBatch.m_objBatchSets.Clear();
                        this.m_objCurrentBatch.m_objBatchSets.AddRange(frmQCSetup.m_objBatchSets.ToArray());
                        this.m_objCurrentBatch.m_objConcentrations.Clear();
                        this.m_objCurrentBatch.m_objConcentrations.AddRange(frmQCSetup.m_objConcentrations.ToArray());
                    }
                }
            }
        }
    }
}