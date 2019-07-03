using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsCtl_PretestMedStatment : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        public clsCtl_PretestMedStatment()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDcl_PretestMedStatment();
        }
        #endregion

        /// <summary>
        /// 类变量
        /// </summary>
        private frmPretestMedStatment m_objViewer;
        private clsDcl_PretestMedStatment m_objManage;
        Dictionary<string, string> dicGroup;

        /// <summary>
        /// 实体
        /// </summary>
        public class EntityPretestStat
        {
            //public int n { get; set; }
            public string orderStatus { get; set; }
            public string deptName { get; set; }
            public string medId { get; set; }
            public string medName { get; set; }
            public string medGg { get; set; }
            //public decimal medPrice { get; set; }
            public decimal medMount { get; set; }
            public decimal backMount { get; set; }
            public decimal reMount { get; set; }
            public string medMountStr { get; set; }
            public string backMountStr { get; set; }
            public string reMountStr { get; set; }
            //public decimal medAmt { get; set; }
            public string isHs { get; set; }
        }

        #region 设置窗体对象
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmPretestMedStatment)frmMDI_Child_Base_in;
        }
        #endregion


        #region init
        /// <summary>
        /// init
        /// </summary>
        public void m_mthInit()
        {
            dicGroup = new Dictionary<string, string>();
            m_objViewer.dgvData.Visible = true;
            m_objViewer.cboOrderType.Items.AddRange(new object[] {"停止", "未停止"});
            m_objViewer.cboOrderType.SelectedIndex = 0;
            DateTime dte = DateTime.Now.AddDays(-2);
            m_objViewer.dteStart.Value = Convert.ToDateTime(dte.Year.ToString() + "-" + dte.Month.ToString() + "-" + dte.Day.ToString());
            m_objViewer.dteEnd.Value = Convert.ToDateTime(dte.Year.ToString() + "-" + dte.Month.ToString() + "-" + dte.Day.ToString());
            m_objViewer.dgvData.AutoGenerateColumns = false;
        }
        #endregion


        #region 预发药汇总
        /// <summary>
        /// 预发药汇总
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public void m_mthGetPretestMedStatment()
        {
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string deptStr = m_objViewer.DeptIdArr;
            string medName = m_objViewer.txtMedName.Text;
            DataTable dtbResult = null;
            DataTable reDt = null;
            string orderType = string.Empty;
            string orderStatus = string.Empty;
            string deptName = string.Empty;
            string medId = string.Empty;
            string isHs = string.Empty;
            string isHstmp = string.Empty;
            string isPretestCharge = string.Empty;
            int flgDept = 0;
            int flgReputmedreqId = 0;
            int n = 0;
            List<EntityPretestStat> data = new List<EntityPretestStat>();
            List<EntityPretestStat> data2 = new List<EntityPretestStat>();
            List<EntityPretestStat> data3 = new List<EntityPretestStat>();
            List<EntityPretestStat> dataSource = new List<EntityPretestStat>();
            DateTime dte = DateTime.Now.AddDays(-2);

            if (dteStart != string.Empty && dteEnd != string.Empty)
            {
                if (Convert.ToDateTime(dteStart + " 00:00:00") > Convert.ToDateTime(dteEnd + " 00:00:00"))
                {
                    return;
                }
                if (Convert.ToDateTime(dteEnd + " 00:00:00") > Convert.ToDateTime(dte.ToString("yyyy-MM-dd") + " 00:00:00"))
                {
                    return;
                }
            }

            orderType = m_objViewer.cboOrderType.Text.Trim();
            if (m_objViewer.chkIsHsN.Checked == true)
                isHs = "未回收";
            else if (m_objViewer.chkIsHsY.Checked == true)
                isHs = "是";
            else if (m_objViewer.chkIsHsAll.Checked == true)
                isHs = "全部";

            string rePutmedreqId = string.Empty;
            string rePutmedreqIdStr = string.Empty;
            List<string> lstReputmedreqId = new List<string>(); ;
            decimal getDec = 0;
            decimal reMountSum = 0;

            m_objManage.lngGetPretestMedStatment(dteStart, dteEnd, deptStr, orderType, medName, out dtbResult);

            if (orderType == "停止")
            {
                if (dtbResult.Rows.Count > 0 && dtbResult != null)
                {
                    foreach (DataRow dr in dtbResult.Rows)
                    {
                        if (dr["refputmedreqid_chr"] != DBNull.Value)
                        {
                            if (rePutmedreqIdStr.Contains(dr["refputmedreqid_chr"].ToString()))
                                continue;
                            rePutmedreqIdStr += "'" + dr["refputmedreqid_chr"].ToString() + "',";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(rePutmedreqIdStr))
                {
                    rePutmedreqIdStr = "(" + rePutmedreqIdStr.TrimEnd(',') + ")";
                    m_objManage.lngGetRePretestMedStat(rePutmedreqIdStr, out reDt);
                }

                if (dtbResult.Rows.Count > 0 && dtbResult != null)
                {
                    foreach (DataRow dr in dtbResult.Rows)
                    {
                        flgDept = 0;
                        getDec = 0;
                        reMountSum = 0;
                        isHstmp = string.Empty;
                        deptName = dr["deptName"].ToString();
                        medId = dr["assistcode_chr"].ToString();
                        orderStatus = dr["orderStatus"].ToString();
                        rePutmedreqId = dr["refputmedreqid_chr"].ToString();
                        isPretestCharge = dr["isPretestCharge"].ToString();
                        if (dr["recOperName"] != DBNull.Value && dr["recDate"] != DBNull.Value)
                            isHstmp = "是";
                        else
                            isHstmp = "未回收";

                        if (isHs != "全部")
                        {
                            if (isHstmp != isHs)
                                continue;
                        }

                        for (int i = 0; i < data.Count; i++)
                        {
                            if (deptName == data[i].deptName && medId == data[i].medId && orderStatus == data[i].orderStatus)//&& data[i].isHs == isHstmp& & 
                            {
                                data[i].medMount += Convert.ToDecimal(dr["preAmount"]);
                                if (!string.IsNullOrEmpty(rePutmedreqId) && reDt != null)
                                {
                                    foreach (string var in lstReputmedreqId)
                                    {
                                        if (var == rePutmedreqId)
                                        {
                                            flgReputmedreqId = 1;
                                        }
                                    }
                                    if (flgReputmedreqId == 0)
                                    {
                                        DataRow[] drr = reDt.Select("putmeddetailid_chr = '" + rePutmedreqId + "' and assistcode_chr = '" + medId + "'");

                                        if (drr.Length > 0)
                                        {
                                            lstReputmedreqId.Add(rePutmedreqId);

                                            for (int drI = 0; drI < drr.Length; drI++)
                                            {
                                                getDec += Convert.ToDecimal(drr[drI]["get_dec"]);
                                                reMountSum += Convert.ToDecimal(drr[drI]["premedamount"]);
                                            }
                                        }
                                    }
                                    if (reMountSum >= 0)
                                        data[i].backMount += reMountSum;

                                   

                                    flgReputmedreqId = 0;
                                }

                                if (isPretestCharge == "是")
                                {
                                    data[i].backMount += Convert.ToDecimal(dr["preAmount"]);//减去已收费的
                                }

                                data[i].reMount = data[i].medMount - data[i].backMount;

                                if (data[i].reMount > 0)
                                    data[i].reMountStr = data[i].reMount.ToString();
                                if (data[i].backMount > 0)
                                    data[i].backMountStr = data[i].backMount.ToString();
                                if (data[i].medMount > 0)
                                    data[i].medMountStr = data[i].medMount.ToString();

                                flgDept = 1;
                            }
                        }

                        if (flgDept == 0)
                        {
                            EntityPretestStat vo = new EntityPretestStat();
                            vo.orderStatus = dr["orderStatus"].ToString();
                            vo.deptName = dr["deptName"].ToString();
                            vo.medId = dr["assistcode_chr"].ToString();
                            vo.medName = dr["medicinename_vchr"].ToString();
                            if (vo.medName.Length > 18)
                                vo.medName = vo.medName.Substring(0,18);
                            vo.medGg = dr["medspec_vchr"].ToString();
                            vo.medMount = Convert.ToDecimal(dr["preAmount"]);
                            if (dr["recOperName"] != DBNull.Value && dr["recDate"] != DBNull.Value)
                                vo.isHs = "是";
                            else
                                vo.isHs = "未回收";

                            if (!string.IsNullOrEmpty(rePutmedreqId) && reDt != null)
                            {
                                foreach (string var in lstReputmedreqId)
                                {
                                    if (var == rePutmedreqId)
                                    {
                                        flgReputmedreqId = 1;
                                    }
                                }
                                if (flgReputmedreqId == 0)
                                {
                                    DataRow[] drr = reDt.Select("putmeddetailid_chr = '" + rePutmedreqId + "' and assistcode_chr = '" + medId + "'");

                                    if (drr.Length > 0)
                                    {
                                        lstReputmedreqId.Add(rePutmedreqId);

                                        for (int drI = 0; drI < drr.Length; drI++)
                                        {
                                            getDec += Convert.ToDecimal(drr[drI]["get_dec"]);
                                            reMountSum += Convert.ToDecimal(drr[drI]["premedamount"]);
                                        }
                                    }
                                }

                                if (reMountSum >= 0)
                                    vo.backMount += reMountSum;

                                flgReputmedreqId = 0;
                            }

                            if (isPretestCharge == "是")
                            {
                                vo.backMount += Convert.ToDecimal(dr["preAmount"]);//减去已收费的
                            }

                            vo.reMount = vo.medMount - vo.backMount;

                            if (vo.reMount > 0)
                                vo.reMountStr = vo.reMount.ToString();
                            if (vo.backMount > 0)
                                vo.backMountStr = vo.backMount.ToString();
                            if (vo.medMount > 0)
                                vo.medMountStr = vo.medMount.ToString();


                            data.Add(vo);
                        }
                    }
                }

                if (data.Count > 0 && m_objViewer.chkShowRefund.Checked == true)
                {
                    
                    for (int i = 0; i < data.Count; i++)
                    {
                        data[i].backMountStr = data[i].backMount.ToString();
                        data[i].medMountStr = data[i].medMount.ToString();
                        data[i].reMountStr = data[i].reMount.ToString();
                        if (data[i].reMount > 0)
                        {
                            data2.Add(data[i]);
                        }
                    }
                   
                    string dept = string.Empty;
                    string deptLast = string.Empty;

                    for (int i2 = 0; i2 < data2.Count; i2++)
                    {
                        dept = data2[i2].deptName;
                       
                        dataSource.Add(data2[i2]);
                        if (dept != deptLast)
                        {
                            deptLast = dept;
                            if (i2 != 0)
                            {
                                string dteFromTo = m_objViewer.dteStart.Text + "~" + m_objViewer.dteEnd.Text;
                                EntityPretestStat vo1 = new EntityPretestStat();
                                vo1.deptName = dteFromTo;
                                dataSource.Insert(dataSource.Count - 1, vo1);

                                EntityPretestStat vo = new EntityPretestStat();
                                vo.deptName = "科室名称";
                                vo.medId = "药品代码";
                                vo.medName = "药品名称";
                                vo.medGg = "规格";
                                vo.reMountStr = "应退";
                                vo.medMountStr = "预发";
                                dataSource.Insert(dataSource.Count-1, vo);
                            }
                        }
                    }
                    m_objViewer.dgvData.DataSource = dataSource;
                }
                else
                {
                    m_objViewer.dgvData.DataSource = data;
                }
            }
            else
            {
                if (dtbResult.Rows.Count > 0 && dtbResult != null)
                {
                    foreach (DataRow dr in dtbResult.Rows)
                    {
                        flgDept = 0;
                        getDec = 0;
                        reMountSum = 0;
                        isHstmp = string.Empty;
                        deptName = dr["deptName"].ToString();
                        medId = dr["assistcode_chr"].ToString();
                        orderStatus = dr["orderStatus"].ToString();
                        rePutmedreqId = dr["refputmedreqid_chr"].ToString();
                        isPretestCharge = dr["isPretestCharge"].ToString();
                        if (dr["recOperName"] != DBNull.Value && dr["recDate"] != DBNull.Value)
                            isHstmp = "是";
                        else
                            isHstmp = "未回收";

                        if (isHs != "全部")
                        {
                            if (isHstmp != isHs)
                                continue;
                        }

                        for (int i = 0; i < data.Count; i++)
                        {
                            if (deptName == data[i].deptName && medId == data[i].medId && orderStatus == data[i].orderStatus)//&& data[i].isHs == isHstmp& & 
                            {
                                data[i].medMount += Convert.ToDecimal(dr["preAmount"]);

                                if (data[i].reMount > 0)
                                    data[i].reMountStr = data[i].reMount.ToString();
                                if (data[i].backMount > 0)
                                    data[i].backMountStr = data[i].backMount.ToString();
                                if (data[i].medMount > 0)
                                    data[i].medMountStr = data[i].medMount.ToString();

                                flgDept = 1;
                            }
                        }


                        if (flgDept == 0)
                        {
                            EntityPretestStat vo = new EntityPretestStat();
                            vo.orderStatus = dr["orderStatus"].ToString();
                            vo.deptName = dr["deptName"].ToString();
                            vo.medId = dr["assistcode_chr"].ToString();
                            vo.medName = dr["medicinename_vchr"].ToString();
                            vo.medGg = dr["medspec_vchr"].ToString();
                            vo.medMount = Convert.ToDecimal(dr["preAmount"]);
                            if (dr["recOperName"] != DBNull.Value && dr["recDate"] != DBNull.Value)
                                vo.isHs = "是";
                            else
                                vo.isHs = "未回收";

                            if (vo.reMount > 0)
                                vo.reMountStr = vo.reMount.ToString();
                            if (vo.backMount > 0)
                                vo.backMountStr = vo.backMount.ToString();
                            if (vo.medMount > 0)
                                vo.medMountStr = vo.medMount.ToString();

                            data.Add(vo);
                        }
                    }
                    m_objViewer.dgvData.DataSource = data;
                }
            }
            
        }
        #endregion

        #region 导出EXCEL
        /// <summary>
        /// 
        /// </summary>
        public void m_mthExportToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
                string text = "";

                try
                {
                    for (int i = 0; i < this.m_objViewer.dgvData.ColumnCount / 2; i++)
                    {
                        if (this.m_objViewer.dgvData.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                        }
                    }
                    text += "预发药汇总";
                    streamWriter.WriteLine(text);
                    text = dteStart + "~" + dteEnd;
                    streamWriter.WriteLine(text);
                    text = "";
                    for (int i = 0; i < this.m_objViewer.dgvData.ColumnCount; i++)
                    {
                        if (this.m_objViewer.dgvData.Columns[i].Visible)
                        {
                            if (i > 0)
                            {
                                text += "\t";
                            }
                            text += this.m_objViewer.dgvData.Columns[i].HeaderText.Replace("\n", "");
                        }
                    }
                    streamWriter.WriteLine(text);
                    for (int i = 0; i < this.m_objViewer.dgvData.Rows.Count; i++)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int j = 0; j < this.m_objViewer.dgvData.Columns.Count; j++)
                        {
                            if (this.m_objViewer.dgvData.Columns[j].Visible)
                            {
                                if (j > 0)
                                {
                                    stringBuilder.Append("\t");
                                }
                                stringBuilder.Append((this.m_objViewer.dgvData.Rows[i].Cells[j].Value == null) ? "" : this.m_objViewer.dgvData.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                        streamWriter.WriteLine(stringBuilder);
                    }
                    MessageBox.Show("导出成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    streamWriter.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    streamWriter.Close();
                    stream.Close();
                }
            }
        }
        #endregion

    }
}
