using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.DataCollection;
using com.digitalwave.iCare.common;
using System.Data;

namespace com.digitalwave.iCare.gui.DataCollection.DomainController
{
    //Start====qinhong====住院据采集领域层（常平）==================
    /// <summary>
    /// 住院据采集领域层
    /// </summary>
    internal class clsDcl_ZY
    {
        #region  读取住院信息
        /// <summary>
        /// 读取住院信息
        /// </summary>
        /// <param name="p_dtmStartDate">起始日期</param>
        /// <param name="p_dtmEndDate">截止日期</param>
        /// <returns></returns>
        public long m_lngGetInHospitalInfo(DateTime p_dtmStartDate, DateTime p_dtmEndDate, out List<clsFirstPageVO> p_lstFirstPage, out List<clsOperationVO> p_lstOperation)
        {
            long lngRes = -1;
            p_lstFirstPage = new List<clsFirstPageVO>();
            p_lstOperation = new List<clsOperationVO>();
            //Start====读取数据
            clsEmrSvc objSvc = (clsEmrSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsEmrSvc));
            List<clsFirstPageVO> lstFirstPage = null;
            List<clsOperationVO> lstOperation = null;
            objSvc.m_lngGetFirstPageInfo(p_dtmStartDate.ToString(), p_dtmEndDate.ToString(), out lstFirstPage);
            objSvc.m_lngGetOperationInfo(p_dtmStartDate.ToString(), p_dtmEndDate.ToString(), out lstOperation);
            //End====读取数据

            //Start====数据整理
            #region 数据整理
            if (lstFirstPage != null)
            {
                for (int i = 0; i < lstFirstPage.Count; i++) //病案首页
                {
                    lstFirstPage[i].m_strfage = s_strGetAge(lstFirstPage[i].m_strfbirthday);
                    lstFirstPage[i].m_strfcountrybh = s_strSetCounty()[lstFirstPage[i].m_strfcountry];
                    if (s_strSetNation().ContainsKey(lstFirstPage[i].m_strfnationality))
                    {
                        lstFirstPage[i].m_strfnationalitybh = s_strSetNation()[lstFirstPage[i].m_strfnationality];
                    }
                    else
                        lstFirstPage[i].m_strfnationalitybh = "99";
                    
                    //lstFirstPage[i].m_strffbbh = lstFirstPage[i].m_strffb; //付款方式编码

                    if (lstFirstPage[i].m_strfzkdate == DateTime.MinValue)//首次专科时间
                        lstFirstPage[i].m_strfzkdate = Convert.ToDateTime("1900-01-01");
                    else
                        lstFirstPage[i].m_strfzktime = lstFirstPage[i].m_strfzkdate.ToString("HHmmssffff");

                    if (lstFirstPage[i].m_strDateTime == DateTime.MinValue)//输入时间
                        lstFirstPage[i].m_strDateTime = Convert.ToDateTime("1900-01-01");

                    //lstFirstPage[i].m_strfzkdate = lstFirstPage[i].m_strfzkdate; //首次专科日期
                    //lstFirstPage[i].m_strfjobbh = lstFirstPage[i].m_strfjob; //职业编号
                    lstFirstPage[i].m_Intfryqhmmins = lstFirstPage[i].m_Intfryqhmdays * 24 + lstFirstPage[i].m_Intfryqhmhours * 24 + lstFirstPage[i].m_Intfryqhmmins; //入院前昏迷总分钟
                    lstFirstPage[i].m_Intfryhmcounts = lstFirstPage[i].m_Intfryhmdays * 24 + lstFirstPage[i].m_Intfryhmhours * 24 + lstFirstPage[i].m_Intfryhmmins; //入院后昏迷总分钟'
                  
                    lstFirstPage[i].m_strfcytime = lstFirstPage[i].m_strfcydate.ToString("HHmmssffff");
                    lstFirstPage[i].m_strfrytime = lstFirstPage[i].m_strfrydate.ToString("HHmmssffff");
                }
                p_lstFirstPage.AddRange(lstFirstPage);
            }
            if (lstOperation != null)
            {
                for (int i = 0; i < lstOperation.Count; i++) //手术
                {
                    string[] strQkYhArr = lstOperation[i].m_strfqiekou.Split('/');
                    if (strQkYhArr.Length == 2)
                    {
                        lstOperation[i].m_strfqiekoubh = strQkYhArr[0];
                        lstOperation[i].m_strfyuhe = strQkYhArr[1];
                        switch (strQkYhArr[1])
                        {
                            case "甲":
                                lstOperation[i].m_strfyuhebh = "1";
                                break;
                            case "乙":
                                lstOperation[i].m_strfyuhebh = "2";
                                break;
                            case "丙":
                                lstOperation[i].m_strfyuhebh = "3";
                                break;
                            case "其他":
                                lstOperation[i].m_strfyuhebh = "4";
                                break;
                        }
                    }
                }
                p_lstOperation.AddRange(lstOperation);
            }
            #endregion
            //End====数据整理

