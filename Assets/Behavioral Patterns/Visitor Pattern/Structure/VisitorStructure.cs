//-------------------------------------------------------------------------------------
//	VisitorStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisitorStructure : MonoBehaviour
{
	void Start ( )
    {
        // Setup structure
        // 创建一个结构
        ObjectStructure o = new ObjectStructure();
        // 结构中加入元素A,B
        o.Attach(new ConcreteElementA());
        o.Attach(new ConcreteElementB());

        // Create visitor objects
        // 创建访问者
        ConcreteVisitor1 v1 = new ConcreteVisitor1();
        ConcreteVisitor2 v2 = new ConcreteVisitor2();

        // Structure accepting visitors
        // structure允许visitor访问
        o.Accept(v1);
        o.Accept(v2);
    }
}

/// <summary>
/// The 'Visitor' abstract class  抽象访问者
/// </summary>
abstract class Visitor
{
    // 为要访问的对象增加Visit操作接口,传入具体被访问的对象
    public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
    public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
}

/// <summary>
/// A 'ConcreteVisitor' class 具体访问者1
/// </summary>
class ConcreteVisitor1 : Visitor
{
    // 实现具体的Visit的接口
    public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
    {
        Debug.Log(concreteElementA.GetType().Name+" visited by "+this.GetType().Name);
    }

    public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
    {
        Debug.Log(concreteElementB.GetType().Name + " visited by " + this.GetType().Name);
    }
}

/// <summary>
/// A 'ConcreteVisitor' class 具体访问者2
/// </summary>
class ConcreteVisitor2 : Visitor
{
    public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
    {
        Debug.Log(concreteElementA.GetType().Name + " visited by " + this.GetType().Name);
    }

    public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
    {
        Debug.Log(concreteElementB.GetType().Name + " visited by " + this.GetType().Name);
    }
}

/// <summary>
/// The 'Element' abstract class 抽象的被访问对象
/// </summary>
abstract class Element
{
    // 定义一个以Visitor为参数的Accept接口
    public abstract void Accept(Visitor visitor);
}

/// <summary>
/// A 'ConcreteElement' class 具体的元素(被访问对象)
/// </summary>
class ConcreteElementA : Element
{
    // 实现以Vistor为参数的Accept方法
    public override void Accept(Visitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public void OperationA()
    {
    }
}

/// <summary>
/// A 'ConcreteElement' class 具体的元素(被访问对象)
/// </summary>
class ConcreteElementB : Element
{
    public override void Accept(Visitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }

    public void OperationB()
    {
    }
}

/// <summary>
/// The 'ObjectStructure' class 元素的集合
/// </summary>
class ObjectStructure
{
    // 维护一个Element的列表/集合
    private List<Element> _elements = new List<Element>();

    public void Attach(Element element)
    {
        _elements.Add(element);
    }

    public void Detach(Element element)
    {
        _elements.Remove(element);
    }

    // 提供方法, 可以让Visitor访问自己的Element
    public void Accept(Visitor visitor)
    {
        foreach (Element element in _elements)
        {
            element.Accept(visitor);
        }
    }
}
 