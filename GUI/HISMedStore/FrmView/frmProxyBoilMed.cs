using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 中药处方外送代煎服务
    /// </summary>
    public partial class frmProxyBoilMed : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>        
        public frmProxyBoilMed()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量.属性

        /// <summary>
        /// DataSource
        /// </summary>
        DataTable DataSource { get; set; }

        /// <summary>
        /// Main
        /// </summary>
        DataTable DataMain { get; set; }

        /// <summary>
        /// Det
        /// </summary>
        DataTable DataDet { get; set; }

        #region EntityParm
        /// <summary>
        /// EntityParm
        /// </summary>
        class EntityParm
        {
            public string funcCode { get; set; }
            public string groupNo { get; set; }
            public string opIp { get; set; }        // 1 门诊; 2 住院
            public string recorderId { get; set; }
            public string recipeId { get; set; }
            public string putMedId { get; set; }
        }
        #endregion

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            DataMain = new DataTable();
            DataMain.Columns.Add("sendstatus");
            DataMain.Columns.Add("recipedate");
            DataMain.Columns.Add("patname");
            DataMain.Columns.Add("cardno");
            DataMain.Columns.Add("recipeno");
            DataMain.Columns.Add("recipeid");
            DataMain.Columns.Add("deptname");
            DataMain.Columns.Add("doctname");
            DataMain.Columns.Add("bedno");
            DataMain.Columns.Add("putmedid");

            DataDet = new DataTable();
            DataDet.Columns.Add("medcode");
            DataDet.Columns.Add("medname");
            DataDet.Columns.Add("spec");
            DataDet.Columns.Add("usageName");
            DataDet.Columns.Add("qty");
            DataDet.Columns.Add("unit");
            DataDet.Columns.Add("times");
            DataDet.Columns.Add("price");
            DataDet.Columns.Add("total");
            DataDet.Columns.Add("recipeid");
        }
        #endregion

        #region Query
        /// <summary>
        /// Query
        /// </summary>
        void Query()
        {
            try
            {
                int opIp = this.rdoOp.Checked ? 1 : 2;
                if (opIp == 1)
                {
                    this.gvMain.Columns["cardno"].HeaderText = "卡号";
                    this.gvMain.Columns["bedno"].Visible = false;
                }
                else if (opIp == 2)
                {
                    this.gvMain.Columns["cardno"].HeaderText = "住院号";
                    this.gvMain.Columns["bedno"].Visible = true;
                }
                string startDate = this.dteStart.Value.ToString("yyyy-MM-dd");
                string endDate = this.dteEnd.Value.ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(startDate) > Convert.ToDateTime(endDate))
                {
                    MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                clsPublic.PlayAvi("查询数据，请稍候...");
                DataMain.Rows.Clear();
                DataDet.Rows.Clear();
                clsDomainControlOPMedStore svc = new clsDomainControlOPMedStore();
                DataTable dt = svc.QueryProxyBoilMed(startDate, endDate, this.rdoOp.Checked ? 1 : 2);
                svc = null;
                string checkId = string.Empty;
                this.DataSource = dt;
                List<string> lstCheckId = new List<string>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (this.rdoOp.Checked)             // 门诊时recipeId为处方Id
                            checkId = dr["recipeid"].ToString();
                        else if (this.rdoIp.Checked)        // 住院时recipeId为registerId
                            checkId = dr["recipeid"].ToString() + " " + dr["recipeno"].ToString() + Convert.ToDateTime(dr["recipedate"].ToString()).ToString("yyyy-MM-dd");
                        if (lstCheckId.IndexOf(checkId) < 0)
                        {
                            lstCheckId.Add(checkId);
                        }
                        else
                        {
                            continue;
                        }
                        DataRow drNew = DataMain.NewRow();
                        if (dr["sendstatus"] == DBNull.Value)
                        {
                            drNew["sendstatus"] = "未发送";
                        }
                        else
                        {
                            switch (Convert.ToInt32(dr["sendstatus"]))
                            {
                                case -1:
                                    drNew["sendstatus"] = "撤销";
                                    break;
                                case 0:
                                    drNew["sendstatus"] = "未发送";
                                    break;
                                case 1:
                                    drNew["sendstatus"] = "已发送";
                                    break;
                                case 2:
                                    drNew["sendstatus"] = "转药房";
                                    break;
                                default:
                                    drNew["sendstatus"] = "未发送";
                                    break;
                            }
                        }
                        drNew["recipedate"] = dr["recipedate"].ToString();
                        drNew["patname"] = dr["patname"].ToString();
                        drNew["recipeid"] = dr["recipeid"].ToString();
                        drNew["deptname"] = (this.rdoOp.Checked ? dr["deptname"].ToString() : dr["areaname"].ToString());
                        drNew["doctname"] = dr["doctname"].ToString();
                        drNew["recipeno"] = dr["recipeno"].ToString();
                        if (opIp == 1)
                        {
                            drNew["cardno"] = dr["cardno"].ToString();
                            drNew["bedno"] = "";
                        }
                        else if (opIp == 2)
                        {
                            drNew["cardno"] = dr["ipno"].ToString();
                            drNew["bedno"] = dr["bedno"].ToString();
                        }
                        drNew["putmedid"] = dr["putmedid"].ToString();
                        DataMain.Rows.Add(drNew);
                    }
                    DataMain.AcceptChanges();
                    this.gvMain.DataSource = DataMain;

                    if (DataMain.Rows.Count > 0 && DataDet.Rows.Count == 0)
                    {
                        ShowMedDetail(0);
                    }

                    for (int i = 0; i < this.gvMain.RowCount; i++)
                    {
                        if (this.gvMain.Rows[i].Cells["sendstatus"].Value.ToString() == "撤销")
                        {
                            this.gvMain.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                        }
                        else if (this.gvMain.Rows[i].Cells["sendstatus"].Value.ToString() == "已发送")
                        {
                            this.gvMain.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(103, 202, 103);
                        }
                        else if (this.gvMain.Rows[i].Cells["sendstatus"].Value.ToString() == "转药房")
                        {
                            this.gvMain.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }
        #endregion

        #region ShowMedDetail
        /// <summary>
        /// ShowMedDetail
        /// </summary>
        /// <param name="rowIndex"></param>
        void ShowMedDetail(int rowIndex)
        {
            if (rowIndex < 0) return;
            string recipeId = string.Empty;
            string recipeNo = string.Empty;
            string recipeDate = string.Empty;
            if (this.rdoOp.Checked)
            {
                recipeId = this.gvMain.Rows[rowIndex].Cells["recipeid1"].Value.ToString();
            }
            else if (this.rdoIp.Checked)
            {
                recipeId = this.gvMain.Rows[rowIndex].Cells["recipeid1"].Value.ToString();
                recipeNo = this.gvMain.Rows[rowIndex].Cells["recipeno"].Value.ToString();
                recipeDate = this.gvMain.Rows[rowIndex].Cells["recipedate"].Value.ToString();
            }
            clsDomainControlOPMedStore svc = new clsDomainControlOPMedStore();
            DataTable dt = svc.QueryProxyBoilMedDet(recipeId, recipeNo, recipeDate, this.rdoOp.Checked ? 1 : 2);
            svc = null;
            DataDet.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow drNew = DataDet.NewRow();
                    drNew["medcode"] = dr["medcode"].ToString();
                    drNew["medname"] = dr["medname"].ToString();
                    drNew["spec"] = dr["spec"].ToString();
                    drNew["usageName"] = dr["usageName"] == DBNull.Value ? "" : dr["usageName"].ToString().Trim();
                    drNew["qty"] = dr["qty"].ToString();
                    drNew["unit"] = dr["unit"] == DBNull.Value ? "" : dr["unit"].ToString().Trim();
                    drNew["times"] = dr["times"].ToString();
                    drNew["price"] = dr["price"].ToString();
                    drNew["total"] = dr["total"].ToString();
                    drNew["recipeid"] = dr["recipeid"].ToString();
                    DataDet.Rows.Add(drNew);
                }
                DataDet.AcceptChanges();
                this.gvDetail.DataSource = DataDet;

                for (int i = 0; i < this.gvDetail.RowCount; i++)
                {
                    if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                    {
                        this.gvDetail.Rows[i].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }
                }
            }
        }
        #endregion

        #region Web.Post
        /// <summary>
        /// Web.Post
        /// </summary>
        /// <param name="xmlIn"></param>
        /// <returns></returns>
        bool WebPost(string xmlIn)
        {
            try
            {
                using (MedService ms = new MedService())
                {
                    string res = ms.RecipeServcie(xmlIn);
                    //Log.Output(res);
                    return Convert.ToInt32(res) == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
                Log.Output(ex.Message);
                return false;
            }

            #region POST --> 貌似不稳定, 改用wsdl

            //string uri = clsPublic.m_strGetSysparm("1015");
            //if (uri.Trim() == string.Empty)
            //{
            //    MessageBox.Show("请设置t_bse_sysparm 1015号参数。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            ////读取返回消息
            //string res = string.Empty;
            //string postData = HttpUtility.UrlEncode("request") + "=" + HttpUtility.UrlEncode(xmlIn);
            //byte[] dataArray = Encoding.Default.GetBytes(postData);
            ////创建请求
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            //request.Method = "POST";
            //request.ContentLength = dataArray.Length;
            //request.ContentType = "application/x-www-form-urlencoded";
            ////创建输入流
            //Stream dataStream = null;
            //try
            //{
            //    dataStream = request.GetRequestStream();
            //}
            //catch (WebException ex)
            //{
            //    res = ex.Message;
            //    Log.Output(res);
            //    return false;   //连接服务器失败
            //}
            ////发送请求
            //dataStream.Write(dataArray, 0, dataArray.Length);
            //dataStream.Close();

            //// 返回值
            //try
            //{
            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            //    res = reader.ReadToEnd();
            //    reader.Close();
            //}
            //catch (WebException ex)
            //{
            //    res = ex.Message;
            //    Log.Output(res);
            //    return false;
            //}
            //return Convert.ToInt32(res) == 1 ? true : false;

            #endregion
        }
        #endregion

        #region GetPutMedId
        /// <summary>
        /// GetPutMedId
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        string GetPutMedId(string registerId, string recipeNo)
        {
            string putMedIds = string.Empty;
            if (string.IsNullOrEmpty(registerId))
            {
                return putMedIds;
            }
            if (this.DataSource == null || this.DataSource.Rows.Count == 0)
            {
                return putMedIds;
            }
            DataRow[] drr = this.DataSource.Select(string.Format("recipeid = '{0}' and recipeno = {1}", registerId, recipeNo));
            if (drr != null && drr.Length > 0)
            {
                foreach (DataRow dr in drr)
                {
                    putMedIds += dr["putmedid"] == DBNull.Value ? "" : "'" + dr["putmedid"].ToString() + "',";
                }
                putMedIds = putMedIds.TrimEnd(',');
            }
            return putMedIds;
        }
        #endregion

        #region Send
        /// <summary>
        /// Send
        /// </summary>
        void Send()
        {
            if (this.gvMain.SelectedRows.Count > 0)
            {
                EntityParm vo = null;
                List<EntityParm> lstParm = new List<EntityParm>();
                for (int i = 0; i < this.gvMain.SelectedRows.Count; i++)
                {
                    if (this.gvMain.SelectedRows[i].Cells["sendstatus"].Value.ToString() == "未发送")
                    {
                        vo = new EntityParm();
                        vo.funcCode = "add";
                        vo.groupNo = this.gvMain.SelectedRows[i].Cells["recipeno"].Value.ToString();
                        vo.opIp = this.rdoOp.Checked ? "1" : "2";        // 1 门诊; 2 住院
                        vo.recorderId = this.LoginInfo.m_strEmpID;
                        vo.recipeId = this.gvMain.SelectedRows[i].Cells["recipeid1"].Value.ToString();
                        vo.putMedId = this.rdoOp.Checked ? this.gvMain.SelectedRows[i].Cells["putmedid"].Value.ToString() : this.GetPutMedId(vo.recipeId, vo.groupNo);
                        lstParm.Add(vo);
                    }
                }
                if (lstParm.Count == 0)
                {
                    MessageBox.Show("请选择需要发送的药品处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string groupNos = string.Empty;
                string recipeIds = string.Empty;
                string putMedIds = string.Empty;
                foreach (EntityParm item in lstParm)
                {
                    groupNos += item.groupNo + ",";
                    putMedIds += item.putMedId + ",";
                    recipeIds += "'" + item.recipeId + "',";
                }
                // 最后校验
                clsDomainControlOPMedStore svc = new clsDomainControlOPMedStore();
                if (svc.CheckIsSend(putMedIds.TrimEnd(','), true))
                {
                    MessageBox.Show("药品处方已发送。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Query();
                    return;
                }
                svc = null;

                string empId = string.Empty;
                if (clsPublic.m_dlgConfirm(this.LoginInfo.m_strEmpNo, out empId) == DialogResult.Yes)
                {
                    string request = string.Empty;
                    request += "<req>" + Environment.NewLine;
                    request += string.Format("<funcCode>{0}</funcCode>", lstParm[0].funcCode) + Environment.NewLine;
                    request += string.Format("<opIp>{0}</opIp>", lstParm[0].opIp) + Environment.NewLine;
                    request += string.Format("<recipeId>{0}</recipeId>", recipeIds.TrimEnd(',')) + Environment.NewLine;
                    request += string.Format("<groupNo>{0}</groupNo>", groupNos.TrimEnd(',')) + Environment.NewLine;
                    request += string.Format("<recorderId>{0}</recorderId>", empId) + Environment.NewLine;
                    request += string.Format("<putMedId>{0}</putMedId>", putMedIds.TrimEnd(',')) + Environment.NewLine;
                    request += "</req>" + Environment.NewLine;
                    if (this.WebPost(request))
                    {
                        MessageBox.Show("处方发送成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Query();
                    }
                    else
                    {
                        MessageBox.Show("处方发送失败.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择需要发送的药品处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Cancel
        /// <summary>
        /// Cancel
        /// </summary>
        void Cancel()
        {
            if (this.gvMain.SelectedRows.Count > 0)
            {
                EntityParm vo = null;
                List<EntityParm> lstParm = new List<EntityParm>();
                for (int i = 0; i < this.gvMain.SelectedRows.Count; i++)
                {
                    if (this.gvMain.SelectedRows[i].Cells["sendstatus"].Value.ToString() == "已发送")
                    {
                        vo = new EntityParm();
                        vo.funcCode = "cancel";
                        vo.groupNo = this.gvMain.SelectedRows[i].Cells["recipeno"].Value.ToString();
                        vo.opIp = this.rdoOp.Checked ? "1" : "2";        // 1 门诊; 2 住院
                        vo.recorderId = this.LoginInfo.m_strEmpID;
                        vo.recipeId = this.gvMain.SelectedRows[i].Cells["recipeid1"].Value.ToString();
                        vo.putMedId = this.rdoOp.Checked ? this.gvMain.SelectedRows[i].Cells["putmedid"].Value.ToString() : this.GetPutMedId(vo.recipeId, vo.groupNo);
                        lstParm.Add(vo);
                    }
                }
                if (lstParm.Count == 0)
                {
                    MessageBox.Show("请选择需要取消发送的药品处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string groupNos = string.Empty;
                string recipeIds = string.Empty;
                string putMedIds = string.Empty;
                foreach (EntityParm item in lstParm)
                {
                    groupNos += item.groupNo + ",";
                    putMedIds += item.putMedId + ",";
                    recipeIds += "'" + item.recipeId + "',";
                }
                // 最后校验
                clsDomainControlOPMedStore svc = new clsDomainControlOPMedStore();
                if (svc.CheckIsSend(putMedIds.TrimEnd(','), false))
                {
                    MessageBox.Show("药品处方未发送，不需要取消发送。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Query();
                    return;
                }
                svc = null;

                string empId = string.Empty;
                if (clsPublic.m_dlgConfirm(this.LoginInfo.m_strEmpNo, out empId) == DialogResult.Yes)
                {
                    string request = string.Empty;
                    request += "<req>" + Environment.NewLine;
                    request += string.Format("<funcCode>{0}</funcCode>", lstParm[0].funcCode) + Environment.NewLine;
                    request += string.Format("<opIp>{0}</opIp>", lstParm[0].opIp) + Environment.NewLine;
                    request += string.Format("<recipeId>{0}</recipeId>", recipeIds.TrimEnd(',')) + Environment.NewLine;
                    request += string.Format("<groupNo>{0}</groupNo>", groupNos.TrimEnd(',')) + Environment.NewLine;
                    request += string.Format("<recorderId>{0}</recorderId>", empId) + Environment.NewLine;
                    request += string.Format("<putMedId>{0}</putMedId>", putMedIds.TrimEnd(',')) + Environment.NewLine;
                    request += "</req>" + Environment.NewLine;
                    if (this.WebPost(request))
                    {
                        MessageBox.Show("处方取消发送成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Query();
                    }
                    else
                    {
                        MessageBox.Show("处方取消发送失败.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择需要取消发送的药品处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region ConvertMedstore
        /// <summary>
        /// ConvertMedstore
        /// </summary>
        void ConvertMedstore()
        {
            if (this.gvMain.SelectedRows.Count > 0)
            {
                EntityParm vo = null;
                List<EntityParm> lstParm = new List<EntityParm>();
                for (int i = 0; i < this.gvMain.SelectedRows.Count; i++)
                {
                    if (this.gvMain.SelectedRows[i].Cells["sendstatus"].Value.ToString() == "撤销" || this.gvMain.SelectedRows[i].Cells["sendstatus"].Value.ToString() == "未发送")
                    {
                        vo = new EntityParm();
                        vo.funcCode = "convert";
                        vo.groupNo = this.gvMain.SelectedRows[i].Cells["recipeno"].Value.ToString();
                        vo.opIp = this.rdoOp.Checked ? "1" : "2";        // 1 门诊; 2 住院
                        vo.recorderId = this.LoginInfo.m_strEmpID;
                        vo.recipeId = this.gvMain.SelectedRows[i].Cells["recipeid1"].Value.ToString();
                        vo.putMedId = this.rdoOp.Checked ? this.gvMain.SelectedRows[i].Cells["putmedid"].Value.ToString() : this.GetPutMedId(vo.recipeId, vo.groupNo);
                        lstParm.Add(vo);
                    }
                }
                if (lstParm.Count == 0)
                {
                    MessageBox.Show("请选择需要转门诊中药房发药的处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string groupNos = string.Empty;
                string recipeIds = string.Empty;
                string putMedIds = string.Empty;
                foreach (EntityParm item in lstParm)
                {
                    groupNos += item.groupNo + ",";
                    putMedIds += item.putMedId + ",";
                    recipeIds += "'" + item.recipeId + "',";
                }
                // 最后校验
                clsDomainControlOPMedStore svc = new clsDomainControlOPMedStore();
                if (svc.CheckIsSend(putMedIds.TrimEnd(','), true))
                {
                    MessageBox.Show("药品处方已发送，不能转门诊中药房发药。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Query();
                    return;
                }

                string empId = string.Empty;
                if (clsPublic.m_dlgConfirm(this.LoginInfo.m_strEmpNo, out empId) == DialogResult.Yes)
                {
                    if (svc.ConvertMedStore(recipeIds.TrimEnd(','), putMedIds.TrimEnd(','), empId, (this.rdoOp.Checked ? 1 : 2)) > 0)
                    {
                        MessageBox.Show("转门诊中药房成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Query();
                    }
                    else
                    {
                        MessageBox.Show("转门诊中药房失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                svc = null;
            }
            else
            {
                MessageBox.Show("请选择需要取消发送的药品处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #endregion

        #region 事件

        private void frmProxyBoilMed_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void gvMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ShowMedDetail(e.RowIndex);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Query();
        }

        private void rdoOp_CheckedChanged(object sender, EventArgs e)
        {
            this.Query();
        }

        private void rdoIp_CheckedChanged(object sender, EventArgs e)
        {
            this.Query();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.Send();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            this.ConvertMedstore();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }

    #region Log

    public class Log
    {
        public static void OutputXml(string xml)
        {
            bool isWrite = true;
            if (isWrite) Output(xml);
        }

        public static void OutputXml(string xml, bool isWrite)
        {
            if (isWrite) Output(xml);
        }

        public static void Output(string txt)
        {
            string strDate = DateTime.Now.ToString("yyyy-MM-dd");
            string strTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            string strFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\log\" + strDate + ".txt";
            bool blnAllWaysNew = false;
            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(strFile);
                if (fi.Exists)
                {
                    if (fi.Length >= 2000000)
                    {
                        fi.CopyTo(System.AppDomain.CurrentDomain.BaseDirectory + @"\log\" + strDate + "-" + DateTime.Now.ToString("HHmm") + ".txt", true);
                        sw = fi.CreateText();
                    }
                    else
                    {
                        if (blnAllWaysNew)
                        {
                            sw = fi.CreateText();
                        }
                        else
                        {
                            sw = fi.AppendText();
                        }
                    }
                }
                else
                {
                    if (!Directory.Exists(fi.DirectoryName))
                    {
                        Directory.CreateDirectory(fi.DirectoryName);
                    }
                    sw = fi.CreateText();
                }
                sw.WriteLine("-->>>>> " + strTime);
                sw.WriteLine(txt);
                sw.WriteLine();
            }
            catch (Exception e)
            {
                //throw e;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        public static void Output(string fileName, string txt)
        {
            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Exists)
                {
                    sw = fi.AppendText();
                }
                else
                {
                    if (!Directory.Exists(fi.DirectoryName))
                    {
                        Directory.CreateDirectory(fi.DirectoryName);
                    }
                    sw = fi.CreateText();
                }
                sw.WriteLine(txt);
                sw.WriteLine();
            }
            catch (Exception e)
            {
                //throw e;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
    }
    #endregion
}
