//本文件填写0Dummy(Clone)事件执行周期内相关阶段函数
//【记得经常使用 Ctrl+S 保存修改，只有保存以后才能在编辑事件时生效】
//可引用变量 ArgBox - 该事件从上层事件继承的参数盒子

// 在此区域填写自定义的using指令
// 注意：一般事件制作不需要填写; 在你明确知道每个using指令的意义和有明确使用需求的情况下再填写此指令集
#region CustomUsings
using System;
using System.Collections.Generic;
using Config.EventConfig;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Adventure;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Utilities;
using Qsc;
#endregion

#if IN_IDE
public class Event_55c526340bfe4bfa901ca835fd2208c7 : TaiwuEventItem
{
#endif

    /// <summary>
    /// 该事件监听的触发点被触发后，该接口检测事件是否满足执行条件，如果不满足则不执行该事件
    /// </summary>
    /// <returns>true - 可以执行 false - 忽略触发不执行</returns>
    public override bool OnCheckEventCondition()
    {
        if (QscCoreUtils.GetWorldState(this.TaiwuEvent) >= 1000) return false;
        // 在这里看煎饼
        bool HasFuyu = EventHelper.IsTaiwuHasItem(12, 210);
        if (!HasFuyu) return false;
        var Taiwu = DomainManager.Taiwu.GetTaiwu();
        var TWLocation = Taiwu.GetLocation();
        short AreaId = TWLocation.AreaId;
        short BlockId = TWLocation.BlockId;
        var BlockData = EventHelper.GetMapBlockData(AreaId, BlockId);
        var blockType = BlockData.BlockSubType;
        if (blockType < EMapBlockSubType.Farmland || blockType > EMapBlockSubType.Block) return true;
        if (BlockData.Destroyed) return false;
        if (QscCoreUtils.GetQscSubProgress(this.TaiwuEvent) >= 1000) return false; 
        return true;
    }
    
    /// <summary>
    /// 该事件被触发且满足执行条件，事件显示前调用
    /// 一般用于向参数盒子中准备事件链需要用到的参数
    /// </summary>
    public override void OnEventEnter()
    {
        var Taiwu = DomainManager.Taiwu.GetTaiwu();
        // TODO 如果不在谷中设定世界进度

        // 否则初始化进度（现在已经有煎饼了）
        if (QscCoreUtils.GetWorldState(this.TaiwuEvent ) < 0)
        {
            // 清理深谷出口事件
            QscCoreUtils.SetQscProgress(this.TaiwuEvent, 100);
            QscCoreUtils.SetQscSubProgress(this.TaiwuEvent, 0);
            AdaptableLog.Info("Attempt to remove exit...");
            AreaAdventureData adventuresInArea = DomainManager.Adventure.GetAdventuresInArea(0);
            short id = -1;
            AdventureSiteData val = null;
            foreach (var site in adventuresInArea.AdventureSites)
            {
                AdaptableLog.Info($"{site.Key}:{site.Value}");

                if (site.Value.TemplateId == 103)
                {
                    id = site.Key;
                    val = site.Value;
                }
            } 
            if (val != null)
            {
                AdaptableLog.Info("Success @ " + id);
                EventHelper.RemoveAdventureSite(0, id, false, false);
            }
            // 进入提示
            EventHelper.ToEvent("8c069855-3b07-4bc4-90e5-c2c853a62e55");

            return;
        }

        //
        var TWLocation = Taiwu.GetLocation();
        short AreaId = TWLocation.AreaId;
        short BlockId = TWLocation.BlockId;
        var BlockData = EventHelper.GetMapBlockData(AreaId, BlockId);
        var blockType = BlockData.BlockSubType;
        // 检查是不是竹庐
        if (blockType < EMapBlockSubType.Farmland || blockType > EMapBlockSubType.Block)
        {
            // 跳到竹庐事件
            EventHelper.ToEvent("085fba80-2c0b-4590-ade4-2675fa4da780");
            return;
        }
        // 如果没有地块了，结束
        if (QscCoreUtils.GetQscSubProgress(this.TaiwuEvent) >= 100)
        {
            QscCoreUtils.SetQscSubProgress(this.TaiwuEvent, 1001);
            EventHelper.ToEvent("a81b1116-d385-41fa-bf6f-3494e74d8dda");
            return;
        }
        // 按照地块类型，毁坏该地块并跳转
        BlockData.Destroyed = true;
        BlockData.CurrResources = new MaterialResources();
        DomainManager.Map.SetBlockData(DataContextManager.GetCurrentThreadDataContext(), BlockData);
        var EventTbl = QscEvents.GetEventTblFromBlock(blockType);
        QscCoreUtils.IncreaseQscSubProgress(this.TaiwuEvent);

       // AdaptableLog.Info($"Choose EventTbl:{EventTbl}");

        var Entry = EventTbl.Draw(this.TaiwuEvent);
        var EntryEvent = Entry.EntryEvent();
        QscCoreUtils.EventList.Add(EntryEvent);
        EventHelper.ToEvent(EntryEvent.Entry());


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