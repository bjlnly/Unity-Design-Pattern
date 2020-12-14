# Command Pattern 命令模式
## Definition
Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.
<br>命令模式将“请求”封装成对象，以便使用不同的请求、队列或者日志来参数化其他对象，同时支持可撤消的操作。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/command.gif) 

## Participants
The classes and objects participating in this pattern are:

### Command
* declares an interface for executing an operation
* 宣布一个执行业务的接口；

### ConcreteCommand
* defines a binding between a Receiver object and an action
* implements Execute by invoking the corresponding operation(s) on Receiver
* 定义了接收器对象与动作之间的绑定。
* 通过调用Receiver上的相应操作来实现Execute。

### Client 
* creates a ConcreteCommand object and sets its receiver
* 创建一个ConcreteCommand对象，并设置其接收者。
### Invoker
* asks the command to carry out the request
* 要求command执行请求。

### Receiver
* knows how to perform the operations associated with carrying out the request.
* 知道如何执行与执行请求有关的业务；



