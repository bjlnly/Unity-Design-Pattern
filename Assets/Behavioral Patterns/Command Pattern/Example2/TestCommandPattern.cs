//-------------------------------------------------------------------------------------
//	TestCommandPattern.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 操作遥控器按钮的案例
/// </summary>
public class TestCommandPattern : MonoBehaviour
{
    void Start()
    {
        Debug.Log("------------------Command Pattern--------------");
        // 接收者接口  创造TV设备
        IElectronicDevice device = TVRemove.GetDevice();

        // 创造开启命令
        TurnTVOn onCommand = new TurnTVOn(device);
        // 命令绑定到设备按钮 -- 请求者
        DeviceButton onPressed = new DeviceButton(onCommand);
        // 请求者执行
        onPressed.Press();

        // -----------------------
        // 简单的绑定执行
        // 关闭
        TurnTVOff offCommand = new TurnTVOff(device);
        onPressed = new DeviceButton(offCommand);
        onPressed.Press();

        // 调高音量
        TurnVolumeUp volUpCommand = new TurnVolumeUp(device);
        onPressed = new DeviceButton(volUpCommand);
        onPressed.Press();
        onPressed.Press();
        onPressed.Press();

        // 调低音量
        TurnVolumeDown volDownCommand = new TurnVolumeDown(device);
        onPressed = new DeviceButton(volDownCommand);
        onPressed.Press();

        // -----------------------
        // 命令可以通知多个执行者
        // 创建两种接收者
        Television tv = new Television();
        Radio radio = new Radio();

        List<IElectronicDevice> allDevices = new List<IElectronicDevice>();
        allDevices.Add(tv);
        allDevices.Add(radio);

        // 所有接收者都接入  关闭所有设备的命令中
        TurnItAllOff turnOffDevices = new TurnItAllOff(allDevices);
        DeviceButton turnThemOff = new DeviceButton(turnOffDevices);
        // 执行点击按钮
        turnThemOff.Press();

        // -----------------------
        turnThemOff.PressUndo();

    }
}
