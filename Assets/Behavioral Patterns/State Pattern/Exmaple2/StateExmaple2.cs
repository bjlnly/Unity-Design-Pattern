//-------------------------------------------------------------------------------------
//	StateExmaple2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace StateExmaple2
{
    public class StateExmaple2 : MonoBehaviour
    {
        void Start()
        {
            // 创建atm机  执行各种操作  状态在内部转化
            ATMMachine atm = new ATMMachine();
            atm.InsertCard();
            atm.EjectCard();
            atm.InsertCard();
            atm.InsertPin(1234);
            atm.RequestCash(2000);
            atm.InsertCard();
            atm.InsertPin(1234);
        }
    }

    // State Interface
    // 状态接口
    public interface ATMState
    {
        // 声明行为
        void InsertCard();
        void EjectCard();
        void InsertPin(int pinEntered);
        void RequestCash(int cash);
    }


    // ATM机器
    public class ATMMachine
    {
        public ATMState hasCard { get; protected set; }
        public ATMState noCard { get; protected set; }
        public ATMState hasCorrectPin { get; protected set; }
        public ATMState atmOutOfMoney { get; protected set; }

        public ATMState atmState { get; protected set; }

        public int cashInMachine = 2000;
        public bool correctPinEntered = false;

        public ATMMachine()
        {
            hasCard = new HasCard(this);
            noCard = new NoCard(this);
            hasCorrectPin = new HasPin(this);
            atmOutOfMoney = new NoCash(this);

            atmState = noCard;

            if (cashInMachine < 0)
            {
                atmState = atmOutOfMoney;
            }
        }

        // 设置状态
        public void SetATMState(ATMState state)
        {
            atmState = state;
        }

        public void SetCashInMachine(int newCash)
        {
            cashInMachine = newCash;
        }

        // 对外的表现
        //===================================================================================
        // 这里是我们需要实现的Proxy设计模式中的方法，以使接口正常工作
        // 但请记住：ATMMachine的以下方法与状态机模式没有任何关系。
        //===================================================================================
        public void InsertCard()
        {
            atmState.InsertCard();
        }

        public void EjectCard()
        {
            atmState.EjectCard();
        }

        public void RequestCash(int cash)
        {
            atmState.RequestCash(cash);
        }

        public void InsertPin(int pin)
        {
            atmState.InsertPin(pin);
        }

        //===================================================================================
        // Here come the Methods we need to implement from the Proxy Design Pattern to make the interface work
        // but remember: the following methods for ATMMachine don't have anything to do with the state machine pattern
        //===================================================================================
        
        public ATMState GetCurrentState()
        {
            return atmState;
        }

        public int GetCashInMachine()
        {
            return cashInMachine;
        }

    }




    /// <summary>
    /// 具体的状态  -- 有卡插入
    /// </summary>
    public class HasCard : ATMState
    {
        protected ATMMachine atm;

        public HasCard(ATMMachine atm)
        {
            this.atm = atm;
        }

        public void InsertCard()
        {
            Debug.Log("You can't enter one than more card");
        }

        public void EjectCard()
        {
            Debug.Log("Card ejected.");
            atm.SetATMState(atm.noCard);
        }

        public void InsertPin(int pinEntered)
        {
            if (pinEntered == 1234)
            {
                Debug.Log("Correct pin entered.");
                atm.correctPinEntered = true;
                atm.SetATMState(atm.hasCorrectPin);
            }
            else
            {
                Debug.Log("False pin entered.");
                atm.correctPinEntered = false;
                Debug.Log("Card ejected.");
                atm.SetATMState(atm.noCard);
            }
        }

        public void RequestCash(int cash)
        {
            Debug.Log("Enter pin first.");
        }
    }


/// <summary>
/// 无卡状态
/// </summary>
    public class NoCard : ATMState
    {
        protected ATMMachine atm;

        public NoCard(ATMMachine atm)
        {
            this.atm = atm;
        }

        public void InsertCard()
        {
            Debug.Log("Card inserted");
            atm.SetATMState(atm.hasCard);
        }

        public void EjectCard()
        {
            Debug.Log("Enter a card first.");
        }

        public void InsertPin(int pinEntered)
        {
            Debug.Log("Enter a card first.");
        }

        public void RequestCash(int cash)
        {
            Debug.Log("Enter a card first.");
        }
    }


/// <summary>
/// PIN输入的状态
/// </summary>
    public class HasPin : ATMState
    {
        protected ATMMachine atm;

        public HasPin(ATMMachine atm)
        {
            this.atm = atm;
        }

        public void InsertCard()
        {
            Debug.Log("You can't enter one than more card");
        }

        public void EjectCard()
        {
            Debug.Log("Card ejected.");
            atm.SetATMState(atm.noCard);
        }

        public void InsertPin(int pinEntered)
        {
            Debug.Log("Pin already entered.");
        }

        public void RequestCash(int cash)
        {
            if (cash <= atm.cashInMachine)
            {
                Debug.Log(cash + " provided by machine");
                atm.cashInMachine -= cash;
                atm.SetATMState(atm.noCard);

                if (atm.cashInMachine <= 0)
                {
                    atm.SetATMState(atm.atmOutOfMoney);
                }

                Debug.Log("Card ejected.");
            }
            else
            {
                Debug.Log("Don't have enough cash");
                atm.SetATMState(atm.noCard);
                Debug.Log("Card ejected.");
            }
        }
    }


/// <summary>
/// 无钞状态
/// </summary>
    public class NoCash : ATMState
    {
        protected ATMMachine atm;

        public NoCash(ATMMachine atm)
        {
            this.atm = atm;
        }

        public void InsertCard()
        {
            Debug.Log("We don't have no money");
        }

        public void EjectCard()
        {
            Debug.Log("We don't have no money, you didn't enter a card");
        }

        public void InsertPin(int pinEntered)
        {
            Debug.Log("We don't have no money");
        }

        public void RequestCash(int cash)
        {
            Debug.Log("We don't have no money");
        }
    }
}
