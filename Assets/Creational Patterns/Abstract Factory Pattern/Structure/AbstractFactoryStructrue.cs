//-------------------------------------------------------------------------------------
//	AbstractFactoryStructrue.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class AbstractFactoryStructrue : MonoBehaviour
{
    void Start()
    {
        // 外层的调用,只知道客户,抽象工厂,具体工厂,
        // 只需处理客户的操作
        // 完全无需考虑工厂的实现
        // 更无需考虑产品的具体实现和交互
        // Abstract factory #1 具体工厂1创造后,返回抽象工厂1
        AbstractFactory factory1 = new ConcreteFactory1();
        // 用抽象工厂传递参数,客户只操作了抽象
        Client client1 = new Client(factory1);
        client1.Run();

        // Abstract factory #2 具体工厂1创造后,返回抽象工厂2
        AbstractFactory factory2 = new ConcreteFactory2();
        Client client2 = new Client(factory2);
        client2.Run();
    }
}

/// <summary>
/// The 'AbstractFactory' abstract class 抽象工厂
/// </summary>
abstract class AbstractFactory
{
    // 抽象工厂A 创建抽象产品A
    public abstract AbstractProductA CreateProductA();
    // ```
    public abstract AbstractProductB CreateProductB();
}


/// <summary> 
/// The 'ConcreteFactory1' class 具体工厂1
/// </summary>
class ConcreteFactory1 : AbstractFactory
{
    // 具体工厂1创造了具体产品A.具体产品B ,但返回的是抽象产品
    public override AbstractProductA CreateProductA()
    {
        return new ProductA1();
    }
    public override AbstractProductB CreateProductB()
    {
        return new ProductB1();
    }
}

/// <summary>
/// The 'ConcreteFactory2' class 具体工厂2
/// </summary>
class ConcreteFactory2 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA2();
    }
    public override AbstractProductB CreateProductB()
    {
        return new ProductB2();
    }
}

/// <summary>
/// The 'AbstractProductA' abstract class 抽象产品A
/// </summary>
abstract class AbstractProductA
{
}

/// <summary>
/// The 'AbstractProductB' abstract class 抽象产品B
/// </summary>
abstract class AbstractProductB
{
    public abstract void Interact(AbstractProductA a);
}


/// <summary>
/// The 'ProductA1' class 具体产品A
/// </summary>
class ProductA1 : AbstractProductA
{
}

/// <summary>
/// The 'ProductB1' class 具体产品B
/// </summary>
class ProductB1 : AbstractProductB
{
    // 当具体的B产品需要跟A类产品交互的时候,也是面向抽象的A
    public override void Interact(AbstractProductA a)
    {
        Debug.Log(this.GetType().Name + " interacts with " + a.GetType().Name);
    }
}

/// <summary>
/// The 'ProductA2' class 具体产品A2
/// </summary>
class ProductA2 : AbstractProductA
{
}

/// <summary>
/// The 'ProductB2' class 具体产品B2
/// </summary>
class ProductB2 : AbstractProductB
{
    public override void Interact(AbstractProductA a)
    {
        Debug.Log(this.GetType().Name + " interacts with " + a.GetType().Name);
    }
}

/// <summary>
/// The 'Client' class. Interaction environment for the products.
/// 客户类,产品交互的环境,最容易冗余的地方,
/// 抽象的目的就是抽象剥离这里的具体代码
/// </summary>
class Client
{
    // 客户使用抽象的产品
    private AbstractProductA _abstractProductA;
    private AbstractProductB _abstractProductB;

    // Constructor
    // 构造使用抽象工厂
    public Client(AbstractFactory factory)
    {
        _abstractProductB = factory.CreateProductB();
        _abstractProductA = factory.CreateProductA();
    }

    // 函数使用抽象产品
    public void Run()
    {
        _abstractProductB.Interact(_abstractProductA);
    }
}
