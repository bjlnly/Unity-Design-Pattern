//-------------------------------------------------------------------------------------
//	FactoryMethodStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace FactoryMethodStructure
{
   
    public class FactoryMethodStructure : MonoBehaviour
    {
	    void Start ( )
        {
            // An array of creators  一系列的创造者  此处应该使用工厂类
            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            // Iterate over creators and create products 
            // 用抽象的创造者,构建抽象的产品
            // 外层类完全是面向抽象开发
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Debug.Log("Created "+product.GetType().Name);
            }
        }
    }

    /// <summary>
    /// The 'Product' abstract class 抽象产品
    /// </summary>
    abstract class Product
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class 具体产品A
    /// </summary>
    class ConcreteProductA : Product
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class 具体产品B
    /// </summary>
    class ConcreteProductB : Product
    {
    }

    /// <summary>
    /// The 'Creator' abstract class 抽象的创造者
    /// </summary>
    abstract class Creator
    {
        // 基类的创造者只做声明
        public abstract Product FactoryMethod();
    }

    /// <summary>
    /// A 'ConcreteCreator' class 具体创造者A,创造了具体产品A ,返回了抽象产品
    /// </summary>
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    /// <summary>
    /// A 'ConcreteCreator' class 具体创造者B
    /// </summary>
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}