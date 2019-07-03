using System;
using System.Collections.Generic;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    internal class clsQCBatch
    {
        #region 数据
        private clsLisQCBatchVO m_objBatchSet;

        private List<clsLisQCConcentrationVO> m_objConcentrations = new List<clsLisQCConcentrationVO>();

        private List<clsLisQCDataVO> m_objDatas = new List<clsLisQCDataVO>();

        private List<clsLisQCReportVO> m_objReports = new List<clsLisQCReportVO>();

        private string m_strBrokenRules = string.Empty;

        private DateTime m_datBegin = DateTime.MinValue;

        private DateTime m_datEnd = DateTime.MaxValue;

        #endregion

        #region 事件 (事件不会嵌套)
        public class DataLoadFailedEventArgs : System.EventArgs
        {
            private string m_strFailedMessage;
            public string FailedMessage
            {
                get { return this.m_strFailedMessage; }
            }
            public DataLoadFailedEventArgs(string p_strFailedMessage)
            {
                this.m_strFailedMessage = p_strFailedMessage;
            }
        }
        public delegate void DataLoadFailedEventHandler(object sender, DataLoadFailedEventArgs e);

        /// <summary>
        /// 模型重置
        /// </summary>
        public event System.EventHandler Reseted;
        /// <summary>
        /// 模型初始化加载
        /// </summary>
        public event System.EventHandler Loaded;
        /// <summary>
        /// 重新加载某个时间段的数据和报告
        /// </summary>
        public event System.EventHandler Reloaded;
        /// <summary>
        /// 从数据库读取时失败
        /// </summary>
        public event DataLoadFailedEventHandler LoadFailed;
        /// <summary>
        /// 质控批基本设置改变
        /// </summary>
        public event System.EventHandler SetChanged;
        /// <summary>
        /// 浓度改变，并重新加载了数据
        /// </summary>
        public event System.EventHandler ConcentrationChanged;
        /// <summary>
        /// 数据改变
        /// </summary>
        public event System.EventHandler DataChanged;
        /// <summary>
        /// 分析结果变更
        /// </summary>
        public event System.EventHandler BrokenRulesChanged;
        //public event System.EventHandler ReportsChanged;
        #endregion

        #region 获取数据接口
        public int Seq
        {
            get
            {
                if (this.m_objBatchSet != null)
                    return m_objBatchSet.m_intSeq;
                return DBAssist.NullInt;
            }
        }
        public bool IsNull
        {
            get
            {
                if (this.m_objBatchSet == null)
                    return true;
                return false;
            }
        }

        public clsLisQCBatchVO GetQCBatchSet()
        {
            clsLisQCBatchVO temp = new clsLisQCBatchVO();
            if (m_objBatchSet != null) 
            {
                m_objBatchSet.m_mthCopyTo(temp);
            }
            return temp;
        }

        public List<clsLisQCConcentrationVO> GetConcentrations()
        {
            List<clsLisQCConcentrationVO> concentratrionList = new List<clsLisQCConcentrationVO>();
            foreach (clsLisQCConcentrationVO var in m_objConcentrations)
            {
                clsLisQCConcentrationVO temp = new clsLisQCConcentrationVO();
                var.m_mthCopyTo(temp);
                concentratrionList.Add(temp);
            }
            return concentratrionList;
        }

        public List<clsLisQCDataVO> GetDatas()
        {
            List<clsLisQCDataVO> dataList = new List<clsLisQCDataVO>();
            foreach (clsLisQCDataVO data in m_objDatas)
            {
                clsLisQCDataVO temp = new clsLisQCDataVO();
                data.m_mthCopyTo(temp);
                dataList.Add(temp);
            }
            return dataList;
        }

        public List<clsLisQCReportVO> GetReports()
        {
           return this.m_objReports;
        }
        public string BrokenRules
        {
            set
            {
                if (this.IsNull)
                {
                    return;
                }
                if (value != null)
                {
                    if (this.m_strBrokenRules != value)
                    {
                        this.m_strBrokenRules = value;
                        if (this.BrokenRulesChanged != null)
                        {
                            BrokenRulesChanged(this, null);
                        }
                    }
                }
            }
            get
            {
                return this.m_strBrokenRules;
            }
        }
        public DateTime DateBegin
        {
            get
            {
                return this.m_datBegin;
            }
        }
        public DateTime DateEnd
        {
            get
            {
                return this.m_datEnd;
            }
        }
        #endregion

        //private clsDcl_QCDataBusiness m_objDomain = new clsDcl_QCDataBusiness();


        #region 数据提交接口 (在空模型上将不执行任何操作,传入空的参数也不会执行任何操作)
        public void Reset()
        {
            if (this.IsNull)
            {
                return;
            }
            this.m_objBatchSet = null;
            this.m_objConcentrations.Clear();
            this.m_objDatas.Clear();
            this.m_objReports.Clear();
            this.m_strBrokenRules = string.Empty;
            m_datBegin = DateTime.MinValue;
            m_datEnd = DateTime.MaxValue;

            if (this.Reseted != null)
            {
                Reseted(this, null);
            }
        }
        public void UpdateSet(clsLisQCBatchVO p_objSet)
        {
            if (this.IsNull)
            {
                return;
            }
            if (p_objSet != null)
            {
                if (!p_objSet.m_mthEquals(this.m_objBatchSet))
                {
                    p_objSet.m_mthCopyTo(this.m_objBatchSet);
                    this.m_strBrokenRules = string.Empty;

                    if (this.SetChanged != null)
                        SetChanged(this, null);
                }
            }
        }
        public void UpdateConcentrations(List<clsLisQCConcentrationVO> p_objConcentrations)
        {
            if (this.IsNull )
            {
                return;
            }
            if (p_objConcentrations != null)
            {
                this.m_objConcentrations.Clear();
                this.m_strBrokenRules = string.Empty;

                foreach (clsLisQCConcentrationVO var in p_objConcentrations)
                {
                    clsLisQCConcentrationVO temp = new clsLisQCConcentrationVO();
                    var.m_mthCopyTo(temp);
                    this.m_objConcentrations.Add(temp);
                }

                clsLisQCDataVO[] objDatas = null;

                long lngRes = 0;

                lngRes = clsTmdQCDataSmp.s_object.m_lngFind(out objDatas, this.Seq, this.m_datBegin, m_datEnd);

                if (lngRes > 0)
                {
                    this.m_objDatas.Clear();

                    if (objDatas != null)
                    {
                        this.m_objDatas.AddRange(objDatas);
                    }
                }
                else
                {
                    if (this.LoadFailed != null)
                    {
                        LoadFailed(this, new DataLoadFailedEventArgs("读取数据失败."));
                    }
                }
                if (this.ConcentrationChanged != null)
                {
                    ConcentrationChanged(this, null);
                }
            }
        }
        public void UpdateDatas(List<clsLisQCDataVO> p_objDatas)
        {
            if (this.IsNull)
            {
                return;
            }
            if (p_objDatas != null)
            {
                this.m_objDatas.Clear();
                this.m_strBrokenRules = string.Empty;

                foreach (clsLisQCDataVO var in p_objDatas)
                {
                    clsLisQCDataVO temp = new clsLisQCDataVO();
                    var.m_mthCopyTo(temp);
                    this.m_objDatas.Add(temp);
                }
                if (this.DataChanged != null)
                {
                    DataChanged(this, null);
                }
            }
        }        
        #endregion

        #region 加载数据
        public void Load(int p_intQCBatchSeq, DateTime p_dtpDateStart, DateTime p_DateEnd)
        {
            clsLisQCBatchVO objBatchSet = null;
            clsLisQCConcentrationVO[] objConcentrations = null;
            clsLisQCDataVO[] objDatas = null;
            clsLisQCReportVO[] objReports = null;
            long lngRes = 0;

            lngRes = clsTmdQCBatchSmp.s_object.m_lngFind(p_intQCBatchSeq,true, out objBatchSet);
            if (lngRes > 0 && objBatchSet != null)
            {
                lngRes = clsTmdQCBatchConcentrationSmp.s_object.m_lngFind(p_intQCBatchSeq, out objConcentrations);
            }
            if (lngRes > 0 && objBatchSet != null)
            {
                lngRes = clsTmdQCDataSmp.s_object.m_lngFind(out objDatas, p_intQCBatchSeq, p_dtpDateStart, p_DateEnd);
            }
            if (lngRes > 0 && objBatchSet != null)
            {
                lngRes = clsTmdQCReportSmp.s_object.m_lngFind(p_intQCBatchSeq, p_dtpDateStart, p_DateEnd,enmQCStatus.Natrural, out objReports);
            }
            if (lngRes > 0 && objBatchSet != null)
            {
                this.m_objConcentrations.Clear();
                this.m_objDatas.Clear();
                this.m_objReports.Clear();
                this.m_strBrokenRules = string.Empty;

                this.m_objBatchSet = objBatchSet;
                if (objConcentrations != null)
                {
                 this.m_objConcentrations.AddRange(objConcentrations);                   
                }
                if (objDatas != null)
                {
                    this.m_objDatas.AddRange(objDatas);
                }
                if (objReports != null)
                {
                    this.m_objReports.AddRange(objReports);
                }
                this.m_datBegin = p_dtpDateStart;
                this.m_datEnd = p_DateEnd;

                if (this.Loaded != null)
                {
                    Loaded(this, null);
                }
            }
            else
            {
                if (lngRes <= 0)
                {
                    if (this.LoadFailed != null)
                    {
                        LoadFailed(this, new DataLoadFailedEventArgs("读取数据失败."));
                    }
                }
                else if(objBatchSet == null)
                {
                    if (this.LoadFailed != null)
                    {
                        LoadFailed(this, new DataLoadFailedEventArgs("指定的质控批不存在."));
                    }
                }
            }
        }
        public void Reload(DateTime p_dtpDateStart, DateTime p_DateEnd)
        {
            if (this.IsNull)
                return;

            clsLisQCDataVO[] objDatas = null;
            clsLisQCReportVO[] objReports = null;

            long lngRes = 0;

            lngRes = clsTmdQCDataSmp.s_object.m_lngFind(out objDatas, this.Seq, p_dtpDateStart, p_DateEnd);
           
            if (lngRes > 0)
            {
                lngRes = clsTmdQCReportSmp.s_object.m_lngFind(this.Seq, p_dtpDateStart, p_DateEnd, enmQCStatus.Natrural, out objReports);
            }
            if (lngRes > 0)
            {
                this.m_objDatas.Clear();
                this.m_objReports.Clear();
                this.m_strBrokenRules = string.Empty;

                if (objDatas != null)
                {
                    this.m_objDatas.AddRange(objDatas);
                }
                if (objReports != null)
                {
                    this.m_objReports.AddRange(objReports);
                }
                this.m_datBegin = p_dtpDateStart;
                this.m_datEnd = p_DateEnd;

                if (this.Reloaded != null)
                {
                    Reloaded(this, null);
                }
            }
            else
            {
                if (this.LoadFailed != null)
                {
                    LoadFailed(this, new DataLoadFailedEventArgs("读取数据失败."));
                }
            }
        }
        #endregion


        //public void m_mthQueryQCCheckItem(string p_strDeviceID, out DataTable p_dtResult)
        //{
        //    p_dtResult = null;
        //    long num = this.m_objDomain.m_lngQCCheckItem(p_strDeviceID, out p_dtResult);
        //}


    }   
}