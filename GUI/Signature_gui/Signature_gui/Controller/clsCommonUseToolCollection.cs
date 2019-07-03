using System;
using System.Windows.Forms;

namespace com.digitalwave.Emr.Signature_gui
{
	/// <summary>
	/// clsCommonUseToolCollection 的摘要说明。
	/// 外部签名调用设置类
	/// 用法：在构造函数中 类似
	/// 签名值绑定
	/// m_objSign = new clsEmrSignToolCollection();
	/// m_objSign.m_mthBindEmployeeSign(new Control[]{btns,btns1},new Control[]{txtsign,txtsign1},new int[]{1,1},new bool[]{true,false});
	/// m_objSign.m_mthBindEmployeeSign(new Control[]{buttonXP1,buttonXP2},new Control[]{textBox1,textBox2},new int[]{1,1},new string[]{"0000070","0000070"},new bool[]{true,false});
	/// create by tfzhang at 2005-12-27 11:49
	/// </summary>
	public class clsEmrSignToolCollection
	{

        //add by haozhong.liu 2008-11-11 是否显示职称
        private bool m_blnIsShowLevel = true;
        /// <summary>
        /// 是否显示职称
        /// </summary>
        public bool m_BlnIsShowLevel
        {
            get { return m_blnIsShowLevel; }
            set { m_blnIsShowLevel = value; }
        }

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_frmParent"></param>
		public clsEmrSignToolCollection()
		{
		}
		#endregion

		#region 绑定方法
		/// <summary>
		/// 绑定签名常用值签名
		/// </summary>
        /// <param name="p_ctlCall">按钮控件 通常PinkieControls</param>
        /// <param name="p_ctlTarget">签名接受控件 通常textbox、listview</param>
        /// <param name="p_intType">签名列表的类型：1为医生签名；2为护士签名</param>
		/// <param name="p_blnVerify">是否身份验证 true=需要 false=不需要</param>
		public void m_mthBindEmployeeSign(Control p_ctlCall,Control p_ctlTarget,int p_intType,bool p_blnVerify)
		{
            clsCommonUseTool objTool = new clsCommonUseTool();
            objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
            objTool.m_mthBindEmployeeSign(p_ctlCall, p_ctlTarget, p_intType, p_blnVerify);
		}
        /// <summary>
        /// 绑定签名常用值签名
        /// 返回员工所属科室的签名集合
        /// </summary>
        /// <param name="p_ctlCall">按钮控件 通常PinkieControls</param>
        /// <param name="p_ctlTarget">签名接受控件 通常textbox、listview</param>
        /// <param name="p_intType">签名列表的类型：1为医生签名；2为护士签名</param>
        /// <param name="p_blnVerify">是否身份验证 true=需要 false=不需要</param>
        /// <param name="p_employeeID">员工ID</param>
        public void m_mthBindEmployeeSign(Control p_ctlCall, Control p_ctlTarget, int p_intType, bool p_blnVerify,string p_employeeID)
        {
            clsCommonUseTool objTool = new clsCommonUseTool();
            objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
            objTool.m_mthBindEmployeeSign(p_ctlCall, p_ctlTarget, p_intType, p_blnVerify, p_employeeID);
        }

