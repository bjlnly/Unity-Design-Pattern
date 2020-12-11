
# Flyweight Pattern 享元模式
## Definition

Use sharing to support large numbers of fine-grained objects efficiently.
<br>使用共享对象可有效地支持大量的细粒度的对象。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/flyweight.gif)


## Participants

The classes and objects participating in this pattern are:

### Flyweight   (Character)
* declares an interface through which flyweights can receive and act on extrinsic state.
* 声明一个接口，通过该接口，Flyweight可以接收和处理外在状态。

### ConcreteFlyweight   (CharacterA, CharacterB, ..., CharacterZ)
* implements the Flyweight interface and adds storage for intrinsic state, if any. A ConcreteFlyweight object must be sharable. Any state it stores must be intrinsic, that is, it must be independent of the ConcreteFlyweight object's context.
* 实现Flyweight接口，并为内在状态添加存储空间（如果有的话）。ConcreteFlyweight对象必须是可共享的。它存储的任何状态必须是内在的，也就是说，它必须独立于ConcreteFlyweight对象的上下文。

### UnsharedConcreteFlyweight   ( not used )
* not all Flyweight subclasses need to be shared. The Flyweight interface enables sharing, but it doesn't enforce it. It is common for UnsharedConcreteFlyweight objects to have ConcreteFlyweight objects as children at some level in the flyweight object structure (as the Row and Column classes have).
* 并非所有Flyweight子类都需要共享。Flyweight接口允许共享，但它并不强制执行。UnsharedConcreteFlyweight对象在Flyweight对象结构的某个层次上有ConcreteFlyweight对象作为子类是很常见的（就像Row和Column类一样）。

### FlyweightFactory   (CharacterFactory)
* creates and manages flyweight objects
* ensures that flyweight are shared properly. When a client requests a flyweight, the FlyweightFactory objects assets an existing instance or creates one, if none exists.
* 创建和管理FlyWeight
* 确保正确地共享flyweight。当客户要求使用flyweight时，FlyweightFactory对象会将一个现有的实例资产化，如果不存在，则创建一个实例。

### Client   (FlyweightApp)
* maintains a reference to flyweight(s).
* computes or stores the extrinsic state of flyweight(s).
* 维护对flyweight(s)的引用。
* 计算或存储flyweight的外在状态。

