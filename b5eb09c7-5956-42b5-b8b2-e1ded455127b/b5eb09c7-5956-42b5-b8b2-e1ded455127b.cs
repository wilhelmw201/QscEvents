//本文件填写竹屋事件 相枢2(Clone)事件执行周期内相关阶段函数
//【记得经常使用 Ctrl+S 保存修改，只有保存以后才能在编辑事件时生效】
//可引用变量 ArgBox - 该事件从上层事件继承的参数盒子

// 在此区域填写自定义的using指令
// 注意：一般事件制作不需要填写; 在你明确知道每个using指令的意义和有明确使用需求的情况下再填写此指令集
#region CustomUsings
using System;
using System.Collections.Generic;
using Config.EventConfig;
using GameData.Domains.Combat;
using GameData.Domains.TaiwuEvent.EventHelper;
using Qsc;
#endregion

#if IN_IDE
public class Event_b5eb09c7595642b5b8b2e1ded455127b : TaiwuEventItem
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

        int combatResult = CombatResultType.EnemyWin;
        if (ArgBox.Get("CombatResult", ref combatResult))
        {

            if (combatResult == CombatResultType.EnemyDie || combatResult == CombatResultType.PlayerWin || combatResult == CombatResultType.EnemyFlee)
            {
                //TODO 己方胜利
                EventHelper.ToEvent("6a569bdf-afd5-469c-a2c0-e8bc46d7da35");
            }
            else if (combatResult == CombatResultType.EnemyWin || combatResult == CombatResultType.PlayerDie)
            {
                //TODO 敌方胜利
                EventHelper.ToEvent("");
                EventHelper.TriggerLegacyPassingEvent(true);
            }
            else if (combatResult == CombatResultType.PlayerFlee)
            {
                //TODO 玩家逃跑，理论上按逃脱处置。。。
                EventHelper.ToEvent("09325d31-b0e9-405c-91fc-f09f21619a65");
            }
            else
            {
                throw new ArgumentException("未知的战斗结果：" + combatResult);
            }

            return;

        }
        else
        {
            throw new ArgumentException("战斗结果获取失败");
        }
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