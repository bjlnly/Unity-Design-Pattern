//-------------------------------------------------------------------------------------
//	FlyweightPatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Flyweight pattern in which a relatively small number of Character objects is shared many times by a document that has potentially many characters.

//这段真实世界的代码展示了Flyweight模式，
//在这个模式下，一个相对较少的Character对象被一个可能有许多字符的文档多次共享。


namespace FlyweightPatternExample1
{
    public class FlyweightPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Build a document with text
            // 创建一个文档
            string document = "AAZZBBZB";
            char[] chars = document.ToCharArray();

            // 字符工厂
            CharacterFactory factory = new CharacterFactory();

            // extrinsic state
            // 需要的字符大小
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                // 获取元来打印  同一字符不同大小是用一个元打印的
                Character character = factory.GetCharacter(c);
                character.Display(pointSize);
            }
        }
    }

    /// <summary>
    /// The 'FlyweightFactory' class 享元工厂
    /// </summary>
    class CharacterFactory
    {
        // 元素表
        private Dictionary<char, Character> _characters =
          new Dictionary<char, Character>();

        // 获取元素
        public Character GetCharacter(char key)
        {
            // Uses "lazy initialization"
            Character character = null;
            if (_characters.ContainsKey(key))
            {
                character = _characters[key];
            }
            else
            {
                switch (key)
                {
                    case 'A': character = new CharacterA(); break;
                    case 'B': character = new CharacterB(); break;
                    //...
                    case 'Z': character = new CharacterZ(); break;
                }
                _characters.Add(key, character);
            }
            return character;
        }
    }

    /// <summary>
    /// The 'Flyweight' abstract class 抽象元 字符
    /// </summary>
    abstract class Character
    {
        protected char symbol;
        protected int width;
        protected int height;
        protected int ascent;
        protected int descent;
        protected int pointSize;

        public abstract void Display(int pointSize);
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class 具体元 -- 字符A
    /// </summary>
    class CharacterA : Character
    {
        // Constructor
        public CharacterA()
        {
            this.symbol = 'A';
            this.height = 100;
            this.width = 120;
            this.ascent = 70;
            this.descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Debug.Log(this.symbol +
              " (pointsize " + this.pointSize + ")");
        }
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class 具体元 -- 字符B
    /// </summary>
    class CharacterB : Character
    {
        // Constructor
        public CharacterB()
        {
            this.symbol = 'B';
            this.height = 100;
            this.width = 140;
            this.ascent = 72;
            this.descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Debug.Log(this.symbol +
              " (pointsize " + this.pointSize + ")");
        }

    }

    // ... C, D, E, etc.

    /// <summary>
    /// A 'ConcreteFlyweight' class 具体元 字符Z
    /// </summary>
    class CharacterZ : Character
    {
        // Constructor
        public CharacterZ()
        {
            this.symbol = 'Z';
            this.height = 100;
            this.width = 100;
            this.ascent = 68;
            this.descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Debug.Log(this.symbol + " (pointsize " + this.pointSize + ")");
        }
    }
}