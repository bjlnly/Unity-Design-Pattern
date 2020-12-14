//-------------------------------------------------------------------------------------
//	ChainOfResponsibilityStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// 一连串的责任人 都可以执行相似的操作
/// 用户初始只需要面对最低级的责任人即可
/// 请求者和接受者 解耦
/// </summary>
public class ChainOfResponsibilityStructure : MonoBehaviour
{
    void Start()
    { 
        // Setup Chain of Responsibility
        // 创建一个责任链
        Handler h1 = new ConcreteHandler1();
        Handler h2 = new ConcreteHandler2();
        Handler h3 = new ConcreteHandler3();
        // h1先解决  h1解决不了发给h2  h2解决不了发给h3
        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);
 
        // Generate and process request
        // 发起请求  只需h1来面对问题就好了
        int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };
        foreach (int request in requests)
        {
            h1.HandleRequest(request);
        }
    }
  }
 
/// <summary>
/// The 'Handler' abstract class 抽象的责任人类
/// </summary>
abstract class Handler
{
    // 聚合一个自己
    protected Handler successor;

    // 设置下一个责任人
    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    // 抽象的责任请求
    public abstract void HandleRequest(int request);
}

/// <summary>
/// The 'ConcreteHandler1' class 具体的责任人
/// </summary>
class ConcreteHandler1 : Handler
{
    // 具体的责任执行
    public override void HandleRequest(int request)
    {
        if (request >= 0 && request < 10)
        {
            Debug.Log(this.GetType().Name + " handled request " + request);
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

/// <summary>
/// The 'ConcreteHandler2' class 具体的责任人2
/// </summary>
class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            Debug.Log(this.GetType().Name + " handled request " + request);
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

/// <summary>
/// The 'ConcreteHandler3' class 具体的责任人3
/// </summary>
class ConcreteHandler3 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 20 && request < 30)
        {
            Debug.Log(this.GetType().Name+" handled request "+request);
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}
