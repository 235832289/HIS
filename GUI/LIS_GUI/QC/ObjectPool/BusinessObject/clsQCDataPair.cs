using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 质控数据,同一质控时间，同一质控项目，不同质控浓度的数据
    /// </summary>
    public class clsQCDataPair
    {
        private DateTime m_dtQcdate;
        public DateTime QCDate
        {
            get { return m_dtQcdate; }
            set { m_dtQcdate = value; }
        }
        private int m_intSeq;

        public int Seq
        {
            get { return m_intSeq; }
            set { m_intSeq = value; }
        }

        private List<clsLisQCDataVO> m_arrData = new List<clsLisQCDataVO>();

        public clsLisQCDataVO this[int contrationId]
        {
            get
            {
                for (int i = 0; i < m_arrData.Count; i++)
                {
                    if (m_arrData[i].m_intConcentrationSeq == contrationId)
                    {
                        return m_arrData[i];
                    }
                }
                return null;
            }
        }

        public bool Add(clsLisQCDataVO p_objDataVO)
        {
            bool isExist = IsExistSameConcentration(p_objDataVO);
            if (isExist)
            {
                return false;
            }
            m_arrData.Add(p_objDataVO);
            return true;
        }

        private bool IsExistSameConcentration(clsLisQCDataVO p_objDataVO)
        {
            foreach (clsLisQCDataVO vo in m_arrData)
            {
                if (p_objDataVO.m_intConcentrationSeq == vo.m_intConcentrationSeq)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<clsQCDataPair> GetQCDataPairList(List<clsLisQCDataVO> p_dataList)
        {
            List<clsQCDataPair> lstDataPair = new List<clsQCDataPair>();
            p_dataList.Sort(CompareQCDataVO);

            bool isAdd = false;
            foreach (clsLisQCDataVO vo in p_dataList)
            {
                foreach (clsQCDataPair pair in lstDataPair)
                {
                    isAdd = false;
                    if (vo.m_datQCDate == pair.m_dtQcdate)
                    {
                        if (pair.Add(vo))
                        {
                            isAdd = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                //不存在相同时间的
                if (!isAdd) 
                {
                    clsQCDataPair newPair2 = new clsQCDataPair();
                    newPair2.Add(vo);
                    newPair2.m_dtQcdate = vo.m_datQCDate;
                    lstDataPair.Add(newPair2);
                }
                
            }
            return lstDataPair;
        }

        private static int CompareQCDataVO(clsLisQCDataVO x, clsLisQCDataVO y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                    return 1;
                else
                {
                    if (x.m_datQCDate > y.m_datQCDate)
                    {
                        return 1;
                    }
                    if (x.m_datQCDate == y.m_datQCDate)
                    {
                        if (x.m_intSeq > y.m_intSeq)
                        {
                            return 1;
                        }
                        else
                        {
                            if (x.m_intSeq == y.m_intSeq)
                            {
                                return 0;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                    else 
                    {
                        return -1;
                    }

                }

            }
        }
    }

    /// <summary>
    /// 质控数据,同一质控时间，不同质控项目，单一质控浓度的数据
    /// </summary>
    public class clsQCDataPairItem
    {
        /// <summary>
        /// 质控时间
        /// </summary>
        private DateTime m_dtQcdate;
        /// <summary>
        /// 质控时间
        /// </summary>
        public DateTime QCDate
        {
            get { return m_dtQcdate; }
            set { m_dtQcdate = value; }
        }


        private List<clsLisQCDataVO> m_arrData = new List<clsLisQCDataVO>();
        /// <summary>
        /// 获取指定质控批序号的第一个质控数据
        /// </summary>
        /// <param name="contrationId"></param>
        /// <returns></returns>
        public clsLisQCDataVO this[int p_intBatchSeq]
        {
            get
            {
                for (int i = 0; i < m_arrData.Count; i++)
                {
                    if (m_arrData[i].m_intQCBatchSeq == p_intBatchSeq)
                    {
                        return m_arrData[i];
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// 增加质控样本结果并返回true，如果存在相同的质控批序号则不增加并返回false
        /// </summary>
        /// <param name="p_objDataVO"></param>
        /// <returns></returns>
        public bool Add(clsLisQCDataVO p_objDataVO)
        {
            bool isExist = IsExistSameBatch(p_objDataVO);
            if (isExist)
            {
                return false;
            }
            m_arrData.Add(p_objDataVO);
            return true;
        }
        /// <summary>
        /// 判断是否存在与指定样本结果相同的浓度序号,如果存在返回true，否则返回false
        /// </summary>
        /// <param name="p_objDataVO"></param>
        /// <returns></returns>
        private bool IsExistSameBatch(clsLisQCDataVO p_objDataVO)
        {
            foreach (clsLisQCDataVO vo in m_arrData)
            {
                if (p_objDataVO.m_intQCBatchSeq == vo.m_intQCBatchSeq)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 返回质控数据对列表
        /// </summary>
        /// <param name="p_dataList"></param>
        /// <returns></returns>
        public static List<clsQCDataPairItem> GetQCDataPairItemList(List<clsLisQCDataVO> p_dataList)
        {
            List<clsQCDataPairItem> lstDataPair = new List<clsQCDataPairItem>();
            p_dataList.Sort(CompareQCDataVO);

            bool isAdd = false;
            foreach (clsLisQCDataVO vo in p_dataList)
            {
                foreach (clsQCDataPairItem pair in lstDataPair)
                {
                    isAdd = false;
                    if (vo.m_datQCDate == pair.m_dtQcdate)
                    {
                        if (pair.Add(vo))
                        {
                            isAdd = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                //不存在相同时间的
                if (!isAdd)
                {
                    clsQCDataPairItem newPair2 = new clsQCDataPairItem();
                    newPair2.Add(vo);
                    newPair2.m_dtQcdate = vo.m_datQCDate;
                    lstDataPair.Add(newPair2);
                }

            }
            return lstDataPair;
        }
        /// <summary>
        /// 质控样本的结果比较，排序用，控质控日期 Asc, 按质结果序号 Asc
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int CompareQCDataVO(clsLisQCDataVO x, clsLisQCDataVO y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                    return 1;
                else
                {
                    if (x.m_datQCDate > y.m_datQCDate)
                    {
                        return 1;
                    }
                    if (x.m_datQCDate == y.m_datQCDate)
                    {
                        if (x.m_intSeq > y.m_intSeq)
                        {
                            return 1;
                        }
                        else
                        {
                            if (x.m_intSeq == y.m_intSeq)
                            {
                                return 0;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                    else
                    {
                        return -1;
                    }

                }

            }
        }
    }
}
