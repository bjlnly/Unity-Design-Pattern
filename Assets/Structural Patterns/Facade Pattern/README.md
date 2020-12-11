# Facade Pattern 外观模式
## Definition

Provide a unified interface to a set of interfaces in a subsystem. Façade defines a higher-level interface that makes the subsystem easier to use.
<br>要求一个子系统的外部与其内部的通信必须通过一个统一的对象进行。外观模式提供一个高层次的接口，使得子系统更易于使用。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/facade.gif)


## Participants

The classes and objects participating in this pattern are:

### Facade   (MortgageApplication)
* knows which subsystem classes are responsible for a request.
* delegates client requests to appropriate subsystem objects.
* 知道哪些子系统类负责处理一个请求。
* 将客户请求委托给适当的子系统对象。

### Subsystem classes   (Bank, Credit, Loan)
* implement subsystem functionality.
* handle work assigned by the Facade object.
* have no knowledge of the facade and keep no reference to it.
* 实现子系统功能。
* 处理Facade对象分配的工作。
* 对装饰一无所知，也不保留对它的引用。
