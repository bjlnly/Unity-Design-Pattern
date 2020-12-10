//-------------------------------------------------------------------------------------
//	DecoratorStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace DecoratorStructure
{
    // 每一层的装饰,都可以理解为一层继承
    // 但是具体的装饰又可以动态调整,比如可以先装饰d2到被装饰物上,比继承就灵活很多
    public class DecoratorStructure : MonoBehaviour
    {
	    void Start ( )
        {
            // Create ConcreteComponent and two Decorators
            // 创建一个被装饰物  2个具体装饰
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators
            // 给装饰物进行装饰
            d1.SetComponent(c);
            d2.SetComponent(d1);

            // 最终的装饰物来执行
            d2.Operation();
        }
    }

    /// <summary>
    /// The 'Component' abstract class 被装饰的抽象类
    /// </summary>
    abstract class Component
    {
        public abstract void Operation();
    }

    /// <summary>
    /// The 'ConcreteComponent' class 具体的被装饰类
    /// </summary>
    class ConcreteComponent : Component
    {
        // 实现被装饰物的通用功能
        public override void Operation()
        {
            Debug.Log("ConcreteComponent.Operation()");
        }
    }

    /// <summary>
    /// The 'Decorator' abstract class 装饰抽象类,继承了抽象的被装饰对象
    /// 注意虽然此时也有继承  但是继承自抽象
    /// 从此处开始分叉 装饰类和被装饰类的具体类已经不同,可以各自扩展
    /// </summary>
    abstract class Decorator : Component
    {
        // 包含抽象的被装饰物
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        // 实现被抽象对象的功能
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    /// <summary>
    /// The 'ConcreteDecoratorA' class 具体的装饰A
    /// </summary>
    class ConcreteDecoratorA : Decorator
    {
        // 实现了具体被装饰的接口
        public override void Operation()
        {
            base.Operation();
            Debug.Log("ConcreteDecoratorA.Operation()");
        }
    }

    /// <summary>
    /// The 'ConcreteDecoratorB' class 具体的装饰B
    /// </summary>
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Debug.Log("ConcreteDecoratorB.Operation()");
        }

        void AddedBehavior()
        {
        }
    }

}