//-------------------------------------------------------------------------------------
//	InterpreterExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Interpreter pattern which is used to convert a Roman numeral to a decimal.
//这段真实的代码演示了用于将罗马数字转换为十进制数的解释器模式。
namespace InterpreterExample1
{
    public class InterpreterExample1 : MonoBehaviour
    {
        void Start()
        {
            // 定义罗马数字的上下文  
            string roman = "MCMXXVIII";
            Context context = new Context(roman);

            // Build the 'parse tree'
            // 构建语法树
            List<Expression> tree = new List<Expression>();
            tree.Add(new ThousandExpression());
            tree.Add(new HundredExpression());
            tree.Add(new TenExpression());
            tree.Add(new OneExpression());

            // Interpret
            // 解释
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }

            Debug.Log(roman+" = "+ context.Output);
        }
    }

    /// <summary>
    /// The 'Context' class 被解释的上下文
    /// </summary>
    class Context
    {
        private string _input;
        private int _output;

        // Constructor
        public Context(string input)
        {
            this._input = input;
        }

        // Gets or sets input 输入
        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }

        // Gets or sets output 输出
        public int Output
        {
            get { return _output; }
            set { _output = value; }
        }
    }

    /// <summary>
    /// The 'AbstractExpression' class 抽象的解释器
    /// </summary>
    abstract class Expression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.StartsWith(Nine())) // 9是2个字符
            {
                context.Output += (9 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Four())) // 4是2个字符
            {
                context.Output += (4 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Five()))// 5是1个字符
            {
                context.Output += (5 * Multiplier());
                context.Input = context.Input.Substring(1);
            }

            while (context.Input.StartsWith(One()))// 1是一个字符
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(1);
            }
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }

    /// <summary>
    /// A 'TerminalExpression' class 终端解释器
    /// <remarks>
    /// Thousand checks for the Roman Numeral M
    /// 1000位数的检测  罗马数字M
    /// </remarks>
    /// </summary>
    class ThousandExpression : Expression
    {
        public override string One() { return "M"; }
        public override string Four() { return " "; }
        public override string Five() { return " "; }
        public override string Nine() { return " "; }
        public override int Multiplier() { return 1000; }
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// 具体解释器表达
    /// <remarks>
    /// Hundred checks C, CD, D or CM
    /// 100位数 检测 C--100  CD--400 D--500 CM--900
    /// </remarks>
    /// </summary>
    class HundredExpression : Expression
    {
        public override string One() { return "C"; }
        public override string Four() { return "CD"; }
        public override string Five() { return "D"; }
        public override string Nine() { return "CM"; }
        public override int Multiplier() { return 100; }
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Ten checks for X, XL, L and XC
    /// 10位数检测 X,XL,L,XC
    /// </remarks>
    /// </summary>
    class TenExpression : Expression
    {
        public override string One() { return "X"; }
        public override string Four() { return "XL"; }
        public override string Five() { return "L"; }
        public override string Nine() { return "XC"; }
        public override int Multiplier() { return 10; }
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// One checks for I, II, III, IV, V, VI, VI, VII, VIII, IX
    /// 个位数检测
    /// </remarks>
    /// </summary>
    class OneExpression : Expression
    {
        public override string One() { return "I"; }
        public override string Four() { return "IV"; }
        public override string Five() { return "V"; }
        public override string Nine() { return "IX"; }
        public override int Multiplier() { return 1; }
    }
}
