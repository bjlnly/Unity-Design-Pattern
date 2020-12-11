//-------------------------------------------------------------------------------------
//	FacadePatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace FacadePatternExample2
{
    public class FacadePatternExample2 : MonoBehaviour
    {
        void Start()
        {
            // 账号密码登录银行
            BankAccountFacade bankAccount = new BankAccountFacade(12345678, 1234);

            // 取款
            Debug.Log("\"I want to withdraw $50 dollars!\"");
            bankAccount.WithdrawCash(50.00);

            // 取款
            Debug.Log("\"Mh ok now let me withdraw $5000 dollars!?\"");
            bankAccount.WithdrawCash(5000.00);

            //存款
            Debug.Log("\"What tf... maybe save some cash, here are $300 bucks ;-)\"");
            bankAccount.DepositCash(300.00);
        }
    }

    /// <summary>
    /// 账号启动类 -- 子系统
    /// </summary>
    public class WelcomeToBank
    {
        public WelcomeToBank()
        {
            Debug.Log("Welcome to ABC Bank");
            Debug.Log("We are happy to deposit your money :-)");
        }
    }

    /// <summary>
    /// 账号核对类 -- 子系统
    /// </summary>
    public class AccountNumberCheck
    {
        private int accountNumber = 12345678;

        public int GetAccountNumber()
        {
            return accountNumber;
        }

        public bool AccountActive(int accNumber)
        {
            if (accNumber == accountNumber)
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// 安全码检测类 -- 子系统 
    /// </summary>
    public class SecurityCodeCheck
    {
        private int securityCode = 1234;

        public int GetSecurityCode()
        {
            return securityCode;
        }

        public bool IsCodeCorrect(int code)
        {
            if (code == securityCode)
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// 支票检测 -- 子系统
    /// </summary>
    public class FundsCheck
    {
        private double cashInAccount = 1000.00;

        public double GetCashInAccount()
        {
            return cashInAccount;
        }

        protected void DecreaseCashInAccount(double cash)
        {
            cashInAccount -= cash;
        }

        protected void IncreaseCashInAccount(double cash)
        {
            cashInAccount += cash;
        }

        public bool HaveEnoughMoney(double cashToWithdraw)
        {
            if (cashToWithdraw > GetCashInAccount())
            {
                Debug.Log("You don't have enouth money.");
                return false;
            }
            else
            {
                return true;
            }
        }

        // 存款
        public void MakeDeposit(double cash)
        {
            IncreaseCashInAccount(cash);
            Debug.Log("Deposit complete. Current Balance is: " + GetCashInAccount());
        }

        // 取款
        public void WithdrawMoney(double cash)
        {
            DecreaseCashInAccount(cash);
            Debug.Log("Withdraw complete. Current Balance is: " + GetCashInAccount());
        }
    }

    /// <summary>
    /// 银行账户外观
    /// 存取款之前,要校验客户的账号和安全码 
    /// </summary>
    public class BankAccountFacade
    {
        private int accountNumber;
        private int securityCode;
        AccountNumberCheck accChecker;
        SecurityCodeCheck codeChecker;
        FundsCheck fundChecker;
        WelcomeToBank bankWelcome;

        public BankAccountFacade(int accountNumber, int newSecurityCode)
        {
            this.accountNumber = accountNumber;
            this.securityCode = newSecurityCode;

            bankWelcome = new WelcomeToBank();
            codeChecker = new SecurityCodeCheck();
            accChecker = new AccountNumberCheck();
            fundChecker = new FundsCheck();
        }

        public int GetAccountNumber()
        {
            return accountNumber;
        }

        public int GetSecurityCode()
        {
            return securityCode;
        }

        public void WithdrawCash(double cash)
        {
            if (accChecker.AccountActive(GetAccountNumber())
                && codeChecker.IsCodeCorrect(GetSecurityCode())
                && fundChecker.HaveEnoughMoney(cash))
            {
                fundChecker.WithdrawMoney(cash);
                Debug.Log("Transaction complete.");
            }
            else
            {
                Debug.Log("Transaction failed.");
            }
        }

        public void DepositCash(double cash)
        {
            if (accChecker.AccountActive(GetAccountNumber())
                && codeChecker.IsCodeCorrect(GetSecurityCode()))
            {
                fundChecker.MakeDeposit(cash);
                Debug.Log("Transaction complete.");
            }
            else
            {
                Debug.Log("Transaction failed.");
            }
        }
    }

}