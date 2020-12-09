//-------------------------------------------------------------------------------------
//	BridgePatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Bridge pattern in which a BusinessObject abstraction is decoupled from the implementation in DataObject.
//The DataObject implementations can evolve dynamically without changing any clients.
//这段真实的代码演示了桥接模式，在该模式中，BusinessObject抽象与DataObject中的实现分离。
//数据对象实现可以在不更改任何客户端的情况下动态扩展。
namespace BridgePatternExample1
{

    public class BridgePatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Create RefinedAbstraction
            // 创建精确的抽象类
            Customers customers = new Customers("Chicago");

            // Set ConcreteImplementor
            // 设置具体的实施对象
            customers.Data = new CustomersData();

            // Exercise the bridge
            // 桥来调用类
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Add("Henry Velasquez");

            customers.ShowAll();
        }
    }

    /// <summary>
    /// The 'Abstraction' class  抽象具体的类
    /// 只是一个桥 具体要操作哪个实施者的实体 它是不知道的
    /// </summary>
    class CustomersBase // 客户基类
    {
        // 具体抽象数据
        private DataObject _dataObject;
        protected string group;

        public CustomersBase(string group)
        {
            this.group = group;
        }

        // Property
        public DataObject Data
        {
            set { _dataObject = value; }
            get { return _dataObject; }
        }

        public virtual void Next()
        {
            _dataObject.NextRecord();
        }

        public virtual void Prior()
        {
            _dataObject.PriorRecord();
        }

        public virtual void Add(string customer)
        {
            _dataObject.AddRecord(customer);
        }

        public virtual void Delete(string customer)
        {
            _dataObject.DeleteRecord(customer);
        }

        public virtual void Show()
        {
            _dataObject.ShowRecord();
        }

        public virtual void ShowAll()
        {
            Debug.Log("Customer Group: " + group);
            _dataObject.ShowAllRecords();
        }
    }

    /// <summary>
    /// The 'RefinedAbstraction' class 精确的抽象类
    /// </summary>
    class Customers : CustomersBase
    {
        // Constructor
        public Customers(string group)
          : base(group)
        {
        }

        public override void ShowAll()
        {
            // Add separator lines
            Debug.Log("------------------------");
            base.ShowAll();
            Debug.Log("------------------------");
        }
    }

    /// <summary>
    /// The 'Implementor' abstract class  实施者的抽象
    /// </summary>
    abstract class DataObject// 数据
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract void ShowRecord();
        public abstract void ShowAllRecords();
    }

    /// <summary>
    /// The 'ConcreteImplementor' class 实施者的具体,对数据做具体操作
    /// </summary>
    class CustomersData : DataObject
    {
        private List<string> _customers = new List<string>();
        private int _current = 0;

        public CustomersData()
        {
            // Loaded from a database 
            _customers.Add("Jim Jones");
            _customers.Add("Samual Jackson");
            _customers.Add("Allen Good");
            _customers.Add("Ann Stills");
            _customers.Add("Lisa Giolani");
        }

        public override void NextRecord()
        {
            if (_current <= _customers.Count - 1)
            {
                _current++;
            }
        }

        public override void PriorRecord()
        {
            if (_current > 0)
            {
                _current--;
            }
        }

        public override void AddRecord(string customer)
        {
            _customers.Add(customer);
        }

        public override void DeleteRecord(string customer)
        {
            _customers.Remove(customer);
        }

        public override void ShowRecord()
        {
            Debug.Log(_customers[_current]);
        }

        public override void ShowAllRecords()
        {
            foreach (string customer in _customers)
            {
                Debug.Log(" " + customer);
            }
        }
    }
}