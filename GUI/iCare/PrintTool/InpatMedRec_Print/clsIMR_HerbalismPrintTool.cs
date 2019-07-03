using System;
using System.IO;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// Summary description for clsIMR_HerbalismPrintTool.
	/// </summary>
	public class clsIMR_HerbalismPrintTool : clsInpatMedRecPrintBase
	{
		public clsIMR_HerbalismPrintTool(string p_strTypeID) :base(p_strTypeID)
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private clsPrintInPatMedRecItem[] m_objPrintOneItemArr;
		private clsPrintInPatMedRecItem[] m_objPrintMultiItemArr;
		private clsPrintInPatMedRecSign[] m_objPrintSignArr;

		protected override void m_mthSetPrintLineArr()
		{
			m_mthInitPrintLineArr();
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("康复医学科入院记录",285)
										  ,m_objPrintOneItemArr[0],m_objPrintOneItemArr[1],m_objPrintOneItemArr[2]
										  ,m_objPrintOneItemArr[3],m_objPrintOneItemArr[4],m_objPrintOneItemArr[5]
										  ,m_objPrintOneItemArr[6],m_objPrintOneItemArr[7]
										  ,m_objPrintMultiItemArr[0],m_objPrintMultiItemArr[1]
										  ,new clsPrintInPatMedRecPic(),m_objPrintMultiItemArr[2]
										  ,m_objPrintOneItemArr[8],m_objPrintSignArr[0]
										  ,m_objPrintMultiItemArr[3],m_objPrintSignArr[1]
									  });
		}

   		private void m_mthInitPrintLineArr()
		{
			m_objPrintOneItemArr = new clsPrintInPatMedRecItem[9];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[4];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();

			m_objPrintSignArr = new clsPrintInPatMedRecSign[2];
			for(int k3=0;k3<m_objPrintSignArr.Length;k3++)
				m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();
		}

		protected override void m_mthSetSubPrintInfo()
		{
			#region 单个项目
			m_objPrintOneItemArr[0].m_mthSetPrintValue("主诉","主诉：");
			m_objPrintOneItemArr[1].m_mthSetPrintValue("现病史","现病史：");
			m_objPrintOneItemArr[2].m_mthSetPrintValue("既往史","既往史：");
			m_objPrintOneItemArr[3].m_mthSetPrintValue("个人史","个人史：");
			m_objPrintOneItemArr[4].m_mthSetPrintValue("婚育史","婚育史：");
			m_objPrintOneItemArr[5].m_mthSetPrintValue("过敏史","过敏史：");
			m_objPrintOneItemArr[6].m_mthSetPrintValue("家族史","家族史：");
			m_objPrintOneItemArr[7].m_mthSetPrintValue("心理史","心理史：");
			m_objPrintOneItemArr[8].m_mthSetPrintValue("入院诊断","入院诊断：");
			#endregion

			#region 体格检查
			m_objPrintMultiItemArr[0].m_mthSetSpecialTitleValue("体 格 检 查");
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"体格检查>>T","体格检查>>T","体格检查>>P","体格检查>>P","体格检查>>R","体格检查>>R","体格检查>>BP","体格检查>>BP","体格检查>>WT","体格检查>>WT"}
				,new string[]{"T：","#℃","P：","#次/分","R：","#次/分","BP：","#mmHg","WT：","#Kg"});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","体格检查>>一般情况>>发育","体格检查>>一般情况>>营养","体格检查>>一般情况>>体型","体格检查>>一般情况>>体位","体格检查>>一般情况>>意识状态"}
				,new string[]{"\n一般情况：","发育：","营养：","体型：","体位：","意识状态(详见专科情况)："});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","体格检查>>皮肤粘膜>>颜色","体格检查>>皮肤粘膜>>温度","体格检查>>皮肤粘膜>>水肿","体格检查>>皮肤粘膜>>皮疹"
																	 ,"体格检查>>皮肤粘膜>>瘀斑","体格检查>>皮肤粘膜>>褥疮","体格检查>>皮肤粘膜>>疤痕"}
				,new string[]{"\n皮肤粘膜：","颜色：","温度：","水肿：","皮疹：","瘀斑：","褥疮：","疤痕："});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","体格检查>>淋巴结>>肿大","体格检查>>淋巴结>>部位","体格检查>>淋巴结>>压痛"}
				,new string[]{"\n淋巴结：","肿大：","部位：","压痛："});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","体格检查>>淋巴结>>颅骨缺损","体格检查>>头部>>颅骨缺损>>部位","体格检查>>头部>>颅骨缺损>>大小","体格检查>>头部>>结膜充血","体格检查>>头部>>咽部充血","体格检查>>头部>>扁桃体肿大","体格检查>>头部>>口腔溃疡"}
				,new string[]{"\n头  部：","颅骨缺损：","部位：","大小：","结膜充血：","咽部充血：","扁桃体肿大：","口腔溃疡："});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","体格检查>>颈部>>倾斜","体格检查>>颈部>>气管倾斜","体格检查>>颈部>>甲状腺肿大","体格检查>>颈部>>静脉努张"}
				,new string[]{"\n颈  部：","倾斜：","气管偏斜：","甲状腺肿大：","静脉怒张："});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","体格检查>>胸部>>胸部畸形","体格检查>>胸部>>呼吸音","体格检查>>胸部>>罗音","体格检查>>胸部>>心率","体格检查>>胸部>>心率","体格检查>>胸部>>心律","体格检查>>胸部>>心音","体格检查>>胸部>>杂音"}
				,new string[]{"\n胸  部：","胸部畸形：","呼吸音：","罗音：","心率：","#次/分","心律：","心音：","杂音："});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","体格检查>>腹部>>腹壁","体格检查>>腹部>>压痛","体格检查>>腹部>>反跳痛","体格检查>>腹部>>包块","体格检查>>腹部>>肝区压痛","体格检查>>腹部>>脾","体格检查>>腹部>>墨非氏征","体格检查>>腹部>>移动性浊音","体格检查>>腹部>>肾区叩痛","体格检查>>腹部>>输尿管点压痛","体格检查>>腹部>>肠鸣音"}
				,new string[]{"\n腹  部：","腹壁：","压痛：","反跳痛：","包块：","肝区压痛：","脾：","墨非氏征：","移动性浊音：","肾区叩痛：","输尿管点压痛：","肠鸣音："});
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"体格检查>>肛门直肠","体格检查>>外生殖器","","体格检查>>尿道外口>>溃疡","体格检查>>尿道外口>>留置导尿","体格检查>>脊柱","体格检查>>骨盘","","体格检查>>四肢>>骨","体格检查>>四肢>>关节","体格检查>>四肢>>运动"}
				,new string[]{"\n肛门直肠：","\n外生殖器：","\n尿道外口：","溃疡：","留置导尿：","\n脊柱：","\n骨盆：","\n四肢：","骨：","关节：","运动："});
			#endregion

			#region  专科检查(1~8)
			m_objPrintMultiItemArr[1].m_mthSetSpecialTitleValue("专 科 检 查");
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"专科检查>>一、意识状态","专科检查>>一、意识状态>>其他"},new string[]{"\n一、意识形态：","其他："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","专科检查>>二、认知 语言 精神 情绪>>1、言语功能>>构音","专科检查>>二、认知 语言 精神 情绪>>1、言语功能>>失语","","","专科检查>>二、认知 语言 精神 情绪>>2、认知功能>>记忆力>>近事","专科检查>>二、认知 语言 精神 情绪>>2、认知功能>>记忆力>>远事"
				 ,"","专科检查>>二、认知 语言 精神 情绪>>2、认知功能>>定向力>>时间","专科检查>>二、认知 语言 精神 情绪>>2、认知功能>>定向力>>地点","专科检查>>二、认知 语言 精神 情绪>>2、认知功能>>定向力>>人物","专科检查>>二、认知 语言 精神 情绪>>2、认知功能>>注意力"
				,"专科检查>>二、认知 语言 精神 情绪>>2、认知功能>>理解力","专科检查>>二、认知 语言 精神 情绪>>2、认知功能>>解决问题能力","专科检查>>二、认知 语言 精神 情绪>>3、精神状态","","专科检查>>二、认知 语言 精神 情绪>>4、情绪行为>>情绪","专科检查>>二、认知 语言 精神 情绪>>4、情绪行为>>合作程度","专科检查>>二、认知 语言 精神 情绪>>4、情绪行为>>自制力"}
				,new string[]{"\n二、认知 语言 精神 情绪：","\n  1、言语功能：","构音：","失语：","\n  2、认知功能：","记忆力：","近事：","远事：","\n  定向力：","时间：","地点：","人物：","注意力：","理解力：","解决问题能力：","\n  3、精神状态：","\n  4、情绪行为：","情绪：","合作程度：","自制力："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","专科检查>>三、颅神经>>Ⅰ　嗅神经>>嗅觉"},new string[]{"\n三、颅神经：","\n  Ⅰ 嗅神经：","嗅觉："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>三、颅神经>>Ⅱ　视神经>>视力","专科检查>>三、颅神经>>Ⅱ　视神经>>视野","","专科检查>>三、颅神经>>Ⅱ　视神经>>眼底>>视乳头"
				 ,"专科检查>>三、颅神经>>Ⅱ　视神经>>眼底>>动静脉比例","专科检查>>三、颅神经>>Ⅱ　视神经>>眼底>>视网膜出血","专科检查>>三、颅神经>>Ⅱ　视神经>>眼底>>检查"}
				,new string[]{"\n  Ⅱ 视神经：","视力：","视野：","眼底：","视乳头：","动静脉比例：","视网膜出血：","检查："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>眼球位置","专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>眼球震颤","专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>眼球运动"
				,"","专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>瞳孔及瞳孔反射>>大小","专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>瞳孔及瞳孔反射>>大小>>右","专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>瞳孔及瞳孔反射>>大小>>右","专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>瞳孔及瞳孔反射>>大小>>左","专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>瞳孔及瞳孔反射>>大小>>左"
				,"专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>瞳孔及瞳孔反射>>形状","专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>瞳孔及瞳孔反射>>对光反射","专科检查>>三、颅神经>>Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经>>瞳孔及瞳孔反射>>眼睑下垂"}
				,new string[]{"\n  Ⅲ 动眼神经、Ⅳ 滑车神经、Ⅵ 外展神经：","眼球位置：","眼球震颤：","眼球运动：","\n  瞳孔及瞳孔反射：","大小：","右＝","#mm","左＝","#mm","形状：","对光反射：","眼睑下垂："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>三、颅神经>>Ⅴ 三叉神经>>颜面感觉","专科检查>>三、颅神经>>Ⅴ 三叉神经>>角膜反射","","专科检查>>三、颅神经>>Ⅴ 三叉神经>>下颌运动>>嚼肌","专科检查>>三、颅神经>>Ⅴ 三叉神经>>下颌运动>>颞肌"}
				,new string[]{"\n  Ⅴ 三叉神经：","颜面感觉：","角膜反射：","下颌运动：","嚼肌：","颞肌："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>三、颅神经>>Ⅶ 面神经>>皱额","专科检查>>三、颅神经>>Ⅶ 面神经>>鼻唇沟","专科检查>>三、颅神经>>Ⅶ 面神经>>闭眼","专科检查>>三、颅神经>>Ⅶ 面神经>>鼓腮","专科检查>>三、颅神经>>Ⅶ 面神经>>露齿"
				,"专科检查>>三、颅神经>>Ⅶ 面神经>>吹哨","专科检查>>三、颅神经>>Ⅶ 面神经>>口角偏移","专科检查>>三、颅神经>>Ⅶ 面神经>>颞舌前2/3味觉"}
				,new string[]{"\n  Ⅶ 面神经：","皱额：","鼻唇沟：","闭眼：","鼓腮：","露齿：","吹哨：","口角偏歪：","舌前2/3味觉："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>三、颅神经>>Ⅷ 听神经>>听力","专科检查>>三、颅神经>>Ⅷ 听神经>>耳鸣"},new string[]{"\n  Ⅷ 听神经：","听力：","耳鸣："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>三、颅神经>>Ⅸ 舌咽神经、Ⅹ 迷走神经>>舌后1/3味觉","专科检查>>三、颅神经>>Ⅸ 舌咽神经、Ⅹ 迷走神经>>软腭活动","专科检查>>三、颅神经>>Ⅸ 舌咽神经、Ⅹ 迷走神经>>咽反射","专科检查>>三、颅神经>>Ⅸ 舌咽神经、Ⅹ 迷走神经>>吞咽"}
				,new string[]{"\n  Ⅸ 舌咽神经、Ⅹ 迷走神经:：","舌后1/3味觉：","软腭活动：","咽反射：","吞咽："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>三、颅神经>>Ⅺ 副神经>>耸肩","专科检查>>三、颅神经>>Ⅺ 副神经>>转颈"},new string[]{"\n  Ⅺ 副神经：","耸肩：","转颈："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>三、颅神经>>Ⅻ 舌下神经>>伸舌","专科检查>>三、颅神经>>Ⅻ 舌下神经>>舌肌萎缩","专科检查>>三、颅神经>>Ⅻ 舌下神经>>舌肌震颤"},new string[]{"\n  Ⅻ 舌下神经：","伸舌：","舌肌萎缩：","舌肌震颤："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>四、肌张力>>右上肢","专科检查>>四、肌张力>>右上肢","专科检查>>四、肌张力>>左上肢","专科检查>>四、肌张力>>左上肢","专科检查>>四、肌张力>>右下肢","专科检查>>四、肌张力>>右下肢","专科检查>>四、肌张力>>左下肢","专科检查>>四、肌张力>>左下肢"}
				,new string[]{"\n四、肌张力：(Ashworth分级)：","\n  右上肢：","#级","左上肢：","#级","右下肢：","#级","左下肢：","#级"});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","专科检查>>五、肌力>>右上肢>>近端","专科检查>>五、肌力>>右上肢>>近端","专科检查>>五、肌力>>右上肢>>远端","专科检查>>五、肌力>>右上肢>>远端","","专科检查>>五、肌力>>左上肢>>近端","专科检查>>五、肌力>>左上肢>>近端","专科检查>>五、肌力>>左上肢>>远端","专科检查>>五、肌力>>左上肢>>远端"
				,"","专科检查>>五、肌力>>右下肢>>近端","专科检查>>五、肌力>>右下肢>>近端","专科检查>>五、肌力>>右下肢>>远端","专科检查>>五、肌力>>右下肢>>远端","","专科检查>>五、肌力>>左下肢>>近端","专科检查>>五、肌力>>左下肢>>近端","专科检查>>五、肌力>>左下肢>>远端","专科检查>>五、肌力>>左下肢>>远端"}
				,new string[]{"\n五、肌力(痉挛严重者可不测)","\n  右上肢：","近端：","#级","远端：","#级","\n  左上肢：","近端","#级","远端","#级","\n  右下肢：","近端","#级","远端","#级","\n  左下肢：","近端","#级","远端","#级"});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>六、轻瘫试验>>右上肢","专科检查>>六、轻瘫试验>>左上肢","专科检查>>六、轻瘫试验>>右下肢","专科检查>>六、轻瘫试验>>左下肢"},new string[]{"\n六、轻瘫试验：","\n  右上肢：","右下肢：","左上肢：","左下肢："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","专科检查>>七、共济运动>>1.指鼻试验>>右侧","专科检查>>七、共济运动>>1.指鼻试验>>左侧"},new string[]{"\n七、共济运动：","\n  1.指鼻试验：","右侧：","左侧："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>七、共济运动>>2.快复轮替动作>>右侧","专科检查>>七、共济运动>>2.快复轮替动作>>左侧"},new string[]{"\n  2.快复轮替动作：","右侧：","左侧："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>七、共济运动>>3.跟膝胫试验>>右侧","专科检查>>七、共济运动>>3.跟膝胫试验>>左侧"},new string[]{"\n  3.跟膝胫试验：","右侧：","左侧："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>七、共济运动>>4.Romberg’s征>>睁眼","专科检查>>七、共济运动>>4.Romberg’s征>>闭眼"},new string[]{"\n  4.Romberg’s征：","睁眼：","闭眼："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","","专科检查>>八、感觉功能>>浅感觉>>触觉>>右","专科检查>>八、感觉功能>>浅感觉>>触觉>>左","","专科检查>>八、感觉功能>>浅感觉>>痛觉>>右","专科检查>>八、感觉功能>>浅感觉>>痛觉>>左","","专科检查>>八、感觉功能>>浅感觉>>温度觉>>右","专科检查>>八、感觉功能>>浅感觉>>温度觉>>左"}
				,new string[]{"\n八、感觉功能:(合作、不合作)(过敏+++、正常++、减弱+、消失-)","\n  浅感觉：","触觉：","右：","左：","痛觉：","右：","左：","温度觉：","右：","左："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","专科检查>>八、感觉功能>>深感觉>>运动觉>>右","专科检查>>八、感觉功能>>深感觉>>运动觉>>左","","专科检查>>八、感觉功能>>深感觉>>位置觉>>右","专科检查>>八、感觉功能>>深感觉>>位置觉>>左","","专科检查>>八、感觉功能>>深感觉>>震动觉>>右","专科检查>>八、感觉功能>>深感觉>>震动觉>>左"}
				,new string[]{"\n  深感觉：","运动觉：","右：","左：","位置觉：","右：","左：","震动觉：","右：","左："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","专科检查>>八、感觉功能>>复合感觉>>形体觉>>右","专科检查>>八、感觉功能>>复合感觉>>形体觉>>左","","专科检查>>八、感觉功能>>复合感觉>>两点辨别觉>>右","专科检查>>八、感觉功能>>复合感觉>>两点辨别觉>>左"}
				,new string[]{"\n  复合感觉：","形体觉：","右：","左：","两点辨别觉：","右：","左："});
			#endregion

			#region 专科检查(9~12)
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","","","","专科检查>>九、反射>>1、生理反射>>浅反射>>腹壁反射>>右>>上","专科检查>>九、反射>>1、生理反射>>浅反射>>腹壁反射>>右>>中","专科检查>>九、反射>>1、生理反射>>浅反射>>腹壁反射>>右>>下","","专科检查>>九、反射>>1、生理反射>>浅反射>>腹壁反射>>左>>上"
				,"专科检查>>九、反射>>1、生理反射>>浅反射>>腹壁反射>>左>>中","专科检查>>九、反射>>1、生理反射>>浅反射>>腹壁反射>>左>>下","","专科检查>>九、反射>>1、生理反射>>浅反射>>提睾反射>>左","专科检查>>九、反射>>1、生理反射>>浅反射>>提睾反射>>右","","专科检查>>九、反射>>1、生理反射>>浅反射>>肛门反射>>左","专科检查>>九、反射>>1、生理反射>>浅反射>>肛门反射>>右"}
				,new string[]{"\n九、反射","\n  1、生理反射:(阵挛++++、亢进+++、正常++、减弱+、消失-)：","\n  浅反射：","腹壁反射：","右：","上：","中：","下：","左：","上：","中：","下：","\n  提睾反射：","左：","右：","肛门反射：","左：","右："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","专科检查>>九、反射>>1、生理反射>>深反射>>肱二头肌反射>>右侧","专科检查>>九、反射>>1、生理反射>>深反射>>肱二头肌反射>>左侧","","专科检查>>九、反射>>1、生理反射>>深反射>>肱三头肌反射>>右侧","专科检查>>九、反射>>1、生理反射>>深反射>>肱三头肌反射>>左侧","","专科检查>>九、反射>>1、生理反射>>深反射>>桡反射>>右侧"
				,"专科检查>>九、反射>>1、生理反射>>深反射>>反射>>左侧","","专科检查>>九、反射>>1、生理反射>>深反射>>膝反射>>右侧","专科检查>>九、反射>>1、生理反射>>深反射>>膝反射>>左侧","","专科检查>>九、反射>>1、生理反射>>深反射>>踝反射>>右侧","专科检查>>九、反射>>1、生理反射>>深反射>>反射>>左侧","","专科检查>>九、反射>>1、生理反射>>深反射>>阵挛>>踝右侧"
				,"专科检查>>九、反射>>1、生理反射>>深反射>>阵挛>>踝左侧","专科检查>>九、反射>>1、生理反射>>深反射>>阵挛>>髌右侧","专科检查>>九、反射>>1、生理反射>>深反射>>阵挛>>髌左侧"}
				,new string[]{"\n  深反射：","肱二头肌反射：","右侧：","左侧：","肱三头肌反射：","右侧：","左侧：","桡反射：","右侧：","左侧：","膝反射：","右侧：","左侧：","踝反射：","右侧：","左侧：","阵挛：","踝右侧：","左侧：","髌右侧：","左侧："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>九、反射>>2、病理反射>>吸吮反射","","专科检查>>九、反射>>2、病理反射>>掌心下颌反射>>右侧","专科检查>>九、反射>>2、病理反射>>掌心下颌反射>>左侧","","专科检查>>九、反射>>2、病理反射>>Hoffmann sign>>右侧","专科检查>>九、反射>>2、病理反射>>Hoffmann sign>>左侧"
				,"","专科检查>>九、反射>>2、病理反射>>Rossolimo sign>>右侧","专科检查>>九、反射>>2、病理反射>>Rossolimo sign>>左侧","","专科检查>>九、反射>>2、病理反射>>Babinski sign>>右侧","专科检查>>九、反射>>2、病理反射>>Babinski sign>>左侧","","专科检查>>九、反射>>2、病理反射>>Chaddock sign>>右侧","专科检查>>九、反射>>2、病理反射>>Chaddock sign>>左侧"
				,"","专科检查>>九、反射>>2、病理反射>>Oppenheim sign>>右侧","专科检查>>九、反射>>2、病理反射>>Oppenheim sign>>左侧","","专科检查>>九、反射>>2、病理反射>>Gordon sign>>右侧","专科检查>>九、反射>>2、病理反射>>Gordon sign>>左侧"}
				,new string[]{"\n  2、病理反射：","吸吮反射：","掌心下颌反射：","右侧：","左侧：","Hoffmann sign：","右侧：","左侧：","Rossolimo sign：","右侧：","左侧：","Babinski sign：","右侧：","左侧：","Chaddock sign：","右侧：","左侧：","Oppenheim sign：","右侧：","左侧：","Gordon sign：","右侧：","左侧："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>十、植物神经功能>>异常出汗","专科检查>>十、植物神经功能>>大便功能","专科检查>>十、植物神经功能>>小便功能"},new string[]{"\n十、植物神经功能","\n  异常出汗：","大便功能：","小便功能"});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>十一、脑膜刺激征>>颈抵抗","专科检查>>十一、脑膜刺激征>>下颌距胸骨","专科检查>>十一、脑膜刺激征>>横指","专科检查>>十一、脑膜刺激征>>Kering sign","专科检查>>十一、脑膜刺激征>>Brudzinskin sign"}
				,new string[]{"\n十一、脑膜刺激征","\n  颈抵抗：","下颌距胸骨：","横指：","Kering sign：","Brudzinskin sign："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","","专科检查>>十二、功能状态>>分离运动>>左上肢","专科检查>>十二、功能状态>>分离运动>>左下肢","专科检查>>十二、功能状态>>分离运动>>右上肢","专科检查>>十二、功能状态>>分离运动>>右下肢"},new string[]{"\n十二、功能状态","\n  分离运动：","左上肢：","左下肢：","右上肢：","右下肢："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>十二、功能状态>>共同运动>>左上肢","专科检查>>十二、功能状态>>共同运动>>左下肢","专科检查>>十二、功能状态>>共同运动>>右上肢","专科检查>>十二、功能状态>>共同运动>>右下肢"},new string[]{"\n  共同运动：","左上肢：","左下肢：","右上肢：","右下肢："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>十二、功能状态>>翻身>>向左侧翻","专科检查>>十二、功能状态>>翻身>>向右侧翻"},new string[]{"\n  翻身：","向左侧翻：","向右侧翻："});
			
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>十二、功能状态>>卧坐转移>>卧 → 坐","专科检查>>十二、功能状态>>卧坐转移>>坐 → 卧","专科检查>>十二、功能状态>>坐位平衡"},new string[]{"\n  卧坐转移：","卧 → 坐：","坐 → 卧：","坐位平衡："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>十二、功能状态>>坐站转移>>坐 → 站","专科检查>>十二、功能状态>>坐站转移>>站 → 坐","专科检查>>十二、功能状态>>站位平衡"},new string[]{"\n  坐站转移：","坐 → 站：","站 → 坐：","站位平衡："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>十二、功能状态>>步行>>轮椅操作","专科检查>>十二、功能状态>>步行>>平地行走","专科检查>>十二、功能状态>>步行>>上下楼梯","专科检查>>十二、功能状态>>步行>>借助器具","专科检查>>十二、功能状态>>步态"}
				,new string[]{"\n  步行：","轮椅操作：","平地行走：","上下楼梯：","借助器具：","步态："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"专科检查>>十二、功能状态>>关节活动度","专科检查>>十二、功能状态>>关节疼痛"},new string[]{"\n  关节活动度：","关节疼痛："});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"","专科检查>>十二、功能状态>>日常生活>>进食","专科检查>>十二、功能状态>>日常生活>>梳头","专科检查>>十二、功能状态>>日常生活>>洗脸","专科检查>>十二、功能状态>>日常生活>>刷牙","专科检查>>十二、功能状态>>日常生活>>漱口","专科检查>>十二、功能状态>>日常生活>>穿上衣","专科检查>>十二、功能状态>>日常生活>>穿裤子"
				,"专科检查>>十二、功能状态>>日常生活>>穿鞋","专科检查>>十二、功能状态>>日常生活>>如厕转移","专科检查>>十二、功能状态>>日常生活>>如厕清洁","专科检查>>十二、功能状态>>日常生活>>洗澡"}
				,new string[]{"\n  日常生活：","进食：","梳头：","洗脸：","刷牙：","漱口：","穿上衣：","穿裤子：","穿鞋：","如厕转移：","如厕清洁：","洗澡："});
			#endregion

			#region 辅助检查 & 康复治疗计划
			m_objPrintMultiItemArr[2].m_mthSetSpecialTitleValue("辅 助 检 查");
			m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[]{"辅助检查>>1、实验室检查","辅助检查>>2、CT或MR检查","辅助检查>>3、X线检查","辅助检查>>4、其他检查"},new string[]{"\n  实验室检查：","\n  CT或MR检查：","\n  X线检查：","\n  其他检查："});

			m_objPrintMultiItemArr[3].m_mthSetSpecialTitleValue("康复治疗计划");
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[]{"","康复治疗计划>>一、存在问题>>1、认知、语言障碍","康复治疗计划>>一、存在问题>>2、运动障碍","康复治疗计划>>一、存在问题>>3、感觉障碍","康复治疗计划>>一、存在问题>>4、关节疼痛及ROM异常","康复治疗计划>>一、存在问题>>5、ADL障碍","康复治疗计划>>一、存在问题>>6、大小便障碍","康复治疗计划>>一、存在问题>>7、其他"}
				,new string[]{"\n一、存在问题：","\n  1、认知、语言障碍：","\n  2、运动障碍：","\n  3、感觉障碍：","\n  4、关节疼痛及ROM异常：","\n  5、ADL 障碍：","\n  6、大小便障碍：","\n  7、其他："});
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[]{"","康复治疗计划>>二、治疗计划"},new string[]{"\n二、治疗计划：\n    ",""});
			#endregion

			#region 签名和日期
			m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[]{"住院医师","主治医师","日期"},new string[]{"住院医师：","主治医师：","日期："});
			m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[]{"康复治疗计划>>医师","康复治疗计划>>时间"},new string[]{"医师：","日期："});
			#endregion

		}


		#region Print Class

		/// <summary>
		/// 项目打印
		/// </summary>
		private class clsPrintInPatMedRecItem : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string m_strSpecialTitle = "";
			private string m_strTitle = "";
			private string m_strText = "";
			private string m_strTextXml = "";
			private bool m_blnNoContent = false;
			private bool m_blnNoPrint = true;
			private clsInpatMedRec_Item m_objItemContent = null;

			public clsPrintInPatMedRecItem()
			{}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnNoContent == true && m_blnNoPrint == true)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					if(m_strTitle != "")
					{
						p_objGrp.DrawString(m_strTitle,p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
						p_intPosY += 20;
						m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent==null ? "" : m_objItemContent.m_strItemContent)  ,(m_objItemContent==null ? "<root />" : m_objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,m_objItemContent != null);
						m_mthAddSign2(m_strTitle,m_objPrintContext.m_ObjModifyUserArr);
					}
					else
					{
						if(m_strSpecialTitle != "")
						{
							p_intPosY += 20;
							p_objGrp.DrawString(m_strSpecialTitle,clsIMR_HerbalismPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+300,p_intPosY);
							p_intPosY += 40;
						}
						m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText ,m_strTextXml,m_dtmFirstPrintTime,m_blnNoPrint == false);
						m_mthAddSign2(m_strSpecialTitle,m_objPrintContext.m_ObjModifyUserArr);
					}

					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					if(m_strTitle != "")
						m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					else
						m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
					p_intPosY += 20;

					intLine++;
				}			

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

				m_blnIsFirstPrint = true;
			}
			/// <summary>
			/// 设置多项打印内容
			/// </summary>
			/// <param name="p_strKeyArr">打印内容的哈希键数组</param>
			/// <param name="p_strTitleArr">小标题数组(即对应于窗体Lable但不存储于数据库的需打印的内容)</param>
			public void m_mthSetPrintValue(string[] p_strKeyArr,string[] p_strTitleArr)
			{
				if(p_strKeyArr == null || p_strTitleArr == null || p_strKeyArr.Length != p_strTitleArr.Length)
				{
					m_blnNoContent = true;
					return;
				}
				m_blnNoPrint = false;
				if(m_blnHavePrintInfo(p_strKeyArr) == true)
					m_mthMakeText(p_strTitleArr,p_strKeyArr,ref m_strText,ref m_strTextXml);
			}
			/// <summary>
			/// 设置单项打印内容
			/// </summary>
			/// <param name="p_strKey">哈希键</param>
			/// <param name="p_strTitle">小标题</param>
			public void m_mthSetPrintValue(string p_strKey,string p_strTitle)
			{
				if(m_hasItems != null && p_strKey != null)
					if(m_hasItems.Contains(p_strKey))
						m_objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
				m_strTitle = p_strTitle;
			}
			/// <summary>
			/// 设置大标题如“体格检查”
			/// </summary>
			/// <param name="p_strTitle"></param>
			public void m_mthSetSpecialTitleValue(string p_strTitle)
			{
				m_strSpecialTitle = p_strTitle;
			}

		}

		/// <summary>
		/// 签名和日期
		/// </summary>
		private class clsPrintInPatMedRecSign : clsIMR_PrintLineBase
		{
			private clsInpatMedRec_Item[] objSignContent = null;
			private string[] m_strTitleArr = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(objSignContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				p_intPosY += 40;
				for(int i=0; i<objSignContent.Length; i++)
				{
					if(m_strTitleArr[i].IndexOf("日期") < 0)
					{
						p_objGrp.DrawString(m_strTitleArr[i]+(objSignContent[i]==null ? "" : objSignContent[i].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
						p_intPosY += 20;
					}
					else
					{
						p_objGrp.DrawString(m_strTitleArr[i]+ (objSignContent[i] == null ? "" :DateTime.Parse( objSignContent[i].m_strItemContent).ToString("yyyy年MM月dd日")),p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
						p_intPosY += 20;
					}
				}
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			}
			/// <summary>
			/// 设置签名和日期值
			/// </summary>
			/// <param name="p_strkeyArr">值</param>
			/// <param name="p_strTitleArr">标题</param>
			public void m_mthSetPrintSignValue(string[] p_strkeyArr,string[] p_strTitleArr)
			{
				if(p_strkeyArr == null || p_strTitleArr == null || p_strkeyArr.Length != p_strTitleArr.Length)
					return;
				objSignContent = m_objGetContentFromItemArr(p_strkeyArr);
				m_strTitleArr = p_strTitleArr;
			}

		}

		#endregion

	}
}
