# Chain of Responsibility Pattern 责任链模式
## Definition

Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.
<br>使多个对象都有机会处理请求，从而避免了请求的发送者和接受者之间的耦合关系。将这些对象连成一条链，并沿着这条链传递该请求，直到有对象处理它为止。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/chain.gif)


## Participants

The classes and objects participating in this pattern are:

### Handler   (Approver)
* defines an interface for handling the requests
* (optional) implements the successor link
* 定义了一个处理请求的接口
* (可选)实现后继联系。

### ConcreteHandler   (Director, VicePresident, President)
* handles requests it is responsible for
* can access its successor
* if the ConcreteHandler can handle the request, it does so; otherwise it forwards the request to its successor
* 处理其负责的请求
* 可以访问其后续机构
* 如果ConcreteHandler能够处理请求，它就处理；否则，它就把请求转发给它的后继者。

### Client   (ChainApp)
* initiates the request to a ConcreteHandler object on the chain
* 启动对链上ConcreteHandler对象的请求。

