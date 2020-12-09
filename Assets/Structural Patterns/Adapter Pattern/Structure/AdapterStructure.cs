//-------------------------------------------------------------------------------------
//	AdapterStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
// 一种对已有上线逻辑新增功能,但又不想修改调用方法的最佳实践
// 完美符合开闭原则  缺点是太多的适配器会影响代码的阅读,混乱逻辑
// 可操作的情况下最好还是选择重构比较好
public class AdapterStructure : MonoBehaviour
{
	void Start( )
    {
        // Create adapter and place a request
        // 创建适配器, 设置了请求,请求的代码实际走了 适配的新类
        Target target = new Adapter();
        target.Request();
    }
}

/// <summary>
/// The 'Target' class 目标类  用户操作的类
/// </summary>
class Target
{
    public virtual void Request()
    {
        Debug.Log("Called Target Request()");
    }
}

/// <summary>
/// The 'Adapter' class 适配器类  继承或者依赖目标类  实现已有接口
/// </summary>
class Adapter : Target
{
    // 依赖新的操作类(对用户不可见的类)
    private Adaptee _adaptee = new Adaptee();

    public override void Request()
    {
        // Possibly do some other work
        //  and then call SpecificRequest
        // 做一些操作,最终调用新的类的方法
        _adaptee.SpecificRequest();
    }
}

/// <summary>
/// The 'Adaptee' class // 新的类 有新的行为 对用户无需感知
/// </summary>
class Adaptee
{
    public void SpecificRequest()
    {
        Debug.Log("Called SpecificRequest()");
    }
}