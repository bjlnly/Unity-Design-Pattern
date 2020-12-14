//-------------------------------------------------------------------------------------
//	TurnVolumeUp.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// 具体命令--调高音量
/// </summary>
public class TurnVolumeUp : ICommand
{
    IElectronicDevice device;

    public TurnVolumeUp(IElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        this.device.VolumeUp();
    }

    public void Undo()
    {
        this.device.VolumeDown();
    }
}
