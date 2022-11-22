# 太吾秘境事件包
包含了所有的事件。目前主要是搭一个框架，以后再慢慢完善事件，敌人和掉落列表。依赖于隔壁的QscLib来进行事件碎片的拼接。
游玩时建议安装突破mod和随时存档mod，不是用来sl的，是用来防红字的...
# 编译 
自带的编译器不能添加项目引用，不知道咋想的。我修改(魔改)了作者提供的编译器来添加对QscLib的引用，所以你用他的事件修改器是无法编译的。你需要先编译QscLib (https://github.com/wilhelmw201/QscLib) 之后把生成的dll放在The Scroll Of Taiwu\Backend\TargetLib文件夹下（你需要创建它）。并用我的魔改TaiwuEventCompiler.dll覆盖SteamLibrary\steamapps\common\The Scroll Of Taiwu\Event\EventCompiler下的同名dll才能编译（编译完成后额外需要按下一个任意键退出编译器）。生成的Qsclib当然也要作为一个mod加载。
有问题，建议，bug和pull request请提在issue里面。感激不尽。
# Changelog
- v0.01 初版。经过几十个小时的奋力码代码和找bug，仅仅做到了流程可以走下来。。目前还在收集意见建议。事件不全（比如商店都还没做），难度完全没有调整(不过我普通难度过了),绝技和护体的等级也需要调整（说的就是你,移魂大法,还有那几个9品减伤绝技）。
# 已知bug
- 在正常档中载入这个mod并过月会红字。但是因为现在对正常游戏流程完全没支持，所以以后再说吧。
- 精制现在有bug。（我已经把精制隐藏掉了）
- 我现在不知道小猴子那个事件的guid，所以没法取消掉猴王事件。请不要去踩那个奇遇。同样的，如果没清理掉的话，深谷出口也烦请不要踩。
# 提交bug
请添加issue，并附上log的exception那段的内容，最好可以带上存档。