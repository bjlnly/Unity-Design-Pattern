//-------------------------------------------------------------------------------------
//	StateStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace StateStructure
{
    
    public class StateStructure : MonoBehaviour
    {
	    void Start ( )
        {
            // Setup context in a state
            // 创建上下文  构造入具体的状态
            Context c = new Context(new ConcreteStateA());

            // Issue requests, which toggles state
            // 请求
            c.Request();
            c.Request();
            c.Request();
            c.Request();
        }
    }

    /// <summary>
    /// The 'State' abstract class 抽象状态类
    /// </summary>
    abstract class State
    {
        // 定义接口用于执行具体行为
        public abstract void Handle(Context context);
    }

    /// <summary>
    /// A 'ConcreteState' class 具体的状态
    /// </summary>
    class ConcreteStateA : State
    {
        // 执行行为
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    /// <summary>
    /// A 'ConcreteState' class 具体状态B
    /// </summary>
    class ConcreteStateB : State
    {
        // 执行行为
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

    /// <summary>
    /// The 'Context' class 上下文
    /// </summary>
    class Context
    {
        // 持有抽象状态
        private State _state;

        // Constructor
        public Context(State state)
        {
            this.State = state;
        }

        // Gets or sets the state
        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
              Debug.Log("State: " +_state.GetType().Name);
            }
        }

        // 请求的时候 就调用当前状态的行为
        public void Request()
        {
            _state.Handle(this);
        }
    }

}