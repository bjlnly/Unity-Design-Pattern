﻿//-------------------------------------------------------------------------------------
//	TurnTVOn.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// 具体命令--开启设备
/// </summary>
public class TurnTVOn : ICommand
{
    IElectronicDevice device;

    public TurnTVOn(IElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        this.device.On();
    }

    public void Undo()
    {
        this.device.Off();
    }
}
