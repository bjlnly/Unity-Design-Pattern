//-------------------------------------------------------------------------------------
//	IElectronicDevice.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

// interface for electronic devices (or receivers)
// 电器接口--为接收者使用
public interface IElectronicDevice
{
    // 开, 关, 音量+ 音量-
    void On();
    void Off();
    void VolumeUp();
    void VolumeDown();
}
