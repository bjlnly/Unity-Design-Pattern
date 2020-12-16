# Mediator Pattern 中介者模式
## Definition

Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.
<br>用一个中介对象封装一系列的对象交互，中介者使各对象不需要显示地相互作用，从而使其耦合松散，而且可以独立地改变它们之间的交互。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/mediator.gif)


## Participants

The classes and objects participating in this pattern are:

### Mediator  (IChatroom)
* defines an interface for communicating with Colleague objects
* 定义了一个与Colleague对象进行通信的接口

### ConcreteMediator  (Chatroom)
* implements cooperative behavior by coordinating Colleague objects
* knows and maintains its colleagues
* 通过协调Colleague对象实现合作行为。
* 了解并维护其Colleague

### Colleague classes  (Participant)
* each Colleague class knows its Mediator object
* each colleague communicates with its mediator whenever it would have otherwise communicated with another colleague
* 每个Colleague类都知道它的Mediator对象。
* 每位同事在与另一位同事沟通时，都会与其调解人进行沟通
