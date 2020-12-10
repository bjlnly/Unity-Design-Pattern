//-------------------------------------------------------------------------------------
//	DecoratorPatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace DecoratorPatternExample2
{
    public class DecoratorPatternExample2 : MonoBehaviour
    {
        void Start()
        {
            // Make Pizzas:
            // 制作匹萨
            // 多重装饰之后 返回的还是匹萨基类
            IPizza basicPizza = new TomatoSauce(new Mozzarella(new PlainPizza()));
            Debug.Log("Ingredients of Pizza: " + basicPizza.GetDescription());
            Debug.Log("Total Cost: " + basicPizza.GetCost());
        }
    }


/// <summary>
/// 匹萨接口
/// </summary>
    public interface IPizza
    {
        // 两个基础属性  -- 描述,价格
        string GetDescription();
        double GetCost();
    }


/// <summary>
/// 最简单的匹萨  具体被装饰的类
/// </summary>
    public class PlainPizza : IPizza
    {
        public string GetDescription()
        {
            return "Thin Dough";
        }

        public double GetCost()
        {
            return 4.00;
        }
    }


/// <summary>
/// 装饰基类  继承自匹萨基类
/// </summary>
    public abstract class ToppingDecorator : IPizza
    {
        // 有匹萨基类属性的基础上 实现基类的接口
        protected IPizza tempPizza;

        public ToppingDecorator(IPizza newPizza)
        {
            this.tempPizza = newPizza;
        }


        public virtual string GetDescription()
        {
            return tempPizza.GetDescription();
        }

        public virtual double GetCost()
        {
            return tempPizza.GetCost();
        }
    }



/// <summary>
/// 具体的装饰 -- 奶酪
/// </summary>
    public class Mozzarella : ToppingDecorator
    {
        public Mozzarella(IPizza newPizza) : base(newPizza)
        {
            Debug.Log("Adding Dough");
            Debug.Log("Adding Morarella");
        }

        public override string GetDescription()
        {
            return tempPizza.GetDescription() + ", Mozzarella";
        }

        public override double GetCost()
        {
            return tempPizza.GetCost() + 0.50;
        }
    }

/// <summary>
/// 具体的装饰 -- 西红柿
/// </summary>
    public class TomatoSauce : ToppingDecorator
    {
        public TomatoSauce(IPizza newPizza) : base(newPizza)
        {
            Debug.Log("Adding Sauce");
        }

        public override string GetDescription()
        {
            return tempPizza.GetDescription() + ", Tomato Sauce";
        }

        public override double GetCost()
        {
            return tempPizza.GetCost() + 0.35;
        }
    }




    namespace BadStyleExample
    {
        public abstract class Pizza
        {
            public abstract void SetDescription(string newDescription);
            public abstract string GetDescription();
            public abstract double GetCost();
            //public abstract bool HasFontina();
        }

        // this way would force to create an infinite amount of subclasses for each type of pizza
        // and if cost if calculated off of individual topings you would have to change cost for all pizzas
        // if cost for one topping chages
        
        // 这种方式将迫使为每种类型的比萨饼创建无限量的子类。
        // 如果成本是按单个比萨饼计算的，你就必须改变所有比萨饼的成本。
        public class ThreeCheesePizza : Pizza
        {
            public override void SetDescription(string newDescription)
            {
            }

            public override string GetDescription()
            {
                return "Mozarella, Fontina, Parmesan, Cheese Pizza";
            }

            public override double GetCost()
            {
                return 10.00;
            }

        }
    }

}