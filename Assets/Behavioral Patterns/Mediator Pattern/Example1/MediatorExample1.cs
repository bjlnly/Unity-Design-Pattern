//-------------------------------------------------------------------------------------
//	MediatorExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Mediator pattern facilitating loosely coupled communication between 
//different Participants registering with a Chatroom.The Chatroom is the central hub through which all communication takes place.
//At this point only one-to-one communication is implemented in the Chatroom, but would be trivial to change to one-to-many.
//这段真实世界的代码展示了Mediator模式，它促进了不同用户之间松散耦合的通信。
//不同的参与者在聊天室注册。聊天室是所有交流的中心枢纽。
//目前，聊天室中只实现了一对一的交流，但如果改成一对多，也不会很麻烦。
namespace MediatorExample1
{
    public class MediatorExample1 : MonoBehaviour
    {
        void Start()
        {
            // Create chatroom
            // 创建一个具体的中介
            Chatroom chatroom = new Chatroom();

            // Create participants and register them
            // 创建一些具体用户,返回抽象
            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");

            // 用户注册到中介
            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            // Chatting participants
            // 可以相互聊天啦
            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");

        }
    }

    /// <summary>
    /// The 'Mediator' abstract class 抽象的中介--聊天室
    /// </summary>
    abstract class AbstractChatroom
    {
        // 加入新用户
        public abstract void Register(Participant participant);
        // 发送消息
        public abstract void Send(string from, string to, string message);
    }

    /// <summary>
    /// The 'ConcreteMediator' class 具体的中介
    /// </summary>
    class Chatroom : AbstractChatroom
    {
        // 维护用户列表
        private Dictionary<string, Participant> _participants =
          new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        // A通过聊天室发消息
        public override void Send( string from, string to, string message)
        {
            // B通过聊天室接收
            Participant participant = _participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    /// <summary>
    /// The 'AbstractColleague' class 抽象的用户Colleague
    /// </summary>
    class Participant
    {
        // 需要知道聊天室
        private Chatroom _chatroom;
        private string _name;

        // Constructor
        public Participant(string name)
        {
            this._name = name;
        }

        // Gets participant name
        public string Name
        {
            get { return _name; }
        }

        // Gets chatroom
        public Chatroom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }

        // 知道目标用户的名字
        // Sends message to given participant
        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
        }

        // 知道发送消息用户的名字
        // Receives message from given participant
        public virtual void Receive(string from, string message)
        {
            Debug.Log(from + " to " + Name + ": '" + message + "'");
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class 具体的聊天对象 -- 一个披头士
    /// </summary>
    class Beatle : Participant
    {
        // Constructor
        public Beatle(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Debug.Log("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class 另一个用户 -- 不是披头士
    /// </summary>
    class NonBeatle : Participant
    {
        // Constructor
        public NonBeatle(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Debug.Log("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}