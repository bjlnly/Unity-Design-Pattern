//-------------------------------------------------------------------------------------
//	BuilderStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuilderStructure : MonoBehaviour
{
	void Start ( )
    {
        // Create director and builder
        // 建造者和导演
        Director director = new Director();

        Builder b1 = new ConcreteBuilder1();
        Builder b2 = new ConcreteBuilder2();

        // Construct two products
        // 导演发起建造
        director.Construct(b1);
        // 具体的建造者建造完后,返回具体产品
        Product p1 = b1.GetResult();
        // 产品自身做展示
        p1.Show();

        director.Construct(b2);
        Product p2 = b2.GetResult();
        p2.Show();
    }
}

/// <summary>
/// The 'Director' class 导演类 组装复杂产品 面向抽象组装
/// 面向抽象,处理抽象
/// </summary>
class Director
{
    // Builder uses a complex series of steps
    public void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}

/// <summary>
/// The 'Builder' abstract class 建造者抽象类
/// 抽象的步骤  并声明最终会提供具体的产品
/// </summary>
abstract class Builder
{
    // 抽象的建造部分
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    // 获得产品
    public abstract Product GetResult();
}

/// <summary>
/// The 'ConcreteBuilder1' class 具体的建造者,构建产品的具体部分
/// 实现抽象的建筑过程  提供具体的产品
/// </summary>
class ConcreteBuilder1 : Builder
{
    private Product _product = new Product();

    // 组装部分
    public override void BuildPartA()
    {
        _product.Add("PartA");
    }

    public override void BuildPartB()
    {
        _product.Add("PartB");
    }

    public override Product GetResult()
    {
        return _product;
    }
}

/// <summary>
/// The 'ConcreteBuilder2' class
/// </summary>
class ConcreteBuilder2 : Builder
{
    private Product _product = new Product();

    public override void BuildPartA()
    {
        _product.Add("PartX");
    }

    public override void BuildPartB()
    {
        _product.Add("PartY");
    }

    public override Product GetResult()
    {
        return _product;
    }
}

/// <summary>
/// The 'Product' class 产品类  这是个复杂对象  用户面对的对象
/// 具体的复杂产品  由多个具体步骤多可能组合 有多种组合形式  自己不做组合
/// </summary>
class Product
{
    // 多个部分组成,具体如何组成,产品自己不管
    private List<string> _parts = new List<string>();

    public void Add(string part)
    {
        _parts.Add(part);
    }

    public void Show()
    {
      Debug.Log("\nProduct Parts -------");
        foreach (string part in _parts)
        {
            Debug.Log(part);
        }

    }
}