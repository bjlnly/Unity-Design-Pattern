//-------------------------------------------------------------------------------------
//	ICommand.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;


// commands:
// command interface:
// 抽象的命令类
public interface ICommand
{
    // 执行
    void Execute();
    // 重做
    void Undo();
}