        /// <summary>
        /// 绑定签名常用值签名
        /// 返回员工所属科室的签名集合
        /// </summary>
        /// <param name="p_ctlCall">按钮控件 通常PinkieControls</param>
        /// <param name="p_ctlTarget">签名接受控件 通常textbox、listview</param>
        /// <param name="p_intType">签名列表的类型：1为医生签名；2为护士签名</param>
        /// <param name="p_blnVerify">是否身份验证 true=需要 false=不需要</param>
        /// <param name="p_employeeID">员工ID</param>
        /// <param name="p_blnIsorNoneShowLevel">是否显示职称:0通过参数配置设置；1显示，2不显示</param>
        public void m_mthBindEmployeeSign(Control p_ctlCall, Control p_ctlTarget, int p_intType, bool p_blnVerify, string p_employeeID, int p_intIsorNoneShowLevel)
        {
            clsCommonUseTool objTool = new clsCommonUseTool();
            if (p_intIsorNoneShowLevel == 1)
            {
                objTool.m_BlnIsShowLevel = true;
            }
            else if (p_intIsorNoneShowLevel == 2)
            {
                objTool.m_BlnIsShowLevel = false;
            }
            else
            {
                objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
            }
            objTool.m_mthBindEmployeeSign(p_ctlCall, p_ctlTarget, p_intType, p_blnVerify, p_employeeID);
        }
        /// <summary>
        /// 绑定签名常用值签名
        /// 返回员工所属科室的签名集合
        /// </summary>
        /// <param name="p_ctlCall">按钮控件 通常PinkieControls</param>
        /// <param name="p_ctlTarget">签名接受控件 通常textbox、listview</param>
        /// <param name="p_intType">签名列表的类型：1为医生签名；2为护士签名</param>
        /// <param name="p_blnVerify">是否身份验证 true=需要 false=不需要</param>
        /// <param name="p_employeeID">员工ID</param>
        /// <param name="p_blnIsMultiSignAndNoTag">是否可以添加多个签名，并且只返回名称，不返回ID（ true=是 false=否）</param>
        public void m_mthBindEmployeeSign(Control p_ctlCall, Control p_ctlTarget, int p_intType, bool p_blnVerify, string p_employeeID, bool p_blnIsMultiSignAndNoTag)
        {
            p_ctlCall.Tag = p_blnIsMultiSignAndNoTag;
            clsCommonUseTool objTool = new clsCommonUseTool();
            objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
            objTool.m_mthBindEmployeeSign(p_ctlCall, p_ctlTarget, p_intType, p_blnVerify, p_employeeID);
        }
		/// <summary>
		/// 绑定签名常用值签名
		/// 数组传入
		/// </summary>
		/// <param name="p_ctlCallArr">按钮控件 通常PinkieControls</param>
		/// <param name="p_ctlTargetArr">签名接受控件 通常textbox、listview</param>
		/// <param name="p_intTypeArr">签名列表的类型：1为医生签名；2为护士签名</param>
		/// <param name="p_blnVerify">是否身份验证 true=需要 false=不需要</param>
		public void m_mthBindEmployeeSign(Control[] p_ctlCallArr,Control[] p_ctlTargetArr,int[] p_intTypeArr,bool[] p_blnVerifyArr)
		{
			if(p_ctlCallArr != null && p_ctlCallArr.Length > 0)
			{
                clsCommonUseTool objTool;
                for (int i = 0; i < p_ctlCallArr.Length; i++)
                {
                    objTool = new clsCommonUseTool();
                    objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
                    objTool.m_mthBindEmployeeSign(p_ctlCallArr[i], p_ctlTargetArr[i], p_intTypeArr[i], p_blnVerifyArr[i]);
                }
			}
		}
		/// <summary>
		/// 绑定特定部门签名常用值签名
		/// </summary>
        /// <param name="p_ctlCall">按钮控件 通常PinkieControls</param>
        /// <param name="p_ctlTarget">签名接受控件 通常textbox、listview</param>
        /// <param name="p_intType">签名列表的类型：1为医生签名；2为护士签名</param>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="p_blnVerify">是否身份验证 true=需要 false=不需要</param>
		public void m_mthBindEmployeeSign(Control p_ctlCall,Control p_ctlTarget,int p_intType,string p_strDeptID,bool p_blnVerify)
		{
            clsCommonUseTool objTool = new clsCommonUseTool();
            objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
            objTool.m_mthBindEmployeeSign(p_ctlCall, p_ctlTarget, p_intType, p_strDeptID, p_blnVerify);
		}
		/// <summary>
		/// 绑定特定部门签名常用值签名
		/// 数组传入
		/// </summary>
		/// <param name="p_ctlCallArr">按钮控件 通常PinkieControls</param>
		/// <param name="p_ctlTargetArr">签名接受控件 通常textbox、listview</param>
		/// <param name="p_intTypeArr">签名列表的类型：1为医生签名；2为护士签名</param>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="p_blnVerify">是否身份验证 true=需要 false=不需要</param>
		public void m_mthBindEmployeeSign(Control[] p_ctlCallArr,Control[] p_ctlTargetArr,int[] p_intTypeArr,string[] p_strDeptIDArr,bool[] p_blnVerifyArr)
		{
			if(p_ctlCallArr != null && p_ctlCallArr.Length > 0)
			{
                clsCommonUseTool objTool;
                for (int i = 0; i < p_ctlCallArr.Length; i++)
                {
                    objTool = new clsCommonUseTool();
                    objTool.m_BlnIsShowLevel = m_blnIsShowLevel;
                    objTool.m_mthBindEmployeeSign(p_ctlCallArr[i], p_ctlTargetArr[i], p_intTypeArr[i], p_strDeptIDArr[i], p_blnVerifyArr[i]);
                }
			}
		}
		#endregion

	}
}
