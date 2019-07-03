using System;

namespace iCare
{
	public abstract class clsHRPMessage
	{
		public const string c_strAskForModify = "是否修改记录？";

		public const string c_strAskForDelete = "是否删除记录？";

		public const string c_strAskForSign = "请记录者签名！";

		public const string c_strSaveFail = "对不起，保存失败！";

		public const string c_strSaveSuccess = "保存成功！";

		/// <summary>
		/// 提示打印翻页
		/// </summary>
		public const string c_strPromptForPrint = "打印完第一页后，请把纸张翻转！";
	}	

}
