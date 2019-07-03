using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 辅助查找UI
    /// </summary>
    public partial class frmAidFind : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 通用参数对象
        /// </summary>
        private object objParm = new object();        
        /// <summary>
        /// 参数类型 1 通用收费控件病区; 2 通用收费控件病床(+病区ID); 3 一日清单窗体

        /// </summary>
        private int ParmType = 0;
        /// <summary>
        /// 查询病床信息时病区ID
        /// </summary>
        private string ParmAreaID = "";
        /// <summary>
        /// 数据集

        /// </summary>
        private DataTable dtRecord = null;
        /// <summary>
        /// 当前行

        /// </summary>
        private int CurrRow = -1;
        /// <summary>
        /// 登录员所属科室(病区)ID列表
        /// </summary>
        private ArrayList objDeptIDArr;
        /// <summary>
        /// 构造

        /// </summary>
        public frmAidFind()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造

        /// </summary>
        /// <param name="Obj">对象</param>
        /// <param name="Type">类型 1 通用收费控件病区; 2 通用收费控件病床(+病区ID)</param>
        /// <param name="AreaID">病区ID</param>
        /// <param name="DeptIDArr">登录员所属科室(病区)ID列表</param>
        public frmAidFind(object Obj, int Type, string AreaID, ArrayList DeptIDArr)
        {
            InitializeComponent();

            ParmType = Type;
            ParmAreaID = AreaID;
            objDeptIDArr = DeptIDArr;

            objParm = Obj;            
        }

        private void frmAidFind_Load(object sender, EventArgs e)
        {
            this.m_mthLoadData();
        }
        
        private void frmAidFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                if (CurrRow != -1)
                {
                    DataRowView drv = this.dt.Rows[CurrRow].Tag as DataRowView;
                    this.m_mthSelectVal(drv);
                }
                else
                {                   
                    this.dt.Focus();
                }                               
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (CurrRow != -1 && CurrRow > 0)
                {
                    CurrRow--;
                    this.dt.CurrentCell = this.dt.Rows[CurrRow].Cells[0];
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (CurrRow != -1 && CurrRow < this.dt.Rows.Count - 1)
                {
                    CurrRow++;                    
                    this.dt.CurrentCell = this.dt.Rows[CurrRow].Cells[0];
                }
            }
        }

        private void txtVal_TextChanged(object sender, EventArgs e)
        {
            if (dtRecord == null)
            {
                return;
            }
            else
            {
                string val = this.txtVal.Text.Trim();
                string exp = "1=1";

                if (val != "")
                {
                    if (ParmType == 1)
                    {
                        exp = "code_vchr like '" + val + "%' or deptname_vchr like '" + val + "%' or pycode_chr like '" + val.ToUpper() + "%' or wbcode_chr like '" + val + "%'"; 
                    }
                    else if (ParmType == 2 || ParmType == 3)
                    {
                        exp = "code_chr like '" + val + "%'";
                    }
                }
                
                this.m_mthFillArea(exp);                
            }
        }

        #region 加载字典数据
        /// <summary>
        /// 加载字典数据
        /// </summary>        
        private void m_mthLoadData()
        {
            long l = 0;      
            dtRecord = null;

            if (ParmType == 1)
            {
                clsDcl_Charge objCharge = new clsDcl_Charge();
                l = objCharge.m_lngGetDeptArea(out dtRecord, 2);                
            }
            else if (ParmType == 2 || ParmType == 3)
            {
                clsDcl_CommonFind objFind = new clsDcl_CommonFind();
                l = objFind.m_lngGetBedinfo(ParmAreaID, 0, out dtRecord);                
            }

            if (l > 0)
            {
                this.m_mthFillArea("1=1");                
            }
        }

        #region 填充病区信息
        /// <summary>
        /// 填充病区信息
        /// </summary>
        /// <param name="Exp">条件表达式</param>
        private void m_mthFillArea(string Exp)
        {
            this.dt.Rows.Clear();
            DataView dv = new DataView(dtRecord);
            dv.RowFilter = Exp;

            foreach (DataRowView drv in dv)
            {
                //颜色
                Color FCR = Color.Black;

                string[] sarr = new string[1];

                if (ParmType == 1)
                {
                    if (objDeptIDArr.Count > 0 && objDeptIDArr.IndexOf(drv["deptid_chr"].ToString().Trim()) == -1)
                    {
                        continue;
                    }

                    sarr[0] = drv["deptname_vchr"].ToString().Trim();
                }
                else if (ParmType == 2 || ParmType == 3)
                {
                    if (drv["lastname_vchr"].ToString().Trim() == "")
                    {
                        continue;
                    }

                    if (drv["pstatus_int"].ToString() == "2")
                    {
                        sarr[0] = drv["code_chr"].ToString().Trim() + "床 " + drv["lastname_vchr"].ToString().Trim() + "(预)";
                        FCR = Color.Red; 
                    }
                    else
                    {
                        sarr[0] = drv["code_chr"].ToString().Trim() + "床 " + drv["lastname_vchr"].ToString().Trim();
                    }                    
                }                

                int row = this.dt.Rows.Add(sarr);
                this.dt.Rows[row].Tag = drv;
                this.dt.Rows[row].DefaultCellStyle.ForeColor = FCR;
            }

            if (this.dt.Rows.Count == 0)
            {
                CurrRow = -1;
            }
            else
            {
                CurrRow = 0;
            }
        }
        #endregion

        #region 选值

        /// <summary>
        /// 选值

        /// </summary>
        /// <param name="drv"></param>
        public void m_mthSelectVal(DataRowView drv)
        {
            if (ParmType == 1)
            {
                ((ucPatientInfo)objParm).Parm_AreaID = drv["deptid_chr"].ToString();
                ((ucPatientInfo)objParm).Parm_AreaName = drv["deptname_vchr"].ToString().Trim();               
            }
            else if (ParmType == 2)
            {
                ((ucPatientInfo)objParm).Parm_Zyh = drv["inpatientid_chr"].ToString(); 
                //((ucPatientInfo)objParm).Parm_BedID = drv["bedid_chr"].ToString();
                //((ucPatientInfo)objParm).Parm_BedName = drv["code_chr"].ToString().Trim() + "床";                               
            }
            else if (ParmType == 3)
            {
                ((frmRptEveryDayBill)objParm).RegisterID = drv["registerid_chr"].ToString();
                ((frmRptEveryDayBill)objParm).BedName = drv["code_chr"].ToString().Trim() + "床 " + drv["lastname_vchr"].ToString().Trim();
            }

            this.Close();
        }
        #endregion
        #endregion

        private void dt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dt.SelectedRows.Count > 0)
                {
                    DataRowView drv = this.dt.SelectedRows[0].Tag as DataRowView;
                    this.m_mthSelectVal(drv);
                }
            }
        }

        private void dt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                DataRowView drv = this.dt.Rows[e.RowIndex].Tag as DataRowView;
                this.m_mthSelectVal(drv);
            }
        }               
    }
}