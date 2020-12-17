# State Pattern 状态模式
## Definition

Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.
<br>当一个对象内在状态改变时允许其改变行为，这个对象看起来像改变了其类。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/state.gif)


## Participants

The classes and objects participating in this pattern are:

### Context  (Account)
* defines the interface of interest to clients
* maintains an instance of a ConcreteState subclass that defines the current state.
* 定义Client感兴趣的接口
* 维护一个定义当前状态的ConcreteState子类的实例。

### State  (State)
* defines an interface for encapsulating the behavior associated with a particular state of the Context.
* 定义了一个接口，用于封装与上下文特定状态相关的行为。

### Concrete State  (RedState, SilverState, GoldState)
* each subclass implements a behavior associated with a state of Context
* 每个子类都实现了一个与Context状态相关联的行为。
