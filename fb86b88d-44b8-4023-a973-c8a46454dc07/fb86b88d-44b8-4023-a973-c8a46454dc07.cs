//本文件填写迎战dummy(Clone)事件执行周期内相关阶段函数
//【记得经常使用 Ctrl+S 保存修改，只有保存以后才能在编辑事件时生效】
//可引用变量 ArgBox - 该事件从上层事件继承的参数盒子

// 在此区域填写自定义的using指令
// 注意：一般事件制作不需要填写; 在你明确知道每个using指令的意义和有明确使用需求的情况下再填写此指令集
#region CustomUsings
using System.Collections.Generic;
using System.Linq;
using Config.EventConfig;
using GameData.Domains.Character;
using GameData.Domains.TaiwuEvent.EventHelper;
using Qsc;
using System;
#endregion CustomUsings

#if IN_IDE
public class Event_fb86b88d44b84023a973c8a46454dc07 : TaiwuEventItem
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
        
        BaseEditorEvent ev = QscCoreUtils.EventList.Last();
        if (!(ev is EditorBattleEvent))
        {
            throw new System.InvalidOperationException("Popped incorrect item from event stack, got" + ev.GetType());
        }
        EditorBattleEvent Event = (EditorBattleEvent) ev;
        int enemyId;
        if (Event.EnemyId < 0)
        {
            enemyId = QscEnemyUtils.CreateFittingEnemy(this.TaiwuEvent);
            var enemy = EventHelper.GetCharacterById(enemyId);
            sbyte consuShould = (sbyte)(QscCoreUtils.GetWorldState(this.TaiwuEvent) * 2);
            if (consuShould > 18)
            {
                consuShould = 18;
            }
            if (enemy.GetConsummateLevel() < consuShould)
            {
                enemy.SetConsummateLevel(consuShould, GameData.Domains.DomainManager.TaiwuEvent.MainThreadDataContext);

            }

        }
        else
        {
            enemyId = EventHelper.CreateNonIntelligentCharacter((short)Event.EnemyId);
        }
        EventHelper.Log("fb86b88d-44b8-4023-a973-c8a46454dc07 Enemy=" + enemyId);

        ArgBox.Set("BattleEventEnemy", enemyId);
        
    }
    
    /// <summary>
    /// 该事件执行完毕，即将退出该事件时调用
    /// 一般用于从参数盒子中移除事件链中不需要用到的参数，或记录事件触发月份，确保后续触发几率计算
    /// </summary>
    public override void OnEventExit()
    {
        // not called here since event not over yet..


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