//本文件填写SimpleLootGenEvent_0Entry(Clone)事件执行周期内相关阶段函数
//【记得经常使用 Ctrl+S 保存修改，只有保存以后才能在编辑事件时生效】
//可引用变量 ArgBox - 该事件从上层事件继承的参数盒子

// 在此区域填写自定义的using指令
// 注意：一般事件制作不需要填写; 在你明确知道每个using指令的意义和有明确使用需求的情况下再填写此指令集
#region CustomUsings
using System.Collections.Generic;
using Config.EventConfig;
using GameData.DomainEvents;
using Qsc;
using System.Linq;
using System;
using Config;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Utilities;
using System.Reflection.Metadata.Ecma335;
#endregion

#if IN_IDE
public class Event_84c4968edb08418dbc190141ddd41d62 : TaiwuEventItem
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
        EditorSimpleSkillGenEvent Event = (EditorSimpleSkillGenEvent)QscCoreUtils.EventList.Last();
        List<short> SkillsI = new List<short> { };

        var worldState = QscCoreUtils.GetWorldState(this.TaiwuEvent);
        AdaptableLog.Info($"got Event with {Event.qualityBonus.Length}({Event.allowedTypes.Length}) requests => pick {Event.count}");
        for (int i = 0; i < Event.qualityBonus.Length; i++)
        {

            int qualityModifier = Event.qualityBonus[i];
            int baseChancesIdx = Math.Clamp(worldState + qualityModifier / 100, 0, 8);
            int otherChancesIdx = baseChancesIdx;
            int mixmod = Math.Abs(qualityModifier) % 100;
            if (qualityModifier > 0 && baseChancesIdx != 8)
            {
                otherChancesIdx = baseChancesIdx + 1;
            }
            else if (qualityModifier < 0 && baseChancesIdx != 0)
            {
                otherChancesIdx = baseChancesIdx - 1;
            }
            GradeTable TmpTable = new GradeTable(QscData.GenWeights[baseChancesIdx], 100 - mixmod, QscData.GenWeights[otherChancesIdx], mixmod);


            int grade = TmpTable.Draw(this.TaiwuEvent);
            List<short> Skills = QscLootGenerator.GenerateRandomGongFa(this.TaiwuEvent, Event.allowedTypes[i], grade, 1);

            SkillsI = SkillsI.Concat(Skills).ToList();

            
        }

        List<bool> isGongFa = Enumerable.Repeat(true, SkillsI.Count).ToList();
        AdaptableLog.Info("EditorSkillPickEvent: generated" + SkillsI.Count);
        QscCoreUtils.CallEvent(new EditorSimpleSkillPickEvent(
            SkillsI.Select((a) => { return (int)a; }).ToList(), 
            isGongFa,  Event.count, Event.gold), "cb9862f4-a382-4061-bbfc-bd61e01a8ead");
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
        return default;
    }

#if IN_IDE
}
#endif