            lstFirstPage = null;
            lstOperation = null;


            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 数据调整代码
        //计算年龄
        private string s_strGetAge(DateTime datBirth)
        {
            DateTime datNow = DateTime.Now;
            string strResult = "";
            int years = datNow.Year - datBirth.Year;
            int months = datNow.Month - datBirth.Month;
            int days = datNow.Day - datBirth.Day;
            int hours = datNow.Hour - datBirth.Hour;
            int minutes = datNow.Minute - datBirth.Minute;

            TimeSpan compare = datNow.Date - datBirth.Date;
            //int hours = (int)(compare.TotalHours) % 24;
            //int minutes = (int)compare.TotalMinutes % 60;

            if (minutes < 0)
            {
                hours--;
                minutes += 60;
            }

            if (hours < 0)
            {
                days--;
                hours += 24;
            }

            if (days < 0)
            {
                months--;
                days += 30;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            if (years >= 15)
            {
                strResult = years.ToString() + "岁";
            }
            else if (years >= 1)
            {
                strResult = years.ToString() + "岁" + months.ToString() + "月";
            }
            else if (months >= 1)
            {
                strResult = months.ToString() + "月" + days.ToString() + "天";
            }
            else if (days >= 1)
            {
                strResult = compare.Days.ToString() + "天" + hours.ToString() + "小时";
            }
            else if (hours >= 1)
            {
                strResult = hours.ToString() + "小时" + minutes.ToString() + "分钟";
            }
            else
                strResult = minutes.ToString() + "分钟";

            return strResult;
        }

        //加载国家代码
        private Dictionary<string, string> s_strSetCounty()
        {
            string m_strContents = @"462马尔代夫、466马里、470马耳他、474马提尼克、478毛里塔尼亚、480毛里求斯、484墨西哥、492摩纳哥、496蒙古、498摩尔多瓦、500蒙特塞拉特、504摩洛哥、508莫桑比克、512阿曼、516纳米比亚、520瑙鲁、524尼泊尔、528荷兰、530荷属安的列斯、533阿鲁巴、540新喀里多尼亚、548瓦努阿图、554新西兰、558尼加拉瓜、562尼日尔、566尼日利亚、570纽埃、574诺福克岛、578挪威、580北马里亚纳、581美属太平洋各群岛、583密克罗尼西亚、584马绍尔群岛、585贝劳、586巴基斯坦、591巴拿马、598巴布亚新几内亚、600巴拉圭、604秘鲁、608菲律宾、612皮特凯恩群岛、616波兰、620葡萄牙、624几内亚比绍、626东帝汶、630波多黎各、634卡塔尔、638留尼汪、642罗马尼亚、643俄罗斯、646卢旺达、654圣赫勒拿、659圣基茨和尼维斯、660安圭拉、662圣卢西亚、666圣皮埃尔和密克隆、670圣文森特和格林纳丁斯、674圣马力诺、678圣多美和普林西比、682沙特阿拉伯、686塞内加尔、690塞舌尔、694塞拉利昂、702新加坡、703斯洛伐克、704越南、705斯洛文尼亚、706索马里、710南非、716津巴布韦、724西班牙、732西撒哈拉、736苏丹、740苏里南、744斯瓦尔巴群岛、748斯威士兰、752瑞典、756瑞士、760叙利亚、762塔吉克斯坦、764泰国、768多哥、772托克劳、776汤加、780特立尼达和多巴哥、784阿联酋、788突尼斯、792土耳其、795土库曼斯坦、796特克斯和凯科斯群岛、798图瓦卢、800乌干达、804乌克兰、807马其顿、818埃及、826英国、834坦桑尼亚、840美国、850美属维尔京群岛、854布基纳法索、858乌拉圭、860乌兹别克斯坦、862委内瑞拉、876瓦利斯和富图纳群岛、882西萨摩亚、887也门、891南斯拉夫、894赞比亚、458马来西亚、004阿富汗、008阿尔巴尼亚、010南极洲、012阿尔及利亚、016美属萨摩亚、020安道尔、024安哥拉、028安提瓜和巴布达、031阿塞拜疆、032阿根廷、036澳大利亚、040奥地利、044巴哈马、048巴林、050孟加拉国、051亚美尼亚、052巴巴多斯、056比利时、060百慕大、064不丹、068玻利维亚、070波斯尼亚和黑塞哥维那、072博茨瓦纳、074布维岛、076巴西、084伯利兹、086英属印度洋领土、090所罗门群岛、092英属维尔京群岛、096文莱、100保加利亚、104缅甸、108布隆迪、112白俄罗斯、116柬埔寨、120喀麦隆、124加拿大、132佛得角、136开曼群岛、140中非、144斯里兰卡、148乍得、152智利、156中国、158中国台湾、162圣诞岛、166科科斯(基林)群岛、170哥伦比亚、174科摩罗、175马约特、178刚果、180扎伊尔、184库克群岛、188哥斯达黎加、191克罗地亚、192古巴、196塞浦路斯、203捷克、204贝宁、208丹麦、212多米尼克、214多米尼加共和国、218厄瓜多尔、222萨尔瓦多、226赤道几内亚、231埃塞俄比亚、232厄立特里亚、233爱沙尼亚、234法罗群岛、238马尔维纳斯群岛、239南乔治亚岛和南桑德韦、242斐济、246芬兰、250法国、254法属圭亚那、258法属波利尼西亚、260法属南部领土、262吉布提、266加蓬、268格鲁吉亚、270冈比亚、276德国、288加纳、292直布罗陀、296基里巴斯、300希腊、304格陵兰、308格林纳达、312瓜德罗普、316关岛、320危地马拉、324几内亚、328圭亚那、332海地、334赫德岛和麦克唐纳岛、336梵蒂冈、340洪都拉斯、344香港、348匈牙利、352冰岛、356印度、360印度尼西亚、364伊朗、368伊拉克、372爱尔兰、374巴勒斯坦、376以色列、380意大利、384科特迪瓦、388牙买加、392日本、398哈萨克斯坦、400约旦、404肯尼亚、408朝鲜、410韩国、414科威特、417吉尔吉斯斯坦、418老挝、422黎巴嫩、426莱索托、428拉脱维亚、430利比里亚、434利比亚、438列支敦士登、440立陶宛、442卢森堡、446澳门、450马达加斯加、454马拉维";
            string[] ContentsArr = m_strContents.Split('、');
            Dictionary<string, string> dicGj = new Dictionary<string, string>();
            foreach (string s in ContentsArr)
            {
                dicGj.Add(s.Substring(3, s.Length - 3), s.Substring(0, 3));
            }
            return dicGj;
        }

        //加载民族代码
        private Dictionary<string, string> s_strSetNation()
        {
            string m_strContents = @"01汉族、02蒙古族、03回族、04藏族、05维吾尔族、06苗族、07彝族、08壮族、09布依族、10朝鲜族、11满族、12侗族、13瑶族、14白族、15土家族、16哈尼族、17哈萨克族、18傣族、19黎族、20傈僳族、21佤族、22畲族、23高山族、24拉祜族、25水族、26东乡族、27纳西族、28景颇族、29柯尔克孜、30土族、31达斡尔族、32仫佬族、33羌族、34布朗族、35撒拉族、36毛难族、37仡佬族、38锡伯族、39阿昌族、40普米族、41塔吉克族、42怒族、43乌孜别克、44俄罗斯族、45鄂温克族、46崩龙族、47保安族、48裕固族、49京族、50塔塔尔族、51独龙族、52鄂伦春族、53赫哲族、54门巴族、55珞巴族、56基诺族、99其他族";
            string[] ContentsArr = m_strContents.Split('、');
            Dictionary<string, string> dicMz = new Dictionary<string, string>();
            foreach (string s in ContentsArr)
            {
                dicMz.Add(s.Substring(2, s.Length - 2), s.Substring(0, 2));
            }
            return dicMz;
        }

        //费用计算
        /// <summary>
        /// 设置默认费用信息
        /// </summary>
        private clsFirstPageVO m_mthLoadChargeInfo(clsEmrSvc objSvc, clsFirstPageVO p_lstFirstPage)
        {
            clsInHospitalMainCharge[] objChargeArr = null;
            string m_DblSelf = null;
            DataTable m_strBBRegisterID = null;
            long lngRes = 0;
            //入院时间大于更新时间，采用新版获取费用方式否则手填
            m_strBBRegisterID = objSvc.m_lngGetRgisterIDByInpatientID(p_lstFirstPage.m_strfzyid);
            if (m_strBBRegisterID.Rows.Count < 1)
                lngRes = objSvc.m_lngGetCHRCATE(null, p_lstFirstPage.m_strfzyid, out objChargeArr);
            else
                lngRes = objSvc.m_lngGetChargeChanKe(null, p_lstFirstPage.m_strfzyid, m_strBBRegisterID, out objChargeArr);
            lngRes = objSvc.m_lngGetSelfPay(null, p_lstFirstPage.m_strfzyid, out m_DblSelf);
            if (objChargeArr != null && objChargeArr.Length > 0)
            {
                double dblSum = 0D;
                for (int i = 0; i < objChargeArr.Length; i++)
                {
                    p_lstFirstPage = m_mthSetMoneyValueToUI(objChargeArr[i].m_dblMoney, objChargeArr[i].m_strTypeName, ref dblSum, p_lstFirstPage);
                }
                p_lstFirstPage.m_Dblfsum1 = dblSum;
                if (string.IsNullOrEmpty(m_DblSelf))
                {
                    p_lstFirstPage.m_Dblfzfje = Convert.ToDouble(m_DblSelf);
                }

            }

            return p_lstFirstPage;

        }
        double mzamt = 0.0;//麻醉费
        double ssamt = 0.0;//手术费
        double sszlamt = 0.0;//手术治疗费
        double kjyamt = 0.0;//抗菌药费
        double xyamt = 0.0;//西药费
        double fssxmamt = 0.0;//非手术项目治疗费    
        double lcwlzlf = 0.0;//临床物理治疗费

        #region 设置费用至clsFirstPageVO
        /// <summary>
        /// 设置费用至clsFirstPageVO
        /// </summary>
        /// <param name="p_dblMoney">费用金额</param>
        /// <param name="p_strChargeName">费用名称</param>
        /// <param name="p_dblSum">总和</param>
        private clsFirstPageVO m_mthSetMoneyValueToUI(double p_dblMoney, string p_strChargeName, ref double p_dblSum, clsFirstPageVO p_lstFirstPage)
        {
            if (string.IsNullOrEmpty(p_strChargeName))
            {
                return p_lstFirstPage;
            }

            #region  判断
            switch (p_strChargeName)
            {

                case "临床诊断项目费"://
                    p_lstFirstPage.m_Dblfzdllcf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "手术治疗费"://sszlamt
                    p_lstFirstPage.m_Dblfzllfssf = p_dblMoney;
                    sszlamt = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "麻醉费"://
                    p_lstFirstPage.m_Dblfzllfmzf = p_dblMoney;
                    mzamt = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "手术费"://           
                    p_lstFirstPage.m_Dblfzllfsszlf = p_dblMoney;
                    ssamt = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "其他费":
                    p_lstFirstPage.m_Dblfqtf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "护理费"://
                    p_lstFirstPage.m_Dblfzhfwlhlf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "血费":
                    p_lstFirstPage.m_Dblfxylxf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "抗菌药物费用"://
                    p_lstFirstPage.m_Dblfxylgjf = p_dblMoney;
                    kjyamt = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "西药费"://
                    p_lstFirstPage.m_Dblfxyf = p_dblMoney;
                    xyamt = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "中草药费":
                    p_lstFirstPage.m_Dblfzcyf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "中成药费"://
                    p_lstFirstPage.m_Dblfzchyf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "一般医疗服务费"://
                    p_lstFirstPage.m_Dblfzhfwlylf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "一般治疗操作费"://
                    p_lstFirstPage.m_Dblfzhfwlczf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "其他费用":
                    p_lstFirstPage.m_Dblfzhfwlqtf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "病理诊断费":
                    p_lstFirstPage.m_Dblfzdlblf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "实验室诊断费"://
                    p_lstFirstPage.m_Dblfzdlsssf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "影像学诊断费"://
                    p_lstFirstPage.m_Dblfzdlyxf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "非手术治疗项目费"://
                    p_lstFirstPage.m_Dblfzllffssf = p_dblMoney;
                    fssxmamt = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "临床物理治疗费"://
                    p_lstFirstPage.m_Dblfzllfwlzwlf = p_dblMoney;
                    lcwlzlf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "康复费":
                    p_lstFirstPage.m_Dblfkflkff = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "中医治疗费":
                    p_lstFirstPage.m_Dblfzylzf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "白蛋白类制品费":
                    p_lstFirstPage.m_Dblfxylbqbf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "球蛋白类制品费":
                    p_lstFirstPage.m_Dblfxylqdbf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "凝血因子类制品费":
                    p_lstFirstPage.m_Dblfxylyxyzf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "细胞因子类制品费":
                    p_lstFirstPage.m_Dblfxylxbyzf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "检查用一次性医用材料"://
                    p_lstFirstPage.m_Dblfhclcjf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "治疗用一次性医用材料费"://
                    p_lstFirstPage.m_Dblfhclzlf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
                case "手术用一次性医用材料费"://
                    p_lstFirstPage.m_Dblfhclssf = p_dblMoney;
                    p_dblSum += p_dblMoney;
                    break;
            }
            #endregion

            ////if (mzamt + ssamt + sszlamt != 0)
            ////{
            //txtSszlfAmt.Text = Convert.ToString(mzamt + ssamt + sszlamt);
            ////}
            ////if (kjyamt + xyamt != 0)
            ////{
            //txtWMAmt.Text = Convert.ToString(kjyamt + xyamt);
            ////}
            ////if (fssxmamt + lcwlzlf != 0)
            ////{
            //txtFsszlxmfAmt.Text = Convert.ToString(fssxmamt + lcwlzlf);
            ////}
            p_lstFirstPage.m_Dblfzllffssf = fssxmamt + lcwlzlf;
            p_lstFirstPage.m_Dblfzllfssf = mzamt + ssamt + sszlamt;
            p_lstFirstPage.m_Dblfxyf = kjyamt + xyamt;

            return p_lstFirstPage;
        }
        #endregion
        #endregion

        #region 上传病案首页信息
        /// <summary>
        /// 上传病案首页信息
        /// </summary>
        /// <param name="p_lstRecord"></param>
        /// <returns></returns>
        public long m_lngUploadFirstPageInfo(List<clsFirstPageVO> p_lstRecord)
        {
            long lngRes = -1;
            clsDataUpload_Svc objSvc = (clsDataUpload_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsDataUpload_Svc));
            objSvc.m_lngInsertFirstPageRecordInfo(p_lstRecord);
            return lngRes;
        }
        #endregion

        #region 上传手术信息
        /// <summary>
        /// 上传手术信息
        /// </summary>
        /// <param name="p_lstRecord"></param>
        /// <returns></returns>
        public long m_lngUploadOperationInfo(List<clsOperationVO> p_lstRecord)
        {
            long lngRes = -1;
            clsDataUpload_Svc objSvc = (clsDataUpload_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsDataUpload_Svc));
            objSvc.m_lngUploadOperationInfo(p_lstRecord);
            return lngRes;
        }
        #endregion


        #region 删除病案首页前置信息
        /// <summary>
        /// 删除病案首页前置信息
        /// </summary>
        /// <param name="p_lstRecord"></param>
        /// <returns></returns>
        public long m_lngDelFirstPageDataByDate(string p_strStardDate, string p_strEndDate)
        {
            long lngRes = -1;
            clsDataUpload_Svc objSvc = (clsDataUpload_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsDataUpload_Svc));
            objSvc.m_lngDelFirstPageDataByDate(p_strStardDate,p_strEndDate);
            return lngRes;
        }
        #endregion
    }


    //End====qinhong====住院据采集领域层（常平）==================
}
