//-------------------------------------------------------------------------------------
//	TurnTVOff.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
/// <summary>
/// 具体命令--关闭设备
/// </summary>
public class TurnTVOff : ICommand
{
    IElectronicDevice device;

    public TurnTVOff(IElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        this.device.Off();
    }

    public void Undo()
    {
        this.device.On();
    }
}

