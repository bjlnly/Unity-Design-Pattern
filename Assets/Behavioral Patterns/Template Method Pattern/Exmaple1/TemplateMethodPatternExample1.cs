//-------------------------------------------------------------------------------------
//	TemplateMethodPatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

/* 
 Used to create a group of sublcasses that have to execute a similar group of methods
 You create an abstract class that contains a method called the Template Method
 The Template method contains a series of method calls that every sublcass object will call
 The subclass objects can override some of the method calls
 用于创建一组必须执行类似方法的子类。
 你创建了一个抽象类，其中包含一个叫做模板方法的方法。
 Template方法包含一系列方法调用，每个子lcass对象都会调用该方法
 子类对象可以覆盖一些方法调用。
*/

namespace TemplateMethodPatternExample1
{

    public class TemplateMethodPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // 创建策略A1
            Hoagie cust12Hoagie = new ItalienHoagie();
            cust12Hoagie.MakeSandwich();
            
            // 创建策略A2
            Hoagie cust13Hoagie = new VeggieHoagie();
            cust13Hoagie.MakeSandwich();
        }
    }

    /// <summary>
    /// 抽象模板
    /// </summary>
    public abstract class Hoagie
    {
        /// <summary>
        /// 模板步骤
        /// </summary>
        public void MakeSandwich()
        {
            Debug.Log("Making new Sandwich");
            
            CutBun();

            if (CustomerWantsMeat())
            {
                AddMeat();
            }

            if (CustomerWantsCheese())
            {
                AddCheese();
            }

            if (CustomerWantsVegetables())
            {
                AddVegetables();
            }

            if (CustomerWantsCondiments())
            {
                AddCondiments();
            }

            WrapTheHoagie();
        }
        // 固定通用模板步奏
        protected abstract void AddMeat();
        protected abstract void AddCheese();
        protected abstract void AddVegetables();
        protected abstract void AddCondiments();

        protected virtual bool CustomerWantsMeat() { return true; } // << called Hook
        protected virtual bool CustomerWantsCheese() { return true; }
        protected virtual bool CustomerWantsVegetables() { return true; }
        protected virtual bool CustomerWantsCondiments() { return true; }

        // 无需子类执行的步骤
        protected void CutBun()
        {
            Debug.Log("Bun is Cut");
        }

        protected void WrapTheHoagie()
        {
            Debug.Log("Hoagie is wrapped.");
        }
    }

    /// <summary>
    /// 具体的模板策略
    /// </summary>
    public class ItalienHoagie : Hoagie
    {
        protected override void AddMeat()
        {
            Debug.Log("Adding the Meat: Salami");
        }

        protected override void AddCheese()
        {
            Debug.Log("Adding the Cheese: Provolone");
        }

        protected override void AddVegetables()
        {
            Debug.Log("Adding the Vegetables: Tomatoes");
        }

        protected override void AddCondiments()
        {
            Debug.Log("Adding the Condiments: Vinegar");
        }
    }


    /// <summary>
    /// 具体的模板策略2
    /// </summary>
    public class VeggieHoagie : Hoagie
    {
        protected override void AddMeat()
        {
        }

        protected override void AddCheese()
        {
        }

        protected override void AddVegetables()
        {
            Debug.Log("Adding the Vegetables: Tomatoes");
        }

        protected override void AddCondiments()
        {
            Debug.Log("Adding the Condiments: Vinegar");
        }

        protected override bool CustomerWantsMeat() { return false; }
        protected override bool CustomerWantsCheese() { return false; }

    }

    // Bad代码演示
    namespace BadExample
    {
        // this way you would have to rewrite a lot of code
        // especially if something changes or another class differs and does e.g. not AddMeat()
        //这样一来，你将不得不重写很多代码。
        // 特别是当某些东西改变了，或者另一个类不同，例如没有AddMeat()
        public class ItalienHoagie
        {
            public void MakeSandwich()
            {
                CutBun();
                AddMeat();
                AddCheese();
                AddVegtables();
                AddCondiments();
                WrapHoagie();
            }

            public void CutBun()
            {
                Debug.Log("Hoagie is Cut");
            }

            public void AddMeat()
            {
                Debug.Log("Added Meat");
            }

            public void AddCheese()
            {
                Debug.Log("Added Cheese");
            }

            public void AddVegtables()
            {
                Debug.Log("Added Vegies");
            }

            public void AddCondiments()
            {
                Debug.Log("Added Condiments");
            }

            public void WrapHoagie()
            {
                Debug.Log("Wrapped Hoagie");
            }
        }
    }
}