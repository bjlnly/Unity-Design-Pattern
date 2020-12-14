//-------------------------------------------------------------------------------------
//	TurnVolumeDown.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// 具体命令-- 调低音量
/// </summary>
public class TurnVolumeDown : ICommand
{
    IElectronicDevice device;

    public TurnVolumeDown(IElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        this.device.VolumeDown();
    }

    public void Undo()
    {
        this.device.VolumeUp();
    }
}
