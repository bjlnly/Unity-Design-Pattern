//-------------------------------------------------------------------------------------
//	ObserverStructure.cs
//-------------------------------------------------------------------------------------


//[Definition]
//--------------------------------
// Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.
// 
// [Participants]
//--------------------------------
//  The classes and objects participating in this pattern are:
// 
// Subject
//      knows its observers.Any number of Observer objects may observe a subject
//      provides an interface for attaching and detaching Observer objects.
// ConcreteSubject
//      stores state of interest to ConcreteObserver
//      sends a notification to its observers when its state changes
// Observer
//      defines an updating interface for objects that should be notified of changes in a subject.
// ConcreteObserver
//      maintains a reference to a ConcreteSubject object
//      stores state that should stay consistent with the subject's
//      implements the Observer updating interface to keep its state consistent with the subject's


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObserverStructure : MonoBehaviour
{
    void Start()
    {
        // Configure Observer pattern
        // 设置具体的被观察者
        ConcreteSubject s = new ConcreteSubject();

        // 增加观察者
        s.Attach(new ConcreteObserver(s, "X"));
        s.Attach(new ConcreteObserver(s, "Y"));
        s.Attach(new ConcreteObserver(s, "Z"));

        // Change subject and notify observers
        // 修改被观察者的状态,然后通知观察者
        s.SubjectState = "ABC";
        s.Notify();
        // Change subject and notify observers again
        s.SubjectState = "666";
        s.Notify();
    }
}

/// <summary>
/// The 'Subject' abstract class 被观察的抽象类
/// </summary>
abstract class Subject
    {
        // 观察者列表
        private List<Observer> _observers = new List<Observer>();

        // 增加观察者
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        // 移除观察者
        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        // 推送消息
        public void Notify()
        {
            foreach (Observer o in _observers)
            {
                o.Update();
            }
        }
    }

    /// <summary>
    /// The 'ConcreteSubject' class 具体的被观察者
    /// </summary>
    class ConcreteSubject : Subject
    {
        // 状态--观察者关心的状态
        private string _subjectState;

        // Gets or sets subject state
        public string SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }
    }

    /// <summary>
    /// The 'Observer' abstract class 抽象的观察者
    /// </summary>
    abstract class Observer
    {
        // 抽象接口  供被观察者改变时通知使用
        public abstract void Update();
    }

    /// <summary>
    /// The 'ConcreteObserver' class 具体的观察者
    /// </summary>
    class ConcreteObserver : Observer
    {
        private string _name;
        // 状态 -- 与观察者保持一致
        private string _observerState;
        // 具体的观察对象 -- 引用的
        private ConcreteSubject _subject;

        // Constructor
        public ConcreteObserver(
          ConcreteSubject subject, string name)
        {
            // 引用到观察对象
            this._subject = subject;
            this._name = name;
        }

        public override void Update()
        {
            // 更新状态
            _observerState = _subject.SubjectState;
            Debug.Log("Observer "+ _name+"'s new state is "+_observerState);
    }

        // Gets or sets subject
        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }

