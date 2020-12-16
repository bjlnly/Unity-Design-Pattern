//-------------------------------------------------------------------------------------
//	MementoStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class MementoStructure : MonoBehaviour
{
	void Start ( )
    {
        // 创建备份发起者
        Originator o = new Originator();
        // 设置状态
        o.State = "On";

        // Store internal state
        // 创建存储控制,并创建备份
        Caretaker c = new Caretaker();
        c.Memento = o.CreateMemento();

        // Continue changing originator
        // 继续设置状态
        o.State = "Off";

        // Restore saved state
        // 恢复备份的状态
        o.SetMemento(c.Memento);

    }
}

/// <summary>
/// The 'Originator' class 发起类
/// </summary>
class Originator
{
    private string _state;

    // Property
    public string State
    {
        get { return _state; }
        set
        {
            _state = value;
            Debug.Log("State = " + _state);
        }
    }

    // Creates memento 
    // 创建备份
    public Memento CreateMemento()
    {
        return (new Memento(_state));
    }

    // Restores original state
    // 恢复备份
    public void SetMemento(Memento memento)
    {
        Debug.Log("Restoring state...");
        State = memento.State;
    }
}

/// <summary>
/// The 'Memento' class 备份类
/// </summary>
class Memento
{
    private string _state;

    // Constructor
    public Memento(string state)
    {
        this._state = state;
    }

    // Gets or sets state
    public string State
    {
        get { return _state; }
    }
}

/// <summary>
/// The 'Caretaker' class 备份管理类
/// </summary>
class Caretaker
{
    private Memento _memento;

    // Gets or sets memento
    public Memento Memento
    {
        set { _memento = value; }
        get { return _memento; }
    }
}
