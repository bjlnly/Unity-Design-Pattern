//-------------------------------------------------------------------------------------
//	CompositePatternExample1.cs
//-------------------------------------------------------------------------------------

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//This real-world code demonstrates the Composite pattern used in building a graphical tree structure made up of primitive nodes(lines, circles, etc) and composite 
// nodes(groups of drawing elements that make up more complex elements).

//这段真实世界的代码演示了组合模式，用于构建由原始节点（线、圆等）和复合节点组成的图形树结构。
// 节点（组成更复杂元素的绘画元素组）。

namespace CompositePatternExample1
{
    public class CompositePatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Create a tree structure
            // 创建树形结构 -- 图片
            CompositeElement root =
              new CompositeElement("Picture");
            // 红线 篮圈 ... 叶子
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Circle"));
            root.Add(new PrimitiveElement("Green Box"));

            // Create a branch
            // 枝干 两个圆
            CompositeElement comp =
              new CompositeElement("Two Circles");
            comp.Add(new PrimitiveElement("Black Circle"));
            comp.Add(new PrimitiveElement("White Circle"));
            root.Add(comp);

            // Add and remove a PrimitiveElement
            // 移除叶子
            PrimitiveElement pe =
              new PrimitiveElement("Yellow Line");
            root.Add(pe);
            root.Remove(pe);

            // Recursively display nodes
            root.Display(1);

        }
    }


    /// <summary>
    /// The 'Component' Tree node 树节点 抽象要素
    /// </summary>
    abstract class DrawingElement
    {
        protected string _name;

        // Constructor
        public DrawingElement(string name)
        {
            this._name = name;
        }

        // 抽象对象的接口
        public abstract void Add(DrawingElement d);
        public abstract void Remove(DrawingElement d);
        public abstract void Display(int indent);
    }

    /// <summary>
    /// The 'Leaf' class 叶子类 独立抽象的话, 叶子类不能增删改查, 其实很多接口都不能是实现
    /// </summary>
    class PrimitiveElement : DrawingElement
    {
        // Constructor
        public PrimitiveElement(string name)
          : base(name)
        {
        }

        public override void Add(DrawingElement c)
        {
            Debug.Log("Cannot add to a PrimitiveElement");
        }

        public override void Remove(DrawingElement c)
        {
            Debug.Log("Cannot remove from a PrimitiveElement");
        }

        public override void Display(int indent)
        {
            Debug.Log(new String('-', indent) + " " + _name);
        }
    }
    /// <summary>
    /// The 'Composite' class
    /// </summary>
    class CompositeElement : DrawingElement
    {
        private List<DrawingElement> elements =
            new List<DrawingElement>();

        // Constructor
        public CompositeElement(string name)
            : base(name)
        {
        }

        public override void Add(DrawingElement d)
        {
            elements.Add(d);
        }

        public override void Remove(DrawingElement d)
        {
            elements.Remove(d);
        }

        public override void Display(int indent)
        {
            Debug.Log(new String('-', indent) +
                      "+ " + _name);

            // Display each child element on this node
            foreach (DrawingElement d in elements)
            {
                d.Display(indent + 2);
            }
        }
    }
}