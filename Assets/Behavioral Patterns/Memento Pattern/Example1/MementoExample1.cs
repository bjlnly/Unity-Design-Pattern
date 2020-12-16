//-------------------------------------------------------------------------------------
//	MediatorExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

//This real-world code demonstrates the Memento pattern which temporarily saves and then restores the SalesProspect's internal state.
//这段真实世界的代码演示了Memento模式，
//它可以暂时保存然后恢复SalesProspect的内部状态。
namespace MementoExample1
{
    public class MementoExample1 : MonoBehaviour
    {
        void Start()
        {
            // 创建发起 并设置参数
            SalesProspect s = new SalesProspect();
            s.Name = "Bruce";
            s.Phone = "(412) 256-6666";
            s.Budget = 25000.0;

            // Store internal state
            // 存储状态,被传给备份管理
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento();

            // Continue changing originator
            // 继续修改源数据
            s.Name = "Oliver";
            s.Phone = "(310) 209-8888";
            s.Budget = 1000000.0;

            // Restore saved state
            // 恢复备份
            s.RestoreMemento(m.Memento);

        }
    }

    /// <summary>
    /// The 'Originator' class 发起类
    /// </summary>
    class SalesProspect
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Debug.Log("Name:  " + _name);
            }
        }

        // Gets or sets phone
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                Debug.Log("Phone: " + _phone);
            }
        }

        // Gets or sets budget
        public double Budget
        {
            get { return _budget; }
            set
            {
                _budget = value;
                Debug.Log("Budget: " + _budget);
            }
        }

        // Stores memento
        // 存储备份 返回备份
        public Memento SaveMemento()
        {
            Debug.Log("\nSaving state --\n");
            return new Memento(_name, _phone, _budget);
        }

        // Restores memento
        // 恢复备份
        public void RestoreMemento(Memento memento)
        {
            Debug.Log("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }

    /// <summary>
    /// The 'Memento' class 备份类
    /// </summary>
    class Memento
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Constructor
        public Memento(string name, string phone, double budget)
        {
            this._name = name;
            this._phone = phone;
            this._budget = budget;
        }

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or set phone
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        // Gets or sets budget
        public double Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
    }

    /// <summary>
    /// The 'Caretaker' class 备份类的管理
    /// </summary>
    class ProspectMemory
    {
        private Memento _memento;

        // Property
        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}