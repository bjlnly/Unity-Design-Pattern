//-------------------------------------------------------------------------------------
//	ObserverExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Observer pattern in which registered investors are notified every time a stock changes value.
//这段真实世界的代码展示了观察者模式，即每当股票价值变化时，注册投资者都会得到通知。
namespace ObserverExample1
{
    public class ObserverExample1 : MonoBehaviour
    {
        void Start()
        {
            // Create IBM stock and attach investors
            // 创建具体的股票  并绑定注册投资者
            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors
            // 价格变动
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

        }
    }

    /// <summary>
    /// The 'Subject' abstract class 抽象Subject
    /// </summary>
    abstract class Stock
    {
        private string _symbol;
        private double _price;
        // 维护观察者的列表
        private List<IInvestor> _investors = new List<IInvestor>();

        // Constructor
        public Stock(string symbol, double price)
        {
            this._symbol = symbol;
            this._price = price;
        }

        // 增加观察者
        public void Attach(IInvestor investor)
        {
            _investors.Add(investor);
        }

        // 移除观察者
        public void Detach(IInvestor investor)
        {
            _investors.Remove(investor);
        }

        // 通知观察者
        public void Notify()
        {
            foreach (IInvestor investor in _investors)
            {
                investor.Update(this);
            }

            Debug.Log("Stock Notify( ) called");
        }

        // Gets or sets the price
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    // 价格真正变动 通知
                    Notify();
                }
            }
        }

        // Gets the symbol
        public string Symbol
        {
            get { return _symbol; }
        }
    }

    /// <summary>
    /// The 'ConcreteSubject' class 具体的Subject -- IBM的股票
    /// </summary>
    class IBM : Stock
    {
        // Constructor
        public IBM(string symbol, double price)
          : base(symbol, price)
        {
        }
    }

    /// <summary>
    /// The 'Observer' interface 观察者的接口 -- 投资者
    /// </summary>
    interface IInvestor
    {
        // 定义通知接口
        void Update(Stock stock);
    }

    /// <summary>
    /// The 'ConcreteObserver' class 具体的观察者 -- 具体投资者
    /// </summary>
    class Investor : IInvestor
    {
        private string _name;
        // 持有观察的引用
        private Stock _stock;

        // Constructor
        public Investor(string name)
        {
            this._name = name;
        }

        // 实现观察者的通用接口
        public void Update(Stock stock)
        {
            //Debug.Log("Notified {0} of {1}'s " +"change to {2:C}", _name, stock.Symbol, stock.Price);
            Debug.Log("Notified "+ _name+" of "+ stock+"'s " + "change to "+stock.Price);
        }

        // Gets or sets the stock
        public Stock Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
    }
}
