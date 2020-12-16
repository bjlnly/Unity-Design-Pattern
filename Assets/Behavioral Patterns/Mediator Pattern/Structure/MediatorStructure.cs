//-------------------------------------------------------------------------------------
//	MediatorStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class MediatorStructure : MonoBehaviour
{
    void Start()
    {
        // 创建中介
        ConcreteMediator m = new ConcreteMediator();

        // 创建2个交互对象
        ConcreteColleague1 c1 = new ConcreteColleague1(m);
        ConcreteColleague2 c2 = new ConcreteColleague2(m);

        m.Colleague1 = c1;
        m.Colleague2 = c2;

        // c1发送  c2接收  相互解耦
        c1.Send("How are you?");
        c2.Send("Fine, thanks");

    }
}

/// <summary>
/// The 'Mediator' abstract class 抽象的中介者
/// </summary>
abstract class Mediator
{
    public abstract void Send(string message,Colleague colleague);
}

/// <summary>
/// The 'ConcreteMediator' class 具体的中介者
/// </summary>
class ConcreteMediator : Mediator
{
    private ConcreteColleague1 _colleague1;
    private ConcreteColleague2 _colleague2;

    public ConcreteColleague1 Colleague1
    {
        set { _colleague1 = value; }
    }

    public ConcreteColleague2 Colleague2
    {
        set { _colleague2 = value; }
    }

    // 两个Colleague隔离
    public override void Send(string message,Colleague colleague)
    {
        if (colleague == _colleague1)
        {
            _colleague2.Notify(message);
        }
        else
        {
            _colleague1.Notify(message);
        }
    }
}

/// <summary>
/// The 'Colleague' abstract class 抽象的Colleague交互类
/// </summary>
abstract class Colleague
{
    // Colleague可以不用知道别的Colleague,但要知道mediator中介者
    protected Mediator mediator;

    // Constructor
    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }
}

/// <summary>
/// A 'ConcreteColleague' class 具体的Colleague
/// </summary>
class ConcreteColleague1 : Colleague
{
    // Constructor
    public ConcreteColleague1(Mediator mediator)
        : base(mediator)
    {
    }

    // 发消息
    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    // 接消息
    public void Notify(string message)
    {
        Debug.Log("Colleague1 gets message: "+ message);
    }
}

/// <summary>
/// A 'ConcreteColleague' class 第二个Colleague
/// </summary>
class ConcreteColleague2 : Colleague
{
    // Constructor
    public ConcreteColleague2(Mediator mediator)
        : base(mediator)
    {
    }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public void Notify(string message)
    {
        Debug.Log("Colleague2 gets message: "+ message);
    }
}
