//-------------------------------------------------------------------------------------
//	CompositeStructure.cs
//-------------------------------------------------------------------------------------

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 这个例子其实是一个抽象版本的组合模式,
/// 虽然枝干包含了叶子,用户还是得分清 枝干和叶子,用户反而对抽象的元件,不了解
/// 用户没有面向抽象开发,依旧违反了依赖倒置的原则
/// 另一种方案是,用户直接了解元件--当然元件需要是具体类
/// 元件既可以是叶子,也可以是枝干,用户此时只需操作元件
/// </summary>
public class CompositeStructure : MonoBehaviour
{
	void Start ( )
    {
        // Create a tree structure
        // 创建一个树形结构
        // 根是一个复合,包含2个叶子
        Composite root = new Composite("root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        // 枝干X 包含2个叶子
        Composite comp = new Composite("Composite X");
        comp.Add(new Leaf("Leaf XA"));
        comp.Add(new Leaf("Leaf XB"));

        // 根包含枝干X
        root.Add(comp);
        // 根还可以继续包含别的叶子
        root.Add(new Leaf("Leaf C"));

        // Add and remove a leaf
        // 根可以增加,移除叶子
        Leaf leaf = new Leaf("Leaf D");
        root.Add(leaf);
        root.Remove(leaf);

        // Recursively display tree
        // 展示根
        root.Display(1);

    }
}

/// <summary>
/// The 'Component' abstract class 抽象的元件  枝干和叶子都继承它
/// </summary>
abstract class Component
{
    protected string name;

    // Constructor
    public Component(string name)
    {
        this.name = name;
    }

    // 抽象组合中对象的接口
    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
}

/// <summary>
/// The 'Composite' class 复合类  这是个枝干 
/// </summary>
class Composite : Component
{
    private List<Component> _children = new List<Component>();

    // Constructor
    public Composite(string name)
      : base(name)
    {
    }

    public override void Add(Component component)
    {
        _children.Add(component);
    }

    public override void Remove(Component component)
    {
        _children.Remove(component);
    }

    public override void Display(int depth)
    {
        Debug.Log(new String('-', depth) + name);

        // Recursively display child nodes
        foreach (Component component in _children)
        {
            component.Display(depth + 2);
        }
    }
}

/// <summary>
/// The 'Leaf' class  叶子类
/// </summary>
class Leaf : Component
{
    // Constructor
    public Leaf(string name)
      : base(name)
    {
    }

    public override void Add(Component c)
    {
        Debug.Log("Cannot add to a leaf");
    }

    public override void Remove(Component c)
    {
        Debug.Log("Cannot remove from a leaf");
    }

    public override void Display(int depth)
    {
        Debug.Log(new String('-', depth) + name);
    }
}
