//-------------------------------------------------------------------------------------
//	VisitorPatternExample1.cs
//-------------------------------------------------------------------------------------

//This real-world code demonstrates the Visitor pattern in which two objects traverse a list of Employees and performs the same operation on each Employee. 
//The two visitor objects define different operations -- one adjusts vacation days and the other income.
//这段真实世界的代码演示了Visitor模式，其中两个对象遍历了一个雇员列表，并对每个雇员执行相同的操作。
//这两个访问者对象定义了不同的操作--一个调整假期，另一个调整收入。
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VisitorPatternExample1
{
    public class VisitorPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Setup employee collection
            // 设置structure,并加入element
            Employees e = new Employees();
            e.Attach(new Clerk());
            e.Attach(new Director());
            e.Attach(new President());

            // Employees are 'visited'
            // structure通过Accept允许Visitor访问element
            e.Accept(new IncomeVisitor());
            e.Accept(new VacationVisitor());

        }
    }

    /// <summary>
    /// The 'Visitor' interface 抽象的访问者
    /// </summary>
    interface IVisitor
    {
        // 定义visit接口,传入element
        void Visit(Element element);
    }

    /// <summary>
    /// A 'ConcreteVisitor' class 具体的visitor
    /// </summary>
    class IncomeVisitor : IVisitor
    {
        // 实现visit接口 操作element
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Debug.Log(employee.GetType().Name+" "+ employee.Name+"'s new income: "+employee.Income);
        }
    }

    /// <summary>
    /// A 'ConcreteVisitor' class 具体的visitor2
    /// </summary>
    class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 3 extra vacation days
            employee.VacationDays += 3;
            Debug.Log(employee.GetType().Name + " " + employee.Name + "'s new vacation days:" + employee.VacationDays);
        }
    }

    /// <summary>
    /// The 'Element' abstract class 抽象的element
    /// </summary>
    abstract class Element
    {
        // 定义抽象的Accept方法,传入visitor接口
        public abstract void Accept(IVisitor visitor);
    }

    /// <summary>
    /// The 'ConcreteElement' class 具体的element
    /// </summary>
    class Employee : Element
    {
        private string _name;
        private double _income;
        private int _vacationDays;

        // Constructor
        public Employee(string name, double income,
          int vacationDays)
        {
            this._name = name;
            this._income = income;
            this._vacationDays = vacationDays;
        }

        // Gets or sets the name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or sets income
        public double Income
        {
            get { return _income; }
            set { _income = value; }
        }

        // Gets or sets number of vacation days
        public int VacationDays
        {
            get { return _vacationDays; }
            set { _vacationDays = value; }
        }

        /// <summary>
        /// 实现Accept方法,将自己传给visitor
        /// </summary>
        /// <param name="visitor"></param>
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// The 'ObjectStructure' class 结构Structure
    /// </summary>
    class Employees
    {
        // 维护element列表/集合
        private List<Employee> _employees = new List<Employee>();

        public void Attach(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            _employees.Remove(employee);
        }

        // 实现方法可以让Visitor访问到element
        public void Accept(IVisitor visitor)
        {
            foreach (Employee e in _employees)
            {
                e.Accept(visitor);
            }
        }
    }

    // Three employee types

    class Clerk : Employee
    {
        // Constructor
        public Clerk()
          : base("Hank", 25000.0, 14)
        {
        }
    }

    class Director : Employee
    {
        // Constructor
        public Director()
          : base("Elly", 35000.0, 16)
        {
        }
    }

    class President : Employee
    {
        // Constructor
        public President()
          : base("Dick", 45000.0, 21)
        {
        }
    }
}