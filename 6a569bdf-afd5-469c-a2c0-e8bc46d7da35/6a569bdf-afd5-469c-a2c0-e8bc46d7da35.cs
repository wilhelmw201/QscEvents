//本文件填写竹屋事件 相枢3跳转(Clone)事件执行周期内相关阶段函数
//【记得经常使用 Ctrl+S 保存修改，只有保存以后才能在编辑事件时生效】
//可引用变量 ArgBox - 该事件从上层事件继承的参数盒子

// 在此区域填写自定义的using指令
// 注意：一般事件制作不需要填写; 在你明确知道每个using指令的意义和有明确使用需求的情况下再填写此指令集
#region CustomUsings
using System.Collections.Generic;
using Config.EventConfig;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using Qsc;
#endregion

#if IN_IDE
public class Event_6a569bdfafd5469ca2c0e8bc46d7da35 : TaiwuEventItem
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
        // 移除伤病
        var taiwu = DomainManager.Taiwu.GetTaiwu();
        var injuries = new GameData.Domains.Character.Injuries();
        injuries.Initialize();
        taiwu.SetInjuries(injuries, DataContextManager.GetCurrentThreadDataContext());
        var poison = new PoisonInts();
        poison.Initialize();
        taiwu.SetPoisoned(ref poison, DataContextManager.GetCurrentThreadDataContext());

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
        switch (QscCoreUtils.GetNextBoss(this.TaiwuEvent))
        {
            case XiangShuType.MoNv:
                return "<Character key=RoleTaiwu str=Name/>战胜了莫女！\n正当莫女伏倒在地之时，一只麻雀突然落在她的耳边，叽喳轻语起来，\n“原来，已送到了吗……”莫女似乎听懂了麻雀的话语，终于面露微笑，轻叹一声，化作一缕青烟消失在了天际…… ";
            case XiangShuType.DaYueYaoChang:
                return "<Character key=RoleTaiwu str=Name/>战胜了大岳瑶常！\n大岳瑶常虽败不倒，只是半跪于地，望着天空出神，\n半晌之后，大岳瑶常忽然向太吾问道：“世间还有几只妖魔？”\n太吾难以作答，只得摇头，待太吾定睛再看，大岳瑶常却已化为了一尊石像…… ";
            case XiangShuType.ShuFang:
                return "<Character key=RoleTaiwu str=Name/>战胜了术方！\n术方翻身跃起，点了点头，又以手中的令牌指了指天，再指了指地，最后向太吾一揖到地！\r\n太吾尚不知道术方究竟是何用意，她已乘云而起，飘然而去了…… ";
            case XiangShuType.XueFeng:
                return "<Character key=RoleTaiwu str=Name/>战胜了血枫！\n血枫虽然身受重伤，仍张牙舞爪，矗立不倒，眼看又要向太吾扑来！\r\n但是，当太吾准备好二度迎敌时，血枫的身形却忽然凝固，\r\n原来早已气绝多时，很快化作数段枫木散落了一地…… ";
            case XiangShuType.YiXiang:
                return "<Character key=RoleTaiwu str=Name/>战胜了以向！\n“玉死，玉死，息壤作魂不是魂，\r\n玉死，玉死，孩童终要见大人，\r\n玉死，玉死，哎哟……技不如人无处隐……”\r\n以向边唱边叹，待到歌声一止，他终于散落成了无数玉珠，纷纷遁入了地底……  ";
            case XiangShuType.WeiQi:
                return "<Character key=RoleTaiwu str=Name/>战胜了卫起！\n卫起仰天而倒，重重地摔在了污泥当中，“是了……师父说的舍身取义……我好像懂了……”\r\n卫起边消融在污泥中边说道：“断命求义非真义，入得污泥方成道……”";
            case XiangShuType.YiYiHou:
                return "<Character key=RoleTaiwu str=Name/>战胜了衣以候！\n太吾虽与衣以候生死相拼，但待她败下阵来，太吾却莫名的怜惜起她……\r\n“便是这个眼神……与我那丑狐一模一样……”\r\n衣以候笑中带泪，话音未落，已化成了片片桃花，随风而去…… ";
            case XiangShuType.JinHuangEr:
                return "<Character key=RoleTaiwu str=Name/>战胜了金凰儿！\n金凰儿虽身受重伤，却仍嘻嘻而笑：“不错，便是你啦！”\r\n她说着，盛了一碗金黄的美酒递来给太吾，太吾不由自主的想要去接，\r\n哪知一眨眼，眼前便什么也没有了…… ";
            case XiangShuType.JiuHan:
                return "<Character key=RoleTaiwu str=Name/>战胜了九寒！\n无数冰雪自九寒的身躯之中飞散出来，一时之间，天地如入冰宫！\r\n你透过冰雪，仿佛看到漫天的雪花化作了一位温柔的雪女，\r\n轻轻拉起九寒的手，带着他消失在了风雪之中…… ";
            case XiangShuType.LongYuFu:
                return "<Character key=RoleTaiwu str=Name/>战胜了龙语获！\n【文案待定】";
            case XiangShuType.ZiWuXiao:
                return "<Character key=RoleTaiwu str=Name/>战胜了紫无绡！\n【文案待定】";
            case XiangShuType.HuanXin:
                return "<Character key=RoleTaiwu str=Name/>战胜了焕心！\n 恭喜！至此您已经通关了太吾秘境的全部内容。后续会逐渐丰富事件类型，并且增加走出山谷的奇遇。也许以后还会把整个奇遇移植到山谷外。如果有兴趣您还可以继续挑战染尘子。";
            case XiangShuType.RanChenZi:
                return "<Character key=RoleTaiwu str=Name/>战胜了染尘子！\n【文案待定】";
            default:
                return "???";
        }

        int progress = Qsc.QscCoreUtils.GetQscProgress(this.TaiwuEvent);
        QscCoreUtils.SetQscProgress(this.TaiwuEvent, progress * 100);
        QscCoreUtils.SetQscSubProgress(this.TaiwuEvent, 0);

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