//-------------------------------------------------------------------------------------
//	VisitorPatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VisitorPatternExample2
{
    /// <summary>
    /// 继承不影响访问,因为元素本身都继承了抽象的接口
    /// </summary>
    public class VisitorPatternExample2 : MonoBehaviour
    {
        void Start()
        {
            // Setup employee collection
            // 设置员工结构,并加入员工
            Employees e = new Employees();
            e.Attach(new Clerk());
            e.Attach(new Director());
            e.Attach(new President());

            // Employees are 'visited'
            // 赋予行政和财务访问员工的权限,并让其进行不同的操作
            e.Accept(new IncomeVisitor());
            e.Accept(new VacationVisitor());
        }


        /// <summary>
        /// The 'Visitor' interface 抽象的Visitor
        /// </summary>
        interface IVisitor
        {
            // 定义Visit方法,传入element
            void Visit(Element element);
        }

        /// <summary>
        /// A 'ConcreteVisitor' class 具体的Visitor
        /// </summary>
        class IncomeVisitor : IVisitor
        {
            // 实现Visitor方法,操作element
            public void Visit(Element element)
            {
                Employee employee = element as Employee;

                // Provide 10% pay raise
                employee.Income *= 1.10;

                Debug.Log(string.Format("{0} {1}'s new income: {2:C}",
                  employee.GetType().Name, employee.Name,
                  employee.Income));
            }
        }

        /// <summary>
        /// A 'ConcreteVisitor' class 具体的visitor
        /// </summary>
        class VacationVisitor : IVisitor
        {
            // 实现visit方法,操作element
            public void Visit(Element element)
            {
                Employee employee = element as Employee;

                // Provide 3 extra vacation days
                employee.VacationDays += 3;
                Debug.Log(string.Format("{0} {1}'s new vacation days: {2}",
                  employee.GetType().Name, employee.Name,
                  employee.VacationDays));
            }
        }

        /// <summary>
        /// The 'Element' abstract class 抽象的元素
        /// </summary>
        abstract class Element
        {
            // 定义Accept方法,用于把自己传给Visitor
            public abstract void Accept(IVisitor visitor);
        }

        /// <summary>
        /// The 'ConcreteElement' class 具体的Element
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
            /// 实现Accept方法,把自己传给Visitor
            /// </summary>
            /// <param name="visitor"></param>
            public override void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        /// <summary>
        /// The 'ObjectStructure' class 数据结构类 Structure
        /// </summary>
        class Employees
        {
            // 维护element的列表
            private List<Employee> _employees = new List<Employee>();

            public void Attach(Employee employee)
            {
                _employees.Add(employee);
            }

            public void Detach(Employee employee)
            {
                _employees.Remove(employee);
            }

            /// <summary>
            /// 提供接口,可以让Visitor访问到element
            /// </summary>
            /// <param name="visitor"></param>
            public void Accept(IVisitor visitor)
            {
                foreach (Employee e in _employees)
                {
                    e.Accept(visitor);
                }
            }
        }

        // Three employee types

        /// <summary>
        /// 元素的继承
        /// </summary>
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

}

