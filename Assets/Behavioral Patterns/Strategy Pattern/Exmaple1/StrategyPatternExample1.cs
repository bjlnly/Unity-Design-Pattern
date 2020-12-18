//-------------------------------------------------------------------------------------
//	StrategyPatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Strategy pattern which encapsulates sorting algorithms in the form of sorting objects. 
//This allows clients to dynamically change sorting strategies including Quicksort, Shellsort, and Mergesort.
//这段真实世界的代码展示了策略模式，它以排序对象的形式封装了排序算法。
//这允许客户动态地改变排序策略，包括Quicksort、Shellsort和Mergesort。
namespace StrategyPatternExample1
{
    public class StrategyPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Two contexts following different strategies
            // 下面的Context 被设置了不同的策略 
            SortedList studentRecords = new SortedList();

            // 接入基本数据
            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            // 选用不同策略
            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();

        }
    }

    /// <summary>
    /// The 'Strategy' abstract class 抽象策略 -- 排序算法
    /// </summary>
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    /// <summary>
    /// A 'ConcreteStrategy' class 具体策略 -- 快速排序
    /// </summary>
    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort(); // Default is Quicksort
            Debug.Log("-------QuickSorted list------- ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class 具体策略 -- shell 排序
    /// </summary>
    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort(); not-implemented
            Debug.Log("-------ShellSorted list------- ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class 具体策略 merge排序
    /// </summary>
    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            Debug.Log("-------MergeSorted list------- ");
        }
    }

    /// <summary>
    /// The 'Context' class 上下文
    /// </summary>
    class SortedList
    {
        private List<string> _list = new List<string>();
        // 内聚抽象策略
        private SortStrategy _sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        // 排序
        public void Sort()
        {
            _sortstrategy.Sort(_list);
            // Iterate over list and display results
            foreach (string name in _list)
            {
                Debug.Log(" " + name);
            }
        }
    }
}