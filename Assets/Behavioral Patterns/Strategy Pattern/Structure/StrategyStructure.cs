//-------------------------------------------------------------------------------------
//	StrategyStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace StrategyStructure
{
    public class StrategyStructure : MonoBehaviour
    {
	    void Start ( )
        {
            Context context;

            // Three contexts following different strategies
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();
        }
    }

    /// <summary>
    /// The 'Strategy' abstract class 抽象策略
    /// </summary>
    abstract class Strategy
    {
        // 提供统一接口给 Context使用
        public abstract void AlgorithmInterface();
    }

    /// <summary>
    /// A 'ConcreteStrategy' class 具体策略
    /// </summary>
    class ConcreteStrategyA : Strategy
    {
        // 实现策略接口
        public override void AlgorithmInterface()
        {
            Debug.Log("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class 具体策略B
    /// </summary>
    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class 具体策略C
    /// </summary>
    class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// The 'Context' class 选择策略的对象
    /// </summary>
    class Context
    {
        // 设置策略
        private Strategy _strategy;

        // Constructor
        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        // 实施策略
        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}