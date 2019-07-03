using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.BIHOrderServer;

using System.Collections;
using com.digitalwave.iCare.gui.HIS;


namespace com.digitalwave.iCare.BIHOrder
{
    class clsCtl_BedPatientList : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量声名
        clsDcl_ExecuteOrder m_objManage = null;
        
        #endregion

        #region 构造函数
        public clsCtl_BedPatientList()
        {
            m_objManage = new clsDcl_ExecuteOrder();
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmBedPatientList m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmBedPatientList)frmMDI_Child_Base_in;

        }
        #endregion

     
        /// <summary>
        /// 界面导入当前病区数据
        /// </summary>
        internal void LoadTheDate()
        {
           
            this.m_objViewer.m_dtvPersonList.Rows.Clear();
            
            //long lngRes = m_objManage.m_lngGetBihBedByArea((string)m_objViewer.m_txtArea.Tag, "", out arrBed);
            BindThePersonList(this.m_objViewer.arrBed);
            SelectAll();

        }

        #region 梆定病人列表
        private void BindThePersonList(clsBIHCanExecOrder[] arrBed)
        {
            int k=0;
            for (int i = 0; i < arrBed.Length; i++)
            {
                if (arrBed[i] == null)
                {
                    return;
                }
                this.m_objViewer.m_dtvPersonList.Rows.Add();
                k=this.m_objViewer.m_dtvPersonList.RowCount-1;
                //this.m_objViewer.m_dtvPersonList.Rows[k].Cells["dtv_DEPTNAME_VCHR"].Value = arrBed[i].m_strCURAREAName;
                //this.m_objViewer.m_dtvPersonList.Rows[k].Cells["dtv_bedcode"].Value = arrBed[i].m_strCURBEDName;
                this.m_objViewer.m_dtvPersonList.Rows[k].Cells["dtv_bedcode"].Value = arrBed[i].m_strBedName;
                this.m_objViewer.m_dtvPersonList.Rows[k].Cells["m_dtvLastName"].Value = arrBed[i].m_strPatientName;
                this.m_objViewer.m_dtvPersonList.Rows[k].Cells["sex_chr"].Value = arrBed[i].m_strPatientSex;
                this.m_objViewer.m_dtvPersonList.Rows[k].Cells["ISINCEPT_INT"].Value = "0";
                this.m_objViewer.m_dtvPersonList.Rows[k].Tag = arrBed[i];
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
            //this.m_objViewer.m_chkSelectAll.Checked = true;
            //this.m_objViewer.m_txtArea.Text = this.m_objViewer.LoginInfo.m_strInpatientAreaName;
            //this.m_objViewer.m_txtArea.Tag = this.m_objViewer.LoginInfo.m_strInpatientAreaID;
            LoadTheDate();
           
        }

        internal void ChangeTheSelectState(int rowNum)
        {
            if (this.m_objViewer.m_dtvPersonList.Rows.Count > 0 && rowNum >= 0)
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

        

        internal void sendTheBill()
        {
           //IPutMadicine madicine;
           this.m_objViewer.m_arrPersionID = getListArray();
         
        }

        private ArrayList getListArray()
        {
            //欠费的病人列表
            ArrayList m_arrLessMoney = new ArrayList();
            //皮试不通过的病人列表
            ArrayList m_arrFeel = new ArrayList();
            ArrayList m_arrBedID = new ArrayList();
            for (int i = 0; i < this.m_objViewer.m_dtvPersonList.RowCount; i++)
            {
                if (this.m_objViewer.m_dtvPersonList.Rows[i].Cells["ISINCEPT_INT"].Value.ToString().Trim().Equals("1"))
                {
                    if (this.m_objViewer.m_intStatus == 1)
                    {
                        //欠费过虑
                        if (this.m_objViewer.m_arrPatient.Contains(((clsBIHCanExecOrder)this.m_objViewer.m_dtvPersonList.Rows[i].Tag).m_strRegisterID.ToString()))
                        {
                            m_arrLessMoney.Add(((clsBIHCanExecOrder)this.m_objViewer.m_dtvPersonList.Rows[i].Tag));

                        }
                        else
                        {
                            m_arrBedID.Add(((clsBIHCanExecOrder)this.m_objViewer.m_dtvPersonList.Rows[i].Tag).m_strRegisterID);
                        }
                        /*<================================*/
                    }
                    else if (this.m_objViewer.m_intStatus == 0)
                    {
                        //皮试过虑
                        if (this.m_objViewer.m_arrFeelTest.Contains(((clsBIHCanExecOrder)this.m_objViewer.m_dtvPersonList.Rows[i].Tag).m_strRegisterID.ToString()))
                        {
                            m_arrFeel.Add(((clsBIHCanExecOrder)this.m_objViewer.m_dtvPersonList.Rows[i].Tag));

                        }
                        else
                        {
                            m_arrBedID.Add(((clsBIHCanExecOrder)this.m_objViewer.m_dtvPersonList.Rows[i].Tag).m_strRegisterID);
                        }
                        /*<================================*/
                    }
                }
            }
            
            if (this.m_objViewer.m_intStatus == 1)
            {
                //欠费病人不能执行提示框
                LessMoneyAlert(m_arrLessMoney);
               
            }
            else if (this.m_objViewer.m_intStatus == 0)
            {
                //皮试不通过病人不能执行提示框
                string m_strMessage = "";
                for (int i = 0; i < m_arrFeel.Count; i++)
                {
                    m_strMessage += ((clsBIHCanExecOrder)m_arrFeel[i]).m_strBedName + "床病人" + ((clsBIHCanExecOrder)m_arrFeel[i]).m_strPatientName + "\r\n";
                }
                if (!m_strMessage.Equals(""))
                {
                    m_strMessage += "存在皮试项目还没有结果或为阳性,审核时请先进行相应处理!";
                    MessageBox.Show(m_strMessage, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                /*<======================================*/
            }
            return m_arrBedID;
        }

        /// <summary>
        /// 欠费病人不能执行提示框
        /// </summary>
        /// <param name="m_arrLessMoney"></param>
        private void LessMoneyAlert(ArrayList m_arrLessMoney)
        {
            string m_strMessage = "";
            for (int i = 0; i < m_arrLessMoney.Count; i++)
            {
                m_strMessage += ((clsBIHCanExecOrder)m_arrLessMoney[i]).m_strBedName + "床病人" + ((clsBIHCanExecOrder)m_arrLessMoney[i]).m_strPatientName + "\r\n";
            }
            if (!m_strMessage.Equals(""))
            {
                m_strMessage += "为欠费病人,医嘱不能执行!";
                MessageBox.Show(m_strMessage, "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            /*<======================================*/
        }
    }
}
