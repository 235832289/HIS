using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using weCare.Core.Entity;
using weCare.Core.Utils;
using weCare.Core.Dac;

namespace weCare
{
    /// <summary>
    /// 孕产妇分娩信息上传.控制台
    /// </summary>
    public partial class frmConsole : Form
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmConsole()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量.属性

        /// <summary>
        /// 时间点
        /// </summary>
        string timePoint = " 05:30:00";

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            this.progressBarControl.Visible = false;
            this.RefreshTask();
            this.gcTask.Dock = System.Windows.Forms.DockStyle.Fill;
        }
        #endregion

        #region RefreshTask
        /// <summary>
        /// RefreshTask
        /// </summary>
        void RefreshTask()
        {
            int sortNo = 0;
            List<EntitySysTaskLog> data = this.GetTaskLog();
            data.Sort();
            foreach (EntitySysTaskLog item in data)
            {
                item.sortNo = ++sortNo;
            }
            this.gcTask.DataSource = data;

            string maxDate = string.Empty;
            if (data != null && data.Count > 0)
            {
                maxDate = data[data.Count - 1].execTime;
            }
            else
            {
                maxDate = DateTime.Now.ToString("yyyy-MM-dd") + timePoint;
            }
            if (DateTime.Now > Convert.ToDateTime(maxDate))
            {
                this.gvTask.ViewCaption = "上传时间：" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + timePoint;
            }
            else
            {
                this.gvTask.ViewCaption = "下次上传时间：" + maxDate;
            }
        }
        #endregion

        #region Upload
        /// <summary>
        /// Upload
        /// </summary>
        void Upload()
        {
            try
            {
                string Sql = string.Empty;
                IDataParameter[] parm = null;
                SqlHelper svc = new SqlHelper(EnumBiz.onlineDB);

                string todayStr = DateTime.Now.ToString("yyyy-MM-dd");

                Sql = @"select a.inpatientid, a.inpatientdate, a.opendate
                          from inpatmedrec a
                         where a.typeid = 'frmIMR_childbirth'
                           and a.status = '0'
                           and (a.opendate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";
                parm = svc.CreateParm(2);
                parm[0].Value = todayStr + " 00:00:00";
                parm[1].Value = todayStr + " 23:59:59";
                DataTable dtRec = svc.GetDataTable(Sql, parm);

                Sql = @"select a.registerid, a.inpatientid, a.inpatientdate, a.uploaddate
                          from t_opr_bih_wacrecord a
                         where (a.uploaddate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";
                parm = svc.CreateParm(2);
                parm[0].Value = todayStr + " 00:00:00";
                parm[1].Value = todayStr + " 23:59:59";
                DataTable dtUp = svc.GetDataTable(Sql, parm);

                Sql = @"";

                List<EntityMother> lstMother = new List<EntityMother>();
                if (dtRec != null && dtRec.Rows.Count > 0)
                {
                    EntityMother vo = null;
                    DataRow[] drr = null;
                    foreach (DataRow drRec in dtRec.Rows)
                    {
                        vo = new EntityMother();
                        vo.ipNo = drRec["inpatientid"].ToString();
                        if (dtUp != null && dtUp.Rows.Count > 0)
                        {
                            drr = dtUp.Select("inpatientid = '" + vo.ipNo + "'");
                            vo.flagId = ((drr != null && drr.Length > 0) ? 1 : 0);
                        }
                        else
                        {
                            vo.flagId = 0;
                        }

                        #region 明细项目




                        #endregion

                        lstMother.Add(vo);
                    }
                }
                if (lstMother != null && lstMother.Count > 0)
                {
                    string registerId = string.Empty;
                    //设置一个最大值
                    this.progressBarControl.Properties.Maximum = lstMother.Count;

                    this.progressBarControl.Visible = true;
                    this.progressBarControl.Position = 0;
                    foreach (EntityMother motherVo in lstMother)
                    {
                        #region xml.setvalue

                        StringBuilder xmlUpload = new StringBuilder();
                        xmlUpload.AppendLine("<?xml version=\"1.0\" encoding=\"GBK\" ?>");
                        xmlUpload.AppendLine("<Document type=\"Request Save\" versionNumber=\"\" value=\"1.0\">");
                        xmlUpload.AppendLine("<realmCode code=\"4419.CN\"/>");
                        xmlUpload.AppendLine("<code code=\"4419.A01.02.208\" codeSystem=\"4419.CN.01\" codeSystemName=\"东莞市妇幼卫生信息交互共享文档分类编码系统\"/>");
                        xmlUpload.AppendLine("<title>请求推送某孕产妇分娩信息</title>");
                        xmlUpload.AppendLine("<author>");
                        xmlUpload.AppendLine("<authorID code=\"763709818\" authorname=\"东莞市茶山医院\"/>");
                        xmlUpload.AppendLine("<InformationsystemID code=\"A74CC68F-B009-4264-A880-FBE87DD91E56\" InformationsystemName=\"东莞市茶山医院HIS管理系统\"/>");
                        xmlUpload.AppendLine(string.Format("<GenerationTime type=\"TS\" value=\"{0}\"/>", DateTime.Now.ToString("yyyyMMddHHmm")));
                        xmlUpload.AppendLine("</author>");
                        xmlUpload.AppendLine("<component>");
                        xmlUpload.AppendLine(string.Format("<OperationType value=\"{0}\"/>", motherVo.flagId == 0 ? "NEW" : "UPDATE"));
                        xmlUpload.AppendLine("<recordNumber value=\"1\" type=\"INT\"/>");
                        xmlUpload.AppendLine("<record>");
                        xmlUpload.AppendLine(string.Format("<HISID>{0}</HISID>", motherVo.HISID));                          // HIS系统唯一ID
                        xmlUpload.AppendLine(string.Format("<BARCODE>{0}</BARCODE>", motherVo.BARCODE));                    // 孕产妇保健手册号
                        xmlUpload.AppendLine(string.Format("<IDCARD>{0}</IDCARD>", motherVo.IDCARD));                       // 女方身份证号
                        xmlUpload.AppendLine(string.Format("<NAME>{0}</NAME>", motherVo.NAME));                             // 母亲姓名
                        xmlUpload.AppendLine(string.Format("<HDSB0101021>{0}</HDSB0101021>", motherVo.HDSB0101021));        // 母亲出生日期
                        xmlUpload.AppendLine(string.Format("<HDSB0101022 code=\"{0}\" codeSystem=\"GB/T 2659-2000\">{1}</HDSB0101022>", motherVo.HDSB0101022_1, motherVo.HDSB0101022_2));   // 母亲国籍代码; 母亲国籍
                        xmlUpload.AppendLine(string.Format("<HDSB0101023 code=\"{0}\" codeSystem=\"GB 3304-1991\">{1}</HDSB0101023>", motherVo.HDSB0101023_1, motherVo.HDSB0101023_2));     // 母亲民族代码; 母亲民族
                        xmlUpload.AppendLine(string.Format("<HDSB0101024 code=\"{0}\" codeSystem=\"CV02.01.101\">{1}</HDSB0101024>", motherVo.HDSB0101024_1, motherVo.HDSB0101024_2));      // 母亲身份证件类别代码; 母亲身份证件类别名
                        xmlUpload.AppendLine(string.Format("<HDSB0101025>{0}</HDSB0101025>", motherVo.HDSB0101025));        // 母亲身份证件号码
                        xmlUpload.AppendLine(string.Format("<HDSB0101040 code=\"{0}\" codeSystem=\"GBT 2260—2012\">{1}</HDSB0101040>", motherVo.HDSB0101040_1, motherVo.HDSB0101040_2));   // 母亲户籍地址区划代码; 母亲户籍地址
                        xmlUpload.AppendLine(string.Format("<HDSB0101045>{0}</HDSB0101045>", motherVo.HDSB0101045));        // 母亲详细户籍地址(包括门牌号)
                        xmlUpload.AppendLine(string.Format("<PRESENTADDRESS code=\"{0}\" codeSystem=\"GBT 2260—2012\">{1}</PRESENTADDRESS>", motherVo.PRESENTADDRESS_1, motherVo.PRESENTADDRESS_2));    // 母亲现住地址行政区划代码; 母亲现住地址
                        xmlUpload.AppendLine(string.Format("<FULLPRESENTADDRESS>{0}</FULLPRESENTADDRESS>", motherVo.FULLPRESENTADDRESS));                                                   // 母亲详细现住地址(包括门牌号)

                        xmlUpload.AppendLine(string.Format("<HDSB0101026>{0}</HDSB0101026>", motherVo.HDSB0101026));        // 父亲姓名
                        xmlUpload.AppendLine(string.Format("<HDSB0101027>{0}</HDSB0101027>", motherVo.HDSB0101027));        // 父亲出生日期
                        xmlUpload.AppendLine(string.Format("<HDSB0101028 code=\"{0}\" codeSystem=\"GB/T 2659-2000\">{1}</HDSB0101028>", motherVo.HDSB0101028_1, motherVo.HDSB0101028_2));   // 父亲国籍代码; 父亲国籍
                        xmlUpload.AppendLine(string.Format("<HDSB0101029 code=\"{0}\" codeSystem=\"GB 3304-1991\">{1}</HDSB0101029>", motherVo.HDSB0101029_1, motherVo.HDSB0101029_2));     // 父亲民族代码; 父亲民族
                        xmlUpload.AppendLine(string.Format("<HDSB0101030 code=\"{0}\" codeSystem=\"CV02.01.101\">{1}</HDSB0101030>", motherVo.HDSB0101030_1, motherVo.HDSB0101030_2));      // 父亲身份证件类别代码; 父亲身份证件类别名
                        xmlUpload.AppendLine(string.Format("<HDSB0101031>{0}</HDSB0101031>", motherVo.HDSB0101031));        // 父亲身份证件号码
                        xmlUpload.AppendLine(string.Format("<HDSB0101046 code=\"{0}\" codeSystem=\"GBT 2260—2012\">{1}</HDSB0101046>", motherVo.HDSB0101046_1, motherVo.HDSB0101046_2));   // 父亲户籍地址区划代码; 父亲户籍地址
                        xmlUpload.AppendLine(string.Format("<HDSB0101051>{0}</HDSB0101051>", motherVo.HDSB0101051));        // 父亲详细户籍地址(包括门牌号)
                        xmlUpload.AppendLine(string.Format("<HPRESENTADDRESS code=\"{0}\" codeSystem=\"GBT 2260—2012\">{1}</HPRESENTADDRESS>", motherVo.HPRESENTADDRESS_1, motherVo.HPRESENTADDRESS_2));    // 父亲现住地址行政区划代码; 父亲现住地址
                        xmlUpload.AppendLine(string.Format("<HFULLPRESENTADDRESS>{0}</HFULLPRESENTADDRESS>", motherVo.HFULLPRESENTADDRESS));                                                // 父亲详细现住地址(包括门牌号)

                        xmlUpload.AppendLine(string.Format("<MATTER code=\"{0}\" codesystem=\"STD_ISSUEREASON\">{1}</MATTER>", motherVo.MATTER_1, motherVo.MATTER_2));                      // 签发原因代码; 签发原因（00：信息齐全(双亲)，02：信息不全(单亲)）
                        xmlUpload.AppendLine(string.Format("<BEDNO>{0}</BEDNO>", motherVo.BEDNO));                          // 床号
                        xmlUpload.AppendLine(string.Format("<ZYH>{0}</ZYH>", motherVo.ZYH));                                // 住院号
                        xmlUpload.AppendLine(string.Format("<INTIRE>{0}</INTIRE>", motherVo.INTIRE));                       // 当前第几胎
                        xmlUpload.AppendLine(string.Format("<INHOSPITALIZATIONIN>{0}</INHOSPITALIZATIONIN>", motherVo.INHOSPITALIZATIONIN));                                                // 当前第几次住院
                        xmlUpload.AppendLine(string.Format("<PLACETYPE code=\"{0}\" codesystem=\"STD_PLACETYPE\">{1}</PLACETYPE>", motherVo.PLACETYPE_1, motherVo.PLACETYPE_2));            // 分娩地点类型代码; 分娩地点类型名称
                        xmlUpload.AppendLine(string.Format("<CYESISWEEK>{0}</CYESISWEEK>", motherVo.CYESISWEEK));           // 分娩孕周(日)
                        xmlUpload.AppendLine(string.Format("<FETUSNUMBER code=\"{0}\" codesystem=\"STD_FETUSNUM\">{1}</FETUSNUMBER>", motherVo.FETUSNUMBER_1, motherVo.FETUSNUMBER_2));     // 胎数代码; 胎数
                        xmlUpload.AppendLine(string.Format("<TAIMOPOLIEFANGSHI code=\"{0}\" codesystem=\"STD_TAIMOPOLIE\">{1}</TAIMOPOLIEFANGSHI>", motherVo.TAIMOPOLIEFANGSHI_1, motherVo.TAIMOPOLIEFANGSHI_2));   // 胎膜破裂方式代码; 胎膜破裂方式名称
                        xmlUpload.AppendLine(string.Format("<TAIMOPOLIE>{0}</TAIMOPOLIE>", motherVo.TAIMOPOLIE));           // 胎膜破裂时间
                        xmlUpload.AppendLine(string.Format("<CHILDBIRTHTIME>{0}</CHILDBIRTHTIME>", motherVo.CHILDBIRTHTIME));                                                               // 分娩时间
                        xmlUpload.AppendLine(string.Format("<CHIBIRTYPE code=\"{0}\" codesystem=\"STD_CHIBIRTYPE\">{1}</CHIBIRTYPE>", motherVo.CHIBIRTYPE_1, motherVo.CHIBIRTYPE_2));       // 分娩方式代码; 分娩方式
                        xmlUpload.AppendLine(string.Format("<FETUSPOSITION code=\"{0}\" codesystem=\"STD_FETUSPOSITION\">{1}</FETUSPOSITION>", motherVo.FETUSPOSITION_1, motherVo.FETUSPOSITION_2));    // 胎方位代码; 胎方位
                        xmlUpload.AppendLine(string.Format("<ONELAYHOUR>{0}</ONELAYHOUR>", motherVo.ONELAYHOUR));           // 第一产程（小时）
                        xmlUpload.AppendLine(string.Format("<ONELAY>{0}</ONELAY>", motherVo.ONELAY));                       // 第一产程（分钟）
                        xmlUpload.AppendLine(string.Format("<TWOLAYHOUR>{0}</TWOLAYHOUR>", motherVo.TWOLAYHOUR));           // 第二产程（小时）
                        xmlUpload.AppendLine(string.Format("<TWOLAY>{0}</TWOLAY>", motherVo.TWOLAY));                       // 第二产程（分钟）
                        xmlUpload.AppendLine(string.Format("<THREELAYHOUR>{0}</THREELAYHOUR>", motherVo.THREELAYHOUR));     // 第三产程（小时）
                        xmlUpload.AppendLine(string.Format("<THREELAY>{0}</THREELAY>", motherVo.THREELAY));                 // 第三产程（分钟）
                        xmlUpload.AppendLine(string.Format("<ALLLAYHOUR>{0}</ALLLAYHOUR>", motherVo.ALLLAYHOUR));           // 总产程（小时）
                        xmlUpload.AppendLine(string.Format("<ALLLAY>{0}</ALLLAY>", motherVo.ALLLAY));                       // 总产程（分钟）
                        xmlUpload.AppendLine(string.Format("<PLACENTALTIME>{0}</PLACENTALTIME>", motherVo.PLACENTALTIME));  // 胎盘娩出时间
                        xmlUpload.AppendLine(string.Format("<PLACENTALFANGSHI code=\"{0}\"  codesystem=\"STD_PLACENTALFANGSHI\">{1}</PLACENTALFANGSHI>", motherVo.PLACENTALFANGSHI_1, motherVo.PLACENTALFANGSHI_2));    // 胎盘娩出方式代码; 胎盘娩出方式
                        xmlUpload.AppendLine(string.Format("<DELIVERYMEASURES>{0}</DELIVERYMEASURES>", motherVo.DELIVERYMEASURES));                                                         // 分娩措施
                        xmlUpload.AppendLine(string.Format("<TAIPAN code=\"{0}\" codesystem=\"STD_TAIPAN\">{1}</TAIPAN>", motherVo.TAIPAN_1, motherVo.TAIPAN_2));                           // 胎膜胎盘完整性代码; 胎盘完整性
                        xmlUpload.AppendLine(string.Format("<PLACENTA code=\"{0}\" codesystem=\"STD_PLACENTA\">{1}</PLACENTA>", motherVo.PLACENTA_1, motherVo.PLACENTA_2));                 // 胎膜完整性代码; 胎膜完整性
                        xmlUpload.AppendLine(string.Format("<JIDAI>{0}</JIDAI>", motherVo.JIDAI));                          // 脐带长度(单位：cm)
                        xmlUpload.AppendLine(string.Format("<LUCIDITY code=\"{0}\" codesystem=\"STD_LUCIDITY\">{1}</LUCIDITY>", motherVo.LUCIDITY_1, motherVo.LUCIDITY_2));                 // 羊水清否代码; 羊水清否
                        xmlUpload.AppendLine(string.Format("<DEGREE code=\"{0}\" codesystem=\"STD_DEGREE\">{1}</DEGREE>", motherVo.DEGREE_1, motherVo.DEGREE_2));                           // 羊水分度代码; 羊水分度
                        xmlUpload.AppendLine(string.Format("<AMNIOTIC>{0}</AMNIOTIC>", motherVo.AMNIOTIC));                 // 羊水量(单位：ml)
                        xmlUpload.AppendLine(string.Format("<PLACENTALLONG>{0}</PLACENTALLONG>", motherVo.PLACENTALLONG));                                                                  // 胎盘长（单位cm）
                        xmlUpload.AppendLine(string.Format("<PLACENTAWIDTH>{0}</PLACENTAWIDTH>", motherVo.PLACENTAWIDTH));                                                                  // 胎盘宽（单位cm）
                        xmlUpload.AppendLine(string.Format("<PLACENTALTHICKNESS>{0}</PLACENTALTHICKNESS>", motherVo.PLACENTALTHICKNESS));                                                   // 胎盘厚（单位cm）
                        xmlUpload.AppendLine(string.Format("<ISPERINEUMCUT code=\"{0}\" codesystem=\"STD_ISPERINEUMCUT\">{1}</ISPERINEUMCUT>", motherVo.ISPERINEUMCUT_1, motherVo.ISPERINEUMCUT_2));    // 会阴情况代码; 会阴情况
                        xmlUpload.AppendLine(string.Format("<SUTURESITUATION code=\"{0}\" codesystem=\"STD_SUTURESITUATION\">{1}</SUTURESITUATION>", motherVo.SUTURESITUATION_1, motherVo.SUTURESITUATION_2));  // 缝合情况代码; 缝合情况
                        xmlUpload.AppendLine(string.Format("<SEW>{0}</SEW>", motherVo.SEW));                                // 缝合针数(单位：针)
                        xmlUpload.AppendLine(string.Format("<OPERATIONREASON>{0}</OPERATIONREASON>", motherVo.OPERATIONREASON));// 手术原因
                        xmlUpload.AppendLine(string.Format("<CHUXUE>{0}</CHUXUE>", motherVo.CHUXUE));                       // 阴道分娩产后2h出血量（单位：ml）
                        xmlUpload.AppendLine(string.Format("<SSZXM>{0}</SSZXM>", motherVo.SSZXM));                          // 手术人
                        xmlUpload.AppendLine(string.Format("<ACCUSR>{0}</ACCUSR>", motherVo.ACCUSR));                       // 接生人
                        xmlUpload.AppendLine(string.Format("<OPERATEDATE>{0}</OPERATEDATE>", motherVo.OPERATEDATE));        // 录入时间
                        xmlUpload.AppendLine(string.Format("<ORG code=\"{0}\" codesystem=\"STD_ORGAN\">{1}</ORG>", motherVo.ORG_1, motherVo.ORG_2));                                        // 录入单位机构代码; 录入单位
                        foreach (EntityChild vo in motherVo.lstChild)
                        {
                            xmlUpload.AppendLine("<BABY>");
                            xmlUpload.AppendLine(string.Format("<BABYNAME>{0}</BABYNAME>", vo.BABYNAME));                   // 婴儿姓名
                            xmlUpload.AppendLine(string.Format("<SEX code=\"{0}\" codesystem=\"GB/T 2261.1\">{1}</SEX>", vo.SEX_1, vo.SEX_2));                                              // 婴儿性别代码; 婴儿性别
                            xmlUpload.AppendLine(string.Format("<SEQUENCE>{0}</SEQUENCE>", vo.SEQUENCE));                   // 胎次
                            xmlUpload.AppendLine(string.Format("<DATEOFBIRTH>{0}</DATEOFBIRTH>", vo.DATEOFBIRTH));          // 出生时间
                            xmlUpload.AppendLine(string.Format("<AVOIRDUPOIS>{0}</AVOIRDUPOIS>", vo.AVOIRDUPOIS));          // 体重
                            xmlUpload.AppendLine(string.Format("<STATURE>{0}</STATURE>", vo.STATURE));                      // 身长
                            xmlUpload.AppendLine(string.Format("<TOUWEI>{0}</TOUWEI>", vo.TOUWEI));                         // 头围
                            xmlUpload.AppendLine(string.Format("<ISBUG code=\"{0}\" codesystem=\"STD_ISBUG\">{1}</ISBUG>", vo.ISBUG_1, vo.ISBUG_2));                                        // 是否畸形代码; 是否畸形
                            xmlUpload.AppendLine(string.Format("<APGAR1>{0}</APGAR1>", vo.APGAR1));                         // 1min Apgar总分
                            xmlUpload.AppendLine(string.Format("<APGAR5>{0}</APGAR5>", vo.APGAR5));                         // 5min Apgar总分
                            xmlUpload.AppendLine(string.Format("<APGAR10>{0}</APGAR10>", vo.APGAR10));                      // 10min Apgar总分
                            xmlUpload.AppendLine(string.Format("<HBIGTIME code=\"{0}\" codesystem=\"STD_HBIGTIME\">{1}</HBIGTIME>", vo.HBIGTIME_1, vo.HBIGTIME_2));                         // 是否注射乙肝免疫球蛋白代码; 是否注射乙肝免疫球蛋白
                            xmlUpload.AppendLine(string.Format("<INJECTIONDATE>{0}</INJECTIONDATE>", vo.INJECTIONDATE));                                                                    // 注射日期
                            xmlUpload.AppendLine(string.Format("<JILIANG>{0}</JILIANG>", vo.JILIANG));                                                                                      // 注射剂量（单位：IU）
                            xmlUpload.AppendLine(string.Format("<SKINCONTACT code=\"{0}\" codesystem=\"STD_SKINCONTACT\">{1}</SKINCONTACT>", vo.SKINCONTACT_1, vo.SKINCONTACT_2));          // 产后30分钟内皮肤接触情况代码; 产后30分钟内皮肤接触情况
                            xmlUpload.AppendLine("</BABY>");
                        }
                        xmlUpload.AppendLine("</record>");
                        xmlUpload.AppendLine("</component>");
                        xmlUpload.AppendLine("</Document>");

                        #endregion

                        Log.Output("上传信息：" + Environment.NewLine + xmlUpload.ToString());
                        WebService ws = new WebService();
                        string res = ws.SaveInfoStringTypeXML("A74CC68F-B009-4264-A880-FBE87DD91E56", "763709818", xmlUpload.ToString());
                        Log.Output("返回信息：" + Environment.NewLine + res);

                        //ws.HelloWorld()

                        //ws.GetInfo()

                        MessageBox.Show(res);

                        // 处理当前消息队列中的所有windows消息
                        Application.DoEvents();
                        // 执行步长
                        this.progressBarControl.PerformStep();
                        // regId数组
                        registerId += motherVo.RegisterId + ",";
                    }

                    EntitySysTaskLog logVo = new EntitySysTaskLog();
                    logVo.typeId = "0006";
                    logVo.execTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    logVo.ipAddr = Function.LocalIP();
                    logVo.execStatus = 1;
                    logVo.execDesc = "上传成功 共 " + lstMother.Count + " 人 " + registerId.TrimEnd(',');
                    this.SaveTaskLog(logVo);
                }
            }
            catch (Exception ex)
            {
                Log.Output("异常信息：" + Environment.NewLine + ex.Message);
            }
            finally
            {
                this.progressBarControl.Visible = false;
                this.RefreshTask();
                this.gvTask.ViewCaption = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + timePoint;
            }
        }
        #endregion

        #region 读取日志
        /// <summary>
        /// 读取日志
        /// </summary>
        /// <returns></returns>
        public List<EntitySysTaskLog> GetTaskLog()
        {
            List<EntitySysTaskLog> data = new List<EntitySysTaskLog>();
            SqlHelper svc = null;
            try
            {
                svc = new SqlHelper(EnumBiz.onlineDB);
                EntitySysTaskLog vo = new EntitySysTaskLog() { typeId = "0006" };
                data = EntityTools.ConvertToEntityList<EntitySysTaskLog>(svc.Select(vo, EntitySysTaskLog.Columns.typeId));
            }
            catch (Exception e)
            {
                ExceptionLog.OutPutException(e);
            }
            finally
            {
                svc = null;
            }
            return data;
        }
        #endregion

        #region 保存日志
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="logVo"></param>
        /// <returns></returns>
        public int SaveTaskLog(EntitySysTaskLog logVo)
        {
            int affectRows = 0;
            SqlHelper svc = null;
            try
            {
                svc = new SqlHelper(EnumBiz.onlineDB);
                affectRows = svc.Commit(svc.GetInsertParm(logVo));
            }
            catch (Exception e)
            {
                ExceptionLog.OutPutException(e);
                affectRows = -1;
            }
            finally
            {
                svc = null;
            }
            return affectRows;
        }
        #endregion

        #region GetDefaultXml

        string GetDefaultXml()
        {
            #region xml.setvalue

            EntityMother motherVo = new EntityMother();
            motherVo.lstChild = new List<EntityChild>();

            StringBuilder xmlUpload = new StringBuilder();
            xmlUpload.AppendLine("<?xml version=\"1.0\" encoding=\"GBK\" ?>");
            xmlUpload.AppendLine("<Document type=\"Request Save\" versionNumber=\"\" value=\"1.0\">");
            xmlUpload.AppendLine("<realmCode code=\"4419.CN\"/>");
            xmlUpload.AppendLine("<code code=\"4419.A01.02.208\" codeSystem=\"4419.CN.01\" codeSystemName=\"东莞市妇幼卫生信息交互共享文档分类编码系统\"/>");
            xmlUpload.AppendLine("<title>请求推送某孕产妇分娩信息</title>");
            xmlUpload.AppendLine("<author>");
            xmlUpload.AppendLine("<authorID code=\"763709818\" authorname=\"东莞市茶山医院\"/>");
            xmlUpload.AppendLine("<InformationsystemID code=\"A74CC68F-B009-4264-A880-FBE87DD91E56\" InformationsystemName=\"东莞市茶山医院HIS管理系统\"/>");
            xmlUpload.AppendLine(string.Format("<GenerationTime type=\"TS\" value=\"{0}\"/>", DateTime.Now.ToString("yyyyMMddHHmm")));
            xmlUpload.AppendLine("</author>");
            xmlUpload.AppendLine("<component>");
            xmlUpload.AppendLine(string.Format("<OperationType value=\"{0}\"/>", motherVo.flagId == 0 ? "NEW" : "UPDATE"));
            xmlUpload.AppendLine("<recordNumber value=\"1\" type=\"INT\"/>");
            xmlUpload.AppendLine("<record>");
            xmlUpload.AppendLine(string.Format("<HISID>{0}</HISID>", motherVo.HISID));                          // HIS系统唯一ID
            xmlUpload.AppendLine(string.Format("<BARCODE>{0}</BARCODE>", motherVo.BARCODE));                    // 孕产妇保健手册号
            xmlUpload.AppendLine(string.Format("<IDCARD>{0}</IDCARD>", motherVo.IDCARD));                       // 女方身份证号
            xmlUpload.AppendLine(string.Format("<NAME>{0}</NAME>", motherVo.NAME));                             // 母亲姓名
            xmlUpload.AppendLine(string.Format("<HDSB0101021>{0}</HDSB0101021>", motherVo.HDSB0101021));        // 母亲出生日期
            xmlUpload.AppendLine(string.Format("<HDSB0101022 code=\"{0}\" codeSystem=\"GB/T 2659-2000\">{1}</HDSB0101022>", motherVo.HDSB0101022_1, motherVo.HDSB0101022_2));   // 母亲国籍代码; 母亲国籍
            xmlUpload.AppendLine(string.Format("<HDSB0101023 code=\"{0}\" codeSystem=\"GB 3304-1991\">{1}</HDSB0101023>", motherVo.HDSB0101023_1, motherVo.HDSB0101023_2));     // 母亲民族代码; 母亲民族
            xmlUpload.AppendLine(string.Format("<HDSB0101024 code=\"{0}\" codeSystem=\"CV02.01.101\">{1}</HDSB0101024>", motherVo.HDSB0101024_1, motherVo.HDSB0101024_2));      // 母亲身份证件类别代码; 母亲身份证件类别名
            xmlUpload.AppendLine(string.Format("<HDSB0101025>{0}</HDSB0101025>", motherVo.HDSB0101025));        // 母亲身份证件号码
            xmlUpload.AppendLine(string.Format("<HDSB0101040 code=\"{0}\" codeSystem=\"GBT 2260—2012\">{1}</HDSB0101040>", motherVo.HDSB0101040_1, motherVo.HDSB0101040_2));   // 母亲户籍地址区划代码; 母亲户籍地址
            xmlUpload.AppendLine(string.Format("<HDSB0101045>{0}</HDSB0101045>", motherVo.HDSB0101045));        // 母亲详细户籍地址(包括门牌号)
            xmlUpload.AppendLine(string.Format("<PRESENTADDRESS code=\"{0}\" codeSystem=\"GBT 2260—2012\">{1}</PRESENTADDRESS>", motherVo.PRESENTADDRESS_1, motherVo.PRESENTADDRESS_2));    // 母亲现住地址行政区划代码; 母亲现住地址
            xmlUpload.AppendLine(string.Format("<FULLPRESENTADDRESS>{0}</FULLPRESENTADDRESS>", motherVo.FULLPRESENTADDRESS));                                                   // 母亲详细现住地址(包括门牌号)

            xmlUpload.AppendLine(string.Format("<HDSB0101026>{0}</HDSB0101026>", motherVo.HDSB0101026));        // 父亲姓名
            xmlUpload.AppendLine(string.Format("<HDSB0101027>{0}</HDSB0101027>", motherVo.HDSB0101027));        // 父亲出生日期
            xmlUpload.AppendLine(string.Format("<HDSB0101028 code=\"{0}\" codeSystem=\"GB/T 2659-2000\">{1}</HDSB0101028>", motherVo.HDSB0101028_1, motherVo.HDSB0101028_2));   // 父亲国籍代码; 父亲国籍
            xmlUpload.AppendLine(string.Format("<HDSB0101029 code=\"{0}\" codeSystem=\"GB 3304-1991\">{1}</HDSB0101029>", motherVo.HDSB0101029_1, motherVo.HDSB0101029_2));     // 父亲民族代码; 父亲民族
            xmlUpload.AppendLine(string.Format("<HDSB0101030 code=\"{0}\" codeSystem=\"CV02.01.101\">{1}</HDSB0101030>", motherVo.HDSB0101030_1, motherVo.HDSB0101030_2));      // 父亲身份证件类别代码; 父亲身份证件类别名
            xmlUpload.AppendLine(string.Format("<HDSB0101031>{0}</HDSB0101031>", motherVo.HDSB0101031));        // 父亲身份证件号码
            xmlUpload.AppendLine(string.Format("<HDSB0101046 code=\"{0}\" codeSystem=\"GBT 2260—2012\">{1}</HDSB0101046>", motherVo.HDSB0101046_1, motherVo.HDSB0101046_2));   // 父亲户籍地址区划代码; 父亲户籍地址
            xmlUpload.AppendLine(string.Format("<HDSB0101051>{0}</HDSB0101051>", motherVo.HDSB0101051));        // 父亲详细户籍地址(包括门牌号)
            xmlUpload.AppendLine(string.Format("<HPRESENTADDRESS code=\"{0}\" codeSystem=\"GBT 2260—2012\">{1}</HPRESENTADDRESS>", motherVo.HPRESENTADDRESS_1, motherVo.HPRESENTADDRESS_2));    // 父亲现住地址行政区划代码; 父亲现住地址
            xmlUpload.AppendLine(string.Format("<HFULLPRESENTADDRESS>{0}</HFULLPRESENTADDRESS>", motherVo.HFULLPRESENTADDRESS));                                                // 父亲详细现住地址(包括门牌号)

            xmlUpload.AppendLine(string.Format("<MATTER code=\"{0}\" codesystem=\"STD_ISSUEREASON\">{1}</MATTER>", motherVo.MATTER_1, motherVo.MATTER_2));                      // 签发原因代码; 签发原因（00：信息齐全(双亲)，02：信息不全(单亲)）
            xmlUpload.AppendLine(string.Format("<BEDNO>{0}</BEDNO>", motherVo.BEDNO));                          // 床号
            xmlUpload.AppendLine(string.Format("<ZYH>{0}</ZYH>", motherVo.ZYH));                                // 住院号
            xmlUpload.AppendLine(string.Format("<INTIRE>{0}</INTIRE>", motherVo.INTIRE));                       // 当前第几胎
            xmlUpload.AppendLine(string.Format("<INHOSPITALIZATIONIN>{0}</INHOSPITALIZATIONIN>", motherVo.INHOSPITALIZATIONIN));                                                // 当前第几次住院
            xmlUpload.AppendLine(string.Format("<PLACETYPE code=\"{0}\" codesystem=\"STD_PLACETYPE\">{1}</PLACETYPE>", motherVo.PLACETYPE_1, motherVo.PLACETYPE_2));            // 分娩地点类型代码; 分娩地点类型名称
            xmlUpload.AppendLine(string.Format("<CYESISWEEK>{0}</CYESISWEEK>", motherVo.CYESISWEEK));           // 分娩孕周(日)
            xmlUpload.AppendLine(string.Format("<FETUSNUMBER code=\"{0}\" codesystem=\"STD_FETUSNUM\">{1}</FETUSNUMBER>", motherVo.FETUSNUMBER_1, motherVo.FETUSNUMBER_2));     // 胎数代码; 胎数
            xmlUpload.AppendLine(string.Format("<TAIMOPOLIEFANGSHI code=\"{0}\" codesystem=\"STD_TAIMOPOLIE\">{1}</TAIMOPOLIEFANGSHI>", motherVo.TAIMOPOLIEFANGSHI_1, motherVo.TAIMOPOLIEFANGSHI_2));   // 胎膜破裂方式代码; 胎膜破裂方式名称
            xmlUpload.AppendLine(string.Format("<TAIMOPOLIE>{0}</TAIMOPOLIE>", motherVo.TAIMOPOLIE));           // 胎膜破裂时间
            xmlUpload.AppendLine(string.Format("<CHILDBIRTHTIME>{0}</CHILDBIRTHTIME>", motherVo.CHILDBIRTHTIME));                                                               // 分娩时间
            xmlUpload.AppendLine(string.Format("<CHIBIRTYPE code=\"{0}\" codesystem=\"STD_CHIBIRTYPE\">{1}</CHIBIRTYPE>", motherVo.CHIBIRTYPE_1, motherVo.CHIBIRTYPE_2));       // 分娩方式代码; 分娩方式
            xmlUpload.AppendLine(string.Format("<FETUSPOSITION code=\"{0}\" codesystem=\"STD_FETUSPOSITION\">{1}</FETUSPOSITION>", motherVo.FETUSPOSITION_1, motherVo.FETUSPOSITION_2));    // 胎方位代码; 胎方位
            xmlUpload.AppendLine(string.Format("<ONELAYHOUR>{0}</ONELAYHOUR>", motherVo.ONELAYHOUR));           // 第一产程（小时）
            xmlUpload.AppendLine(string.Format("<ONELAY>{0}</ONELAY>", motherVo.ONELAY));                       // 第一产程（分钟）
            xmlUpload.AppendLine(string.Format("<TWOLAYHOUR>{0}</TWOLAYHOUR>", motherVo.TWOLAYHOUR));           // 第二产程（小时）
            xmlUpload.AppendLine(string.Format("<TWOLAY>{0}</TWOLAY>", motherVo.TWOLAY));                       // 第二产程（分钟）
            xmlUpload.AppendLine(string.Format("<THREELAYHOUR>{0}</THREELAYHOUR>", motherVo.THREELAYHOUR));     // 第三产程（小时）
            xmlUpload.AppendLine(string.Format("<THREELAY>{0}</THREELAY>", motherVo.THREELAY));                 // 第三产程（分钟）
            xmlUpload.AppendLine(string.Format("<ALLLAYHOUR>{0}</ALLLAYHOUR>", motherVo.ALLLAYHOUR));           // 总产程（小时）
            xmlUpload.AppendLine(string.Format("<ALLLAY>{0}</ALLLAY>", motherVo.ALLLAY));                       // 总产程（分钟）
            xmlUpload.AppendLine(string.Format("<PLACENTALTIME>{0}</PLACENTALTIME>", motherVo.PLACENTALTIME));  // 胎盘娩出时间
            xmlUpload.AppendLine(string.Format("<PLACENTALFANGSHI code=\"{0}\"  codesystem=\"STD_PLACENTALFANGSHI\">{1}</PLACENTALFANGSHI>", motherVo.PLACENTALFANGSHI_1, motherVo.PLACENTALFANGSHI_2));    // 胎盘娩出方式代码; 胎盘娩出方式
            xmlUpload.AppendLine(string.Format("<DELIVERYMEASURES>{0}</DELIVERYMEASURES>", motherVo.DELIVERYMEASURES));                                                         // 分娩措施
            xmlUpload.AppendLine(string.Format("<TAIPAN code=\"{0}\" codesystem=\"STD_TAIPAN\">{1}</TAIPAN>", motherVo.TAIPAN_1, motherVo.TAIPAN_2));                           // 胎膜胎盘完整性代码; 胎盘完整性
            xmlUpload.AppendLine(string.Format("<PLACENTA code=\"{0}\" codesystem=\"STD_PLACENTA\">{1}</PLACENTA>", motherVo.PLACENTA_1, motherVo.PLACENTA_2));                 // 胎膜完整性代码; 胎膜完整性
            xmlUpload.AppendLine(string.Format("<JIDAI>{0}</JIDAI>", motherVo.JIDAI));                          // 脐带长度(单位：cm)
            xmlUpload.AppendLine(string.Format("<LUCIDITY code=\"{0}\" codesystem=\"STD_LUCIDITY\">{1}</LUCIDITY>", motherVo.LUCIDITY_1, motherVo.LUCIDITY_2));                 // 羊水清否代码; 羊水清否
            xmlUpload.AppendLine(string.Format("<DEGREE code=\"{0}\" codesystem=\"STD_DEGREE\">{1}</DEGREE>", motherVo.DEGREE_1, motherVo.DEGREE_2));                           // 羊水分度代码; 羊水分度
            xmlUpload.AppendLine(string.Format("<AMNIOTIC>{0}</AMNIOTIC>", motherVo.AMNIOTIC));                 // 羊水量(单位：ml)
            xmlUpload.AppendLine(string.Format("<PLACENTALLONG>{0}</PLACENTALLONG>", motherVo.PLACENTALLONG));                                                                  // 胎盘长（单位cm）
            xmlUpload.AppendLine(string.Format("<PLACENTAWIDTH>{0}</PLACENTAWIDTH>", motherVo.PLACENTAWIDTH));                                                                  // 胎盘宽（单位cm）
            xmlUpload.AppendLine(string.Format("<PLACENTALTHICKNESS>{0}</PLACENTALTHICKNESS>", motherVo.PLACENTALTHICKNESS));                                                   // 胎盘厚（单位cm）
            xmlUpload.AppendLine(string.Format("<ISPERINEUMCUT code=\"{0}\" codesystem=\"STD_ISPERINEUMCUT\">{1}</ISPERINEUMCUT>", motherVo.ISPERINEUMCUT_1, motherVo.ISPERINEUMCUT_2));    // 会阴情况代码; 会阴情况
            xmlUpload.AppendLine(string.Format("<SUTURESITUATION code=\"{0}\" codesystem=\"STD_SUTURESITUATION\">{1}</SUTURESITUATION>", motherVo.SUTURESITUATION_1, motherVo.SUTURESITUATION_2));  // 缝合情况代码; 缝合情况
            xmlUpload.AppendLine(string.Format("<SEW>{0}</SEW>", motherVo.SEW));                                // 缝合针数(单位：针)
            xmlUpload.AppendLine(string.Format("<OPERATIONREASON>{0}</OPERATIONREASON>", motherVo.OPERATIONREASON));// 手术原因
            xmlUpload.AppendLine(string.Format("<CHUXUE>{0}</CHUXUE>", motherVo.CHUXUE));                       // 阴道分娩产后2h出血量（单位：ml）
            xmlUpload.AppendLine(string.Format("<SSZXM>{0}</SSZXM>", motherVo.SSZXM));                          // 手术人
            xmlUpload.AppendLine(string.Format("<ACCUSR>{0}</ACCUSR>", motherVo.ACCUSR));                       // 接生人
            xmlUpload.AppendLine(string.Format("<OPERATEDATE>{0}</OPERATEDATE>", motherVo.OPERATEDATE));        // 录入时间
            xmlUpload.AppendLine(string.Format("<ORG code=\"{0}\" codesystem=\"STD_ORGAN\">{1}</ORG>", motherVo.ORG_1, motherVo.ORG_2));                                        // 录入单位机构代码; 录入单位
            foreach (EntityChild vo in motherVo.lstChild)
            {
                xmlUpload.AppendLine("<BABY>");
                xmlUpload.AppendLine(string.Format("<BABYNAME>{0}</BABYNAME>", vo.BABYNAME));                   // 婴儿姓名
                xmlUpload.AppendLine(string.Format("<SEX code=\"{0}\" codesystem=\"GB/T 2261.1\">{1}</SEX>", vo.SEX_1, vo.SEX_2));                                              // 婴儿性别代码; 婴儿性别
                xmlUpload.AppendLine(string.Format("<SEQUENCE>{0}</SEQUENCE>", vo.SEQUENCE));                   // 胎次
                xmlUpload.AppendLine(string.Format("<DATEOFBIRTH>{0}</DATEOFBIRTH>", vo.DATEOFBIRTH));          // 出生时间
                xmlUpload.AppendLine(string.Format("<AVOIRDUPOIS>{0}</AVOIRDUPOIS>", vo.AVOIRDUPOIS));          // 体重
                xmlUpload.AppendLine(string.Format("<STATURE>{0}</STATURE>", vo.STATURE));                      // 身长
                xmlUpload.AppendLine(string.Format("<TOUWEI>{0}</TOUWEI>", vo.TOUWEI));                         // 头围
                xmlUpload.AppendLine(string.Format("<ISBUG code=\"{0}\" codesystem=\"STD_ISBUG\">{1}</ISBUG>", vo.ISBUG_1, vo.ISBUG_2));                                        // 是否畸形代码; 是否畸形
                xmlUpload.AppendLine(string.Format("<APGAR1>{0}</APGAR1>", vo.APGAR1));                         // 1min Apgar总分
                xmlUpload.AppendLine(string.Format("<APGAR5>{0}</APGAR5>", vo.APGAR5));                         // 5min Apgar总分
                xmlUpload.AppendLine(string.Format("<APGAR10>{0}</APGAR10>", vo.APGAR10));                      // 10min Apgar总分
                xmlUpload.AppendLine(string.Format("<HBIGTIME code=\"{0}\" codesystem=\"STD_HBIGTIME\">{1}</HBIGTIME>", vo.HBIGTIME_1, vo.HBIGTIME_2));                         // 是否注射乙肝免疫球蛋白代码; 是否注射乙肝免疫球蛋白
                xmlUpload.AppendLine(string.Format("<INJECTIONDATE>{0}</INJECTIONDATE>", vo.INJECTIONDATE));                                                                    // 注射日期
                xmlUpload.AppendLine(string.Format("<JILIANG>{0}</JILIANG>", vo.JILIANG));                                                                                      // 注射剂量（单位：IU）
                xmlUpload.AppendLine(string.Format("<SKINCONTACT code=\"{0}\" codesystem=\"STD_SKINCONTACT\">{1}</SKINCONTACT>", vo.SKINCONTACT_1, vo.SKINCONTACT_2));          // 产后30分钟内皮肤接触情况代码; 产后30分钟内皮肤接触情况
                xmlUpload.AppendLine("</BABY>");
            }
            xmlUpload.AppendLine("</record>");
            xmlUpload.AppendLine("</component>");
            xmlUpload.AppendLine("</Document>");

            #endregion

            return xmlUpload.ToString();
        }
        #endregion

        #endregion

        #region 事件

        private void frmConsole_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Init();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.None)
            {
                e.Cancel = true;
            }
            else
            {
                if (MessageBox.Show("确定退出任务？？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void frmConsole_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮 
            if (this.WindowState == FormWindowState.Minimized)
            {
                // 隐藏任务栏区图标 
                // this.ShowInTaskbar = false;
                this.Visible = false;
                // 图标显示在托盘区 
                this.notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //判断是否已经最小化于托盘 
            if (WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
                this.Activate();
                //任务栏区显示图标 
                //this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                this.notifyIcon.Visible = false;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder xmlUpload = new StringBuilder();
                xmlUpload.AppendLine("test 01");
                xmlUpload.AppendLine("test 02");
                xmlUpload.AppendLine("test 03");

                Log.Output("上传信息：" + Environment.NewLine + this.GetDefaultXml());

                WebService ws = new WebService();
                //byte[] res = ws.SaveInfo("A74CC68F-B009-4264-A880-FBE87DD91E56", "763709818", Encoding.Default.GetBytes(this.GetDefaultXml()));

                string res = ws.SaveInfoStringTypeXML("A74CC68F-B009-4264-A880-FBE87DD91E56", "763709818", this.GetDefaultXml());

                //WebService ws = new WebService();
                //byte[] res = ws.HelloWorld(Encoding.Default.GetBytes(xmlUpload.ToString()));

                //ws.HelloWorld()

                //ws.GetInfo()

                Log.Output("返回信息：" + Environment.NewLine + res); //Encoding.Default.GetString(res));

                MessageBox.Show(res); //(Encoding.Default.GetString(res));

                //this.Upload();
            }
            catch (Exception ex)
            {
                Log.Output("异常信息：" + Environment.NewLine + ex.Message);
            }
        }

        bool isExecing = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToString("HH:mm:ss") == timePoint.Trim())
            {
                try
                {
                    if (isExecing) return;
                    isExecing = true;
                    this.Upload();
                }
                finally
                {
                    isExecing = false;
                }
            }
        }

        #endregion

    }

    #region 实体

    #region Mother
    /// <summary>
    /// Mother
    /// </summary>
    public class EntityMother
    {
        /// <summary>
        /// 本次住院唯一ID
        /// </summary>
        public string RegisterId { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string ipNo { get; set; }
        /// <summary>
        /// HIS系统唯一ID
        /// </summary>
        public string HISID { get; set; }
        /// <summary>
        /// 孕产妇保健手册号
        /// </summary>
        public string BARCODE { get; set; }
        /// <summary>
        /// 女方身份证号
        /// </summary>
        public string IDCARD { get; set; }
        /// <summary>
        /// 母亲姓名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 母亲出生日期
        /// </summary>
        public string HDSB0101021 { get; set; }
        /// <summary>
        /// 母亲国籍代码
        /// </summary>
        public string HDSB0101022_1 { get; set; }
        /// <summary>
        /// 母亲国籍
        /// </summary>
        public string HDSB0101022_2 { get; set; }
        /// <summary>
        /// 母亲民族代码
        /// </summary>
        public string HDSB0101023_1 { get; set; }
        /// <summary>
        /// 母亲民族
        /// </summary>
        public string HDSB0101023_2 { get; set; }
        /// <summary>
        /// 母亲身份证件类别代码
        /// </summary>
        public string HDSB0101024_1 { get; set; }
        /// <summary>
        /// 母亲身份证件类别名
        /// </summary>
        public string HDSB0101024_2 { get; set; }
        /// <summary>
        /// 母亲身份证件号码
        /// </summary>
        public string HDSB0101025 { get; set; }
        /// <summary>
        /// 母亲户籍地址区划代码
        /// </summary>
        public string HDSB0101040_1 { get; set; }
        /// <summary>
        /// 母亲户籍地址
        /// </summary>
        public string HDSB0101040_2 { get; set; }
        /// <summary>
        /// 母亲详细户籍地址(包括门牌号)
        /// </summary>
        public string HDSB0101045 { get; set; }
        /// <summary>
        /// 母亲现住地址行政区划代码
        /// </summary>
        public string PRESENTADDRESS_1 { get; set; }
        /// <summary>
        /// 母亲现住地址
        /// </summary>
        public string PRESENTADDRESS_2 { get; set; }
        /// <summary>
        /// 母亲详细现住地址(包括门牌号)
        /// </summary>
        public string FULLPRESENTADDRESS { get; set; }
        /// <summary>
        /// 父亲姓名
        /// </summary>
        public string HDSB0101026 { get; set; }
        /// <summary>
        /// 父亲出生日期
        /// </summary>
        public string HDSB0101027 { get; set; }
        /// <summary>
        /// 父亲国籍代码
        /// </summary>
        public string HDSB0101028_1 { get; set; }
        /// <summary>
        /// 父亲国籍
        /// </summary>
        public string HDSB0101028_2 { get; set; }
        /// <summary>
        /// 父亲民族代码
        /// </summary>
        public string HDSB0101029_1 { get; set; }
        /// <summary>
        /// 父亲民族
        /// </summary>
        public string HDSB0101029_2 { get; set; }
        /// <summary>
        /// 父亲身份证件类别代码
        /// </summary>
        public string HDSB0101030_1 { get; set; }
        /// <summary>
        /// 父亲身份证件类别名
        /// </summary>
        public string HDSB0101030_2 { get; set; }
        /// <summary>
        /// 父亲身份证件号码
        /// </summary>
        public string HDSB0101031 { get; set; }
        /// <summary>
        /// 父亲户籍地址区划代码
        /// </summary>
        public string HDSB0101046_1 { get; set; }
        /// <summary>
        /// 父亲户籍地址
        /// </summary>
        public string HDSB0101046_2 { get; set; }
        /// <summary>
        /// 父亲详细户籍地址(包括门牌号)
        /// </summary>
        public string HDSB0101051 { get; set; }
        /// <summary>
        /// 父亲现住地址行政区划代码
        /// </summary>
        public string HPRESENTADDRESS_1 { get; set; }
        /// <summary>
        /// 父亲现住地址
        /// </summary>
        public string HPRESENTADDRESS_2 { get; set; }
        /// <summary>
        /// 父亲详细现住地址(包括门牌号)
        /// </summary>
        public string HFULLPRESENTADDRESS { get; set; }
        /// <summary>
        /// 签发原因代码
        /// </summary>
        public string MATTER_1 { get; set; }
        /// <summary>
        /// 签发原因（00：信息齐全(双亲)，02：信息不全(单亲)）
        /// </summary>
        public string MATTER_2 { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public string BEDNO { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string ZYH { get; set; }
        /// <summary>
        /// 当前第几胎
        /// </summary>
        public string INTIRE { get; set; }
        /// <summary>
        /// 当前第几次住院
        /// </summary>
        public string INHOSPITALIZATIONIN { get; set; }
        /// <summary>
        /// 分娩地点类型代码
        /// </summary>
        public string PLACETYPE_1 { get; set; }
        /// <summary>
        /// 分娩地点类型名称
        /// </summary>
        public string PLACETYPE_2 { get; set; }
        /// <summary>
        /// 分娩孕周(日)
        /// </summary>
        public string CYESISWEEK { get; set; }
        /// <summary>
        /// 胎数代码
        /// </summary>
        public string FETUSNUMBER_1 { get; set; }
        /// <summary>
        /// 胎数
        /// </summary>
        public string FETUSNUMBER_2 { get; set; }
        /// <summary>
        /// 胎膜破裂方式代码
        /// </summary>
        public string TAIMOPOLIEFANGSHI_1 { get; set; }
        /// <summary>
        /// 胎膜破裂方式名称
        /// </summary>
        public string TAIMOPOLIEFANGSHI_2 { get; set; }
        /// <summary>
        /// 胎膜破裂时间
        /// </summary>
        public string TAIMOPOLIE { get; set; }
        /// <summary>
        /// 分娩时间
        /// </summary>
        public string CHILDBIRTHTIME { get; set; }
        /// <summary>
        /// 分娩方式代码
        /// </summary>
        public string CHIBIRTYPE_1 { get; set; }
        /// <summary>
        /// 分娩方式
        /// </summary>
        public string CHIBIRTYPE_2 { get; set; }
        /// <summary>
        /// 胎方位代码
        /// </summary>
        public string FETUSPOSITION_1 { get; set; }
        /// <summary>
        /// 胎方位
        /// </summary>
        public string FETUSPOSITION_2 { get; set; }
        /// <summary>
        /// 第一产程（小时）
        /// </summary>
        public string ONELAYHOUR { get; set; }
        /// <summary>
        /// 第一产程（分钟）
        /// </summary>
        public string ONELAY { get; set; }
        /// <summary>
        /// 第二产程（小时）
        /// </summary>
        public string TWOLAYHOUR { get; set; }
        /// <summary>
        /// 第二产程（分钟）
        /// </summary>
        public string TWOLAY { get; set; }
        /// <summary>
        /// 第三产程（小时）
        /// </summary>
        public string THREELAYHOUR { get; set; }
        /// <summary>
        /// 第三产程（分钟）
        /// </summary>
        public string THREELAY { get; set; }
        /// <summary>
        /// 总产程（小时）
        /// </summary>
        public string ALLLAYHOUR { get; set; }
        /// <summary>
        /// 总产程（分钟）
        /// </summary>
        public string ALLLAY { get; set; }
        /// <summary>
        /// 胎盘娩出时间
        /// </summary>
        public string PLACENTALTIME { get; set; }
        /// <summary>
        /// 胎盘娩出方式代码
        /// </summary>
        public string PLACENTALFANGSHI_1 { get; set; }
        /// <summary>
        /// 胎盘娩出方式
        /// </summary>
        public string PLACENTALFANGSHI_2 { get; set; }
        /// <summary>
        /// 分娩措施
        /// </summary>
        public string DELIVERYMEASURES { get; set; }
        /// <summary>
        /// 胎膜胎盘完整性代码
        /// </summary>
        public string TAIPAN_1 { get; set; }
        /// <summary>
        /// 胎盘完整性
        /// </summary>
        public string TAIPAN_2 { get; set; }
        /// <summary>
        /// 胎膜完整性代码
        /// </summary>
        public string PLACENTA_1 { get; set; }
        /// <summary>
        /// 胎膜完整性
        /// </summary>
        public string PLACENTA_2 { get; set; }
        /// <summary>
        /// 脐带长度(单位：cm)
        /// </summary>
        public string JIDAI { get; set; }
        /// <summary>
        /// 羊水清否代码
        /// </summary>
        public string LUCIDITY_1 { get; set; }
        /// <summary>
        /// 羊水清否
        /// </summary>
        public string LUCIDITY_2 { get; set; }
        /// <summary>
        /// 羊水分度代码
        /// </summary>
        public string DEGREE_1 { get; set; }
        /// <summary>
        /// 羊水分度
        /// </summary>
        public string DEGREE_2 { get; set; }
        /// <summary>
        /// 羊水量(单位：ml)
        /// </summary>
        public string AMNIOTIC { get; set; }
        /// <summary>
        /// 胎盘长（单位cm）
        /// </summary>
        public string PLACENTALLONG { get; set; }
        /// <summary>
        /// 胎盘宽（单位cm）
        /// </summary>
        public string PLACENTAWIDTH { get; set; }
        /// <summary>
        /// 胎盘厚（单位cm）
        /// </summary>
        public string PLACENTALTHICKNESS { get; set; }
        /// <summary>
        /// 会阴情况代码
        /// </summary>
        public string ISPERINEUMCUT_1 { get; set; }
        /// <summary>
        /// 会阴情况
        /// </summary>
        public string ISPERINEUMCUT_2 { get; set; }
        /// <summary>
        /// 缝合情况代码
        /// </summary>
        public string SUTURESITUATION_1 { get; set; }
        /// <summary>
        /// 缝合情况
        /// </summary>
        public string SUTURESITUATION_2 { get; set; }
        /// <summary>
        /// 缝合针数(单位：针)
        /// </summary>
        public string SEW { get; set; }
        /// <summary>
        /// 手术原因
        /// </summary>
        public string OPERATIONREASON { get; set; }
        /// <summary>
        /// 阴道分娩产后2h出血量（单位：ml）
        /// </summary>
        public string CHUXUE { get; set; }
        /// <summary>
        /// 手术人
        /// </summary>
        public string SSZXM { get; set; }
        /// <summary>
        /// 接生人
        /// </summary>
        public string ACCUSR { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public string OPERATEDATE { get; set; }
        /// <summary>
        /// 录入单位机构代码
        /// </summary>
        public string ORG_1 { get; set; }
        /// <summary>
        /// 录入单位
        /// </summary>
        public string ORG_2 { get; set; }
        /// <summary>
        /// 标志: 0 new; 1 update 
        /// </summary>
        public int flagId { get; set; }
        /// <summary>
        /// 婴儿
        /// </summary>
        public List<EntityChild> lstChild { get; set; }
    }
    #endregion

    #region Child
    /// <summary>
    /// Child
    /// </summary>
    public class EntityChild
    {
        /// <summary>
        /// 婴儿姓名
        /// </summary>
        public string BABYNAME { get; set; }
        /// <summary>
        /// 婴儿性别代码
        /// </summary>
        public string SEX_1 { get; set; }
        /// <summary>
        /// 婴儿性别
        /// </summary>
        public string SEX_2 { get; set; }
        /// <summary>
        /// 胎次
        /// </summary>
        public string SEQUENCE { get; set; }
        /// <summary>
        /// 出生时间
        /// </summary>
        public string DATEOFBIRTH { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public string AVOIRDUPOIS { get; set; }
        /// <summary>
        /// 身长
        /// </summary>
        public string STATURE { get; set; }
        /// <summary>
        /// 头围
        /// </summary>
        public string TOUWEI { get; set; }
        /// <summary>
        /// 是否畸形代码
        /// </summary>
        public string ISBUG_1 { get; set; }
        /// <summary>
        /// 是否畸形
        /// </summary>
        public string ISBUG_2 { get; set; }
        /// <summary>
        /// 1min Apgar总分
        /// </summary>
        public string APGAR1 { get; set; }
        /// <summary>
        /// 5min Apgar总分
        /// </summary>
        public string APGAR5 { get; set; }
        /// <summary>
        /// 10min Apgar总分
        /// </summary>
        public string APGAR10 { get; set; }
        /// <summary>
        /// 是否注射乙肝免疫球蛋白代码
        /// </summary>
        public string HBIGTIME_1 { get; set; }
        /// <summary>
        /// 是否注射乙肝免疫球蛋白
        /// </summary>
        public string HBIGTIME_2 { get; set; }
        /// <summary>
        /// 注射日期
        /// </summary>
        public string INJECTIONDATE { get; set; }
        /// <summary>
        /// 注射剂量（单位：IU）
        /// </summary>
        public string JILIANG { get; set; }
        /// <summary>
        /// 产后30分钟内皮肤接触情况代码
        /// </summary>
        public string SKINCONTACT_1 { get; set; }
        /// <summary>
        /// 产后30分钟内皮肤接触情况
        /// </summary>
        public string SKINCONTACT_2 { get; set; }
    }
    #endregion

    #endregion

}
