//-------------------------------------------------------------------------------------
//	TurnItAllOff.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 具体命令--所有设备全部关闭
/// </summary>
public class TurnItAllOff : ICommand
{
    List<IElectronicDevice> devices;

    public TurnItAllOff(List<IElectronicDevice> devices)
    {
        this.devices = devices;
    }

    public void Execute()
    {
        foreach (IElectronicDevice device in devices)
        {
            device.Off();
        }
    }

    public void Undo()
    {
        foreach (IElectronicDevice device in devices)
        {
            device.On();
        }
    }
}