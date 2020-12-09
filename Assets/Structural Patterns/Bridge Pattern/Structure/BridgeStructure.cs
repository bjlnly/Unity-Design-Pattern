//-------------------------------------------------------------------------------------
//	BridgeStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
// 组成是抽象类,精确的抽象类,具体类,具体实现类,为啥是叫桥接模式?
// 因为具体实现和具体抽象,都是由抽象类来操作的,Main未曾直接操作具体的任何内容
// 抽象 和 具体 可以各自独立扩展  互不干扰
// 抽象化和实现化做到了解耦  抽象化无需继承实现化  nice!!!
public class BridgeStructure : MonoBehaviour
{
	void Start ( )
    {
        // 定义一个抽象  new自精确的抽象化类 
        Abstraction ab = new RefinedAbstraction();

        // Set implementation and call
        // 给抽象的抽象实现一个  具体的实现
        ab.Implementor = new ConcreteImplementorA();
        // 执行具体的实现
        ab.Operation();

        // Change implemention and call
        ab.Implementor = new ConcreteImplementorB();
        ab.Operation();
    }
}

/// <summary>
/// The 'Abstraction' class 抽象类  注意抽象类不一定真的抽象  它只是抽象了实现  应该算是桥接类
/// </summary>
class Abstraction
{
    // 持有实现者 实现者才是一个抽象类或者接口
    protected Implementor implementor;

    // Property
    public Implementor Implementor
    {
        set { implementor = value; }
    }

    // 功能接口中委托实现者来具体实现
    public virtual void Operation()
    {
        implementor.Operation();
    }
}

/// <summary>
/// The 'Implementor' abstract class 实现者  是一个抽象类或者接口
/// </summary>
abstract class Implementor
{
    // 提供抽象化的接口
    public abstract void Operation();
}

/// <summary>
/// The 'RefinedAbstraction' class 具体的抽象角色
/// </summary>
class RefinedAbstraction : Abstraction
{
    // 子类可以增加新功能
    public override void Operation()
    {
        implementor.Operation();
    }
}

/// <summary>
/// The 'ConcreteImplementorA' class 具体的实现者
/// </summary>
class ConcreteImplementorA : Implementor
{
    // 实现了实现者的接口.函数
    public override void Operation()
    {
        Debug.Log("ConcreteImplementorA Operation");
    }
}

/// <summary>
/// The 'ConcreteImplementorB' class
/// </summary>
class ConcreteImplementorB : Implementor
{
    public override void Operation()
    {
        Debug.Log("ConcreteImplementorB Operation");
    }
}
