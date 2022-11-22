//本文件填写竹屋事件 事件执行周期内相关阶段函数
//【记得经常使用 Ctrl+S 保存修改，只有保存以后才能在编辑事件时生效】
//可引用变量 ArgBox - 该事件从上层事件继承的参数盒子

// 在此区域填写自定义的using指令
// 注意：一般事件制作不需要填写; 在你明确知道每个using指令的意义和有明确使用需求的情况下再填写此指令集
#region CustomUsings
using System.Collections.Generic;
using Config.EventConfig;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Utilities;
using Qsc;

#endregion

#if IN_IDE
public class Event_cec4ff38184f482eaffa37dce10e30e1 : TaiwuEventItem
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
        int bossid = -1;
        

        Qsc.XiangShuType Boss = QscCoreUtils.GetNextBoss(this.TaiwuEvent);
        AdaptableLog.Info($"WorldState{QscCoreUtils.GetWorldState(this.TaiwuEvent)}, next boss is {Boss}");

        if (Boss == XiangShuType.ZiWuXiao)
        {
            bossid = Config.Character.DefKey.ZiWuxiao;
        }
        else if (Boss == XiangShuType.LongYuFu)
        {
            bossid = Config.Character.DefKey.LongYufu;
        }
        else if (Boss == XiangShuType.HuanXin)
        {
            bossid = Config.Character.DefKey.HuanxinIllusion;
        }
        else if (Boss == XiangShuType.RanChenZi)
        {
            bossid = Config.Character.DefKey.AntagonistRanchenzi;
        }
        else
        {
            int world = QscCoreUtils.GetWorldState(this.TaiwuEvent);
            int baseid = -1;
            if (world == 0)
            {
                baseid = Config.Character.DefKey.WeakenedMonv0;
            }
            else if (world == 1)
            {
                baseid = Config.Character.DefKey.WeakenedMonv1;
            }
            else
            {
                baseid = Config.Character.DefKey.Monv0 + world;
            }
            bossid = baseid + 9*(int)Boss;
        }

        AdaptableLog.Info($"Creating Xiangshu: {bossid}");
        var BossChar = EventHelper.CreateNonIntelligentCharacter((short)bossid);
        ArgBox.Set("Xiangshu", BossChar);
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
        Qsc.XiangShuType Boss = QscCoreUtils.GetNextBoss(this.TaiwuEvent);
        switch (Boss)
        {
            case XiangShuType.MoNv:
                return "你遭遇了莫女！\n“那剑我已舍身取回，你为何还不来拿？\n你定是仍在怪我鲁莽，也罢，我便用那剑将你杀了吧……”\n莫女幽幽地念道，话音未落，突然直扑向太吾！  ";
            case XiangShuType.DaYueYaoChang:
                return "你遭遇了大岳瑶常！\n“青天厚土，朗朗乾坤，何以会有这许多杀不尽、除不完的邪物？\n你又是何方妖怪！？是了，任你是佛是魔……尽皆当斩，当斩……”\n大岳瑶常说完，突然一声大喝，径直向太吾袭来！ ";
            case XiangShuType.ShuFang:
                return "你遭遇了术方！\n“通天彻地化万灵，句句天机字字金，赠尔玄玄两三言，爱惜性命何必听？\n尔若依言奉我令，我亦破肚献真心，区区天规何足忌，茫茫人世莫虚行！”\n术方唱完，哈哈大笑，突然抽出长剑向太吾疾刺而来！ ";
            case XiangShuType.XueFeng:
                return "你遭遇了血枫！\n“呜……吾还能再战！再战！”\n血枫面带凶狂之气，一见到太吾，便向其袭来！ ";
            case XiangShuType.YiXiang:
                return "你遭遇了以向！\n“玉活，玉活，溶去息壤凝作魂，\n玉活，玉活，如是孩童初见人，\n玉活，玉活，羞与人望常常隐……\n哎呀，玉不见啦！可是你偷走了我的活玉？”\n以向唱罢，两眼直勾勾地盯着太吾看，似乎便是太吾偷走了他的“活玉”……  ";
            case XiangShuType.WeiQi:
                return "你遭遇了卫起！\n“师父一直教导我：‘欲成大道，舍身取义’！\n我连命都舍了，可大道何在！？舍命难道及不上‘舍身’吗？！这是何故？你道这是何故？”\n卫起一边胡言乱语，一边目露凶光地向太吾步步逼近……";
            case XiangShuType.YiYiHou:
                return "你遭遇了衣以候！\n“你可知丑狐去了哪里？是飞上了天宫？是坠落了黄泉？\n你不必答我，你们都想欺骗于我，唯有我那丑狐……”\n衣以候越说越悲怆，突然衣衫燃起无明异火，飞身向太吾袭来！";
            case XiangShuType.JinHuangEr:
                return "你遭遇了金凰儿！\n“我问你啊，方今之世，可有圣人吗？\n我等不到圣人，唯有出来寻找，且让我试试你可有圣人之才如何？”\n金凰儿嘻笑着对你说，不料话音未落，已拔刀向太吾劈来！ ";
            case XiangShuType.JiuHan:
                return "你遭遇了九寒！\n “洪水将至，你们却不去避祸……\n我欲救你们性命，你们反倒怕我多过于怕洪水，连我的面也不想看到……唉……”\n九寒悲伤的说着，忽然一个转身，犹如化作了一阵刺骨的寒风迎面向太吾袭来！ ";
            case XiangShuType.LongYuFu:
                return "你遭遇了龙语fu！\n【文案待定】";
            case XiangShuType.ZiWuXiao:
                return "你遭遇了紫无绡！\n【文案待定】";
            case XiangShuType.HuanXin:
                return "你遭遇了焕心！\n【文案待定】";
            case XiangShuType.RanChenZi:
                return "你遭遇了染尘子！\n【文案待定】";
            default:
                return "???";
        }
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