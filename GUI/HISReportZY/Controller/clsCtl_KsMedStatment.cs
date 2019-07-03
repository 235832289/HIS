using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsCtl_KsMedStatment : com.digitalwave.GUI_Base.clsController_Base
    {

    #region 构造函数
        public clsCtl_KsMedStatment()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDcl_KsMedStatment();
        }
        #endregion

        /// <summary>
        /// 类变量
        /// </summary>
        private frmKsMedStatment m_objViewer;
        private clsDcl_KsMedStatment m_objManage;

        /// <summary>
        /// 实体
        /// </summary>
        public class EntityPretestStat
        {
            public int n { get; set; }
            public string deptName { get; set; }
            public string medId { get; set; }
            public string medName { get; set; }
            public string medGg { get; set; }
            public decimal medPrice { get; set; }
            public decimal medMount { get; set; }
            public decimal medAmt { get; set; }
        }

        #region 设置窗体对象
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmKsMedStatment)frmMDI_Child_Base_in;
        }
        #endregion

        #region init
        /// <summary>
        /// init
        /// </summary>
        public void m_mthInit()
        {
            m_objViewer.dteStart.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString());
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
        public void m_mthGetCureMedStatment()
        {
            string dteStart = m_objViewer.dteStart.Text;
            string dteEnd = m_objViewer.dteEnd.Text;
            string deptStr = m_objViewer.DeptIdArr;
            DataTable dtbResult = null;
            string orderType = string.Empty;
            string orderStatus = string.Empty;
            string deptName = string.Empty;
            string medId = string.Empty;
            int flgDept = 0;
            int n = 0;
            List<EntityPretestStat> data = new List<EntityPretestStat>();

            m_objManage.lngGetKsMedStatment(dteStart, dteEnd, deptStr, out dtbResult);

            if (dtbResult.Rows.Count > 0 && dtbResult != null)
            {
                foreach(DataRow dr in dtbResult.Rows)
                {
                    flgDept = 0;
                    deptName = dr["deptName"].ToString();
                    medId = dr["assistcode_chr"].ToString();

                    for (int i = 0; i < data.Count; i++)
                    {
                        if (deptName == data[i].deptName && medId == data[i].medId )
                        {
                            if (dr["medMount"] != DBNull.Value)
                                data[i].medMount += Convert.ToDecimal(dr["medMount"]);
                            if (dr["medMount"] != DBNull.Value && dr["unitprice_mny"] != DBNull.Value)
                                data[i].medAmt += Convert.ToDecimal(dr["unitprice_mny"]) * Convert.ToDecimal(dr["medMount"]);
                            flgDept = 1;
                        }
                    }

                    if (flgDept == 0)
                    {
                        EntityPretestStat vo = new EntityPretestStat();
                        vo.n = ++n;
                        vo.deptName = dr["deptName"].ToString();
                        vo.medId = dr["assistcode_chr"].ToString();
                        vo.medName = dr["DicName"].ToString();
                        vo.medGg = dr["medspec_vchr"].ToString();
                        if (dr["unitprice_mny"] != DBNull.Value)
                            vo.medPrice = Convert.ToDecimal(dr["unitprice_mny"]);
                        if (dr["medMount"] != DBNull.Value)
                            vo.medMount = Convert.ToDecimal(dr["medMount"]);
                        if (dr["medMount"] != DBNull.Value && dr["unitprice_mny"] != DBNull.Value)
                            vo.medAmt = Convert.ToDecimal(dr["unitprice_mny"]) * Convert.ToDecimal(dr["medMount"]);
                        data.Add(vo);
                    }
                }
            }

            m_objViewer.dgvData.DataSource = data;
            
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
                    text += "科室用药汇总";
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