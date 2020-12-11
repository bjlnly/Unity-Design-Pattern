//-------------------------------------------------------------------------------------
//	FacadeStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
/// <summary>
/// 有各种复杂的子系统  客户直接操作子系统不合适  需要跟外观沟通  -- 有点外交官的意思
/// </summary>
public class FacadeStructure : MonoBehaviour
{
	void Start ( )
    {
        // 创建一个接待 -- 外观类
        Facade facade = new Facade();

        // 执行接待工作 A. B
        facade.MethodA();
        facade.MethodB();
    }
}

/// <summary>
/// The 'Subsystem ClassA' class 子系统类A
/// </summary>
class SubSystemOne
{
    public void MethodOne()
    {
        Debug.Log(" SubSystemOne Method");
    }
}

/// <summary>
/// The 'Subsystem ClassB' class 子系统类B
/// </summary>
class SubSystemTwo
{
    public void MethodTwo()
    {
        Debug.Log(" SubSystemTwo Method");
    }
}

/// <summary>
/// The 'Subsystem ClassC' class 子系统C
/// </summary>
class SubSystemThree
{
    public void MethodThree()
    {
        Debug.Log(" SubSystemThree Method");
    }
}

/// <summary>
/// The 'Subsystem ClassD' class 子系统D
/// </summary>
class SubSystemFour
{
    public void MethodFour()
    {
        Debug.Log(" SubSystemFour Method");
    }
}

/// <summary>
/// The 'Facade' class 外观类  接待类 
/// </summary>
class Facade
{
    // 接待类熟悉所有子系统
    // 同时整合各个子系统的工作  提供给客户端
    private SubSystemOne _one;
    private SubSystemTwo _two;
    private SubSystemThree _three;
    private SubSystemFour _four;

    public Facade()
    {
        _one = new SubSystemOne();
        _two = new SubSystemTwo();
        _three = new SubSystemThree();
        _four = new SubSystemFour();
    }

    public void MethodA()
    {
        Debug.Log("\nMethodA() ---- ");
        _one.MethodOne();
        _two.MethodTwo();
        _four.MethodFour();
    }

    public void MethodB()
    {
        Debug.Log("\nMethodB() ---- ");
        _two.MethodTwo();
        _three.MethodThree();
    }
}