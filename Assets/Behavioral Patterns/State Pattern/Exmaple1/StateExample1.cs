//-------------------------------------------------------------------------------------
//	StateExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

//This real-world code demonstrates the State pattern which allows an Account to behave differently depending on its balance. 
//The difference in behavior is delegated to State objects called RedState, SilverState and GoldState. 
//These states represent overdrawn accounts, starter accounts, and accounts in good standing.
//这段真实世界的代码演示了状态模式，它允许一个账户根据其余额的不同而采取不同的行为。
//行为上的差异被委托给名为RedState、SilverState和GoldState的状态对象。
//这些状态代表透支账户、启动账户和信誉良好的账户。
namespace StateExample1
{
    public class StateExample1 : MonoBehaviour
    {
        void Start()
        {
            // Open a new account
            // 创建一个账户
            Account account = new Account("Jim Johnson");

            // Apply financial transactions
            // 账户做操作 但是其实账户的行为随着余额的不同会有不同反馈
            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);
        }
    }

    /// <summary>
    /// The 'State' abstract class 抽象状态
    /// </summary>
    abstract class State
    {
        // 持有账户的引用
        protected Account account;
        protected double balance;

        protected double interest;
        protected double lowerLimit;
        protected double upperLimit;

        // Properties
        public Account Account
        {
            get { return account; }
            set { account = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        // 声明具体的行为
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest();
    }


    /// <summary>
    /// A 'ConcreteState' class 具体的状态
    /// <remarks>
    /// Red indicates that account is overdrawn 透支 
    /// </remarks>
    /// </summary>
    class RedState : State
    {
        private double _serviceFee;

        // Constructor
        public RedState(State state)
        {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialize();
        }

        private void Initialize()
        {
            // Should come from a datasource
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            _serviceFee = 15.00;
        }

        // 红名下的具体行为
        // 存钱
        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        // 取钱
        public override void Withdraw(double amount)
        {
            amount = amount - _serviceFee;
            Debug.Log("No funds available for withdrawal!");
        }

        // 支付利息
        public override void PayInterest()
        {
            // No interest is paid
        }

        private void StateChangeCheck()
        {
            if (balance > upperLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }

    /// <summary>
    /// A 'ConcreteState' class 具体状态
    /// <remarks>
    /// Silver indicates a non-interest bearing state 银色代表无息
    /// </remarks>
    /// </summary>
    class SilverState : State
    {
        // Overloaded constructors

        public SilverState(State state) :
          this(state.Balance, state.Account)
        {
        }

        public SilverState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {
            // Should come from a datasource
            interest = 0.0;
            lowerLimit = 0.0;
            upperLimit = 1000.0;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance < lowerLimit)
            {
                account.State = new RedState(this);
            }
            else if (balance > upperLimit)
            {
                account.State = new GoldState(this);
            }
        }
    }

    /// <summary>
    /// A 'ConcreteState' class 具体状态3 
    /// <remarks>
    /// Gold indicates an interest bearing state 金色标识付息状态 
    /// </remarks>
    /// </summary>
    class GoldState : State
    {
        // Overloaded constructors
        public GoldState(State state)
          : this(state.Balance, state.Account)
        {
        }

        public GoldState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {
            // Should come from a database
            interest = 0.05;
            lowerLimit = 1000.0;
            upperLimit = 10000000.0;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance < 0.0)
            {
                account.State = new RedState(this);
            }
            else if (balance < lowerLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }

    /// <summary>
    /// The 'Context' class 上下文类 -- 账户
    /// </summary>
    class Account
    {
        // 私有状态
        private State _state;
        private string _owner;

        // Constructor
        public Account(string owner)
        {
            // New accounts are 'Silver' by default
            this._owner = owner;
            this._state = new SilverState(0.0, this);
        }

        //to fix the private field "_owner' is assigned but its value is never used warning
        public string GetOwner()
        {
            return _owner;
        }

        // Properties
        public double Balance
        {
            get { return _state.Balance; }
        }

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void Deposit(double amount)
        {
            _state.Deposit(amount);
            Debug.Log("Deposited " + amount + "---");
            Debug.Log(" Balance = " + this.Balance);
            Debug.Log(" Status = " + this.State.GetType().Name);
            Debug.Log("");
        }

        public void Withdraw(double amount)
        {
            _state.Withdraw(amount);
            Debug.Log("Deposited " + amount + "---");
            Debug.Log(" Balance = " + this.Balance);
            Debug.Log(" Status = " + this.State.GetType().Name + "\n");
        }

        public void PayInterest()
        {
            _state.PayInterest();
            Debug.Log("Interest Paid --- ");
            Debug.Log(" Balance = " + this.Balance);
            Debug.Log(" Status = " + this.State.GetType().Name);

        }
    }
}