using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace CriticalValueService
{
    /// <summary>
    /// 查询参数实体
    /// </summary>
    [Serializable]
    public class EntityParm
    {
        public string YYBH { get; set; }
        public string XM { get; set; }
        public string DJH { get; set; }
        public string DJLB { get; set; }
        public string KSRQ { get; set; }
        public string ZZRQ { get; set; }
        public string FPWYH { get; set; }
        public string YLZFY { get; set; }
        public string KSHH { get; set; }
        public string ZZHH { get; set; }
    }

    /// <summary>
    /// 发票分类
    /// </summary>
    [Serializable]
    public class EntityInvoCat
    {
        public string catId { get; set; }
        public string catName { get; set; }
        public decimal catMny { get; set; }
    }

    /// <summary>
    /// 项目实体
    /// </summary>
    [Serializable]
    public class EntityItem
    {
        public string sbCode { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string catName { get; set; }
        public decimal price { get; set; }
        public decimal amount { get; set; }
        public decimal money { get; set; }
    }
}
