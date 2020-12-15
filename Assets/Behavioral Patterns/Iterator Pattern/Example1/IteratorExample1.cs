//-------------------------------------------------------------------------------------
//	IteratorExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

//This real-world code demonstrates the Iterator pattern which is used to iterate over a collection of items and skip a specific number of items each iteration.
//这段真实世界的代码演示了Iterator模式，
//它用于在一个项目集合上进行迭代，并在每次迭代中跳过特定数量的项目。
namespace IteratorExample1
{
    public class IteratorExample1 : MonoBehaviour
    {
        void Start()
        {
            // Build a collection
            // 构建一个集合
            Collection collection = new Collection();
            collection[0] = new Item("Item 0");
            collection[1] = new Item("Item 1");
            collection[2] = new Item("Item 2");
            collection[3] = new Item("Item 3");
            collection[4] = new Item("Item 4");
            collection[5] = new Item("Item 5");
            collection[6] = new Item("Item 6");
            collection[7] = new Item("Item 7");
            collection[8] = new Item("Item 8");

            // Create iterator 
            // 通过集合创建遍历器
            Iterator iterator = collection.CreateIterator();

            // Skip every other item
            // 设置单次迭代的跨度
            iterator.Step = 2;

            Debug.Log("Iterating collection:");

            for (Item item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Debug.Log(item.Name);
            }
        }
    }

    /// <summary>
    /// A collection item 一个集合的单个项目
    /// </summary>
    class Item
    {
        private string _name;

        // Constructor
        public Item(string name)
        {
            this._name = name;
        }

        // Gets name
        public string Name
        {
            get { return _name; }
        }
    }

    /// <summary>
    /// The 'Aggregate' interface 集合接口
    /// </summary>
    interface IAbstractCollection
    {
        // 创建迭代器
        Iterator CreateIterator();
    }

    /// <summary>
    /// The 'ConcreteAggregate' class 具体的集合
    /// </summary>
    class Collection : IAbstractCollection
    {
        // 具体的数据
        private ArrayList _items = new ArrayList();

        // 通过集合创建迭代器
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }

    /// <summary>
    /// The 'Iterator' interface 抽象的迭代器接口
    /// </summary>
    interface IAbstractIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }

    /// <summary>
    /// The 'ConcreteIterator' class 具体的迭代器
    /// </summary>
    class Iterator : IAbstractIterator
    {
        // 内聚具体集合
        private Collection _collection;
        private int _current = 0; // 提供序号
        private int _step = 1; // 提供单次迭代数量

        // Constructor
        public Iterator(Collection collection)
        {
            this._collection = collection;
        }

        // Gets first item
        public Item First()
        {
            _current = 0;
            return _collection[_current] as Item;
        }

        // Gets next item
        public Item Next()
        {
            _current += _step;
            if (!IsDone)
                return _collection[_current] as Item;
            else
                return null;
        }

        // Gets or sets stepsize
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        // Gets current iterator item
        public Item CurrentItem
        {
            get { return _collection[_current] as Item; }
        }

        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }
    }
}