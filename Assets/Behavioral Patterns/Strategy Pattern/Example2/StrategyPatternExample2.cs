//-------------------------------------------------------------------------------------
//	StrategyPatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace StrategyPatternExample2
{
    public class StrategyPatternExample2 : MonoBehaviour
    {
        void Start()
        {
            // create dog and bird example objects
            // 创建实体类对象
            Animal sparky = new Dog();
            Animal tweety = new Bird();

            // 尝试执行策略
            Debug.Log("Dog: " + sparky.TryToFly());
            Debug.Log("Bird: " + tweety.TryToFly());

            // change behaviour of dog
            // 修改策略
            sparky.SetFlyingAbility(new ItFlys());

            // 再尝试执行策略
            Debug.Log("Dog: " + sparky.TryToFly());
            Debug.Log("Bird: " + tweety.TryToFly());
        }
    }


    // Using Interfaces for decoupling
    // putting behaviour that varies in different classes
    // 使用接口进行解耦
    // 把不同的行为放在不同的类中
    // 这就是个抽象策略
    public interface IFly
    {
        string Fly();
    }

    // Class that holds behaviour for objects that can fly
    // 具体策略
    class ItFlys : IFly
    {
        public string Fly()
        {
            return "Flying high";
        }
    }

    // Class that holds behaviour for objects that can not fly
    class CantFly : IFly
    {
        public string Fly()
        {
            return "I can't fly";
        }
    }

    class FlyingSuperFast : IFly
    {
        public string Fly()
        {
            return "Fly super fast";
        }
    }


    // Classes that hold an instance of the behaviours above:
    // 策略选择执行者
    public class Animal
    {
        // hereby adding the behaviour
        // it also can change that way
        // 组合一个策略
        public IFly flyingType;

        // 实施策略
        public string TryToFly()
        {
            return flyingType.Fly();
        }

        // 设置策略
        public void SetFlyingAbility(IFly newFlyingType)
        {
            this.flyingType = newFlyingType;
        }
    }

    // derived objects that vary from the base Animal:
    // 具体执行者
    public class Dog : Animal
    {
        public Dog()
        {
            flyingType = new CantFly();
        }
    }

    public class Bird : Animal
    {
        public Bird()
        {
            flyingType = new ItFlys();
        }
    }
}

// Rembember:
// ALWAYS
// eliminate duplicate code
// eliminate technices that allow one class to affect others
// 消除重复的代码
// 消除允许一个类影响其他类的技术。