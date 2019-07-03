using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.BIHOrder.Control;
using System.Collections;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.BIHOrder
{
    class clsCtl_OrderExecedPatientList : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量声名
        clsDcl_ExecuteOrder m_objManage = null;
        clsDcl_InputOrder m_objInputOrder = null;
        
        
        #endregion

        #region 构造函数
        public clsCtl_OrderExecedPatientList()
        {
            m_objManage = new clsDcl_ExecuteOrder();
            m_objInputOrder = new clsDcl_InputOrder();

        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmOrderExecedPatientList m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOrderExecedPatientList)frmMDI_Child_Base_in;

        }
        #endregion

        #region 病区事件
        public void m_txtAreaInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Columns.Add("病区编号", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("病区名称", 90, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 170;
        }
        public void m_txtAreaFindItem(string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            clsBIHArea[] objItemArr;
            long lngRes = m_objInputOrder.m_lngFindArea(strFindCode, out objItemArr);
            if (lngRes > 0 && objItemArr != null && objItemArr.Length > 0)
            {
                //获取有权限访问的病区ID集合
                if (m_objViewer.LoginInfo != null)
                {
                    IList ilUsableAreaID = m_objViewer.LoginInfo.m_ilUsableAreaID;
                    clsDcl_InputOrder objInputOrder = new clsDcl_InputOrder();
                    objItemArr = (clsBIHArea[])(objInputOrder.GetUsableAreaObject(objItemArr, ilUsableAreaID)).ToArray(typeof(clsBIHArea));
                }
                for (int i = 0; i < objItemArr.Length; i++)
                {
                    /** @update by xzf (05-09-20) 
                     * 
                     */
                    //@ListViewItem lvi=lvwList.Items.Add(objItemArr[i].m_strAreaID);
                    ListViewItem lvi = lvwList.Items.Add(objItemArr[i].code);
                    lvi.SubItems.Add(objItemArr[i].m_strAreaName);
                    lvi.Tag = objItemArr[i].m_strAreaID;
                    /* <<======================== */
                }
            }
        }
        public void m_txtAreaSelectItem(System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_objViewer.m_txtArea.Text = lviSelected.SubItems[1].Text;
                m_objViewer.m_txtArea.Tag = lviSelected.Tag;
                LoadTheDate();
            }
        }

        /// <summary>
        /// 界面导入当前病区数据
        /// </summary>
        internal void LoadTheDate()
        {
            if (m_objViewer.m_txtArea.Tag == null || ((string)m_objViewer.m_txtArea.Tag).Trim().Equals(""))
            {
                MessageBox.Show("病区必须选！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtArea.Focus();
                return;
            }
            this.m_objViewer.m_dtvPersonList.Rows.Clear();
            clsBIHPatientInfo[] m_arrObjPatient;
            DataTable m_dtPatients;
            long lngRes = m_objManage.m_lngGetPersonListByArea((string)m_objViewer.m_txtArea.Tag, out m_dtPatients);
            m_mthGetPatientInfoFromDateTable(m_dtPatients, out m_arrObjPatient);
            BindThePersonList(m_arrObjPatient);
            SelectAll();

        }

        #region 梆定病人列表
        private void BindThePersonList(clsBIHPatientInfo[] m_arrObjPatient)
        {
            int k=0;
            for (int i = 0; i < m_arrObjPatient.Length; i++)
            {
                if (m_arrObjPatient[i] == null)
                {
                    return;
                }
                this.m_objViewer.m_dtvPersonList.Rows.Add();
                k=this.m_objViewer.m_dtvPersonList.RowCount-1;
                this.m_objViewer.m_dtvPersonList.Rows[k].Cells["bedname"].Value = m_arrObjPatient[i].m_strBedName;
                this.m_objViewer.m_dtvPersonList.Rows[k].Cells["name_vchr"].Value = m_arrObjPatient[i].m_strPatientName;
                this.m_objViewer.m_dtvPersonList.Rows[k].Cells["sex_chr"].Value = m_arrObjPatient[i].m_strSex;
                this.m_objViewer.m_dtvPersonList.Rows[k].Cells["inpatientid_chr"].Value = m_arrObjPatient[i].m_strInHospitalNo;
                this.m_objViewer.m_dtvPersonList.Rows[k].Cells["ISINCEPT_INT"].Value = "0";
                this.m_objViewer.m_dtvPersonList.Rows[k].Tag = m_arrObjPatient[i];
            }
        }
        #endregion


        #endregion

        #region 病人表转换成病人信息对象数组
        /// <summary>
        /// 病人表转换成病人信息对象数组
        /// </summary>
        /// <param name="objRow"></param>
        /// <param name="objPatient"></param>
        private void m_mthGetPatientInfoFromDateTable(DataTable m_dtPatients, out clsBIHPatientInfo[] m_arrObjPatient)
        {
            m_arrObjPatient = new clsBIHPatientInfo[0];
            if (m_dtPatients == null)
            {
                return;
            }
            m_arrObjPatient = new clsBIHPatientInfo[m_dtPatients.Rows.Count];
            for (int i = 0; i < m_dtPatients.Rows.Count; i++)
            {
                m_arrObjPatient[i] = new clsBIHPatientInfo();
                m_arrObjPatient[i].m_strRegisterID = clsConverter.ToString(m_dtPatients.Rows[i]["RegisterID_Chr"]).Trim();
                m_arrObjPatient[i].m_strPatientID = clsConverter.ToString(m_dtPatients.Rows[i]["PatientID_Chr"]).Trim();
                m_arrObjPatient[i].m_strInHospitalNo = clsConverter.ToString(m_dtPatients.Rows[i]["InPatientID_Chr"]).Trim();
                m_arrObjPatient[i].m_dtInHospital = clsConverter.ToDateTime(m_dtPatients.Rows[i]["InPatient_Dat"]);
                m_arrObjPatient[i].m_strDeptID = clsConverter.ToString(m_dtPatients.Rows[i]["DeptID_Chr"]).Trim();
                m_arrObjPatient[i].m_strAreaID = clsConverter.ToString(m_dtPatients.Rows[i]["AreaID_Chr"]).Trim();

                m_arrObjPatient[i].m_strAreaName = clsConverter.ToString(m_dtPatients.Rows[i]["AreaName"]).Trim();
                m_arrObjPatient[i].m_strBedID = clsConverter.ToString(m_dtPatients.Rows[i]["BedID_Chr"]).Trim();
                m_arrObjPatient[i].m_strBedName = clsConverter.ToString(m_dtPatients.Rows[i]["BedName"]).Trim();
                /** update by xzf (05-09-29) */
                //@ m_arrObjPatient[i].m_strDiagnose=clsConverter.ToString(objRow["Diagnose_Vchr"]).Trim();
                m_arrObjPatient[i].m_strDiagnose = clsConverter.ToString(m_dtPatients.Rows[i]["ICD10DIAGTEXT_VCHR"]).Trim();
                /* <<============================= */
                m_arrObjPatient[i].m_intInTimes = clsConverter.ToInt(m_dtPatients.Rows[i]["InPatientCount_Int"]);
                m_arrObjPatient[i].m_strPatientName = clsConverter.ToString(m_dtPatients.Rows[i]["Name_VChr"]).Trim();

                m_arrObjPatient[i].m_strSex = clsConverter.ToString(m_dtPatients.Rows[i]["Sex_Chr"]).Trim();
                m_arrObjPatient[i].m_dtBorn = clsConverter.ToDateTime(m_dtPatients.Rows[i]["Birth_Dat"]);
                m_arrObjPatient[i].m_strPayTypeID = clsConverter.ToString(m_dtPatients.Rows[i]["PayTypeID_Chr"]).Trim();
                m_arrObjPatient[i].m_strPayTypeName = clsConverter.ToString(m_dtPatients.Rows[i]["PayTypeName_VChr"]).Trim();
                m_arrObjPatient[i].m_strInpatientState = clsConverter.ToString(m_dtPatients.Rows[i]["state"]).Trim();
                m_arrObjPatient[i].m_strMzdiagnose_vchr = clsConverter.ToString(m_dtPatients.Rows[i]["mzdiagnose_vchr"]).Trim();
                m_arrObjPatient[i].m_strDiagnose_vchr = clsConverter.ToString(m_dtPatients.Rows[i]["diagnose_vchr"]).Trim();
                if (m_dtPatients.Rows[i]["limitrate_mny"] != System.DBNull.Value)
                {
                    m_arrObjPatient[i].m_dblLIMITRATE_MNY = double.Parse(m_dtPatients.Rows[i]["limitrate_mny"].ToString());
                }
                try
                {
                    TimeSpan span1 = clsConverter.ToDateTime(m_dtPatients.Rows[i]["today"].ToString().Trim()) - m_arrObjPatient[i].m_dtBorn;
                    m_arrObjPatient[i].m_intAge = span1.Days / 365;
                }
                catch
                {
                }
                try
                {
                    m_arrObjPatient[i].m_strREMARKNAME_VCHR = m_dtPatients.Rows[i]["REMARKNAME_VCHR"].ToString().Trim();
                }
                catch
                {
                }
                try
                {
                    m_arrObjPatient[i].m_strDES_VCHR = m_dtPatients.Rows[i]["DES_VCHR"].ToString().Trim();
                }
                catch
                {
                }
            }
        }
        #endregion

        #region 选项框事件处理
        /// <summary>
        /// 选项框事件处理
        /// </summary>
        internal void SelectAll()
        {
            if (m_objViewer.m_chkSelectAll.Checked == true)
            {
                for (int i = 0; i < m_objViewer.m_dtvPersonList.Rows.Count; i++)
                {
                    m_objViewer.m_dtvPersonList.Rows[i].Cells["ISINCEPT_INT"].Value = "1";
                }
            }
            else
            {
                for (int i = 0; i < m_objViewer.m_dtvPersonList.Rows.Count; i++)
                {
                    m_objViewer.m_dtvPersonList.Rows[i].Cells["ISINCEPT_INT"].Value = "0";
                }
            }
        }
        #endregion

        /// <summary>
        /// 初始化界面
        /// </summary>
        internal void IniTheForm()
        {
            this.m_objViewer.m_chkSelectAll.Checked = true;
            //this.m_objViewer.m_txtArea.Text = this.m_objViewer.LoginInfo.m_strInpatientAreaName;
            //this.m_objViewer.m_txtArea.Tag = this.m_objViewer.LoginInfo.m_strInpatientAreaID;
            this.m_objViewer.m_txtArea.Focus();
            LoadTheDate();
           
        }

        internal void ChangeTheSelectState(int rowNum, int ColumnIndex)
        {
            if (this.m_objViewer.m_dtvPersonList.Rows.Count > 0 && rowNum >= 0)
            {
                if (ColumnIndex == 4)
                {
                    if (this.m_objViewer.m_dtvPersonList.Rows[rowNum].Cells["ISINCEPT_INT"].Value.ToString().Trim().Equals("0"))
                    {
                        this.m_objViewer.m_dtvPersonList.Rows[rowNum].Cells["ISINCEPT_INT"].Value = "1";
                    }
                    else if (this.m_objViewer.m_dtvPersonList.Rows[rowNum].Cells["ISINCEPT_INT"].Value.ToString().Trim().Equals("1"))
                    {
                        this.m_objViewer.m_dtvPersonList.Rows[rowNum].Cells["ISINCEPT_INT"].Value = "0";
                    }
                }

                
            }
           
        }

        internal void sendTheBill()
        {
           IPutMadicine madicine;
           ArrayList m_arrRegisterid=getListArray();
           madicine = PutMadicineFactory.GetInstance();
           long ret=madicine.CreatePutMedDetail(m_arrRegisterid, this.m_objViewer.LoginInfo.m_strEmpID);
           if (ret > 0)
           {
              bool ifAll= madicine.IsAllPatSend((string)this.m_objViewer.m_txtArea.Tag);
              if (ifAll)
              {
                  string m_strAreaID = "";
                  if(this.m_objViewer.m_txtArea.Tag!=null)
                  {
                      m_strAreaID = (string)this.m_objViewer.m_txtArea.Tag;
                 
                  }
                  if (!m_strAreaID.Equals(""))
                  {
                      DataTable m_dtItem = new DataTable();
                      long lngRes = m_objInputOrder.m_lngFindSendArea(m_strAreaID, out m_dtItem);
                      if (m_dtItem.Rows.Count == 0)
                      {
                          lngRes = madicine.GetAreaComplete(m_strAreaID, out m_dtItem);
                          if (m_dtItem.Rows.Count == 0)
                          {
                              if (MessageBox.Show("病区病人全部发送完毕，是否置全区摆药标志? ", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                              {

                                  madicine = PutMadicineFactory.GetInstance();
                                  ret = madicine.SetAreaComplete(m_strAreaID, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);

                              }
                          }
                      }
                  }
              }
           }
           LoadTheDate();
        }

        /// <summary>
        /// 批量执行发送(医嘱执行界面调用）
        /// </summary>
        internal void sendTheAllBill()
        {
            IPutMadicine madicine;
            ArrayList m_arrRegisterid = getListArray();
            madicine = PutMadicineFactory.GetInstance();
            long ret = madicine.CreatePutMedDetail(m_arrRegisterid, this.m_objViewer.LoginInfo.m_strEmpID);
            if (ret > 0)
            {
                string m_strAreaID = "";
                if (this.m_objViewer.m_txtArea.Tag != null)
                {
                    m_strAreaID = (string)this.m_objViewer.m_txtArea.Tag;

                }
                DataTable dtbResult;
                ret=madicine.GetAreaComplete(m_strAreaID,out  dtbResult);
                if (dtbResult.Rows.Count == 0)
                {
                    ret = madicine.SetAreaComplete(m_strAreaID, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);
                }
                       
            }
           
        }


        private ArrayList getListArray()
        {
            ArrayList m_arrRegisterid = new ArrayList();
            for (int i = 0; i < this.m_objViewer.m_dtvPersonList.RowCount; i++)
            {
                if (this.m_objViewer.m_dtvPersonList.Rows[i].Cells["ISINCEPT_INT"].Value.ToString().Equals("1"))
                {
                    m_arrRegisterid.Add(((clsBIHPatientInfo)this.m_objViewer.m_dtvPersonList.Rows[i].Tag).m_strRegisterID);
                }
            }
            return m_arrRegisterid;
        }
    }
}
