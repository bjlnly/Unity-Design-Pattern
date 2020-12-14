//-------------------------------------------------------------------------------------
//	CommandExample1.cs
//-------------------------------------------------------------------------------------

//This real-world code demonstrates the Command pattern used in a simple calculator with unlimited number of undo's and redo's.
//Note that in C#  the word 'operator' is a keyword. Prefixing it with '@' allows using it as an identifier.

//这段实际代码演示了一个简单的计算器中使用的Command模式，可以无限次的撤销和重做。
//注意，在C#中，"operator "是一个关键字。用'@'作为前缀，可以将其作为标识符使用。

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandExample1
{
    /// <summary>
    /// 计算器的案例
    /// </summary>
    public class CommandExample1 : MonoBehaviour
    {
	    void Start ( )
        {
            // Create user and let her compute
            // 创建请求者
            User user = new User();

            // User presses calculator buttons
            // 点击计算机按钮操作
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands
            // undo 4次命令
            user.Undo(4);

            // Redo 3 commands
            // redo 3次命令
            user.Redo(3);
        }
    }

    /// <summary>
    /// The 'Command' abstract class 抽象的命令类
    /// </summary>
    abstract class Command
    {
        // 执行
        public abstract void Execute();
        // 撤销
        public abstract void UnExecute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class 具体命令 -- 计算
    /// </summary>
    class CalculatorCommand : Command
    {
        private char _operator;
        private int _operand;
        private Calculator _calculator; // 计算  真正操作对象

        // Constructor
        public CalculatorCommand(Calculator calculator,
          char @operator, int operand)
        {
            this._calculator = calculator;
            this._operator = @operator;
            this._operand = operand;
        }

        // Gets operator
        public char Operator
        {
            set { _operator = value; }
        }

        // Get operand
        public int Operand
        {
            set { _operand = value; }
        }

        // Execute new command
        public override void Execute()
        {
            _calculator.Operation(_operator, _operand);
        }

        // Unexecute last command
        public override void UnExecute()
        {
            _calculator.Operation(Undo(_operator), _operand);
        }

        // Returns opposite operator for given operator
        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default:
                    throw new
            ArgumentException("@operator");
            }
        }
    }

    /// <summary>
    /// The 'Receiver' class 接收者
    /// </summary>
    class Calculator
    {
        private int _curr = 0;

        // 具体的运算
        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': _curr += operand; break;
                case '-': _curr -= operand; break;
                case '*': _curr *= operand; break;
                case '/': _curr /= operand; break;
            }
            Debug.Log("Current value = " + _curr+ " ( following "+ @operator+operand+" )");
        }
    }

    /// <summary>
    /// The 'Invoker' class 请求者
    /// </summary>
    class User
    {
        // Initializers
        // 只是参与生成命令
        private Calculator _calculator = new Calculator();
        // 内聚命令
        private List<Command> _commands = new List<Command>();
        private int _current = 0;

        public void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (_current < _commands.Count - 1)
                {
                    Command command = _commands[_current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Debug.Log("\n---- Undo "+ levels + " levels");
            // Perform undo operations
            for (int i = 0; i < levels; i++)
            {
                if (_current > 0)
                {
                    Command command = _commands[--_current] as Command;
                    command.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            // 创建命令并执行
            Command command = new CalculatorCommand(
              _calculator, @operator, operand);
            command.Execute();

            // Add command to undo list
            // 增加命令到undo列表
            _commands.Add(command);
            _current++;
        }
    }
}