//本文件填写竹屋事件选项b4655bbf-b37f-427b-be6a-8347ad5b9129在事件执行周期内的相关阶段函数

//【记得经常使用 Ctrl+S 保存修改，只有保存以后才能在编辑事件时生效】

//在本选项所属事件的执行周期函数文件中填写的using指令集，在该文件内同步生效
//可引用变量 ArgBox - 该变量对应事件中从上层事件继承的参数盒子
//OptionAvailableConditions - 该变量用于决定该选项显示时在问号图标上提示玩家满足何种条件选项可用的Tips数据，如果未对该变量初始化，则选项不会显示问号图标

//请填写以下接口
#region CustomUsings
using System.Collections.Generic;
using Config.EventConfig;
#endregion
#if IN_IDE
using System.Collections.Generic;

public class EventOption_b4655bbfb37f427bbe6a8347ad5b9129 : Event_085fba802c0b4590ade42675fa4da780
{
#endif

    /// <summary>
    /// 选项被创建时调用的接口，可以在这里进行OptionAvailableConditions的初始化
    /// 如果选项没有问号提示图标的显示需求，则可以不初始化OptionAvailableConditions
    /// 可以在这里把选项状态初始化为UnRead状态，对于存在记录已读状态的选项，在OnSelect里把状态设置为Normal
    /// </summary>
    private void OnCreate()
    {
        // 选项默认状态设置为未读状态，如果没有标记过已读，则显示为蓝色
        // thisOption.DefaultState = EventOptionState.UnRead;
        // 选项条件可用性：条件组必须全部满足;消耗类条件必须是独立的条件元素
        // OptionAvailableConditions = new[]
        // {
        //     //选项条件组，多个条件中仅需要满足一个
        //     {{TeamMateLess,10},{CharacterNotInGroup}},		//同道数量小于10
        // 	   {{MovePointMore,5}}		//可用行动力不少于5  （更多可用条件设置详见文档）
        // };
        
        // OptionConsumeInfos = new[]
        // {
        //     {Food,1000},        //消耗1000食物
        //     {Authority,20},     //消耗20威望
        //     {MovePoint,5}       //消耗5行动力
        // };
    }
    
    /// <summary>
    /// 该选项所属事件将要被显示时调用的接口，用于检测该选项是否在事件窗口可见
    /// 如果选项始终可见，则可以不填写此接口
    /// </summary>
    /// <returns>true - 可见，会显示在选项列表中 false - 暂时对玩家不可见</returns>
    private bool OnVisibleCheck()
    {
        //TODO
        return true;
    }
    
    /// <summary>
    /// 该选项通过了OnVisibleCheck接口检测后，该接口被调用
    /// 用于检测该选项是否可以点击交互
    /// 注意：
    /// ① 如果该选项在编辑器被指定了立场，且立场与进行选项选择的角色(大部分情况下，这个角色是太吾)的立场差异较大，则无论这里返回值如何，该选项均不可以点击
    ///   比如 【刚正】 立场的选项不可以被【中庸】【叛逆】【唯我】立场的角色选择，【中庸】立场的选项不可以被【刚正】【唯我】立场的角色选择
    /// ② 如果OptionAvailableConditions被初始化，且其内相关的条件未满足，则无论这里返回值如何，该选项均不可以点击
    /// </summary>
    /// <returns>true - 可以进行点击交互 false - 暂时不可点击</returns>
    private bool OnAvailableCheck()
    {
        //TODO
        return true;
    }
    
    /// <summary>
    /// 该选项确定将要显示在选项列表，需要对编辑器预置中的占位符进行替换时调用的接口
    /// 如果选项文本预设满足系统默认的占位符替换方案，则可以不填写此接口
    /// </summary>
    /// <returns>string.Empty - 使用系统默认的占位符替换方案，详见文档</returns>
    private string OnGetReplacedContent()
    {
        //TODO
        return string.Empty;
    }
    
    /// <summary>
    /// 该选项被玩家选择时调用的接口，返回要跳转到的事件的Guid
    /// 同时需要处理使指定事件进入监听(调用接口EventHelper.AddEventListen)、退出监听(调用接口EventHelper.RemoveEventListen)等的逻辑
    /// 对于存在记录已读状态的选项，在这个接口里把状态设置为Normal
    /// </summary>
    /// <returns>string.Empty - 没有要跳转到的事件</returns>
    private string OnSelect()
    {
        // 选项标记为已读，如果再次进入该事件则显示为暗灰色。如果本事件链再次触发，则会清除已读标记
        // SetOptionRead(thisOption.OptionKey);
        //TODO 有需要分不同条件跳转时，在这里编码if/switch分支
	return "dbcb6dbf-d40c-4806-824f-65f77e8c8249";
    }
    
    /// <summary>
    /// 获取额外格式化使用的多语言字段
    /// </summary>
    /// <returns></returns>
    public List<string> GetExtraFormatLanguageKeys()
    {
        return default;
    }

#if IN_IDE
}
#endif
