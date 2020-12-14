//-------------------------------------------------------------------------------------
//	DeviceButton.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

// 内聚命令 请求者
public class DeviceButton
{
    ICommand cmd;

    public DeviceButton(ICommand cmd)
    {
        this.cmd = cmd;
    }

    // 按下按钮
    public void Press()
    {
        //其实调用者（设备按钮）根本不知道它是干什么的
        this.cmd.Execute(); // actually the invoker (device button) has no idea what it does
    }

    // 撤销
    public void PressUndo()
    {
        this.cmd.Undo();
    }
}

