//-------------------------------------------------------------------------------------
//	ChainOfResponsibilityExample1.cs
//-------------------------------------------------------------------------------------

//This real-world code demonstrates the Chain of Responsibility pattern in which several linked 
//managers and executives can respond to a purchase request or hand it off to a superior. 
//Each position has can have its own set of rules which orders they can approve.
//这段真实世界的代码展示了责任链模式，其中有几个相互关联的环节。
//管理人员和行政人员可以对采购请求作出反应，也可以将其交给上级。
//每个职位可以有自己的一套规则，他们可以批准哪些订单。


using UnityEngine;
using System.Collections;

namespace ChainOfResponsibilityExample1
{ 
    public class ChainOfResponsibilityExample1 : MonoBehaviour
    {
	    void Start ( )
        {
            // Setup Chain of Responsibility
            // 创建一个责任链
            Approver larry = new Director();
            Approver sam = new VicePresident();
            Approver tammy = new President();

            //主任转给副总裁 副总裁转给总裁
            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);

            // Generate and process purchase requests
            Purchase p = new Purchase(2034, 350.00, "Assets");
            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);

        }
    }

    /// <summary>
    /// The 'Handler' abstract class 抽象的责任人
    /// </summary>
    abstract class Approver
    {
        // 可被设置的下一层责任人
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        // 抽象的执行请求方法
        public abstract void ProcessRequest(Purchase purchase);
    }

    /// <summary>
    /// The 'ConcreteHandler' class 具体的责任人 主任
    /// </summary>
    class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0) // 10000权限
            {
                Debug.Log(this.GetType().Name+" approved request# "+purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler' class 具体的责任人 副总裁
    /// </summary>
    class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)// 25000权限
            {
                Debug.Log(this.GetType().Name + " approved request# " + purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler' class 具体的责任人 总裁
    /// </summary>
    class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0) // 100000权限
            {
                Debug.Log(this.GetType().Name + " approved request# " + purchase.Number);
            }
            else
            {
                Debug.Log("Request# "+purchase.Number+ "requires an executive meeting!");
            }
        }
    }

    /// <summary>
    /// Class holding request details 购买请求
    /// </summary>
    class Purchase 
    {
        private int _number;
        private double _amount;
        private string _purpose;

        // Constructor
        public Purchase(int number, double amount, string purpose)
        {
            this._number = number;
            this._amount = amount;
            this._purpose = purpose;
        }

        // Gets or sets purchase number
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        // Gets or sets purchase amount
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        // Gets or sets purchase purpose
        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }
    }
}