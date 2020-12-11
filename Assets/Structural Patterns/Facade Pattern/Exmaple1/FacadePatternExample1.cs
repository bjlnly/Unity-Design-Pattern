//-------------------------------------------------------------------------------------
//	FacadePatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

//This real-world code demonstrates the Facade pattern as a MortgageApplication object which provides a simplified interface to a large subsystem of classes measuring the creditworthyness of an applicant.
//这段真实世界的代码展示了作为MortgageApplication对象的Facade模式，
//它为衡量申请人信用度的大型子系统提供了一个简化的接口。

namespace FacadePatternExample1
{
    public class FacadePatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Facade 创建一个外观类  贷款经理
            Mortgage mortgage = new Mortgage();

            // Evaluate mortgage eligibility for customer
            // 创建一个客户
            Customer customer = new Customer("Ann McKinsey");
            // 评定客户是否有资格贷款
            bool eligible = mortgage.IsEligible(customer, 125000);

            // 打印信息
            Debug.Log("\n" + customer.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));
        }
    }

    /// <summary>
    /// The 'Subsystem ClassA' class 子系统A 银行柜台
    /// </summary>
    class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Debug.Log("Check bank for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassB' class 子系统B信用调查部门
    /// </summary>
    class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Debug.Log("Check credit for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassC' class 子系统C贷款部门
    /// </summary>
    class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Debug.Log("Check loans for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// Customer class 客户类
    /// </summary>
    class Customer
    {
        private string _name;

        // Constructor
        public Customer(string name)
        {
            this._name = name;
        }

        // Gets the name
        public string Name
        {
            get { return _name; }
        }
    }

    /// <summary>
    /// The 'Facade' class 外观类. 抵押贷款经理
    /// </summary>
    class Mortgage 
    {
        private Bank _bank = new Bank();
        private Loan _loan = new Loan();
        private Credit _credit = new Credit();

        // 是否有资格接受贷款
        public bool IsEligible(Customer cust, int amount)
        {
            Debug.Log(cust.Name + "applies for " + amount+ " loan\n");

            bool eligible = true;

            // 检测客户的信用资质
            // Check creditworthyness of applicant
            if (!_bank.HasSufficientSavings(cust, amount))
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(cust))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}