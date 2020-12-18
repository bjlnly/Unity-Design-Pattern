//-------------------------------------------------------------------------------------
//	TemplateMethodStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
/// <summary>
/// 算法的骨架是固定的  -- 具体执行不同
/// 跟策略模式的区别是  整体不同还是部分不同
/// </summary>
public class TemplateMethodStructure : MonoBehaviour
{
	void Start ( )
	{
        // 创建算法A1
        AbstractClass aA = new ConcreteClassA();
        // 执行模板
        aA.TemplateMethod();

        // 创建算法A2
        AbstractClass aB = new ConcreteClassB();
        // 执行模板
        aB.TemplateMethod();

    }
}

/// <summary>
/// The 'AbstractClass' abstract class 抽象模板
/// </summary>
abstract class AbstractClass
{
    // 定义通用操作
    public abstract void PrimitiveOperation1();
    public abstract void PrimitiveOperation2();

    // The "Template method"
    // 模板方法 == 算法的骨架
    public void TemplateMethod()
    {
        PrimitiveOperation1();
        PrimitiveOperation2();
        Debug.Log("");
    }
}

/// <summary>
/// A 'ConcreteClass' class 具体部分算法A
/// </summary>
class ConcreteClassA : AbstractClass
{
    // 实现通用操作
    public override void PrimitiveOperation1()
    {
        Debug.Log("ConcreteClassA.PrimitiveOperation1()");
    }
    public override void PrimitiveOperation2()
    {
        Debug.Log("ConcreteClassA.PrimitiveOperation2()");
    }
}

/// <summary>
/// A 'ConcreteClass' class
/// </summary>
class ConcreteClassB : AbstractClass
{
    public override void PrimitiveOperation1()
    {
        Debug.Log("ConcreteClassB.PrimitiveOperation1()");
    }
    public override void PrimitiveOperation2()
    {
        Debug.Log("ConcreteClassB.PrimitiveOperation2()");
    }
}
