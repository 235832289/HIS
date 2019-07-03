using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmConfirmCureDaysPopup : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        List<EntityCureMed> lstOrder { get; set; }

        public bool IsSave { get; set; }

        public frmConfirmCureDaysPopup(List<EntityCureMed> _lstOrder)
        {
            InitializeComponent();
            lstOrder = _lstOrder;
        }

        private void frmConfirmCureDaysPopup_Load(object sender, EventArgs e)
        {
            this.rdo1.Checked = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<string> lstOrderId = new List<string>();
            Dictionary<string, double> dicGet = new Dictionary<string, double>();                   // key: 药房ID+OrderID
            Dictionary<string, double> dicGet3 = new Dictionary<string, double>();                  // key: RegisterId+OrderID+药房ID+药品ID
            Dictionary<string, double> dicTmp = new Dictionary<string, double>();
            Dictionary<string, List<string>> dicOrder = new Dictionary<string, List<string>>();
            string key = string.Empty;
            foreach (EntityCureMed item in lstOrder)
            {
                lstOrderId.Add(item.orderId);
                if (dicOrder.ContainsKey(item.execDeptId))
                {
                    dicOrder[item.execDeptId].Add(item.orderId);
                }
                else
                {
                    dicOrder.Add(item.execDeptId, new List<string>() { item.orderId });
                }
                dicGet.Add(item.execDeptId + "*" + item.orderId, Convert.ToDouble(item.preAmount));
                dicTmp.Add(item.registerId + "*" + item.orderId + "*" + item.execDeptId, Convert.ToDouble(item.preAmount));
            }
            Dictionary<string, string> dicMedId = new Dictionary<string, string>();
            using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
            {
                dicMedId = svc.GetMedIdByOrderId(lstOrderId);
            }
            string orderId = string.Empty;
            List<string> lstKey = new List<string>();
            lstKey.AddRange(dicTmp.Keys);
            foreach (string item in lstKey)
            {
                orderId = item.Split('*')[1];
                if (dicMedId.ContainsKey(orderId))
                {
                    dicGet3.Add(item + "*" + dicMedId[orderId], dicTmp[item]);
                }
            }

            #region 需求量
            List<string> lstOrderId_NoInDic = new List<string>();
            Dictionary<string, double> dicGet2 = new Dictionary<string, double>();                  // key: 药房ID+药品ID            
            Dictionary<string, List<string>> dicOrder2 = new Dictionary<string, List<string>>();    // key: 药房ID+药品ID
            foreach (string storeid in dicOrder.Keys)
            {
                foreach (string orderid in dicOrder[storeid])
                {
                    if (!dicMedId.ContainsKey(orderid))
                    {
                        lstOrderId_NoInDic.Add(orderid);     // 不在药品字典中的orderId
                    }
                    else
                    {
                        if (dicOrder2.ContainsKey(storeid))
                        {
                            dicOrder2[storeid].Add(dicMedId[orderid]);
                        }
                        else
                        {
                            dicOrder2.Add(storeid, new List<string>() { dicMedId[orderid] });
                        }
                        key = storeid + "*" + dicMedId[orderid];
                        if (dicGet2.ContainsKey(key))
                        {
                            dicGet2[key] += dicGet[storeid + "*" + orderid];
                        }
                        else
                        {
                            dicGet2.Add(key, dicGet[storeid + "*" + orderid]);
                        }
                    }
                }
            }
            #endregion

            if (dicOrder2.Keys.Count > 0)
            {
                Dictionary<string, double> dicKc = null;    // <药房ID*药ID, 库存量>
                clsDsStorageVO[] dsStorageVOArr = null;
                clsDcl_ExecuteOrder execDcl = new clsDcl_ExecuteOrder();
                execDcl.m_lngGetMedicineKC(dicOrder2, out dicKc, out dsStorageVOArr);
                if (dsStorageVOArr != null && dsStorageVOArr.Length > 0)
                {
                    #region 变量
                    // 领量基本单位转化成最小单位
                    Dictionary<string, string> dicMedName = new Dictionary<string, string>();
                    Dictionary<string, double> dicMedPack = new Dictionary<string, double>();
                    foreach (clsDsStorageVO vo in dsStorageVOArr)
                    {
                        key = vo.m_strPharmacyID + "*" + vo.m_strMedicineID;
                        if (!dicMedPack.ContainsKey(key))
                        {
                            if (vo.m_intIpChargeFlg == 0)
                            {
                                dicMedPack.Add(key, vo.m_dblPackqty);
                            }
                            else
                            {
                                dicMedPack.Add(key, 1);
                            }
                        }
                        if (!dicMedName.ContainsKey(vo.m_strMedicineID))
                        {
                            dicMedName.Add(vo.m_strMedicineID, vo.medName);
                        }
                    }
                    #endregion

                    #region 库存判断
                    lstKey.Clear();
                    lstKey.AddRange(dicGet2.Keys);
                    foreach (string key2 in lstKey)
                    {
                        if (dicMedPack.ContainsKey(key2))                           // 基本单位
                        {
                            dicGet2[key2] = dicGet2[key2] * dicMedPack[key2];       // 最小单位=基本单位*包装量
                        }
                        if (dicKc.ContainsKey(key2))
                        {
                            if (dicGet2[key2] > dicKc[key2])
                            {
                                MessageBox.Show("药品:" + dicMedName[key2.Split('*')[1]] + " 库存不足\r\n\r\n库存数:" + dicKc[key2] + " 需求数:" + dicGet2[key2], "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                // 库存判断通过
                            }
                        }
                        else
                        {
                            string medid = key2.Split('*')[1];
                            if (dicMedName.ContainsKey(medid))
                            {
                                MessageBox.Show("药品:" + dicMedName[medid] + " 无库存", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("药品编码:" + medid + " 无库存", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            return;
                        }
                    }
                    #endregion

                    #region 生成库存扣减信息
                    double ipAmount = 0;
                    double opAmount = 0;
                    EntityCureSubStock subVo = null;
                    List<EntityCureSubStock> lstSubStock = new List<EntityCureSubStock>();
                    foreach (string key3 in dicGet3.Keys)
                    {
                        key = key3.Split('*')[2] + "*" + key3.Split('*')[3];
                        if (dicMedPack.ContainsKey(key))                       // 基本单位
                        {
                            opAmount = dicGet3[key3];
                            ipAmount = dicGet3[key3] * dicMedPack[key];        // 最小单位=基本单位*包装量
                        }
                        else
                        {
                            opAmount = Convert.ToDouble(clsPublic.Round(Convert.ToDecimal(dicGet3[key3]) / Convert.ToDecimal(dicMedPack[key]), 4));  // 基本单位=最小单位/包装量
                            ipAmount = dicGet3[key3];
                        }
                        for (int k = 0; k < dsStorageVOArr.Length; k++)
                        {
                            clsDsStorageVO dsVo = dsStorageVOArr[k];
                            if (dsVo.m_dbIprealgross == 0) continue;
                            if (dsVo.m_strPharmacyID == key.Split('*')[0] && dsVo.m_strMedicineID == key.Split('*')[1])
                            {
                                subVo = new EntityCureSubStock();
                                subVo.serSid = dsVo.m_intSeriesID;
                                subVo.storeId = dsVo.m_strPharmacyID;
                                subVo.medId = dsVo.m_strMedicineID;
                                if (dsVo.m_dbIprealgross <= ipAmount)
                                {
                                    subVo.ipAmountReal = dsVo.m_dbIprealgross;
                                    subVo.opAmountReal = dsVo.m_dbOprealgross;
                                    ipAmount = ipAmount - subVo.ipAmountReal;
                                    opAmount = opAmount - subVo.opAmountReal;
                                    dsVo.m_dbIprealgross = 0;
                                    dsVo.m_dbOprealgross = 0;
                                }
                                else
                                {
                                    subVo.ipAmountReal = ipAmount;
                                    subVo.opAmountReal = opAmount;
                                    subVo.ipAmountVir = subVo.ipAmountReal;
                                    subVo.opAmountVir = subVo.opAmountReal;
                                    ipAmount = 0;
                                    dsVo.m_dbIprealgross -= ipAmount;
                                    dsVo.m_dbOprealgross -= opAmount;
                                }
                                subVo.registerId = key3.Split('*')[0];
                                subVo.orderId = key3.Split('*')[1];
                                lstSubStock.Add(subVo);
                                if (ipAmount == 0) break;
                            }
                        }
                    }
                    #endregion

                    #region 审核
                    string empId = string.Empty;
                    if (clsPublic.m_dlgConfirm(LoginInfo.m_strEmpNo, out empId) == DialogResult.Yes)
                    {
                        foreach (EntityCureMed item in lstOrder)
                        {
                            item.checkDate = this.dtmConfirm.Text;
                            item.checkState = this.rdo1.Checked ? "1" : "-1";
                            item.checkOperName = empId;
                        }
                        using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
                        {
                            if (svc.SaveCureMedConfirm(lstOrder, lstSubStock) > 0)
                            {
                                MessageBox.Show("审核成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.IsSave = true;
                                this.Close();
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
