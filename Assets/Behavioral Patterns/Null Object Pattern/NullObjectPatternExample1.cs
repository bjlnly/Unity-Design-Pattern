using System;
using UnityEngine;

namespace Behavioral_Patterns.Null_Object_Pattern
{
    public class NullObjectPatternExample1:MonoBehaviour
    {
        private void Start()
        {
            // 定义一堆客户 有真有假
            AbstractCustomer customer1 = CustomerFactory.getCustomer("Rob");
            AbstractCustomer customer2 = CustomerFactory.getCustomer("Bob");
            AbstractCustomer customer3 = CustomerFactory.getCustomer("Julie");
            AbstractCustomer customer4 = CustomerFactory.getCustomer("Laura");
 
            // 打印客户信息
            Debug.Log("Customers");
            Debug.Log(customer1.getName());
            Debug.Log(customer2.getName());
            Debug.Log(customer3.getName());
            Debug.Log(customer4.getName());
        }
        /*
         *  Customers
            Rob
            Not Available in Customer Database
            Julie
            Not Available in Customer Database
         */
    }
    
    /// <summary>
    /// 抽象客户
    /// </summary>
    public abstract class AbstractCustomer {
        protected string name;
        public abstract bool isNil();
        public abstract string getName();
    }

    /// <summary>
    /// 真实用户
    /// </summary>
    public class RealCustomer : AbstractCustomer
    {

        public RealCustomer(string name)
        {
            this.name = name;
        }

        public override string getName()
        {
            return name;
        }

        public override bool isNil()
        {
            return false;
        }
    }

    /// <summary>
    /// Null Object
    /// </summary>
    public class NullCustomer : AbstractCustomer
    {

        public override string getName()
        {
            return "Not Available in Customer Database";
        }

        public override bool isNil()
        {
            return true;
        }
    }

    /// <summary>
    /// 客户工厂
    /// </summary>
    public class CustomerFactory
    {

        public static string[] names = {"Rob", "Joe", "Julie"};

        public static AbstractCustomer getCustomer(string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Equals(name))
                {
                    return new RealCustomer(name);
                }
            }

            return new NullCustomer();
        }
    }
}