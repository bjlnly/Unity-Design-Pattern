//-------------------------------------------------------------------------------------
//	PrototypePatternExample1.cs
//-------------------------------------------------------------------------------------

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Prototype pattern in which new Color objects are created by copying pre-existing, user-defined Colors of the same type.
//此真实世界的代码演示了原型模式，在该模式中，通过复制相同类型的预先存在的用户定义的颜色来创建新的颜色对象。
namespace PrototypePatternExample1
{
    public class PrototypePatternExample1 : MonoBehaviour
    {
        void Start()
        {
            ColorManager colormanager = new ColorManager();

            // 实例化一些颜色加入到缓存
            // Initialize with standard colors
            // 实例化一些基础颜色
            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors
            // 实例化一些自定义颜色
            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // User clones selected colors
            // 克隆一些颜色  -- 从缓存里  Main自己克隆,略有不妥 ColorManager克隆会好些
            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;

        }
    }

    /// <summary>
    /// The 'Prototype' abstract class 原型抽象类  颜色原型
    /// </summary>
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    /// <summary>
    /// The 'ConcretePrototype' class 具体原型  颜色
    /// </summary>
    class Color : ColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;

        // Constructor
        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        // Create a shallow copy 实现克隆
        public override ColorPrototype Clone()
        {
            Debug.Log("Cloning color RGB: (" + _red + " ," + _green + "," + _blue + ")");

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    /// <summary>
    /// Prototype manager 管理克隆缓存
    /// </summary>
    class ColorManager
    {
        private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

        // Indexer
        // 根据索引 找到具体原型
        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}
