//本文件填写0Dummy(Clone)事件执行周期内相关阶段函数
//【记得经常使用 Ctrl+S 保存修改，只有保存以后才能在编辑事件时生效】
//可引用变量 ArgBox - 该事件从上层事件继承的参数盒子

// 在此区域填写自定义的using指令
// 注意：一般事件制作不需要填写; 在你明确知道每个using指令的意义和有明确使用需求的情况下再填写此指令集
#region CustomUsings
using System.Collections.Generic;
using System.Diagnostics;
using Config.EventConfig;
using Qsc;
#endregion

#if IN_IDE
public class Event_085fba802c0b4590ade42675fa4da780 : TaiwuEventItem
{
#endif

    /// <summary>
    /// 该事件监听的触发点被触发后，该接口检测事件是否满足执行条件，如果不满足则不执行该事件
    /// </summary>
    /// <returns>true - 可以执行 false - 忽略触发不执行</returns>
    public override bool OnCheckEventCondition()
    {
        //TODO
        return true;
    }
    
    /// <summary>
    /// 该事件被触发且满足执行条件，事件显示前调用
    /// 一般用于向参数盒子中准备事件链需要用到的参数
    /// </summary>
    public override void OnEventEnter()
    {
        //TODO
    }
    
    /// <summary>
    /// 该事件执行完毕，即将退出该事件时调用
    /// 一般用于从参数盒子中移除事件链中不需要用到的参数，或记录事件触发月份，确保后续触发几率计算
    /// </summary>
    public override void OnEventExit()
    {
        //TODO
    }
    
    /// <summary>
    /// 该事件即将显示前调用,获取被替换占位符后的事件显示内容
    /// 如果事件文本预设满足系统默认的占位符替换方案，则可以不填写此接口
    /// </summary>
    public override string GetReplacedContentString()
    {
        //TODO
        return string.Empty;
    }
    
    /// <summary>
    /// 获取额外格式化使用的多语言字段
    /// </summary>
    /// <returns></returns>
    public override List<string> GetExtraFormatLanguageKeys()
    {
        List<string> result = new List<string> { };
        int bossID = QscCoreUtils.GetNextBoss(this.TaiwuEvent);
        switch (bossID)
        {
            case 0:
                result.Add("莺歌燕舞，温暖如春");
                break;
            case 1:
                result.Add("草木不生，一片萧杀");
                break;
            case 2:
                result.Add("冰雪遍地，奇冷无比");
                break;
            case 3:
                result.Add("金光闪烁，灼人眼目");
                break;
            case 4:
                result.Add("异火燎烧，似有还无");
                break;
            case 5:
                result.Add("蛟蛇盘绕，隐有龙吟");
                break;
            case 6:
                result.Add("流光溢彩，幻化不定");
                break;
            case 7:
                result.Add("遍生枫木，鲜红似血");
                break;
            case 8:
                result.Add("霞光万丈，难分昼夜");
                break;
            case 100:
                result.Add("[不知道，等龙语获文案]");
                break;
            case 101:
                result.Add("[不知道，等紫无绡文案]");
                break;
        }
            
    }

#if IN_IDE
}
#endif