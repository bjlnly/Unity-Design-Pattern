//-------------------------------------------------------------------------------------
//	CommandStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace CommandStructure
{
    // 命令模式 请求方和接收方通过命令来解耦
    // 请求方只知命令  接收方也只知命令
    // 方便撤销和重做
    // 虎符.....
    public class CommandStructure : MonoBehaviour
    {
	    void Start ( )
        {
            // Create receiver, command, and invoker
            // 创建接收者
            Receiver receiver = new Receiver();
            // 创建命令并绑定接收者
            Command command = new ConcreteCommand(receiver);
            // 创建请求者
            Invoker invoker = new Invoker();

            // Set and execute command
            // 请求者设置命令 并执行命令
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }

    /// <summary>
    /// The 'Command' abstract class 抽象的命令
    /// </summary>
    abstract class Command
    {
        // 内聚接收者
        protected Receiver receiver;

        // Constructor
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        // 抽象的命令执行方法
        public abstract void Execute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class 具体的命令
    /// </summary>
    class ConcreteCommand : Command
    {
        // Constructor
        public ConcreteCommand(Receiver receiver) :
          base(receiver)
        {
        }

        // 调用接收者 执行命令
        public override void Execute()
        {
            receiver.Action();
        }
    }

    /// <summary>
    /// The 'Receiver' class 接收者
    /// </summary>
    class Receiver
    {
        // 具体的真正执行者  隐藏在命令之后
        public void Action()
        {
          Debug.Log("Called Receiver.Action()");
        }
    }

    /// <summary>
    /// The 'Invoker' class 命令请求者
    /// </summary>
    class Invoker
    {
        // 内聚命令
        private Command _command;

        // 设置命令
        public void SetCommand(Command command)
        {
            this._command = command;
        }

        // 执行命令
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }

}