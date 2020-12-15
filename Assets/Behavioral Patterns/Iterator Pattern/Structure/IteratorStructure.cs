//-------------------------------------------------------------------------------------
//	IteratorStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class IteratorStructure : MonoBehaviour
{
	void Start ( )
	{
        // 创建具体的聚合
        ConcreteAggregate a = new ConcreteAggregate();
        a[0] = "Item A";
        a[1] = "Item B";
        a[2] = "Item C";
        a[3] = "Item D";

        // Create Iterator and provide aggregate
        // 通过聚合来创建遍历
        Iterator i = a.CreateIterator();

        Debug.Log("Iterating over collection:");

        object item = i.First();
        while (item != null)
        {
            Debug.Log(item);
            item = i.Next();
        }
    }
}

    /// <summary>
    /// The 'Aggregate' abstract class 抽象的聚合类
    /// </summary>
    abstract class Aggregate
    {
        // 创建遍历器的接口
        public abstract Iterator CreateIterator();
    }

    /// <summary>
    /// The 'ConcreteAggregate' class 具体的聚合类
    /// </summary>
    class ConcreteAggregate : Aggregate
    {
        private ArrayList _items = new ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }

        // Indexer
        // 返回适当的遍历内容
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }

    /// <summary>
    /// The 'Iterator' abstract class 抽象的遍历类
    /// </summary>
    abstract class Iterator
    {
        // 第一
        public abstract object First();
        // 下一个
        public abstract object Next();
        // 是否完结
        public abstract bool IsDone();
        // 当前序号
        public abstract object CurrentItem();
    }

    /// <summary>
    /// The 'ConcreteIterator' class 具体遍历类
    /// </summary>
    class ConcreteIterator : Iterator
    {
        // 具体的聚合
        private ConcreteAggregate _aggregate;
        private int _current = 0;

        // Constructor
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        // Gets first iteration item
        public override object First()
        {
            return _aggregate[0];
        }

        // Gets next iteration item
        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        // Gets current iteration item
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
