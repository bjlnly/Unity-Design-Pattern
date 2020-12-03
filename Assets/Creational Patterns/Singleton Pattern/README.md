# Singleton Pattern 单例模式
## Definition 定义

Ensure a class has only one instance and provide a global point of access to it.
<br>确保某一个类只有一个实例，而且自行实例化并向整个系统提供这个实例。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/singleton.gif)


## Participants 参与者

The classes and objects participating in this pattern are:
<br>参与这个模式的类和对象是:

### Singleton   (LoadBalancer) 负载均衡器
* defines an Instance operation that lets clients access its unique instance. Instance is a class operation.
<br>定义一个实例操作，让客户端访问它的唯一实例。实例是一个类操作。
* responsible for creating and maintaining its own unique instance.
<br>负责创建和维护自己唯一的实例。
