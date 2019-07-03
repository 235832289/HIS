using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
    /// <summary>
    /// 该类主要针对某些操作需要经过上级确认方可执行进行验证
    /// 通常根据传入的参数进行判断身份
    /// 此处的科主任、护士长均指的是行政的职称，通过角色去实现，而非技术上的职称
    /// </summary>
    public partial class frmValidateByDirector : Form
    {
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        /// <summary>
        /// 验证结果
        /// 通过为True 反之
        /// </summary>
        public bool BlnValidateResult;

        /// <summary>
        /// 上级领导ID
        /// </summary>
        public string mOperatorID;

         

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmValidateByDirector()
        {
            InitializeComponent();
            BlnValidateResult = false;
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,主任医师10or护士长20,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(btnDirector, txtDirectror, 10, true, clsEMRLogin.LoginInfo.m_strEmpID);

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmValidateByDirector(int intFormType,string strDeptID)
        {
            InitializeComponent();
            BlnValidateResult = false;
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            if (intFormType==1)
                //m_mthBindEmployeeSign(按钮,签名框,主任医师10or护士长20,身份验证trueorfalse);
                m_objSign.m_mthBindEmployeeSign(btnDirector, txtDirectror, 10, strDeptID,true);
            else
                //m_mthBindEmployeeSign(按钮,签名框,主任医师10or护士长20,身份验证trueorfalse);
                m_objSign.m_mthBindEmployeeSign(btnDirector, txtDirectror, 20,strDeptID, true );

        }

        /// <summary>
        /// 确认验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtDirectror.Text.Trim().Length == 0)
            {
                MessageBox.Show(this,"上级领导未签名","iCare Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else 
            {
                BlnValidateResult = true;
                this.Close();
            }
        }
        /// <summary>
        /// 取消验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            BlnValidateResult = false;
            this.Close();
        }
    }
}