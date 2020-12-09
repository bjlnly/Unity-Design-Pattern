//-------------------------------------------------------------------------------------
//	BridgePatternExample2.cs
//-------------------------------------------------------------------------------------

/* Decouple an abstraction from its implementation so that the two can vary independently
 * 
 * Progressingly adding functionality while separating out major differences using abstract classes
 * (think of remote controls with the same buttons but difference functionality among the buttons for different tvs)
 * 
 * Use when you want to be able rto change both the abstractions (abstract classes) and concrete classes independently
 * 
 * When you want the first abstract class to define rules (Abstract TV)
 * 
 * The concrete class adds additional rules (Concrete TV)
 * 
 * An abstract class has a reference to the device and it defines abstract methods that will be defined (Abstract Remote)
 * 
 * The concrete Remote defines the abstract methods required
 * 
 * */


using UnityEngine;
using System.Collections;

// 遥控器基类作为桥接 调用实施者--电视的同时 可以调用自己遥控器专属的功能
// 这里的例子可能不太恰当  按钮对电视静音和暂停都不是遥控器自己可以完成的
// 如果是点击按钮时候,遥控器遥控头发光,颜色不同--红色,蓝色 或许更恰当
// 但是原理是对的
namespace BridgePatternExample2
{
    public class BridgePatternExample2 : MonoBehaviour
    {
        void Start()
        {
            // 创建两个遥控器 一个遥控器9是暂停 一个遥控器9是静音
            RemoteButton tv = new TVRemoteMute(new TVDevice(1, 200));
            RemoteButton tv2 = new TVRemotePause(new TVDevice(1, 200));

            Debug.Log("Test TV with Mute");
            tv.ButtonFivePressed();
            tv.ButtonSixPressed();
            tv.ButtonNinePressed(); // < this one differs on each tv

            Debug.Log("Test TV with Pause");
            tv2.ButtonFivePressed();
            tv2.ButtonSixPressed();
            tv2.ButtonNinePressed(); // < this one differs on each tv
        }
    }

    // 实施类 娱乐设备
    public abstract class EntertainmentDevice
    {
        public int deviceState;
        public int maxSetting;
        public int volumeLevel = 0;

        // 有自己的一些接口
        public abstract void ButtonFivePressed();

        public abstract void ButtonSixPressed();

        public void DeviceFeedback()
        {
            if (deviceState > maxSetting || deviceState < 0)
                deviceState = 0;

            Debug.Log("On " + deviceState);
        }

        // 实施抽象类自己也可以实现一些通用功能  ---调节音量
        public void ButtonSevenPressed()
        {
            volumeLevel++;
            Debug.Log("Volume at: " + volumeLevel);
        }

        public void ButtonEightPressed()
        {
            volumeLevel--;
            Debug.Log("Volume at: " + volumeLevel);
        }
    }

    // 具体的实施类 实现实施者基类的接口
    public class TVDevice : EntertainmentDevice
    {
        public TVDevice(int newDeviceState, int newMaxSetting)
        {
            this.deviceState = newDeviceState;
            this.maxSetting = newMaxSetting;
        }

        // 换台
        public override void ButtonFivePressed()
        {
            Debug.Log("Channel up");
            deviceState++;
        }

        public override void ButtonSixPressed()
        {
            Debug.Log("Channel down");
            deviceState--;
        }
    }

    // abstraction layer
    // 遥控器按钮 就是个 桥接 桥接电视和用户
    public abstract class RemoteButton
    {
        // 遥控器可以操作娱乐设备  不一定是电视机  所以是个要用遥控器的设备基类
        private EntertainmentDevice device;

        // 设置具体的设备
        public RemoteButton(EntertainmentDevice device)
        {
            this.device = device;
        }

        public void ButtonFivePressed()
        {
            device.ButtonFivePressed();
        }

        public void ButtonSixPressed()
        {
            device.ButtonSixPressed();
        }

        public void DeviceFeedback()
        {
            device.DeviceFeedback();
        }

        // 抽象基类 [桥接类] 可以自行扩展功能
        public abstract void ButtonNinePressed();
    }


    // refined abstraction:
    // 精确的抽象类  --- TV遥控器 静音
    public class TVRemoteMute : RemoteButton
    {
        public TVRemoteMute(EntertainmentDevice device) : base(device)
        {
        }

        // 扩展了按钮9 -- 静音
        public override void ButtonNinePressed()
        {
            Debug.Log("TV was muted.");
        }
    }

    // 精确的抽象类 --- TV遥控器 暂停
    public class TVRemotePause : RemoteButton
    {
        public TVRemotePause(EntertainmentDevice device) : base(device)
        {
        }

        public override void ButtonNinePressed()
        {
            Debug.Log("TV was paused.");
        }
    }


}