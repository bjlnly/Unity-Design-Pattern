//-------------------------------------------------------------------------------------
//	MediatorExample2.cs
//-------------------------------------------------------------------------------------

/*
 * It is used to handle communication between related objects(Colleagues)
 *
 * All communication is handled by the mediator
 * the colleagues don't need to know anything about each other
 *
 * GOF: Allows loose coupling by encapsulating the way disparate sets of objects
 * interact and communicate with each other.Allows for the actions
 * of each object set to vary independently of one another
 *
 *
 **/

/*
 * 用于处理相关对象之间的通信（同事）。
 *
 * 所有通信均由调解人处理。
 * 同事们不需要知道对方的任何事情
 *
 * GOF：通过封装不同对象集的方式，允许松散耦合。
 * 彼此互动和交流。
 * 每个对象集的数量相互独立地变化。
 *
 *
 **/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MediatorExample2
{

    public class MediatorExample2 : MonoBehaviour
    {
	    void Start ( )
	    {
            // 股票中介
            StockMediator nyse = new StockMediator();

            // important here is:
            // in this example they both might be doing nothing different, but
            // they could be totally different objects and calculate stuff different or so
            // but still be able to talk to the mediator the same easy way
            // that's why we have different objects here:
            //重要的是：
            //在这个例子中，他们两个可能做的事情没有什么不同，但是。
            // 它们可能是完全不同的对象，或者计算的东西也不一样
            //但仍能以同样简单的方式与调解人交谈。
            //这就是为什么我们在这里有不同的对象。
            GormanSlacks broker = new GormanSlacks(nyse);
            JTPoorman broker2 = new JTPoorman(nyse);

            nyse.AddColleague(broker);
            nyse.AddColleague(broker2);

            // because they call methods on the same mediator object they talk to the same mediator
            // who handles all the stock exanche and keeps track of that. so the brokers by themselves
            // don't know anything about each other. which is a good thing :-)
            // 因为它们调用同一中介对象上的方法，所以它们与同一中介对话。
            // 中介处理所有的股票外流，并保持跟踪，所以经纪人自己
            // 彼此都不知道对方的情况，这是件好事:-)
            broker.SaleOffer(Stock.MSFT, 100);
            broker.SaleOffer(Stock.GOOG, 50);

            broker2.BuyOffer(Stock.MSFT, 100);
            broker2.SaleOffer(Stock.NRG, 10);

            broker.BuyOffer(Stock.NRG, 10);
            broker.BuyOffer(Stock.NRG, 50);

            nyse.PrintStockOfferings();
        }


    }

    // I like using enums more than using strings
    // because it prevents typos and I don't need to remember strings ;)
    // 比起使用字符串，我更喜欢使用枚举。
    // 因为它可以防止打字错误，而且我不需要记住字符串;)
    public enum Stock
    {
        MSFT,
        GOOG,
        NRG
    };


    /// <summary>
    /// 股票提供者
    /// </summary>
    public class StockOffer
    {
        public int stockShares { get; private set; }
        public Stock stock { get; private set; }
        public int colleagueCode { get; private set; }

        public StockOffer(int numOfShares, Stock stock, int collCode)
        {
            this.stockShares = numOfShares;
            this.stock = stock;
            this.colleagueCode = collCode;
        }
    }


    /// <summary>
    /// 抽象用户
    /// </summary>
    public abstract class Colleague
    {
        // 了解中介
        private Mediator mediator;
        private int colleagueCode;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public void SetCode(int code)
        {
            colleagueCode = code;
        }

        public void SaleOffer(Stock stock, int shares)
        {
            mediator.SaleOffer(stock, shares, this.colleagueCode);
        }

        public void BuyOffer(Stock stock, int shares)
        {
            mediator.BuyOffer(stock, shares, this.colleagueCode);
        }
    }


    /// <summary>
    /// 具体用户 Gorman Slacks
    /// </summary>
    public class GormanSlacks : Colleague
    {
        // using : base() like here calls the constructor of the base class with the arguments passed in
        // here it calls "Colleague(Mediator mediator)"
        // 像这里一样使用 : base() 调用基类的构造函数，并将参数传入。
        //这里它调用 "Colleague(Mediator mediator)"
        public GormanSlacks(Mediator mediator) : base(mediator)
        {
            Debug.Log("Gorman Slacks signed up with the stockexange");
        }
    }

    /// <summary>
    /// 具体用户2 JT Poorman
    /// </summary>
    public class JTPoorman : Colleague
    {
        public JTPoorman(Mediator mediator) : base(mediator)
        {
            Debug.Log("JT Poorman signed up with the stockexange");
        }
    }






    /// <summary>
    /// 抽象中介者
    /// </summary>
    public interface Mediator
    {
        // 增加同事
        void AddColleague(Colleague colleague);
        // 卖出
        void SaleOffer(Stock stock, int shares, int code);
        // 买入
        void BuyOffer(Stock stock, int shares, int code);
    }


    /// <summary>
    /// 股票中介者
    /// </summary>
    public class StockMediator : Mediator
    {
        private List<Colleague> colleagues;
        private List<StockOffer> buyOffers;
        private List<StockOffer> sellOffers;

        private int colleagueCodes = 0;

        public StockMediator()
        {
            colleagues = new List<Colleague>();
            buyOffers = new List<StockOffer>();
            sellOffers = new List<StockOffer>();
        }

        #region Mediator implementation
        public void AddColleague(Colleague colleague)
        {
            this.colleagues.Add(colleague);
            colleagueCodes += 1;
            colleague.SetCode(colleagueCodes);
        }

        // 卖出
        public void SaleOffer(Stock stock, int shares, int code)
        {
            bool stockSold = false;

            // see if someone is willing to buy:
            for (int i = 0; i < buyOffers.Count; i++)
            {
                StockOffer offer = buyOffers[i];
                // check if the stock is the same:
                if (offer.stock == stock && offer.stockShares == shares)
                {
                    Debug.Log(shares + " shares of " + stock + " stocks sold to colleague with code " + code);

                    buyOffers.Remove(offer);
                    stockSold = true;
                }

                if (stockSold) break;
            }

            if (!stockSold)
            {
                Debug.Log(shares + " shares of " + stock + " stocks added to inventory");
                StockOffer offer = new StockOffer(shares, stock, code);
                sellOffers.Add(offer);
            }
        }

        public void BuyOffer(Stock stock, int shares, int code)
        {
            bool stockBought = false;

            // see if someone is willing to buy:
            // 找到所有卖方
            for (int i = 0; i < sellOffers.Count; i++)
            {
                StockOffer offer = sellOffers[i];
                // check if the stock is the same:
                // 检测有没有需求一样的卖方
                if (offer.stock == stock && offer.stockShares == shares)
                {
                    Debug.Log(shares + " shares of " + stock + " stocks bought by colleague with code " + code);

                    sellOffers.Remove(offer);
                    stockBought = true;
                }

                if (stockBought) break;
            }

            // 如果股票没有买成功, 加入买方列表
            if (!stockBought)
            {
                Debug.Log(shares + " shares of " + stock + " stocks added to inventory");
                StockOffer offer = new StockOffer(shares, stock, code);
                buyOffers.Add(offer);
            }
        }
        #endregion


        // 打印交易者的信息
        public void PrintStockOfferings()
        {
            Debug.Log("For Sale: " + sellOffers.Count);
            foreach (StockOffer offer in sellOffers)
            {
                Debug.Log(offer.stock + " - " + offer.stockShares + " - " + offer.colleagueCode);
            }


            Debug.Log("For Buy: " + buyOffers.Count);
            foreach (StockOffer offer in buyOffers)
            {
                Debug.Log(offer.stock + " - " + offer.stockShares + " - " + offer.colleagueCode);
            }
        }
    }

}